using Grooveshark.SDK.Data;
using Grooveshark.SDK.Utilities;
using RestSharp;
using System;
using System.Configuration;
using System.Linq;
using System.Web.Script.Serialization;
using RateQuotaExceeded = Grooveshark.SDK.Data.RateQuotaExceeded;

namespace Grooveshark.SDK
{
    /// <summary>
    /// Contains base methods for Grooveshark Request Creation
    /// </summary>
    public class BaseServiceRequestFactory
    {
        private readonly string baseServiceUrl;
        private readonly string secret;
        private readonly string key;

        /// <summary>
        /// Initializes a new instance of the <see cref="BaseServiceRequestFactory"/> class.
        /// </summary>
        public BaseServiceRequestFactory()
        {
            this.baseServiceUrl = ConfigurationManager.AppSettings["baseServiceUrl"];
            this.secret = ConfigurationManager.AppSettings["secretKey"];
            this.key = ConfigurationManager.AppSettings["key"];
        }

        /// <summary>
        /// Executes the specified request parameters.
        /// </summary>
        /// <param name="requestParameters">The request parameters.</param>
        /// <param name="useHttps">if set to <c>true</c> [use HTTPS].</param>
        /// <param name="sessionID">The session identifier.</param>
        /// <returns>
        /// the request response parameters
        /// </returns>
        protected ResponseParameters Execute(RequestParameters requestParameters, bool useHttps = false, string sessionID = null)
        {
            requestParameters.header.Add("wsKey", this.key);
            if (!string.IsNullOrEmpty(sessionID))
            {
                requestParameters.header.Add("sessionID", sessionID);
            }
            var jsonSerializer = new JavaScriptSerializer();
            string json = jsonSerializer.Serialize(requestParameters);
            string encryptedJson = Encryptor.Md5Encrypt(json, this.secret);
            string serviceUrl = this.baseServiceUrl;
            if (useHttps)
            {
                serviceUrl = this.baseServiceUrl.Replace("http://", "https://");
            }
            var client = new RestClient(serviceUrl);
            var request = new RestRequest(String.Format("/ws3.php?sig={0}", encryptedJson.ToLower()), Method.POST);
            request.RequestFormat = DataFormat.Json;
            request.AddBody(requestParameters);

            RestResponse response = (RestResponse)client.Execute(request);

            ResponseParameters responseParameters = jsonSerializer.Deserialize<ResponseParameters>(response.Content);

            return responseParameters;
        }

        protected string ExecuteJson(RequestParameters requestParameters, bool useHttps = false, string sessionID = null)
        {
            requestParameters.header.Add("wsKey", this.key);
            if (!string.IsNullOrEmpty(sessionID))
            {
                requestParameters.header.Add("sessionID", sessionID);
            }
            var jsonSerializer = new JavaScriptSerializer();
            string json = jsonSerializer.Serialize(requestParameters);
            string encryptedJson = Encryptor.Md5Encrypt(json, this.secret);
            string serviceUrl = this.baseServiceUrl;
            if (useHttps)
            {
                serviceUrl = this.baseServiceUrl.Replace("http://", "https://");
            }
            var client = new RestClient(serviceUrl);
            var request = new RestRequest(String.Format("/ws3.php?sig={0}", encryptedJson.ToLower()), Method.POST);
            request.RequestFormat = DataFormat.Json;
            request.AddBody(requestParameters);

            RestResponse response = (RestResponse)client.Execute(request);
            if(!string.IsNullOrEmpty(response.Content))
            {
                RateQuotaExceeded.ResponseRootObject responseRateQuotaExceeded = jsonSerializer.Deserialize<RateQuotaExceeded.ResponseRootObject>(response.Content);
                if (responseRateQuotaExceeded != null && responseRateQuotaExceeded.errors != null && responseRateQuotaExceeded.errors.Count > 0 && responseRateQuotaExceeded.errors.First().message.Contains("Rate limit exceeded."))
                {
                    throw new Exception("Rate limit exceeded.");
                }
            }
            return response.Content;
        }
    }
}

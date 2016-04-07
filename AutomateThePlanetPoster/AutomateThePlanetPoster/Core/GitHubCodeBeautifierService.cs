using System.IO;
using System.Net;
using System.Text;

namespace AutomateThePlanetPoster.Core
{
    public class GitHubCodeBeautifierService
    {
        public string Beautify(string urlAddress)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(urlAddress);
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            string beautifedHtml = string.Empty;
            if (response.StatusCode == HttpStatusCode.OK)
            {
                Stream receiveStream = response.GetResponseStream();
                StreamReader readStream = null;

                if (response.CharacterSet == null)
                {
                    readStream = new StreamReader(receiveStream);
                }
                else
                {
                    readStream = new StreamReader(receiveStream, Encoding.GetEncoding(response.CharacterSet));
                }

                beautifedHtml = readStream.ReadToEnd();

                response.Close();
                readStream.Close();
            }
            int indexOfSecondDocumentWrite = beautifedHtml.IndexOf("document.write('", 15);
            System.Console.WriteLine(indexOfSecondDocumentWrite);
            beautifedHtml = beautifedHtml.Substring(indexOfSecondDocumentWrite, beautifedHtml.Length - indexOfSecondDocumentWrite);

            beautifedHtml = beautifedHtml.Replace("document.write('", string.Empty);
            beautifedHtml = beautifedHtml.Replace("')", string.Empty);
            beautifedHtml = beautifedHtml.Replace("\\n", string.Empty);
            beautifedHtml = beautifedHtml.Replace("\\", string.Empty);
            beautifedHtml = beautifedHtml.Replace("with &#10084; ", string.Empty);
            beautifedHtml = beautifedHtml.Trim();

            return beautifedHtml;
        }
    }
}
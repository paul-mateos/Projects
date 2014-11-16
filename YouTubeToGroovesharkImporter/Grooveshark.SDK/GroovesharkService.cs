using Grooveshark.SDK.Data;
using Grooveshark.SDK.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using Artist = Grooveshark.SDK.Data.Artist;
using Session = Grooveshark.SDK.Data.Session;
using Authenticate = Grooveshark.SDK.Data.Authenticate;
using Logout = Grooveshark.SDK.Data.Logout;
using GetUserPlaylists = Grooveshark.SDK.Data.GetUserPlaylists;
using GetPlaylist = Grooveshark.SDK.Data.GetPlaylist;
using DoesExists = Grooveshark.SDK.Data.DoesExists;
using GetSongSearchResults = Grooveshark.SDK.Data.GetSongSearchResults;
using AddUserFavoriteSong = Grooveshark.SDK.Data.AddUserFavoriteSong;

namespace Grooveshark.SDK
{
    /// <summary>
    /// Contains all Groveeskark Service Methods
    /// </summary>
    public class GroovesharkService : BaseServiceRequestFactory
    {
        /// <summary>
        /// The instance
        /// </summary>
        private static GroovesharkService instance;

        /// <summary>
        /// The json serializer
        /// </summary>
        private readonly JavaScriptSerializer JsonSerializer;

        /// <summary>
        /// Initializes a new instance of the <see cref="GroovesharkService"/> class.
        /// </summary>
        public GroovesharkService()
        {
            this.JsonSerializer = new JavaScriptSerializer();
        }

        /// <summary>
        /// Gets the instance.
        /// </summary>
        /// <value>
        /// The instance.
        /// </value>
        public static GroovesharkService Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new GroovesharkService();
                }
                return instance;
            }
        }

        /// <summary>
        /// Starts the session.
        /// </summary>
        /// <returns>
        /// the request response parameters
        /// </returns>
        public Session.Result StartSession()
        {
            RequestParameters requestParameters = new RequestParameters();
            requestParameters.method = "startSession";
            string responseJson = this.ExecuteJson(requestParameters, true);
            Session.ResponseRootObject sessionResponse = this.JsonSerializer.Deserialize<Session.ResponseRootObject>(responseJson);
            if (sessionResponse == null)
            {
                sessionResponse = new Session.ResponseRootObject();
                sessionResponse.result = new Session.Result();
                sessionResponse.result.success = false;
            }

            return sessionResponse.result;
        }

        /// <summary>
        /// Authenticate a user using an established session, a login and an md5 of their password.
        /// </summary>
        /// <param name="userName">Name of the user.</param>
        /// <param name="password">The password.</param>
        /// <param name="sessionID">The session identifier.</param>
        /// <returns>
        /// the request response parameters
        /// </returns>
        public Authenticate.Result Authenticate(string userName, string password, string sessionID)
        {
            RequestParameters requestParameters = new RequestParameters();
            requestParameters.method = "authenticate";
            requestParameters.parameters.Add("login", userName);
            string encryptedPassword = Encryptor.CalculateMD5Hash(password);
            requestParameters.parameters.Add("password", encryptedPassword.ToLower());
            string responseJson = this.ExecuteJson(requestParameters, true, sessionID);
            Authenticate.ResponseRootObject authenticateResponse  = new Authenticate.ResponseRootObject();
            try
            {
                authenticateResponse = this.JsonSerializer.Deserialize<Authenticate.ResponseRootObject>(responseJson);
            }
            catch
            {
                authenticateResponse.result = new Data.Authenticate.Result();
                authenticateResponse.result.success = false;
            }
            if (authenticateResponse == null)
            {
                authenticateResponse.result = new Data.Authenticate.Result();
                authenticateResponse.result.success = false;
            }

            return authenticateResponse.result;
        }

        /// <summary>
        /// Logouts the specified session identifier.
        /// </summary>
        /// <param name="sessionId">The session identifier.</param>
        /// <returns>the request response parameters</returns>
        public Logout.Result Logout(string sessionId)
        {
            RequestParameters requestParameters = new RequestParameters();
            requestParameters.method = "authenticate";
            requestParameters.parameters.Add("sessionID", sessionId);

            string responseJson = this.ExecuteJson(requestParameters, true);
            Logout.ResponseRootObject responseRootObj = this.JsonSerializer.Deserialize<Logout.ResponseRootObject>(responseJson);

            return responseRootObj.result;
        }

        /// <summary>
        /// Gets the artist search results.
        /// </summary>
        /// <param name="query">The query.</param>
        /// <param name="limit">The limit.</param>
        /// <returns>
        /// the request response parameters
        /// </returns>
        public Artist.Result GetArtistSearchResults(string query, int limit)
        {
            RequestParameters requestParameters = new RequestParameters();
            requestParameters.method = "getArtistSearchResults";
            requestParameters.parameters.Add("query", query);
            requestParameters.parameters.Add("limit", limit);

            string responseJson = this.ExecuteJson(requestParameters);
            Artist.ResponseRootObject artistResponse = this.JsonSerializer.Deserialize<Artist.ResponseRootObject>(responseJson);

            return artistResponse.result;
        }

        /// <summary>
        /// Gets the user playlists.
        /// </summary>
        /// <param name="limit">The limit.</param>
        /// <returns>the request response parameters</returns>
        public GetUserPlaylists.Result GetUserPlaylists(string sessionID, int limit = 100)
        {
            RequestParameters requestParameters = new RequestParameters();
            requestParameters.method = "getUserPlaylists";
            requestParameters.parameters.Add("limit", limit);

            string responseJson = this.ExecuteJson(requestParameters);
            GetUserPlaylists.ResponseRootObject responseRootObj = this.JsonSerializer.Deserialize<GetUserPlaylists.ResponseRootObject>(responseJson);

            return responseRootObj.result;
        }

        /// <summary>
        /// Gets the playlist.
        /// </summary>
        /// <param name="playlistId">The playlist identifier.</param>
        /// <param name="limit">The limit.</param>
        /// <returns>
        /// the request response parameters
        /// </returns>
        public GetPlaylist.Result GetPlaylist(int playlistId, int limit = 100)
        {
            RequestParameters requestParameters = new RequestParameters();
            requestParameters.method = "getPlaylist";
            requestParameters.parameters.Add("playlistID", playlistId);
            requestParameters.parameters.Add("limit", limit);
            string responseJson = this.ExecuteJson(requestParameters);
            GetPlaylist.ResponseRootObject responseRootObj = this.JsonSerializer.Deserialize<GetPlaylist.ResponseRootObject>(responseJson);

            return responseRootObj.result;
        }

        /// <summary>
        /// Gets the does artists exist.
        /// </summary>
        /// <param name="artistId">The artist identifier.</param>
        /// <returns>
        /// the request response parameters
        /// </returns>
        public bool GetDoesArtistsExist(int artistId)
        {
            RequestParameters requestParameters = new RequestParameters();
            requestParameters.method = "getDoesArtistExist";
            requestParameters.parameters.Add("artistID", artistId);
            string responseJson = this.ExecuteJson(requestParameters);
            DoesExists.ResponseRootObject responseRootObj = this.JsonSerializer.Deserialize<DoesExists.ResponseRootObject>(responseJson);

            return responseRootObj.result;
        }

        /// <summary>
        /// Gets the does song exist.
        /// </summary>
        /// <param name="songId">The song identifier.</param>
        /// <returns>
        /// the request response parameters
        /// </returns>
        public bool GetDoesSongExist(int songId)
        {
            RequestParameters requestParameters = new RequestParameters();
            requestParameters.method = "getDoesSongExist";
            requestParameters.parameters.Add("songID", songId);
            string responseJson = this.ExecuteJson(requestParameters);
            DoesExists.ResponseRootObject responseRootObj = this.JsonSerializer.Deserialize<DoesExists.ResponseRootObject>(responseJson);

            return responseRootObj.result;
        }

        /// <summary>
        /// Adds the user favorite song.
        /// </summary>
        /// <param name="songId">The song identifier.</param>
        /// <param name="sessionID">The session identifier.</param>
        /// <returns>
        /// is the song added
        /// </returns>
        public bool AddUserFavoriteSong(int songId, string sessionID)
        {
            RequestParameters requestParameters = new RequestParameters();
            requestParameters.method = "addUserFavoriteSong";
            requestParameters.parameters.Add("songID", songId);
            string responseJson = this.ExecuteJson(requestParameters, sessionID: sessionID);
            AddUserFavoriteSong.ResponseRootObject responseRootObj = this.JsonSerializer.Deserialize<AddUserFavoriteSong.ResponseRootObject>(responseJson);

            return responseRootObj.result.success;
        }

        /// <summary>
        /// Gets the song search results.
        /// </summary>
        /// <param name="query">The query.</param>
        /// <param name="country">The country.</param>
        /// <param name="limit">The limit.</param>
        /// <param name="offset">The offset.</param>
        /// <returns>the request response parameters</returns>
        public GetSongSearchResults.Result GetSongSearchResults(string query, string country = "Bulgaria", int limit = 10, int offset = 0)
        {
            RequestParameters requestParameters = new RequestParameters();
            requestParameters.method = "getSongSearchResults";
            requestParameters.parameters.Add("query", query);
            requestParameters.parameters.Add("country", country);
            requestParameters.parameters.Add("limit", limit);
            requestParameters.parameters.Add("offset", offset);

            string responseJson = this.ExecuteJson(requestParameters);
            GetSongSearchResults.ResponseRootObject responseRootObj;
            if (string.IsNullOrEmpty(responseJson))
            {
                responseRootObj = new GetSongSearchResults.ResponseRootObject();
            }
            else
            {
                responseRootObj = this.JsonSerializer.Deserialize<GetSongSearchResults.ResponseRootObject>(responseJson);
            }

            return responseRootObj.result;
        }

        /// <summary>
        /// Gets the artist popular songs.
        /// </summary>
        /// <param name="artistID">The artist identifier.</param>
        /// <returns>the found songs</returns>
        public GetSongSearchResults.Result GetArtistPopularSongs(int artistID)
        {
            RequestParameters requestParameters = new RequestParameters();
            requestParameters.method = "getArtistPopularSongs";
            requestParameters.parameters.Add("artistID", artistID);

            string responseJson = this.ExecuteJson(requestParameters);
            GetSongSearchResults.ResponseRootObject responseRootObj;
            if (string.IsNullOrEmpty(responseJson))
            {
                responseRootObj = new GetSongSearchResults.ResponseRootObject();
            }
            else
            {
                responseRootObj = this.JsonSerializer.Deserialize<GetSongSearchResults.ResponseRootObject>(responseJson);
            }

            return responseRootObj.result;
        }
    }
}

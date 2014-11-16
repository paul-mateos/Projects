using Google.Apis.Auth.OAuth2;
using Google.Apis.Services;
using Google.Apis.Util.Store;
using Google.Apis.YouTube.v3;
using Google.Apis.YouTube.v3.Data;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace YouTube.SDK
{
    /// <summary>
    /// Contains all YouTube Service Methods
    /// </summary>
    public class YouTubeServiceClient
    {
        private static YouTubeServiceClient instance;

        /// <summary>
        /// Gets the instance.
        /// </summary>
        /// <value>
        /// The instance.
        /// </value>
        public static YouTubeServiceClient Instance
        {
            get
            {
                if(instance == null)
                {
                    instance = new YouTubeServiceClient();
                }
                return instance;
            }
        }

        /// <summary>
        /// Gets the play list songs.
        /// </summary>
        /// <param name="userEmail">The user email.</param>
        /// <param name="playListId">The play list identifier.</param>
        /// <returns></returns>
        public List<string> GetPlayListSongs(string userEmail, string playListId)
        {
            List<string> playListSongs = new List<string>();
            
            try
            {
                YouTubeServiceClient service = new YouTubeServiceClient();
                service.GetPlayListSongsInternalAsync(userEmail, playListId, playListSongs).Wait();
            }
            catch (AggregateException ex)
            {
                foreach (var e in ex.InnerExceptions)
                {
                    //TODO: Add Logging
                }
            }

            return playListSongs;
        }

        /// <summary>
        /// Gets the user play lists.
        /// </summary>
        /// <param name="userEmail">The user email.</param>
        /// <returns>list of users playlists</returns>
        public List<YouTubePlayList> GetUserPlayLists(string userEmail)
        {
            List<YouTubePlayList> playLists = new List<YouTubePlayList>();

            try
            {
                YouTubeServiceClient service = new YouTubeServiceClient();
                service.GetUserPlayListsAsync(userEmail, playLists).Wait();
            }
            catch (AggregateException ex)
            {
                foreach (var e in ex.InnerExceptions)
                {
                    //TODO: Add Logging
                }
            }

            return playLists;
        }

        /// <summary>
        /// Gets the play list songs internal asynchronous.
        /// </summary>
        /// <param name="userEmail">The user email.</param>
        /// <param name="playListId">The play list identifier.</param>
        private async Task GetPlayListSongsInternalAsync(string userEmail, string playListId, List<string> playListSongs)
        {
            var youtubeService = await GetYouTubeService(userEmail);

            var channelsListRequest = youtubeService.Channels.List("contentDetails");
            channelsListRequest.Mine = true;
            var nextPageToken = "";
            while (nextPageToken != null)
            {
                PlaylistItemsResource.ListRequest listRequest = youtubeService.PlaylistItems.List("contentDetails");
                listRequest.MaxResults = 50;
                listRequest.PlaylistId = playListId;
                listRequest.PageToken = nextPageToken;
                var response = await listRequest.ExecuteAsync();
                if (playListSongs == null)
                {
                    playListSongs = new List<string>();
                }
                foreach (var playlistItem in response.Items)
                {
                    VideosResource.ListRequest videoR = youtubeService.Videos.List("snippet");
                    videoR.Id = playlistItem.ContentDetails.VideoId;
                    var responseV = await videoR.ExecuteAsync();
                    playListSongs.Add(responseV.Items[0].Snippet.Title);
                }
                nextPageToken = response.NextPageToken;
            }          
        }

        /// <summary>
        /// Gets the user play lists asynchronous.
        /// </summary>
        /// <param name="userEmail">The user email.</param>
        /// <param name="playLists">The play lists.</param>
        /// <returns></returns>
        private async Task GetUserPlayListsAsync(string userEmail, List<YouTubePlayList> playLists)
        {
            var youtubeService = await GetYouTubeService(userEmail);

            var channelsListRequest = youtubeService.Channels.List("contentDetails");
            channelsListRequest.Mine = true;
            var playlists = youtubeService.Playlists.List("snippet");
            playlists.PageToken = "";
            playlists.MaxResults = 50;
            playlists.Mine = true;
            PlaylistListResponse presponse = await playlists.ExecuteAsync();
            foreach (var currentPlayList in presponse.Items)
            {
                playLists.Add(new YouTubePlayList(currentPlayList.Snippet.Title, currentPlayList.Id));
            }
        }

        /// <summary>
        /// Gets you tube service.
        /// </summary>
        /// <param name="userEmail">The user email.</param>
        /// <returns></returns>
        private async Task<YouTubeService> GetYouTubeService(string userEmail)
        {
            UserCredential credential;
            using (var stream = new FileStream("client_secrets.json", FileMode.Open, FileAccess.Read))
            {
                credential = await GoogleWebAuthorizationBroker.AuthorizeAsync(
                    GoogleClientSecrets.Load(stream).Secrets,
                    // This OAuth 2.0 access scope allows for read-only access to the authenticated 
                    // user's account, but not other types of account access.
                    new[] { YouTubeService.Scope.YoutubeReadonly },
                    userEmail,
                    CancellationToken.None,
                    new FileDataStore(this.GetType().ToString())
                );
            }

            var youtubeService = new YouTubeService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = credential,
                ApplicationName = this.GetType().ToString()
            });

            return youtubeService;
        }
    }
}

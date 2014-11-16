using PhantomTube.Core.Core;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using YouTube.SDK;
using YouTube.SDK.Entities;
using YouTube.SDK.Entities.Enums;

namespace PhantomTube.Core.ViewModels
{
    /// <summary>
    /// Contains Methods Related to YouTube Songs Import View
    /// </summary>
    public class YouTubePlaylistsEditViewModel : BaseYouTubePlayerViewModel
    {
        /// <summary>
        /// The log
        /// </summary>
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
      
        /// <summary>
        /// Sorts the songs by artist.
        /// </summary>
        /// <returns></returns>
        public List<YouTubeSong> SortSongsByArtist()
        {
            List<YouTubeSong> songs = this.ObservableSongs.ToList();
            songs.Sort(new SongsComparer());

            return songs;
        }

        /// <summary>
        /// Sorts the songs by title.
        /// </summary>
        /// <returns></returns>
        public List<YouTubeSong> SortSongsByTitle()
        {
            List<YouTubeSong> songs = this.ObservableSongs.ToList();
            songs.Sort(new SongsComparer(SongsSortModes.Name));

            return songs;
        }

        /// <summary>
        /// Saves the current playlist.
        /// </summary>
        public void SaveCurrentPlaylist()
        {
            for (int i = 0; i < this.ObservableSongs.Count; i++)
            {
                YouTubeServiceClient.Instance.UpdateSongPositionInPlaylist(
                    ExecutionContext.CurrentUser,
                    this.SelectedPlaylist.Id,
                    this.ObservableSongs[i],
                    i);
            }
        }
              
        /// <summary>
        /// Exports the songs from current playlist.
        /// </summary>
        /// <param name="fileName">Name of the file.</param>
        public void ExportSongsFromCurrentPlaylist(string fileName)
        {
            StreamWriter writer = new StreamWriter(fileName);
            using(writer)
            {
                foreach (var currentSong in this.ObservableSongs)
                {
                    string currentFormatedSongText = string.Format("{0} - {1}", currentSong.Artist.Trim(), currentSong.Title.Trim());
                    writer.WriteLine(currentFormatedSongText);
                }
            }
        }

        /// <summary>
        /// Creates the new songs collection after move up.
        /// </summary>
        /// <param name="startIndex">The start index.</param>
        /// <param name="selectedCount">The count of the selected steps.</param>
        public void CreateNewTestCaseCollectionAfterMoveUp(int startIndex, int selectedCount)
        {
            List<YouTubeSong> newCollection = new List<YouTubeSong>();
            for (int i = 0; i < startIndex - 1; i++)
            {
                newCollection.Add(this.ObservableSongs[i]);
            }

            for (int i = startIndex; i < startIndex + selectedCount; i++)
            {
                newCollection.Add(this.ObservableSongs[i]);
            }
            for (int i = startIndex - 1; i < startIndex; i++)
            {
                newCollection.Add(this.ObservableSongs[i]);
            }

            for (int i = startIndex + selectedCount; i < this.ObservableSongs.Count; i++)
            {
                newCollection.Add(this.ObservableSongs[i]);
            }

            this.ObservableSongs.Clear();
            newCollection.ForEach(x => this.ObservableSongs.Add(x));
            //UndoRedoManager.Instance().Push((si, c) => this.CreateNewTestStepCollectionAfterMoveDown(si, c), startIndex - 1, selectedCount, "Move up selected test steps");
        }

        /// <summary>
        /// Creates the new songs collection after move down.
        /// </summary>
        /// <param name="startIndex">The start index.</param>
        /// <param name="selectedCount">The count of the selected test steps.</param>
        public void CreateNewTestCaseCollectionAfterMoveDown(int startIndex, int selectedCount)
        {
            List<YouTubeSong> newCollection = new List<YouTubeSong>();
            for (int i = 0; i < startIndex; i++)
            {
                newCollection.Add(this.ObservableSongs[i]);
            }
            newCollection.Add(this.ObservableSongs[startIndex + selectedCount]);
            for (int i = startIndex; i < startIndex + selectedCount; i++)
            {
                newCollection.Add(this.ObservableSongs[i]);
            }

            for (int i = startIndex + selectedCount + 1; i < this.ObservableSongs.Count; i++)
            {
                newCollection.Add(this.ObservableSongs[i]);
            }

            this.ObservableSongs.Clear();
            newCollection.ForEach(x => this.ObservableSongs.Add(x));
            //UndoRedoManager.Instance().Push((si, c) => this.CreateNewTestCaseCollectionAfterMoveUp(si, c), startIndex + 1, selectedCount, "Move down selected test steps");
        }
    }
}
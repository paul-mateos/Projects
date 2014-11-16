using AAngelov.Utilities.Managers;

namespace PhantomTube.Core.Managers
{
    public class RegistryManager : BaseRegistryManager
    {
        /// <summary>
        /// The instance
        /// </summary>
        private static RegistryManager instance;

        /// <summary>
        /// The user name
        /// </summary>
        private readonly string userNameSubKey = "userName";

        /// <summary>
        /// The last playlist
        /// </summary>
        private readonly string lastPlaylistSubKey = "lastPlaylist";

        /// <summary>
        /// The volume sub key
        /// </summary>
        private readonly string volumeSubKey = "volume";

        /// <summary>
        /// The songs to be deleted sub key
        /// </summary>
        private readonly string songsToBeDeletedSubKey = "songsToBeDeleted";

        /// <summary>
        /// The songs to be added sub key
        /// </summary>
        private readonly string songsToBeAddedSubKey = "songsToBeAdded";

        /// <summary>
        /// Initializes a new instance of the <see cref="RegistryManager"/> class.
        /// </summary>
        public RegistryManager()
        {
            this.MainRegistrySubKey = "PhantomTube/settings";
        }

        /// <summary>
        /// Gets the instance.
        /// </summary>
        /// <value>
        /// The instance.
        /// </value>
        public static RegistryManager Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new RegistryManager();
                }
                return instance;
            }
        }

        /// <summary>
        /// Writes the name of the user.
        /// </summary>
        /// <param name="userName">Name of the user.</param>
        public void WriteUserName(string userName)
        {
            this.Write(this.GenerateMergedKey(userNameSubKey), userName);
        }

        /// <summary>
        /// Writes the songs to be deleted.
        /// </summary>
        /// <param name="songsToBeDeleted">The songs to be deleted.</param>
        public void WriteSongsToBeDeleted(string songsToBeDeleted)
        {
            this.Write(this.GenerateMergedKey(songsToBeDeletedSubKey), songsToBeDeleted);
        }

        /// <summary>
        /// Writes the songs to be added.
        /// </summary>
        /// <param name="songsToBeAdded">The songs to be added.</param>
        public void WriteSongsToBeAdded(string songsToBeAdded)
        {
            this.Write(this.GenerateMergedKey(songsToBeAddedSubKey), songsToBeAdded);
        }

        /// <summary>
        /// Writes the volume.
        /// </summary>
        /// <param name="currentVolume">The current volume.</param>
        public void WriteVolume(double currentVolume)
        {
            this.Write(this.GenerateMergedKey(volumeSubKey), currentVolume);
        }

        /// <summary>
        /// Writes the last selected playlist.
        /// </summary>
        /// <param name="playlist">The playlist.</param>
        public void WriteLastSelectedPlaylist(string playlist)
        {
            this.Write(this.GenerateMergedKey(lastPlaylistSubKey), playlist);
        }

        /// <summary>
        /// Reads the name of the user.
        /// </summary>
        /// <returns>the user name</returns>
        public string ReadUserName()
        {
            return this.ReadStr(this.GenerateMergedKey(userNameSubKey));
        }

        /// <summary>
        /// Reads the songs to be deleted.
        /// </summary>
        /// <returns></returns>
        public string ReadSongsToBeDeleted()
        {
            return this.ReadStr(this.GenerateMergedKey(songsToBeDeletedSubKey));
        }

        /// <summary>
        /// Reads the songs to be added.
        /// </summary>
        /// <returns></returns>
        public string ReadSongsToBeAdded()
        {
            return this.ReadStr(this.GenerateMergedKey(songsToBeAddedSubKey));
        }

        /// <summary>
        /// Reads the volume.
        /// </summary>
        /// <returns>the volume</returns>
        public double? ReadVolume()
        {
            double? result = this.ReadDouble(this.GenerateMergedKey(volumeSubKey));
            return result;
        }

        /// <summary>
        /// Reads the last playlist.
        /// </summary>
        /// <returns>the last playlist</returns>
        public string ReadLastPlaylist()
        {
            return this.ReadStr(this.GenerateMergedKey(lastPlaylistSubKey));
        }
    }
}
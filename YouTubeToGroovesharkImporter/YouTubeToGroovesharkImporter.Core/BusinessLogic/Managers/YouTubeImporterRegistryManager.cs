using AAngelov.Utilities.Managers;

namespace YouTubeToGroovesharkImporter.Core.BusinessLogic.Managers
{
    public class YouTubeImporterRegistryManager : BaseRegistryManager
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="YouTubeImporterRegistryManager"/> class.
        /// </summary>
        public YouTubeImporterRegistryManager()
        {
            this.MainRegistrySubKey = "YouTubeToGroovesharkImporter";
        }
    }
}

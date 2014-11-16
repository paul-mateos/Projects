using AAngelov.Utilities.Managers;

namespace YouTubeToGroovesharkImporter.Core.BusinessLogic.Managers
{
    public class RegistryManager : BaseRegistryManager
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="YouTubeImporterRegistryManager"/> class.
        /// </summary>
        public RegistryManager()
        {
            this.MainRegistrySubKey = "YouTubeToGroovesharkImporter/settings";
        }
    }
}
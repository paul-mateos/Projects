using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YouTubeToGroovesharkImporter.Console.Data
{
    /// <summary>
    /// Represents Sont Entity
    /// </summary>
    public class Song
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Song"/> class.
        /// </summary>
        /// <param name="artist">The artist.</param>
        /// <param name="name">The name.</param>
        public Song(string artist, string name)
        {
            this.Artist = artist;
            this.Name = name;
        }

        /// <summary>
        /// Gets or sets the artist.
        /// </summary>
        /// <value>
        /// The artist.
        /// </value>
        public string Artist { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public string Name { get; set; }
    }
}

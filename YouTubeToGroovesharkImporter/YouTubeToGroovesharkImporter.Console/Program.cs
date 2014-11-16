using System;
using System.IO;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;
using YouTube.SDK;
using System.Text.RegularExpressions;
using YouTubeToGroovesharkImporter.Console.Data;
using Grooveshark.SDK;
using Artist = Grooveshark.SDK.Data.Artist;
using Session = Grooveshark.SDK.Data.Session;
using System.Linq;
using System.Text;

namespace YouTubeToGroovesharkImporter
{
    internal class YouTubeToGroovesharkImporterConsole
    {
        /// <summary>
        /// The regex song pattern
        /// </summary>
        private static string RegexSongPattern = @"\s*(?<Artist>[a-zA-Z1-9\s\w]{1,})-(?<Name>[a-zA-Z1-9\-\s\w""']{1,})";
        private static string sessionId = "";

        static void Main(string[] args)
        {
            List<string> playListSongs = new List<string>();
            playListSongs = YouTubeServiceClient.Instance.GetPlayListSongs("angelov.st.anton@gmail.com", "PL1CTk64TxYtCwLKL1FAT9H8BG4fcyK2I3");
            Regex regexNamespaceInitializations = new Regex(RegexSongPattern, RegexOptions.None);
            List<Song> songs = new List<Song>();
            foreach (string currentPlayListSong in playListSongs)
            {
                System.Console.WriteLine(currentPlayListSong);
                Match m = regexNamespaceInitializations.Match(currentPlayListSong);
                if (m.Success)
                {
                    songs.Add(new Song(m.Groups["Artist"].ToString(), m.Groups["Name"].ToString()));
                }
            }
            GroovesharkService groovesharkService = new GroovesharkService();
            Session.Result sessionResult = groovesharkService.StartSession();
            StreamWriter writer = new StreamWriter("whatIsFound.txt", false, Encoding.UTF8, 10);
            using(writer)
            {
                foreach (Song currentSong in songs)
                {
                    Artist.Result artistResult = null;
                    if (currentSong.Artist != null)
                    {
                        artistResult = groovesharkService.GetArtistSearchResults(currentSong.Artist, 5);
                    }
                    if (artistResult == null || artistResult.artists.Count == 0)
                    {
                        string strToWrite = string.Format("Artist: {0} Name: {1} NOT FOUND G", currentSong.Artist, currentSong.Name);
                        System.Console.WriteLine(strToWrite);
                        writer.WriteLine(strToWrite);
                        continue;
                    }
                    string artistName = string.Empty;
                    var query = artistResult.artists.Where(x => x != null && x.ArtistName.Equals(currentSong.Artist));
                    if (query.Count() > 0)
                    {
                        artistName = query.FirstOrDefault().ArtistName;
                    }
                    if (string.IsNullOrEmpty(artistName))
                    {
                        query = artistResult.artists.Where(x => x != null && x.IsVerified.Equals(true));
                        if (query.Count() > 0)
                        {
                            artistName = query.FirstOrDefault().ArtistName;
                        }
                    }
                    else
                    {
                        artistName = artistResult.artists.FirstOrDefault().ArtistName;
                    }

                    string strToWrite1 = string.Format("Artist: {0} Name: {1} Found On G: {2}", currentSong.Artist, currentSong.Name, artistName);
                    System.Console.WriteLine(strToWrite1);
                    writer.WriteLine(strToWrite1);
                }  
            }
            
        }    
    }
}

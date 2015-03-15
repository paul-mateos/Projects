using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace AutomateThePlanetPoster.Core
{
    public class MainViewModel
    {
        private const string FileName = "postsDataBase.xml";
        public List<Post> Posts { get; set; }

        public MainViewModel()
        {
            this.Posts = this.LoadPosts();
            if (this.Posts == null)
            {
                this.Posts = new List<Post>();
            }
        }

        public string GeneratePostsContent()
        {
            StringBuilder sb = new StringBuilder();
            var sortedPosts = this.Posts.OrderBy(x => x.PostType);
            foreach (Post currentPost in sortedPosts)
            {
                string currentAuthorText = currentPost.Site != null ? string.Format("{0}({1})", currentPost.Author, currentPost.Site) : currentPost.Author;
                string currentUrl = currentPost.IsTrackBack == true ? string.Format("{0}/trackback", currentPost.Url.TrimEnd('/')) : currentPost.Url;
                string currentLine = string.Format("<span style=\"font-size: 12pt;\"><a style=\"color: #{0};\" href=\"{1}\" target=\"_blank\">[icon size=\"12px\" icon=\"icon-bolt\" color=\"#000000\"]{2}</a></span> - <span style=\"font-size: 10pt;\"><em>{3}</em></span>", currentPost.PostType.Text(), currentUrl, currentPost.Title, currentAuthorText);
                sb.AppendLine(currentLine);
                // <span style="font-size: 12pt;"><a style="color: #339966;" href="http://blog.cellfish.se/2015/03/should-bugs-be-user-stories.html" target="_blank">[icon size="12px" icon=" icon-bolt" color="#000000"]Should bugs be user stories</a></span> - <span style="font-size: 10pt;"><em>cellfish</em></span>
            }
            return sb.ToString();
        }

        public void WritePostsToDisc()
        {
            if 
                (this.Posts == null) 
            {
                return;
            }

            try
            {
                XmlDocument xmlDocument = new XmlDocument();
                XmlSerializer serializer = new XmlSerializer(typeof(List<Post>));
                using (MemoryStream stream = new MemoryStream())
                {
                    serializer.Serialize(stream, this.Posts);
                    stream.Position = 0;
                    xmlDocument.Load(stream);
                    xmlDocument.Save(FileName);
                    stream.Close();
                }
            }
            catch (Exception ex)
            {
                //Log exception here
            }
        }

        public List<Post> LoadPosts()
        {
            if (string.IsNullOrEmpty(FileName)) 
            {
                return new List<Post>()
                    {
                        new Post()
                    }; 
            }

            List<Post> objectOut = default(List<Post>);

            try
            {
                XmlDocument xmlDocument = new XmlDocument();
                xmlDocument.Load(FileName);
                string xmlString = xmlDocument.OuterXml;

                using (StringReader read = new StringReader(xmlString))
                {
                    Type outType = typeof(List<Post>);

                    XmlSerializer serializer = new XmlSerializer(outType);
                    using (XmlReader reader = new XmlTextReader(read))
                    {
                        objectOut = (List<Post>)serializer.Deserialize(reader);
                        reader.Close();
                    }

                    read.Close();
                }
            }
            catch (Exception ex)
            {
                //Log exception here
            }

            return objectOut;
        }
    }
}

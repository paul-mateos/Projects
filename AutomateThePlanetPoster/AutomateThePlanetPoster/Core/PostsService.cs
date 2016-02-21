using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace AutomateThePlanetPoster.Core
{
    public class PostsService
    {
        private static PostsService instance;
        private const string FileName = "postsDataBase.xml";

        public List<Post> Posts { get; set; }

        public static PostsService Instance
        {
            get
            { 
                if (instance == null)
                {
                    instance = new PostsService();
                    instance.Posts = instance.LoadPosts();
                    if (instance.Posts == null)
                    {
                        instance.Posts = new List<Post>();
                    }
                }
                return instance;
            }
        }

        public string GeneratePostsContent()
        {
            StringBuilder sb = new StringBuilder();
            var sortedPosts = Posts.OrderBy(x => x.PostType);
            
            PostTypes previousCategoryType = PostTypes.NA;
            foreach (Post currentPost in sortedPosts)
            {
                if (previousCategoryType != currentPost.PostType)
                {
                    if (currentPost.PostType != PostTypes.NA)
                    {
                        sb.AppendLine("</ul>");
                    }
                    previousCategoryType = currentPost.PostType;
                    sb.AppendLine(string.Format("<h2>{0}</h2>", currentPost.PostType.GetTitle()));
                    sb.AppendLine("<ul style=\"list-style-type: disc;\">");
                }
               
                string currentAuthorText = currentPost.Site != null ? string.Format("{0}({1})", currentPost.Author, currentPost.Site) : currentPost.Author;
                string currentUrl = currentPost.IsTrackBack == true ? string.Format("{0}/trackback", currentPost.Url.TrimEnd('/')) : currentPost.Url;
                string currentLine = string.Format("<li><span style=\"font-size: 12pt;\"><a style=\"color: #{0};\" href=\"{1}\" target=\"_blank\">{2}</a></span> - <span style=\"font-size: 10pt;\"><em>{3}</em></span></li>", currentPost.PostType.Description(), currentUrl, currentPost.Title, currentAuthorText);
                sb.AppendLine(currentLine);
            }
            sb.AppendLine("</ul>");
            return sb.ToString();
        }

        public void WritePostsToDisc()
        {
            if 
            (Posts == null) 
            {
                return;
            }

            try
            {
                XmlDocument xmlDocument = new XmlDocument();
                XmlSerializer serializer = new XmlSerializer(typeof(List<Post>));
                using (MemoryStream stream = new MemoryStream())
                {
                    serializer.Serialize(stream, Posts);
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
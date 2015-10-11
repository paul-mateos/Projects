using System;
using System.Linq;
using System.ServiceModel.Syndication;
using System.Xml;

namespace RSSReader.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            string url = "http://automatetheplanet.com/feed/";
            XmlReader reader = XmlReader.Create(url);
            SyndicationFeed feed = SyndicationFeed.Load(reader);
            reader.Close();
            foreach (SyndicationItem currentRssItem in feed.Items)
            {
                String subject = currentRssItem.Title.Text;
                String summary = currentRssItem.Summary.Text;
                String currentArticleUrl = currentRssItem.Links.FirstOrDefault().Uri.AbsoluteUri;
                System.Console.WriteLine(subject + " " + summary + " " + currentArticleUrl);                          
            }
        }
    }
}
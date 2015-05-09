using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using HtmlAgilityPack;

namespace LinksExtractor
{
    public class Program
    {
        static string domainPattern = @"(http|https):\/\/(?<domain>[A-Za-z0-9.-]*)";
        static Dictionary<string, bool> crawledUrls = new Dictionary<string, bool>();
        static Dictionary<string, bool> savedUrls = new Dictionary<string, bool>();
        static List<string> savedDomains = new List<string>();
        static void Main(string[] args)
        {
            string mainDomain = @"http://blog.testingcurator.com/";
            ExtractDomainsByUrl(mainDomain, @"http://blog.testingcurator.com/2015/05/03/testing-bits-42615-5215/#more-773");
            SaveResultsToFile(@"D:\testingCurratorAllDomains.txt");
        }

        private static void SaveResultsToFile(string filePath)
        {
            StreamWriter writer = new StreamWriter(filePath);
            using (writer)
            {
                foreach (var currentDomain in savedDomains)
                {
                    writer.WriteLine(currentDomain);
                }
            }
        }

        private static void ExtractDomainsByUrl(string mainDomain, string url)
        {
            var urls = ExtractAllUrlsFromUrl(url);
            foreach (var currentUrl in urls)
            {
                Console.Clear();
                Console.WriteLine(currentUrl);
                if (currentUrl.StartsWith(mainDomain) && !crawledUrls.ContainsKey(currentUrl))
                {
                    crawledUrls.Add(currentUrl, true);
                    ExtractDomainsByUrl(mainDomain, currentUrl);
                }
                else if (currentUrl.StartsWith("http") && !savedUrls.ContainsKey(currentUrl))
                {
                    savedUrls.Add(currentUrl, true);
                    var domain = GetDomainName(currentUrl);
                    if (!savedDomains.Contains(domain))
                    {
                        savedDomains.Add(domain);              
                    }
                }
            }
        }

        private static List<string> ExtractAllUrlsFromUrl(string url)
        {
            List<string> urls = new List<string>();
            HtmlWeb hw = new HtmlWeb();
            HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
            doc = hw.Load(url);
            var allLinks = doc.DocumentNode.SelectNodes("//a[@href]");
            if (allLinks != null && allLinks.Count > 0)
            {
                foreach (HtmlNode link in allLinks)
                {
                    string hrefValue = link.GetAttributeValue("href", string.Empty);
                    urls.Add(hrefValue);
                }
            }           

            return urls;
        }

        private static string GetDomainName(string url)
        {
            string domain = string.Empty;
            Regex regexNamespaceInitializations = new Regex(domainPattern, RegexOptions.None);
            Match m = regexNamespaceInitializations.Match(url);
            if (m.Success)
            {
                domain = m.Groups[0].Value;
            }

            return domain;
        }
    }
}
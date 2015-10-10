using HtmlAgilityPack;
using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;

namespace CodeProject.Articles.Beautifier.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            HtmlWeb hw = new HtmlWeb();
            HtmlDocument doc = hw.Load("http://www.codeproject.com/script/Articles/ArticleVersion.aspx?aid=1021335&av=2183368");
            
            // add introduction and dowload repository button
            string introductionNodeInnerHtml =
                @"<ul class=""download"" style=""background-color: rgb(255, 255, 255);"">
	                                <li><a href=""https://github.com/angelovstanton/Projects/tree/master/PatternsInAutomation.Tests"">Download full source code from GitHub</a></li>
                                </ul>

                                <h2 style=""background-color: rgb(255, 255, 255);"">Introduction</h2>";
            HtmlNode newIntroductionNode = HtmlNode.CreateNode(introductionNodeInnerHtml);
            HtmlNode bodyNode = doc.DocumentNode.SelectSingleNode("//body");
            bodyNode.PrependChild(newIntroductionNode);

            // Fix all code snippets
            var findclasses = doc.DocumentNode.Descendants("div").Where(d => d.Attributes.Contains("class") && d.Attributes["class"].Value.Contains("oembed-gist")).ToList();
            for (int i = 0; i < findclasses.Count(); i++)
            {
                string currentGistUrl = findclasses[i].SelectNodes("a").FirstOrDefault().Attributes["href"].Value;
                System.Console.WriteLine(currentGistUrl);
                string encodedCode = GetEncodedRawCodeByGistUrl(currentGistUrl);
                encodedCode = string.Concat(Environment.NewLine, "<div class=\"oembed-gist\"><pre lang=\"cs\">", encodedCode, "</pre></div>", Environment.NewLine);
                findclasses[i].ParentNode.ReplaceChild(HtmlNode.CreateNode(encodedCode).ParentNode, findclasses[i]);
            }

            // Fix all images' paths
            var allImages = doc.DocumentNode.Descendants("img").ToList();
            for (int i = 0; i < allImages.Count; i++)
            {
                string currentImageSource = allImages[i].Attributes["src"].Value;
                string newImageSource = currentImageSource.Split('/').Last();
                string newImageInnerHtml = string.Format("<img src=\"{0}\">", newImageSource);
                var newHtmlNode = HtmlNode.CreateNode(newImageInnerHtml);
                allImages[i].ParentNode.ReplaceChild(newHtmlNode.ParentNode, allImages[i]);
            }

            // add license agreement to the end of the 
            string imageLicenseAgreementNodeInnerHtml =
                @"<p><span style=""background-color: rgb(255, 255, 255);"">All images are purchased from&nbsp;</span><a href=""http://depositphotos.com/"" style=""background-color: rgb(255, 255, 255);"">DepositPhotos.com</a><span style=""background-color: rgb(255, 255, 255);"">&nbsp;and cannot be downloaded and used for free.</span><br style=""background-color: rgb(255, 255, 255);"" />
<a href=""http://depositphotos.com/license.html"" style=""background-color: rgb(255, 255, 255);"">License Agreement</a></p>";
            HtmlNode mageLicenseAgreementNode = HtmlNode.CreateNode(imageLicenseAgreementNodeInnerHtml);

            bodyNode.AppendChild(mageLicenseAgreementNode);

            // replace repository link with source code button
            var sourceCodeDiv = doc.DocumentNode.Descendants("div").Where(d => d.Attributes.Contains("class") && d.Attributes["class"].Value.Contains("sourceCode")).FirstOrDefault();
            string sourceCodeNodeInnerHtml =
                @"<h3>Source Code</h3>
<ul class=""download"" style=""background-color: rgb(255, 255, 255);"">
	<li><a href=""https://github.com/angelovstanton/Projects/tree/master/PatternsInAutomation.Tests"">Download full source code from GitHub</a></li>
</ul>";
            HtmlNode newSourceCodeNode = HtmlNode.CreateNode(sourceCodeNodeInnerHtml);
            sourceCodeDiv.ParentNode.ReplaceChild(newSourceCodeNode.ParentNode, sourceCodeDiv);

            // Save the html file to desktop

            var desktopFolder = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
            var fullFileName = Path.Combine(desktopFolder, "BeautifiedCodeProjectArticleTest.html");
            doc.Save(fullFileName);
            ////System.Console.WriteLine(allLinks[0].OuterHtml);
            ////System.Console.WriteLine(doc.DocumentNode.OuterHtml);
            ////string encodedCode = GetEncodedRawCodeByGistUrl();
            ////System.Console.WriteLine(encodedCode);
        }

        private static string GetEncodedRawCodeByGistUrl(string nonRawUrl)
        {
            string html = string.Empty;
            string rawUrl = string.Concat(nonRawUrl, "/raw");

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(rawUrl);
            request.AutomaticDecompression = DecompressionMethods.GZip;

            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            {
                using (Stream stream = response.GetResponseStream())
                {
                    using (StreamReader reader = new StreamReader(stream))
                    {
                        html = reader.ReadToEnd();
                    }
                }
            }

            string encodedString = HttpUtility.HtmlEncode(html);

            return encodedString;
        }
    }
}
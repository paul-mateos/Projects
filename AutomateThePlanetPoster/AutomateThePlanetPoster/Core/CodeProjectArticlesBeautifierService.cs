using HtmlAgilityPack;
using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;
using System.Web;

namespace AutomateThePlanetPoster.Core
{
    public class CodeProjectArticlesBeautifierService
    {
        public string Beautify(string sourceHtml)
        {
            string beautifedHtml = string.Empty;
            HtmlDocument doc = new HtmlDocument();
            doc.LoadHtml(sourceHtml);

            this.AddIntroductionSnippetToBeginning(doc);
            this.ReplaceAllGistUrlsWithFormattedCodeSnippets(doc);
            this.FixAllImagesPaths(doc);          
            this.ReplaceSourceCodeDivWithSourceCodeButton(doc);
            this.ReplaceSubscribeDivWithDefaultSubscribeDiv(doc);
            this.AddImagesLicenseAgreementToBodyEnd(doc);
            
            beautifedHtml = doc.DocumentNode.OuterHtml;
            return beautifedHtml;
        }

        private void AddIntroductionSnippetToBeginning(HtmlDocument doc)
        {
            // add introduction and dowload repository button
            if (!doc.DocumentNode.OuterHtml.StartsWith("<div><ul class=\"download\" style=\"background-color: rgb(255, 255, 255);\">"))
            {
                string introductionNodeInnerHtml =
                    @"<div><ul class=""download"" style=""background-color: rgb(255, 255, 255);"">
	                                <li><a href=""https://github.com/angelovstanton/Projects/tree/master/PatternsInAutomation.Tests"">Download full source code from GitHub</a></li>
                                </ul>

                                <h2 style=""background-color: rgb(255, 255, 255);"">Introduction</h2></div>";
                HtmlNode newIntroductionNode = HtmlNode.CreateNode(introductionNodeInnerHtml);
                HtmlNode mainNode = doc.DocumentNode;
                mainNode.PrependChild(newIntroductionNode);
            }
        }

        private void ReplaceAllGistUrlsWithFormattedCodeSnippets(HtmlDocument doc)
        {
            string githubUrlPattern = @"(.*)(?<link>https://(.*)).js(.*)";
            // Fix all code snippets
            var findclasses = doc.DocumentNode.Descendants("div").Where(d => d.Attributes.Contains("class") && d.Attributes["class"].Value.Contains("thrv_wrapper thrv_custom_html_shortcode")).ToList();
            for (int i = 0; i < findclasses.Count(); i++)
            {
                var currentGistUrlNodes = findclasses[i].SelectNodes("code");
                if (currentGistUrlNodes != null)
                {
                    string currentGistUrl = currentGistUrlNodes.FirstOrDefault().InnerText;
                    MatchCollection matches = Regex.Matches(currentGistUrl, githubUrlPattern);
                    System.Console.WriteLine(currentGistUrl);
                    string encodedCode = GetEncodedRawCodeByGistUrl(matches[0].Groups["link"].Value);
                    encodedCode = string.Concat(Environment.NewLine, "<div class=\"oembed-gist\"><pre lang=\"cs\">", encodedCode, "</pre></div>", Environment.NewLine);
                    findclasses[i].ParentNode.ReplaceChild(HtmlNode.CreateNode(encodedCode).ParentNode, findclasses[i]);
                }
            }
        }

        private void FixAllImagesPaths(HtmlDocument doc)
        {
            // Fix all images' paths
            var allImages = doc.DocumentNode.Descendants("img").ToList();
            for (int i = 0; i < allImages.Count; i++)
            {
                string currentImageSource = allImages[i].Attributes["src"].Value;
                string newImageSource = currentImageSource.Split('/').Last();
                if (currentImageSource != newImageSource)
                {
                    string newImageInnerHtml = string.Format("<img src=\"{0}\">", newImageSource);
                    var newHtmlNode = HtmlNode.CreateNode(newImageInnerHtml);
                    allImages[i].ParentNode.ReplaceChild(newHtmlNode.ParentNode, allImages[i]);
                }
            }
        }

        private void AddImagesLicenseAgreementToBodyEnd(HtmlDocument doc)
        {
            var existingLicenseNodes = doc.DocumentNode.Descendants("a").Where(d => d.Attributes.Contains("href") && d.Attributes["href"].Value.Contains("http://depositphotos.com/"));
            if (existingLicenseNodes.Count() == 0)
            {
                // add license agreement to the end of the 
                HtmlNode mainNode = doc.DocumentNode;
                string imageLicenseAgreementNodeInnerHtml =
                    @"<p><span style=""background-color: rgb(255, 255, 255);"">All images are purchased from&nbsp;</span><a href=""http://depositphotos.com/"" style=""background-color: rgb(255, 255, 255);"">DepositPhotos.com</a><span style=""background-color: rgb(255, 255, 255);"">&nbsp;and cannot be downloaded and used for free.</span><br style=""background-color: rgb(255, 255, 255);"" />
<a href=""http://depositphotos.com/license.html"" style=""background-color: rgb(255, 255, 255);"">License Agreement</a></p>";
                HtmlNode mageLicenseAgreementNode = HtmlNode.CreateNode(imageLicenseAgreementNodeInnerHtml);

                mainNode.AppendChild(mageLicenseAgreementNode);
            }
        }

        private void ReplaceSourceCodeDivWithSourceCodeButton(HtmlDocument doc)
        {
            // replace repository link with source code button
            var sourceCodeDiv = doc.DocumentNode.Descendants("div").Where(d => d.Attributes.Contains("class") && d.Attributes["class"].Value.Contains("sourceCode")).FirstOrDefault();
            if (sourceCodeDiv != null || (sourceCodeDiv != null && !sourceCodeDiv.InnerHtml.Contains("class=\"download\"")))
            {
                string sourceCodeNodeInnerHtml =
                    @"<h3>Source Code</h3>
<ul class=""download"" style=""background-color: rgb(255, 255, 255);"">
	<li><a href=""https://github.com/angelovstanton/Projects/tree/master/PatternsInAutomation.Tests"">Download full source code from GitHub</a></li>
</ul>";
                HtmlNode newSourceCodeNode = HtmlNode.CreateNode(sourceCodeNodeInnerHtml);
                sourceCodeDiv.ParentNode.ReplaceChild(newSourceCodeNode.ParentNode, sourceCodeDiv);
            }
        }

        private void ReplaceSubscribeDivWithDefaultSubscribeDiv(HtmlDocument doc)
        {
            var subscribeDiv = doc.DocumentNode.Descendants("div").Where(d => d.Attributes.Contains("class") && d.Attributes["class"].Value.Contains("subscribe")).FirstOrDefault();
            if (subscribeDiv != null)
            {
                string subscribeNodeInnerHtml =
                    @"<div class=""subscribe""><p>If you enjoy my publications, feel free to <strong><a href=""http://automatetheplanet.com/newsletter/"" style=""color: #bda324;"" target=""_blank"">SUBSCRIBE</a></strong><br />
Also, hit these share buttons. <strong>Thank you!</strong></p></div>";
                HtmlNode newSubscribeNode = HtmlNode.CreateNode(subscribeNodeInnerHtml);
                subscribeDiv.ParentNode.ReplaceChild(newSubscribeNode.ParentNode, subscribeDiv);
            }
        }

        private string GetEncodedRawCodeByGistUrl(string nonRawUrl)
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
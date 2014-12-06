using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Mail;
using System.Net;
using System.Net.Http;
using HtmlAgilityPack;
using System.Threading.Tasks;
using System.IO;
using System.Threading;
namespace SendGoogleBookmarksToPocket
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.Write("Enter file to chrome bookmarks html: ");
            string fileToPath = Console.ReadLine();
            if (!File.Exists(fileToPath))
            {
                Console.WriteLine("The provided file does not exists!");
                return;
            }
            Console.Write("Enter your gmail user: ");
            string userName = Console.ReadLine();
            Console.Write("Password: ");
            string password = Console.ReadLine();

            string source = WebUtility.HtmlDecode(File.ReadAllText(fileToPath, Encoding.UTF8));
            HtmlDocument resultat = new HtmlDocument();
            resultat.LoadHtml(source);
            List<HtmlNode> hrefs = resultat.DocumentNode.Descendants().Where(x => (x.Name == "a")).ToList();
            var client = new SmtpClient("smtp.gmail.com", 587)
            {
                Credentials = new NetworkCredential(userName, password),
                EnableSsl = true
            };
            
            foreach (var currentHref in hrefs)
            {
                try
                {
                    Console.WriteLine("Title {0} HREF: {1}", currentHref.InnerText, currentHref.Attributes["href"].Value);
                    client.Send(userName, "add@getpocket.com", currentHref.InnerText, currentHref.Attributes["href"].Value);
                }
                catch(SmtpException)
                {
                    Thread.Sleep(1000);
                }                
            }
            Console.WriteLine("Success all of your Chrome bookmarks are imported to Pocket!");
            Console.ReadLine();
        }
    }
}

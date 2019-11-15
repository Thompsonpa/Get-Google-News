using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using HtmlAgilityPack;
namespace NewsArticles
{
    class Program
    {
        static void Main(string[] args)
        {
            int i = 0;
            while (i == 0)
            {
                MainAsync(args).ConfigureAwait(false).GetAwaiter().GetResult();
                Console.WriteLine(" ");
                Console.WriteLine("Updated: " + DateTime.Now.ToString("hh:mm") + " Next Update: " + DateTime.Now.AddMinutes(15).ToString("hh:mm"));
                Thread.Sleep(TimeSpan.FromMinutes(15));
                Console.Clear();
            }
        }

        async static Task MainAsync(string[] args)
        {
            IList<string> strList = new List<string>();
            strList.Add("https://news.google.com/topics/CAAqIggKIhxDQkFTRHdvSkwyMHZNRGxqTjNjd0VnSmxiaWdBUAE?hl=en-US&gl=US&ceid=US%3Aen"); //Google US News
            strList.Add("https://news.google.com/topics/CAAqJggKIiBDQkFTRWdvSUwyMHZNRGx1YlY4U0FtVnVHZ0pWVXlnQVAB?hl=en-US&gl=US&ceid=US%3Aen"); //Google World
            strList.Add("https://news.google.com/publications/CAAqEQgKIgtDQklTQWdnR0tBQVAB?hl=en-US&gl=US&ceid=US%3Aen"); //Google Local
            strList.Add("https://news.google.com/topics/CAAqJggKIiBDQkFTRWdvSUwyMHZNRGx6TVdZU0FtVnVHZ0pWVXlnQVAB?hl=en-US&gl=US&ceid=US%3Aen"); //Google Business
            strList.Add("https://news.google.com/topics/CAAqJggKIiBDQkFTRWdvSUwyMHZNRGRqTVhZU0FtVnVHZ0pWVXlnQVAB?hl=en-US&gl=US&ceid=US%3Aen"); //Google Tech
            strList.Add("https://news.google.com/topics/CAAqJggKIiBDQkFTRWdvSUwyMHZNREpxYW5RU0FtVnVHZ0pWVXlnQVAB?hl=en-US&gl=US&ceid=US%3Aen"); //Google Entertain
            strList.Add("https://news.google.com/topics/CAAqJggKIiBDQkFTRWdvSUwyMHZNRFp1ZEdvU0FtVnVHZ0pWVXlnQVAB?hl=en-US&gl=US&ceid=US%3Aen"); //Google Sports
            strList.Add("https://news.google.com/topics/CAAqJggKIiBDQkFTRWdvSUwyMHZNRFp0Y1RjU0FtVnVHZ0pWVXlnQVAB?hl=en-US&gl=US&ceid=US%3Aen"); //google Science
            strList.Add("https://news.google.com/topics/CAAqIQgKIhtDQkFTRGdvSUwyMHZNR3QwTlRFU0FtVnVLQUFQAQ?hl=en-US&gl=US&ceid=US%3Aen"); //google health

            foreach (var NewsURL in strList)
            {
                HttpClient client = new HttpClient();
                var response = await client.GetAsync(NewsURL.ToString());
                var pageContents = await response.Content.ReadAsStringAsync();
                HtmlDocument pageDocument = new HtmlDocument();
                pageDocument.LoadHtml(pageContents);
                IEnumerable<HtmlNode> nodes = pageDocument.DocumentNode.SelectNodes("(//article//h3//a)");
                foreach (var item in nodes)
                {
                    if (item.InnerHtml.Contains("Hack") || item.InnerHtml.Contains("Hacking") || item.InnerHtml.Contains("security") || item.InnerHtml.Contains("Hacking") || item.InnerHtml.Contains("Breach") || item.InnerHtml.Contains("AMD") || item.InnerHtml.Contains("nvidia") || item.InnerHtml.Contains("NVIDIA") || item.InnerHtml.Contains("coding"))
                    {
                        Console.WriteLine(item.InnerHtml);
                    }
                }
            }

        }

    }
    public class URLinfoList
    {
        public string URL { set; get; }
        public string From { set; get; }
        public string Location { set; get; }
    }
}



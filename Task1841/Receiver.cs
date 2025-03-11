using AngleSharp.Dom;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YoutubeExplode;
using YoutubeExplode.Converter;

namespace Task1841
{
    /// <summary>
    /// Адресат команды
    /// </summary>
    class Receiver
    {
        public static string Url_ { get;set;}
        static YoutubeClient? client_ { get;set;}
        YoutubeExplode.Videos.Video video_ { get; set;}  
        public Receiver(string url)
        {
            Url_ = url;
        }
        public void Operation1()
        {
            Console.WriteLine("Процесс описания запущен");
            client_ = new YoutubeClient();
            video_ = client_.Videos.GetAsync(Url_).Result;

            var Id = video_.Id;
            var Title = video_.Title;
            var Description = video_.Description;
            var Author = video_.Author.ChannelTitle;
            var Duration = video_.Duration;
            var Engagement = video_.Engagement;

            Console.WriteLine($"Id = {Id}");
            Console.WriteLine($"Title = {Title}");
            Console.WriteLine($"Description = {Description}");
            Console.WriteLine($"Author = {Author}");
            Console.WriteLine($"Duration = {Duration}");
            Console.WriteLine($"Engagement = {Engagement}");
        }

        public async Task Operation2Async()
        {
            Console.WriteLine("Процесс загрузки запущен");
            await client_.Videos.DownloadAsync(Url_, "video.mp4");
        }
            

    }
}

using AngleSharp.Dom;
using System;
using System.Runtime.InteropServices;
using YoutubeExplode;
using YoutubeExplode.Common;
using YoutubeExplode.Converter;
using YoutubeExplode.Videos;

namespace Task1841
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            string videoURL = "https://www.youtube.com/watch?v=-CwJJkAouBw";
            //string videoURL = "https://www.youtube.com/watch?v=i9CPGOTd0G4";
            
            var client = new YoutubeClient();
            var video = client.Videos.GetAsync(videoURL).Result;
    
            var Id = video.Id;
            var Title = video.Title;
            var Description = video.Description;
            var Author = video.Author.ChannelTitle;
            var Duration = video.Duration;
            var Engagement = video.Engagement;

            //var outputFilePath = "C:\\Users\\swnike\\Downloads";
            var outputFilePath = "C:\\Users\\swnike\\source\\repos\\Task1841\\Task1841\\bin\\Debug\\net8.0";

            //client.Videos.DownloadAsync(Id, outputFilePath, builder => builder.SetPreset(ConversionPreset.UltraFast));

            Task task = User_can_download_a_video(client, outputFilePath, Id);



        }
        public static async Task User_can_download_a_video(YoutubeClient youtube, string outputFilePath, VideoId id)
        {
            await youtube.Videos.DownloadAsync(id, outputFilePath, static builder => builder.SetPreset(ConversionPreset.UltraFast));

            var fileInfo = new FileInfo(outputFilePath);
        }
    }
}

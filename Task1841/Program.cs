using AngleSharp.Dom;
using Microsoft.VisualBasic;
using System;
using System.Runtime.InteropServices;
using YoutubeExplode;
using YoutubeExplode.Common;
using YoutubeExplode.Converter;
using YoutubeExplode.Videos;
using YoutubeExplode.Videos.Streams;

namespace Task1841
{
    internal class Program
    {
        static async Task Main(string[] args)
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

            //await client.Videos.DownloadAsync(videoURL, "video.mp4");

            //await client.Videos.DownloadAsync(videoURL, "video.mp4", o => o
            //    .SetContainer("webm") // override format
            //    .SetPreset(ConversionPreset.UltraFast) // change preset
            //    //.SetFFmpegPath("path/to/ffmpeg") // custom FFmpeg location
            //    );//customizing

            //===========Manually selecting streams========================
            var streamManifest = client.Videos.Streams.GetManifestAsync(videoURL);
            //var streamInfo = streamManifest.Result.GetMuxedStreams().GetWithHighestVideoQuality();
            //var streamInfo = streamManifest.Result.GetVideoStreams().GetWithHighestVideoQuality();
            var streamInfo = streamManifest.Result.GetAudioStreams().GetWithHighestBitrate();//GetWithHighestVideoQuality();

            //var streamInfo = streamManifest.Result.GetMuxedStreams().GetWithHighestBitrate();//.GetWithHighestBitrate();

            // ...or the highest quality MP4 video-only stream
            //var streamInfo = streamManifest
            //    .GetVideoOnlyStreams()
            //    .Where(s => s.Container == Container.Mp4)
            //    .GetWithHighestVideoQuality()

            await client.Videos.Streams.DownloadAsync(streamInfo, $"video.{streamInfo.Container}");

        }
        public static async Task UserCanDownloadVideo(YoutubeClient youtube, string outputFilePath, VideoId id, string url)
        {
            //https://ru.stackoverflow.com/questions/1175824/c-%D0%BF%D1%80%D0%BE%D0%B8%D0%B3%D1%80%D1%8B%D0%B2%D0%B0%D0%BD%D0%B8%D0%B5-%D0%B2%D0%B8%D0%B4%D0%B5%D0%BE-%D1%81-youtube
            //https://learn.microsoft.com/en-us/answers/questions/201990/q-why-isnt-my-app-working

            //https://github.com/Tyrrrz/YoutubeExplode
            //https://github.com/Tyrrrz/YoutubeExplode/tree/master/YoutubeExplode.Converter

            var streamManifest = await youtube.Videos.Streams.GetManifestAsync(url);
            var streamInfo = streamManifest.GetMuxedStreams().GetWithHighestVideoQuality();

            await youtube.Videos.Streams.DownloadAsync(streamInfo, outputFilePath);


            //await youtube.Videos.DownloadAsync(id, outputFilePath, static builder => builder.SetPreset(ConversionPreset.UltraFast));

            var fileInfo = new FileInfo(outputFilePath);
        }
    }
}

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
            Console.WriteLine("Youtube Reader\n");
            Console.WriteLine("Введите Youtube URL:");
            string videoURL = Console.ReadLine();
            //string videoURL = "https://www.youtube.com/watch?v=-CwJJkAouBw";
            //string videoURL = "https://www.youtube.com/watch?v=i9CPGOTd0G4";

            // создадим отправителя
            var sender = new Sender();
            // создадим получателя
            var receiver = new Receiver(videoURL);

            // создадим команду
            var commandOne = new CmdGetDescription(receiver);

            // инициализация команды
            sender.SetCommand(commandOne);

            //  выполнение
            sender.Run();

            while (true)
            {
                Console.WriteLine("Считать Видео (Y/N)?");
                string sdecision = Console.ReadLine();
                switch (sdecision)
                {
                    case "N": return;

                    case "Y":
                        var commandTwo = new CmdDownloadVideo(receiver);
                        sender.SetCommand(commandTwo);
                        sender.Run();
                        break;

                    default:
                        break;
                }
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1841
{
    class CmdDownloadVideo : Command
    {
        Receiver receiver;
        public CmdDownloadVideo(Receiver receiver)
        {
            this.receiver = receiver;
        }
        public override void Cancel()
        {
            throw new NotImplementedException();
        }
        public override void Run()
        {
            Console.WriteLine("Команда загрузки видео отправлена");
            receiver.Operation2Async();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1841
{
    /// <summary>
    /// Конкретная реализация команды получения описания видео.
    /// </summary>
    internal class CmdGetDescription : Command
    {
        Receiver receiver;
        public CmdGetDescription(Receiver receiver)
        {
            this.receiver = receiver;
        }

        public override void Cancel()
        {
            throw new NotImplementedException();
        }

        public override void Run()
        {
            Console.WriteLine("Команда  получения описания видео отправлена");
            receiver.Operation1();
        }
    }
}

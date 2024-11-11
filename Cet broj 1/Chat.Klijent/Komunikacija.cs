using Biblioteka;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Chat.Klijent
{
    public class Komunikacija
    {
        private static Komunikacija instanca;

        private Komunikacija()
        {

        }

        public static Komunikacija Instanca { 
            get
            {
                if (instanca == null) instanca = new Komunikacija();
                return instanca;
            } 
        }

        private Socket socket;
        private CommunicationHelper helper;

        internal void Connect()
        {
            socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            socket.Connect("127.0.0.1", 9000);
            helper = new CommunicationHelper(socket);
        }

        public void SaljiPoruku(Poruka poruka)
        {
            try
            {

                helper.SaljiPoruku(poruka);
            }
            catch (IOException)
            {

                throw new ServerCommunicationException();
            }
        }

        public Poruka CitajPoruku()
        {
            return helper.CitajPoruku<Poruka>();
        }
    }
}

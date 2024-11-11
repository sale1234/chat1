using Biblioteka;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Cet.Server
{
    public class Server
    {
        private Socket serverSoket;
        private List<CleintHandler> cleints = new List<CleintHandler>();
        private List<Korisnik> korisnici = new List<Korisnik>();
        internal void Start()
        {
            if(serverSoket == null)
            {
                serverSoket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                serverSoket.Bind(new IPEndPoint(IPAddress.Parse("127.0.0.1"), 9000));
                serverSoket.Listen(5);
                UpisiPodatke();
            }
        }

        private void UpisiPodatke()
        {
            Korisnik k1 = new Korisnik
            {
                Email = "pera1@gmail.com",
                Password = "k1",
                Ime = "Pera 1",
                Prezime = "Peric 1"
            };
            korisnici.Add(k1);
            Korisnik k2 = new Korisnik
            {
                Email = "pera2@gmail.com",
                Password = "k2",
                Ime = "Pera 2",
                Prezime = "Peric 2"
            };
            korisnici.Add(k2);
            Korisnik k3 = new Korisnik
            {
                Email = "pera3@gmail.com",
                Password = "k3",
                Ime = "Pera 3",
                Prezime = "Peric 3"
            };
            korisnici.Add(k3);
        }

        internal void ObradiKlijente()
        {
            try
            {
                while(true)
                {
                    Socket klijentSoket = serverSoket.Accept();
                    CleintHandler handler = new CleintHandler(klijentSoket, cleints, korisnici);
                    cleints.Add(handler);
                    handler.OdjavljeniKlijent += Handler_OdjavljeniKlijent;
                    Thread klijentNit = new Thread(handler.ObradiPoruke);
                    klijentNit.Start();
                }
            }
            catch (SocketException ex)
            {
                Debug.WriteLine(">>>>" + ex.Message);
            }
        }

        private void Handler_OdjavljeniKlijent(object sender, EventArgs e)
        {
            cleints.Remove((CleintHandler)sender);
        }

        internal void Close()
        {
            serverSoket?.Close();
            serverSoket = null;
            
                foreach (var klijent in cleints.ToList())
                {
                    klijent.CloseSoket();
                }
        }
    }
}

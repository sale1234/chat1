using Biblioteka;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Cet.Server
{
    public class CleintHandler
    {
        private Socket klijentSoket;
        private List<CleintHandler> cleints;
        private List<Korisnik> korisnici;
        private CommunicationHelper helper;

        public CleintHandler(Socket klijentSoket, List<CleintHandler> cleints, List<Korisnik> korisnici)
        {
            this.klijentSoket = klijentSoket;
            this.cleints = cleints;
            this.korisnici = korisnici;
            helper = new CommunicationHelper(klijentSoket);
        }

        internal void ObradiPoruke()
        {
            try
            {
                while(true)
                {
                    Poruka poruka = helper.CitajPoruku<Poruka>();
                    switch (poruka.Operacija)
                    {
                        case Operacija.Login:
                            Login(poruka);
                            break;
                        case Operacija.SaljiSvima:
                            SaljiSvima(poruka);
                            break;
                        default:
                            break;
                    }
                }
            }
            catch (IOException ex)
            {
                Debug.WriteLine(">>>>" + ex.Message);
            }
            finally
            {
                if(klijentSoket != null)
                {
                    CloseSoket();
                }
            }
        }

        public Korisnik Korisnik { get; set; }

        private void Login(Poruka poruka)
        {
            bool ulogovan = false;
            foreach (var korisnik in korisnici)
            {
                if(poruka.Posiljalac.Email == korisnik.Email && poruka.Posiljalac.Password == korisnik.Password)
                {
                    ulogovan = true;
                    Korisnik = korisnik;
                }
            }
            if(ulogovan)
            {
                korisnici.Remove(Korisnik);
                Konroler.Instanca.Uloguj(Korisnik);
                Poruka odgovor = new Poruka
                {
                    Uspesno = true,
                    Primalac = Korisnik
                };
                helper.SaljiPoruku(odgovor);
                Poruka zaSve = new Poruka
                {
                    UlogovaniKorisnici = Konroler.Instanca.DajUlogovane()
                };
                SaljiSvima(zaSve);
            }
            else
            {
                Poruka odgovor = new Poruka
                {
                    Uspesno = false,
                    Primalac = Korisnik,
                    Tekst = "Korisnik je vec ulogovan!"
                };
                helper.SaljiPoruku(odgovor);
            }
        }

        public EventHandler OdjavljeniKlijent;
        private object lockObject = new object();

        internal void CloseSoket()
        {
            try
            {
                lock(lockObject)
                {
                    if(klijentSoket != null)
                    {
                        klijentSoket.Shutdown(SocketShutdown.Both);
                        klijentSoket.Close();
                        klijentSoket = null;
                        OdjavljeniKlijent?.Invoke(this, EventArgs.Empty);
                    }
                }

            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }

        private void SaljiSvima(Poruka poruka)
        {
            poruka.Posiljalac = Korisnik;
            Konroler.Instanca.DodajPoruku(poruka);
            foreach (var klijent in cleints)
            {
                if (klijent.Korisnik != null) klijent.helper.SaljiPoruku(poruka);
            }
        }
    }
}

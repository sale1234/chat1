using Biblioteka;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cet.Server
{
    public class Konroler
    {
        private static Konroler instanca;

        private Konroler()
        {
           
        }

        

        public static Konroler Instanca 
        { 
            get
            {
                if (instanca == null) instanca = new Konroler();
                return instanca;
            }
        }

        private List<Korisnik> korisnici = new List<Korisnik>();
        internal List<Korisnik> DajKorisnike()
        {
            
            return korisnici;
        }

        private List<Korisnik> ulogovaniKorisnici = new List<Korisnik>();
        internal void Uloguj(Korisnik korisnik)
        {
            ulogovaniKorisnici.Add(korisnik);
        }

        internal List<Korisnik> DajUlogovane()
        {
            return ulogovaniKorisnici;
        }

        private List<Poruka> poruke = new List<Poruka>();

        internal void DodajPoruku(Poruka poruka)
        {
            if(poruka.Tekst != null)
            {
                poruke.Add(poruka);
            }
        }

        internal List<Poruka> VratiPoruke()
        {
            return poruke;
        }
    }
}

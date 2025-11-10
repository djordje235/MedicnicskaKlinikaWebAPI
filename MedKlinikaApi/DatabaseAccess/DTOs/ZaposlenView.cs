using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using DatabaseAccess.Entiteti;

namespace DatabaseAccess.DTOs
{
    public class ZaposlenView
    {
        public long JMBG { get; set; }
        public DateTime DatumZaposlenja { get; set; }
        public String Pozicija { get; set; }

        public DateTime DatumRodjenja { get; set; }

        public String Ime { get; set; }

        public String Prezime { get; set; }

        public String Adresa { get; set; }

        public int Smena { get; set; }
        [JsonIgnore]
        public LokacijaView? AdresaLokacije { get; set; }

        [JsonIgnore]
        public IList<EmailZaposlenogView>? Emails { get; set; }
        [JsonIgnore]
        public IList<BrTelefonaZaposlenogView>? Telefons {  get; set; }
        [JsonIgnore]
        public IList<OdeljenjeView>? Odeljenja { get; set; }
        public ZaposlenView()
        {
            Emails = new List<EmailZaposlenogView>();
            Telefons = new List<BrTelefonaZaposlenogView>();
            Odeljenja = new List<OdeljenjeView>();
        }
        internal ZaposlenView(Zaposlen? z)
        {
            if(z!=null)
            {
                JMBG = z.JMBG;
                DatumZaposlenja = z.DatumZaposlenja;
                Pozicija = z.Pozicija;
                DatumRodjenja = z.DatumRodjenja;
                Ime = z.Ime;
                Prezime = z.Prezime;
                Adresa = z.Adresa;
                Smena = z.Smena;
                AdresaLokacije = new LokacijaView(z.AdresaLokacije);
            }

        }
    }
}

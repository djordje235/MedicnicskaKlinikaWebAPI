using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using DatabaseAccess.Entiteti;

namespace DatabaseAccess.DTOs
{
    public class PacijentView
    {
        public String? Adresa { get; set; }
        [JsonIgnore]
        public int IdKartona { get; set; }

        public String Ime { get; set; }

        public String Prezime { get; set; }


        public DateTime DatumRodjenja { get; set; }

        public String Pol { get; set; }
        [JsonIgnore]
        public LekarView? Lekar { get; set; }
        [JsonIgnore]
        public IList<RacunView>? Racuni { get; set; }
        [JsonIgnore]
        public IList<PregledView>? Pregledi { get; set; }
        [JsonIgnore]
        public IList<TerminView>? Termini { get; set; }
        [JsonIgnore]
        public IList<BrTelefonaPacijentaView>? Telefons { get; set; }
        [JsonIgnore]
        public IList<EmailPacijentaView>? Emails { get; set; }

        public PacijentView() {
            Racuni = new List<RacunView>();
            Pregledi = new List<PregledView>();
            Termini = new List<TerminView>();
            Telefons = new List<BrTelefonaPacijentaView>();
            Emails = new List<EmailPacijentaView>();
        }

        internal PacijentView(Pacijent? p)
        {
            if(p!=null)
            {
                Adresa = p.Adresa;
                IdKartona = p.IdKartona;
                Ime = p.Ime;
                Prezime = p.Prezime;
                DatumRodjenja = p.DatumRodjenja;
                Pol = p.Pol;
                Lekar = new LekarView(p.Lekar);
            }
        }
    }
}

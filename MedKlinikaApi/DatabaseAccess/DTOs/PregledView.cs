using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using DatabaseAccess.Entiteti;

namespace DatabaseAccess.DTOs
{
    public class PregledView
    {
        public int IdPregleda { get; set; }
        public DateTime Datum { get; set; }

        public DateTime Vreme { get; set; }

        public String? OpisTegoba { get; set; }

        public String? Dijagnoza { get; set; }

        public String? Terapija { get; set; }

        public String? PreporukaZaLecenje { get; set; }

        public String? VrstaPregleda { get; set; }
        [JsonIgnore]
        public PregledView? DodatniPregled {  get; set; }

        [JsonIgnore]
        public PacijentView? Pacijent { get; set; }
        [JsonIgnore]
        public LekarView? Lekar { get; set; }
        [JsonIgnore]
        public OdeljenjeView? Odeljenje { get; set; }
        [JsonIgnore]
        public TerminView? Termin { get; set; }
        [JsonIgnore]
        public IList<LaboratorijskaAnalizaView> LaboratorijskaAnaliza { get; set; }

        public PregledView() 
        {
            LaboratorijskaAnaliza = new List<LaboratorijskaAnalizaView>();
        }

        internal PregledView(Pregled? p)
        {
            if(p!=null)
            {
                IdPregleda = p.IdPregleda;
                Datum = p.Datum;
                Vreme = p.Vreme;
                OpisTegoba = p.OpisTegoba;
                Dijagnoza = p.Dijagnoza;
                Terapija = p.Terapija;
                PreporukaZaLecenje = p.PreporukaZaLecenje;
                VrstaPregleda = p.VrstaPregleda;
                Pacijent = new PacijentView(p.Pacijent);
                Lekar = new LekarView(p.Lekar);
                Odeljenje = new OdeljenjeView(p.Odeljenje);
                Termin = new TerminView(p.Termin);
                DodatniPregled = p.DodatniPregled != null ? new PregledView { IdPregleda = p.DodatniPregled.IdPregleda } : null;
            }
        }

    }
}

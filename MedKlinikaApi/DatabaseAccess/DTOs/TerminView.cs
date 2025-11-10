using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using DatabaseAccess.Entiteti;

namespace DatabaseAccess.DTOs
{
    public class TerminView
    {
        public int IdTermina { get; set; }
        public DateTime Datum { get; set; }

        public DateTime Vreme { get; set; }
        [JsonIgnore]
        public PacijentView? Pacijent { get; set; }
        [JsonIgnore]
        public LekarView? Lekar { get; set; }
        [JsonIgnore]
        public OdeljenjeView? Odeljenje { get; set; }
        [JsonIgnore]
        public PregledView? Pregled { get; set; }

        public TerminView() { }

        internal TerminView(Termin? t)
        {
            if(t!=null)
            {
                IdTermina = t.IdTermina;
                Datum = t.Datum;
                Vreme = t.Vreme;
                Pacijent = new PacijentView(t.Pacijent);
                Lekar = new LekarView(t.Lekar);
                Odeljenje = new OdeljenjeView(t.Odeljenje);
                Pregled = new PregledView(t.Pregled);
            }
        }
    }
}

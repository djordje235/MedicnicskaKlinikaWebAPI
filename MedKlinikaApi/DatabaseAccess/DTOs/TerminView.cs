using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatabaseAccess.Entiteti;

namespace DatabaseAccess.DTOs
{
    public class TerminView
    {
        public int? IdTermina { get; set; }
        public DateTime? Datum { get; set; }

        public DateTime? Vreme { get; set; }

        public PacijentView? Pacijent { get; set; }

        public LekarView? Lekar { get; set; }

        public OdeljenjeView? Odeljenje { get; set; }

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

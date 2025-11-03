using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatabaseAccess.Entiteti;

namespace DatabaseAccess.DTOs
{
    public class RacunView
    {
        public int? Id { get; set; }
        public int? Popust { get; set; }

        public String? VrstaUsluge { get; set; }

        public DateTime? Datum { get; set; }

        public double? Cena { get; set; }

        public LekarView? Lekar { get; set; }

        public PacijentView? Pacijent { get; set; }

        public PlacanjeView? Placanje { get; set; }

        public RacunView() { }

        internal RacunView(Racun? r)
        {
            if(r!=null)
            {
                Id = r.Id;
                Popust = r.Popust;
                VrstaUsluge = r.VrstaUsluge;
                Datum = r.Datum;
                Cena = r.Cena;
                Pacijent = new PacijentView(r.Pacijent);
                Lekar = new LekarView(r.Lekar);
                Placanje = new PlacanjeView(r.Placanje);
            }
        }
    }
}

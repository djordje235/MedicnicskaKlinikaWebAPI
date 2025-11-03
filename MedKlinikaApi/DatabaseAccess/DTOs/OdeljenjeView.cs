using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatabaseAccess.Entiteti;

namespace DatabaseAccess.DTOs
{
    public class OdeljenjeView
    {
        public String? Naziv { get; set; }


        public int? BrProstorije { get; set; }

        public String? RadnoVreme { get; set; }

        public LekarView? GlavniLekar { get; set; }

        public IList<LokacijaView>? Lokacije { get; set; }

        public IList<ZaposlenView>? Zaposleni { get; set; }

        public IList<PregledView>? Pregledi { get; set; }

        public IList<TerminView>? Termini { get; set; }

        public OdeljenjeView() {
            Lokacije = new List<LokacijaView>();
            Zaposleni = new List<ZaposlenView>();
            Pregledi = new List<PregledView>();
            Termini = new List<TerminView>();
        }

        internal OdeljenjeView(Odeljenje? o)
        {
            if(o!=null)
            {
                Naziv = o.Naziv;
                BrProstorije = o.BrProstorije;
                RadnoVreme = o.RadnoVreme;
                GlavniLekar = new LekarView(o.GlavniLekar);
            }
        }


    }
}

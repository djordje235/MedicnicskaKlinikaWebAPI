using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatabaseAccess.Entiteti;

namespace DatabaseAccess.DTOs
{
    public class LekarView : ZaposlenView
    {
        public String? Specijalizacija { get; set; }
        public int? BrLicence { get; set; }
        public Odeljenje? Odeljenje { get; set; }
        public IList<RacunView>? Racuni { get; set; }

        public IList<PacijentView>? Pacijenti { get; set; }

        public IList<TerminView>? Termini { get; set; }

        public IList<PregledView>? Pregledi { get; set; }

        public LekarView() 
        {
            Racuni = new List<RacunView>();
            Pacijenti = new List<PacijentView>();
            Termini = new List<TerminView>();
            Pregledi = new List<PregledView>();
        }

        internal LekarView(Lekar? l) : base(l)
        {
            if(l!=null)
            {
                Specijalizacija = l.Specijalizacija;
                BrLicence = l.BrLicence;
                Odeljenje = l.Odeljenje;
            }
        }


    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseAccess.Entiteti
{
    public class Odeljenje
    {

        public virtual String Naziv { get; set; }


        public virtual int BrProstorije { get; set; }

        public virtual String RadnoVreme { get; set; }

        public virtual Lekar GlavniLekar { get; set; }


        public virtual IList<Lokacija> Lokacije { get; set; }

        public virtual IList<Zaposlen> Zaposleni { get; set; }

        public virtual IList<Pregled> Pregledi { get; set; }

        public virtual IList<Termin> Termini { get; set; }

        public Odeljenje()
        {
            Lokacije = new List<Lokacija>();
            Zaposleni = new List<Zaposlen>();
            Pregledi = new List<Pregled>();
            Termini = new List<Termin>();
        }
    }
}

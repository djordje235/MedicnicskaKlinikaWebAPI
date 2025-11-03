using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseAccess.Entiteti
{
    public class Lekar : Zaposlen
    {
        public virtual String Specijalizacija { get; set; }
        public virtual int BrLicence { get; set; }

        // Veze lekara sa drugim entitetima
        public virtual Odeljenje Odeljenje { get; set; }
        public virtual IList<Racun> Racuni { get; set; }

        public virtual IList<Pacijent> Pacijenti { get; set; }


        public virtual IList<Termin> Termini { get; set; }

        public virtual IList<Pregled> Pregledi { get; set; }

        public Lekar()
        {
            Racuni = new List<Racun>();
            Pacijenti = new List<Pacijent>();
            Termini = new List<Termin>();
            Pregledi = new List<Pregled>();
        }
    }
}

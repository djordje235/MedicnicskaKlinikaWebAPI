using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseAccess.Entiteti
{
    public class Pregled
    {
        public virtual int IdPregleda { get; set; }
        public virtual DateTime Datum { get; set; }

        public virtual DateTime Vreme { get; set; }

        public virtual String OpisTegoba { get; set; }

        public virtual String Dijagnoza { get; set; }

        public virtual String Terapija { get; set; }

        public virtual String PreporukaZaLecenje { get; set; }

        public virtual String VrstaPregleda { get; set; }


        public virtual Pacijent Pacijent { get; set; }

        public virtual Lekar Lekar { get; set; }

        public virtual Odeljenje Odeljenje { get; set; }

        public virtual Termin Termin { get; set; }

        public virtual Pregled DodatniPregled { get; set; }

        public virtual IList<LaboratorijskaAnaliza> LaboratorijskaAnaliza { get; set; }


        public Pregled()
        {
            LaboratorijskaAnaliza = new List<LaboratorijskaAnaliza>();
        }
    }
}

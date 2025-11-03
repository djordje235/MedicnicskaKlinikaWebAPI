using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseAccess.Entiteti
{
    public class Termin
    {
        public virtual int IdTermina { get; set; }
        public virtual DateTime Datum { get; set; }

        public virtual DateTime Vreme { get; set; }

        public virtual Pacijent Pacijent { get; set; }

        public virtual Lekar Lekar { get; set; }

        public virtual Odeljenje Odeljenje { get; set; }

        public virtual Pregled Pregled { get; set; }
    }
}

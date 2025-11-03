using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseAccess.Entiteti
{
    public class Racun
    {
        public virtual int Id { get; set; }
        public virtual int Popust { get; set; }

        public virtual String VrstaUsluge { get; set; }

        public virtual DateTime Datum { get; set; }

        public virtual double Cena { get; set; }

        public virtual Lekar Lekar { get; set; }

        public virtual Pacijent Pacijent { get; set; }

        public virtual Placanje Placanje { get; set; }
    }
}

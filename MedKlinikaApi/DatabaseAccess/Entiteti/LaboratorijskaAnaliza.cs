using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseAccess.Entiteti
{
    public class LaboratorijskaAnaliza
    {
        public virtual int IdAnalize { get; set; }
        public virtual Pacijent Pacijent { get; set; }

        public virtual Pregled Pregled { get; set; }

        public virtual String VrstaAnalize { get; set; }

        public virtual DateTime DatumUzorkovanja { get; set; }

        public virtual String Rezultat { get; set; }

        public virtual String ReferentnaVrednost { get; set; }

        public virtual DateTime Vreme { get; set; }

        public virtual String Komentar { get; set; }

        // Laborant koji je uradio analizu
        public virtual Laborant Laborant { get; set; }
    }
}

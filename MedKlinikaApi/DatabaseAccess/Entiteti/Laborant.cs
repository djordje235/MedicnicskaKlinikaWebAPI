using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseAccess.Entiteti
{
    public class Laborant : Zaposlen
    {
        public virtual String OblastRada { get; set; }

        public virtual String Sertifikat { get; set; }

        // Lista laboratorijskih analiza koje je uradio ovaj laborant
        public virtual IList<LaboratorijskaAnaliza> LaboratorijskeAnalize { get; set; }

        public Laborant()
        {
            LaboratorijskeAnalize = new List<LaboratorijskaAnaliza>();
        }
    }
}

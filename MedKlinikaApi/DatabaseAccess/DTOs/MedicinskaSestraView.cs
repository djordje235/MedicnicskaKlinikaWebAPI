using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatabaseAccess.Entiteti;

namespace DatabaseAccess.DTOs
{
    public class MedicinskaSestraView : ZaposlenView
    {
        public String? OblastRada { get; set; }

        public String? Sertifikat { get; set; }

        public MedicinskaSestraView() { }

        internal MedicinskaSestraView(MedicinskaSestra? m) : base(m)
        {
            if(m!=null)
            {
                OblastRada = m.OblastRada;
                Sertifikat = m.Sertifikat;
            }
        }
    }
}

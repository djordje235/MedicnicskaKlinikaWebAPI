using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatabaseAccess.Entiteti;

namespace DatabaseAccess.DTOs
{
    public class AdministrativnoOsobljeView : ZaposlenView
    {
        public AdministrativnoOsobljeView() : base()
        {

        }

        internal AdministrativnoOsobljeView(AdministrativnoOsoblje? a) : base(a)
        {

        }
    }
}

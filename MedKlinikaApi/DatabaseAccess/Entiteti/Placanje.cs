using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseAccess.Entiteti
{
    public class Placanje
    {
        public virtual int IdPlacanja { get; set; }

        public virtual int ProcenatPacijenta { get; set; }

        public virtual String NacinPlacanja { get; set; }

        public virtual Boolean PlatioPacijent { get; set; }

        public virtual Racun Racun { get; set; }

        public virtual PrivatnoOsiguranje PrivatnoOsiguranje { get; set; }

        public virtual RFZO RFZO { get; set; }


    }
}

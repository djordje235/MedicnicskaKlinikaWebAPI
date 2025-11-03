using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseAccess.Entiteti
{
    public class BrTelefonaPacijenta
    {
        public virtual int Id { get; set; }
        public virtual Pacijent Pacijent { get; set; }
        public virtual String BrojTelefona { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseAccess.Entiteti
{
    public class EmailZaposlenog
    {
        public virtual int Id { get; set; }
        public virtual Zaposlen Zaposlen { get; set; }
        public virtual String Email { get; set; }

    }
}

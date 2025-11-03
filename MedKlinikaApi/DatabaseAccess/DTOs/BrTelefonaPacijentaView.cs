using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatabaseAccess.Entiteti;

namespace DatabaseAccess.DTOs
{
    public class BrTelefonaPacijentaView
    {
        public int? Id { get; set; }
        public PacijentView? Pacijent { get; set; }
        public String? BrojTelefona { get; set; }

        public BrTelefonaPacijentaView() { }

        internal BrTelefonaPacijentaView(BrTelefonaPacijenta? b)
        {
           if(b!=null)
            {
                Id = b.Id;
                Pacijent = new PacijentView(b.Pacijent);
                BrojTelefona = b.BrojTelefona;
            }
        }
    }
}

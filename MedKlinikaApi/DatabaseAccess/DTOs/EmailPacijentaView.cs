using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatabaseAccess.Entiteti;

namespace DatabaseAccess.DTOs
{
    public class EmailPacijentaView
    {
        public int? Id { get; set; }
        public PacijentView? Pacijent { get; set; }

        public String? Email { get; set; }

        public EmailPacijentaView()
        {

        }

        internal EmailPacijentaView(EmailPacijenta? e)
        {
            if(e!=null)
            {
                Id = e.Id;
                Email = e.Email;
                Pacijent = new PacijentView(e.Pacijent);
            }
        }
    }
}

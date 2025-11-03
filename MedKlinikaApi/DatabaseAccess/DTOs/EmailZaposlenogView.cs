using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatabaseAccess.Entiteti;

namespace DatabaseAccess.DTOs
{
    public class EmailZaposlenogView
    {
        public int? Id { get; set; }
        public ZaposlenView? Zaposlen { get; set; }

        public String? Email { get; set; }

        public EmailZaposlenogView()
        {

        }

        internal EmailZaposlenogView(EmailZaposlenog? e)
        {
            if (e != null)
            {
                Id = e.Id;
                Email = e.Email;
                Zaposlen = new ZaposlenView(e.Zaposlen);
            }
        }
    }
}

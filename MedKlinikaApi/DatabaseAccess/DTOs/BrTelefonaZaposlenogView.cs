using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatabaseAccess.Entiteti;

namespace DatabaseAccess.DTOs
{
    public class BrTelefonaZaposlenogView
    {
        public int? Id { get; set; }
        public ZaposlenView? Zaposlen { get; set; }

        public String? BrojTelefona { get; set; }

        public BrTelefonaZaposlenogView() { }

        internal BrTelefonaZaposlenogView(BrTelefonaZaposlenog? b)
        {
            if (b != null)
            {
                Id = b.Id;
                Zaposlen = new ZaposlenView(b.Zaposlen);
                BrojTelefona = b.BrojTelefona;
            }
        }
    }
}

using DatabaseAccess.Entiteti;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DatabaseAccess.DTOs
{
    public class BrTelefonaZaposlenogView
    {
        public int? Id { get; set; }

        [JsonIgnore]
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

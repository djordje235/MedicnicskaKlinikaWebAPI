using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using DatabaseAccess.Entiteti;

namespace DatabaseAccess.DTOs
{
    public class LokacijaView
    {
        public String? Adresa { get; set; }

        public String? RadnoVreme { get; set; }
        [JsonIgnore]
        public IList<ZaposlenView>? Zaposleni { get; set; }
        [JsonIgnore]
        public IList<OdeljenjeView>? Odeljenja { get; set; }

        public LokacijaView() 
        {
            Zaposleni = new List<ZaposlenView>();
            Odeljenja = new List<OdeljenjeView>();
        }

        internal LokacijaView(Lokacija? l)
        {
            if(l!=null)
            {
                Adresa = l.Adresa;
                RadnoVreme = l.RadnoVreme;
            }
        }
    }
}

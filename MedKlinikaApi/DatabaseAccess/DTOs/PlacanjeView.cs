using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using DatabaseAccess.Entiteti;

namespace DatabaseAccess.DTOs
{
    public class PlacanjeView
    {
        public int IdPlacanja { get; set; }

        public int ProcenatPacijenta { get; set; }

        public String? NacinPlacanja { get; set; }

        public Boolean PlatioPacijent { get; set; }
        [JsonIgnore]
        public RacunView? Racun { get; set; }
        [JsonIgnore]
        public PrivatnoOsiguranjeView? PrivatnoOsiguranje { get; set; }
        [JsonIgnore]
        public RFZOView? RFZO { get; set; }

        public PlacanjeView() { }

        internal PlacanjeView(Placanje p)
        {
            if(p!=null)
            {
                IdPlacanja = p.IdPlacanja;
                ProcenatPacijenta = p.ProcenatPacijenta;
                NacinPlacanja = p.NacinPlacanja;
                PlatioPacijent = p.PlatioPacijent;
                Racun = new RacunView(p.Racun);
                PrivatnoOsiguranje = new PrivatnoOsiguranjeView(p.PrivatnoOsiguranje);
            }
        }
    }
}

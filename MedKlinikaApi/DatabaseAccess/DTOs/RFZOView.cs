using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using DatabaseAccess.Entiteti;

namespace DatabaseAccess.DTOs
{
    public class RFZOView
    {

        public int IdOsiguranja { get; set; }
        [JsonIgnore]
        public PacijentView? Pacijent { get; set; }
        [JsonIgnore]
        public IList<PlacanjeView>? Placanja { get; set; }

        public RFZOView() 
        {
            Placanja = new List<PlacanjeView>();
        }

        internal RFZOView(RFZO? r)
        {
            if(r!=null)
            {
                IdOsiguranja = r.IdOsiguranja;
                Pacijent = new PacijentView(r.Pacijent);
            }
        }


    }
}

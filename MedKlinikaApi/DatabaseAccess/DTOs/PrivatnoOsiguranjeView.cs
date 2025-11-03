using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatabaseAccess.Entiteti;

namespace DatabaseAccess.DTOs
{
    public class PrivatnoOsiguranjeView
    {
        public int? IdOsiguranja { get; set; }
        public int? BrPolise { get; set; }

        public String? OsiguravajucaKuca { get; set; }

        public PacijentView? Pacijent { get; set; }

        public IList<PlacanjeView>? Placanja { get; set; }

        public PrivatnoOsiguranjeView()
        {
            Placanja = new List<PlacanjeView>();
        }

        internal PrivatnoOsiguranjeView(PrivatnoOsiguranje? p)
        {
            if(p!=null)
            {
                IdOsiguranja = p.IdOsiguranja;
                BrPolise = p.BrPolise;
                OsiguravajucaKuca = p.OsiguravajucaKuca;
                Pacijent = new PacijentView(p.Pacijent);
            }
        }
    }
}

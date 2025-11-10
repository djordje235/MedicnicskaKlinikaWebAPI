using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using DatabaseAccess.Entiteti;

namespace DatabaseAccess.DTOs
{
    public class LaboratorijskaAnalizaView
    {
        public int IdAnalize { get; set; }
        [JsonIgnore]
        public PacijentView? Pacijent { get; set; }
        [JsonIgnore]
        public  PregledView? Pregled { get; set; }

        public  String VrstaAnalize { get; set; }

        public  DateTime DatumUzorkovanja { get; set; }

        public  String Rezultat { get; set; }

        public  String ReferentnaVrednost { get; set; }

        public  DateTime Vreme { get; set; }

        public  String Komentar { get; set; }
        [JsonIgnore]
        public LaborantView? Laborant { get; set; }

        public LaboratorijskaAnalizaView()
        {

        }

        internal LaboratorijskaAnalizaView(LaboratorijskaAnaliza? l)
        {
            if(l!=null)
            {
                IdAnalize = l.IdAnalize;
                Pacijent = new PacijentView(l.Pacijent);
                Pregled = new PregledView(l.Pregled);
                VrstaAnalize = l.VrstaAnalize;
                DatumUzorkovanja = l.DatumUzorkovanja;
                Rezultat = l.Rezultat;
                ReferentnaVrednost = l.ReferentnaVrednost;
                Vreme = l.Vreme;
                Komentar = l.Komentar;
                Laborant = new LaborantView(l.Laborant);
            }
        }
    }
}

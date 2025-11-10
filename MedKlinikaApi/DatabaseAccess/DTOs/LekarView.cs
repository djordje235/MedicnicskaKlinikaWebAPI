using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using DatabaseAccess.Entiteti;

namespace DatabaseAccess.DTOs
{
    public class LekarView : ZaposlenView
    {
        public String? Specijalizacija { get; set; }
        public int BrLicence { get; set; }
        [JsonIgnore]
        public Odeljenje? Odeljenje { get; set; }
        [JsonIgnore]
        public IList<RacunView>? Racuni { get; set; }
        [JsonIgnore]
        public IList<PacijentView>? Pacijenti { get; set; }
        [JsonIgnore]
        public IList<TerminView>? Termini { get; set; }
        [JsonIgnore]
        public IList<PregledView>? Pregledi { get; set; }

        public LekarView() 
        {
            Racuni = new List<RacunView>();
            Pacijenti = new List<PacijentView>();
            Termini = new List<TerminView>();
            Pregledi = new List<PregledView>();
        }

        internal LekarView(Lekar? l) : base(l)
        {
            if(l!=null)
            {
                Specijalizacija = l.Specijalizacija;
                BrLicence = l.BrLicence;
                Odeljenje = l.Odeljenje;
            }
        }


    }
}

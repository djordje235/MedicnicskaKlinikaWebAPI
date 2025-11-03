using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseAccess.Entiteti
{
    public class Pacijent
    {
        public virtual String Adresa { get; set; }

        public virtual int IdKartona { get; set; }

        public virtual String Ime { get; set; }

        public virtual String Prezime { get; set; }


        public virtual DateTime DatumRodjenja { get; set; }

        public virtual String Pol { get; set; }

        public virtual Lekar Lekar { get; set; }

        public virtual IList<Racun> Racuni { get; set; }

        public virtual RFZO RFZO { get; set; }

        public virtual PrivatnoOsiguranje PrivatnoOsiguranje { get; set; }

        public virtual IList<Pregled> Pregledi { get; set; }

        public virtual IList<Termin> Termini { get; set; }

        public virtual IList<BrTelefonaPacijenta> Telefons { get; set; }

        public virtual IList<EmailPacijenta> Emails { get; set; }
        public Pacijent()
        {
            Racuni = new List<Racun>();
            Pregledi = new List<Pregled>();
            Termini = new List<Termin>();
            Telefons = new List<BrTelefonaPacijenta>();
            Emails = new List<EmailPacijenta>();
        }

    }
}

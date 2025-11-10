using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DatabaseAccess.Entiteti
{
    public abstract class Zaposlen
    {
        public virtual long JMBG { get; set; }
        public virtual DateTime DatumZaposlenja { get; set; }
        public virtual String Pozicija { get; set; }

        public virtual DateTime DatumRodjenja { get; set; }

        public virtual String Ime { get; set; }

        public virtual String Prezime { get; set; }

        public virtual String Adresa { get; set; }

        public virtual int Smena { get; set; }

        public virtual Lokacija AdresaLokacije { get; set; }

        public virtual IList<Odeljenje> Odeljenja { get; set; }

        public virtual IList<BrTelefonaZaposlenog> Telefons { get; set; }

        public virtual IList<EmailZaposlenog> Emails { get; set; }

        public Zaposlen()
        {
            Odeljenja = new List<Odeljenje>();
            Telefons = new List<BrTelefonaZaposlenog>();
            Emails = new List<EmailZaposlenog>();
        }

    }
}

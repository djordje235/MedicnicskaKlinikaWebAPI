using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseAccess.Entiteti
{
    public class Lokacija
    {
        public virtual String Adresa { get; set; }

        public virtual String RadnoVreme { get; set; }

        // 1 lokacija može imati više zaposlenih
        public virtual IList<Zaposlen> Zaposleni { get; set; }

        public virtual IList<Odeljenje> Odeljenja { get; set; }

        public Lokacija()
        {
            Zaposleni = new List<Zaposlen>();
            Odeljenja = new List<Odeljenje>();
        }

    }
}

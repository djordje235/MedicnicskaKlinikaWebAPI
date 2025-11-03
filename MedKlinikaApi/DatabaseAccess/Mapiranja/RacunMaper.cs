using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatabaseAccess.Entiteti;
using FluentNHibernate.Mapping;

namespace DatabaseAccess.Mapiranja
{
    internal class RacunMaper : ClassMap<Racun>
    {
        public RacunMaper()
        {
            Table("RACUN");

            Id(x => x.Id).Column("ID").GeneratedBy.SequenceIdentity("S19376.RACUN_ID_SEQ");

            Map(x => x.Popust).Column("POPUST");
            Map(x => x.VrstaUsluge).Column("VRSTA_USLUGE");
            Map(x => x.Datum).Column("DATUM");
            Map(x => x.Cena).Column("CENA");
            References(x => x.Lekar).Column("JMBG_LEKARA").LazyLoad();
            References(x => x.Pacijent).Column("ID_KARTONA").LazyLoad();

            HasOne(x => x.Placanje).PropertyRef(x => x.Racun);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatabaseAccess.Entiteti;
using FluentNHibernate.Mapping;

namespace DatabaseAccess.Mapiranja
{
    internal class PlacanjeMaper : ClassMap<Placanje>
    {
        public PlacanjeMaper()
        {
            Table("PLACANJE");

            Id(x => x.IdPlacanja).Column("ID_PLACANJA").GeneratedBy.SequenceIdentity("S19376.PLACANJE_ID_SEQ");

            Map(x => x.ProcenatPacijenta).Column("PROCENAT_PACIJENTA");
            Map(x => x.NacinPlacanja).Column("NACIN_PLACANJA");
            Map(x => x.PlatioPacijent).Column("PLATIO_PACIJENT");

            References(x => x.RFZO).Column("ID_OSIGURANJA").LazyLoad();
            References(x => x.Racun).Column("ID_RACUNA").Unique();
            References(x => x.PrivatnoOsiguranje).Columns("ID_PRIV").LazyLoad();


        }
    }
}

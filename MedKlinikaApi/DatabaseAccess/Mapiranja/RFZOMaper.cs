using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatabaseAccess.Entiteti;
using FluentNHibernate.Mapping;

namespace DatabaseAccess.Mapiranja
{
    internal class RFZOMaper : ClassMap<RFZO>
    {
        public RFZOMaper()
        {
            Table("RFZO");

            Id(x => x.IdOsiguranja).Column("ID_OSIGURANJA").GeneratedBy.Assigned();

            HasMany(x => x.Placanja).KeyColumn("ID_OSIGURANJA").LazyLoad().Cascade.All().Inverse();
            References(x => x.Pacijent, "ID_KARTONA").Unique();

        }

    }
}

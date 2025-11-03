using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatabaseAccess.Entiteti;
using FluentNHibernate.Mapping;

namespace DatabaseAccess.Mapiranja
{
    public class LokacijaMaper : ClassMap<Lokacija>
    {
        public LokacijaMaper()
        {
            Table("LOKACIJA");

            Id(x => x.Adresa).Column("ADRESA").GeneratedBy.Assigned();

            Map(x => x.RadnoVreme).Column("RADNO_VREME");

            HasMany(x => x.Zaposleni).KeyColumn("ADRESA_LOKACIJE").LazyLoad().Cascade.All().Inverse();

            HasManyToMany(x => x.Odeljenja).Table("NALAZI_SE").ParentKeyColumn("ADRESA").ChildKeyColumn("NAZIV_ODELJENJA").LazyLoad().Cascade.All().Inverse();

        }
    }
}

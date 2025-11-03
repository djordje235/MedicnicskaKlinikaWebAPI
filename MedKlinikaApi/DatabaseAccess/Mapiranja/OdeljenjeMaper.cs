using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatabaseAccess.Entiteti;
using FluentNHibernate.Mapping;

namespace DatabaseAccess.Mapiranja
{
    internal class OdeljenjeMaper : ClassMap<Odeljenje>
    {
        public OdeljenjeMaper()
        {
            Table("ODELJENJE");

            Id(x => x.Naziv).Column("NAZIV").GeneratedBy.Assigned();

            Map(x => x.BrProstorije).Column("BR_PROSTORIJA");

            Map(x => x.RadnoVreme).Column("RADNO_VREME");

            References(x => x.GlavniLekar).Column("JMBG_LEKARA").Unique().LazyLoad();

            HasManyToMany(x => x.Lokacije).Table("NALAZI_SE").ParentKeyColumn("NAZIV_ODELJENJA").ChildKeyColumn("ADRESA").LazyLoad();

            HasManyToMany(x => x.Zaposleni).Table("RADI_U").ParentKeyColumn("NAZIV_ODELJENJA").ChildKeyColumn("JMBG_ZAPOSLENOG").LazyLoad().Cascade.All().Inverse();

            HasMany(x => x.Pregledi).KeyColumn("NAZIV_ODELJENJA").LazyLoad().Cascade.All().Inverse();

            HasMany(x => x.Termini).KeyColumn("NAZIV_ODELJENJA").LazyLoad().Cascade.All().Inverse();
        }
    }
}

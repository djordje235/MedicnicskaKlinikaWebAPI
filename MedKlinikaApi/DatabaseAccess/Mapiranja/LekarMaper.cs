using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatabaseAccess.Entiteti;
using FluentNHibernate.Mapping;

namespace DatabaseAccess.Mapiranja
{
    internal class LekarMaper : SubclassMap<Lekar>
    {
        public LekarMaper()
        {
            Table("LEKAR");

            KeyColumn("JMBG");

            Map(x => x.Specijalizacija).Column("SPECIJALIZACIJA");
            Map(x => x.BrLicence).Column("BR_LICENCE");

            HasOne(x => x.Odeljenje).PropertyRef(x => x.GlavniLekar);

            HasMany(x => x.Racuni).KeyColumn("JMBG_LEKARA").LazyLoad().Cascade.All().Inverse();

            HasMany(x => x.Pacijenti).KeyColumn("JMBG_LEKARA").LazyLoad().Cascade.All().Inverse();

            HasMany(x => x.Termini).KeyColumn("JMBG_LEKARA").LazyLoad().Cascade.All().Inverse();

            HasMany(x => x.Pregledi).KeyColumn("JMBG_LEKARA").LazyLoad().Cascade.All().Inverse();
        }
    }
}

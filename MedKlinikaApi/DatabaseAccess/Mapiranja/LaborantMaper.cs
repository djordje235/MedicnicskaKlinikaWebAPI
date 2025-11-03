using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatabaseAccess.Entiteti;
using FluentNHibernate.Mapping;

namespace DatabaseAccess.Mapiranja
{
    internal class LaborantMaper : SubclassMap<Laborant>
    {
        public LaborantMaper()
        {
            Table("LABORANT");

            KeyColumn("JMBG");

            Map(x => x.OblastRada).Column("OBLAST_RADA");
            Map(x => x.Sertifikat).Column("SERTIFIKAT");

            HasMany(x => x.LaboratorijskeAnalize).KeyColumn("JMBG_LABORANTA").LazyLoad().Cascade.All().Inverse();
        }
    }
}

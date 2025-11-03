using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatabaseAccess.Entiteti;
using FluentNHibernate.Mapping;

namespace DatabaseAccess.Mapiranja
{
    internal class TerminMaper : ClassMap<Termin>
    {
        public TerminMaper()
        {
            Table("TERMIN");

            Id(x => x.IdTermina).Column("ID_TERMINA").GeneratedBy.Sequence("TERMIN_ID_SEQ");

            Map(x => x.Datum).Column("DATUM");
            Map(x => x.Vreme).Column("VREME");

            References(x => x.Lekar).Column("JMBG_LEKARA").LazyLoad();
            References(x => x.Odeljenje).Column("NAZIV_ODELJENJA").LazyLoad();
            References(x => x.Pacijent).Column("ID_KARTONA").LazyLoad();
            HasOne(x => x.Pregled).PropertyRef(x => x.Termin);
        }
    }
}

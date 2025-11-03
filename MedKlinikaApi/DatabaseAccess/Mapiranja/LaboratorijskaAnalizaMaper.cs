using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatabaseAccess.Entiteti;
using FluentNHibernate.Mapping;

namespace DatabaseAccess.Mapiranja
{
    internal class LaboratorijskaAnalizaMaper : ClassMap<LaboratorijskaAnaliza>
    {
        public LaboratorijskaAnalizaMaper()
        {
            Table("LABORATORIJSKA_ANALIZA");

            Id(x => x.IdAnalize).Column("ID_ANALIZE").GeneratedBy.Sequence("LABORATORIJSKA_ANALIZA_ID_SEQ");

            Map(x => x.VrstaAnalize).Column("VRSTA_ANALIZE");
            Map(x => x.DatumUzorkovanja).Column("DATUM_UZORKOVANJA");
            Map(x => x.Rezultat).Column("REZULTAT");
            Map(x => x.ReferentnaVrednost).Column("REFERENTNA_VREDNOST");
            Map(x => x.Vreme).Column("VREME");
            Map(x => x.Komentar).Column("KOMENTAR");

            References(x => x.Pregled).Column("ID_PREGLEDA").LazyLoad();
            References(x => x.Pacijent).Column("ID_KARTONA").LazyLoad();
            References(x => x.Laborant).Column("JMBG_LABORANTA").LazyLoad();
        }
    }
}

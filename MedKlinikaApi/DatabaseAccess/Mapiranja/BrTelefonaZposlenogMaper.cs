using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatabaseAccess.Entiteti;
using FluentNHibernate.Mapping;

namespace DatabaseAccess.Mapiranja
{
    internal class BrTelefonaZaposlenogMaper : ClassMap<BrTelefonaZaposlenog>
    {
        public BrTelefonaZaposlenogMaper()
        {
            Table("BR_TELEFONA_ZAPOSLENOG");

            Id(x => x.Id).Column("ID").GeneratedBy.Sequence("BR_TELEFONA_ZAPOSLENOG_ID_SEQ");

            Map(x => x.BrojTelefona).Column("BR_TELEFONA");

            References(x => x.Zaposlen).Column("JMBG_ZAPOSLENOG").LazyLoad();
        }
    }
}

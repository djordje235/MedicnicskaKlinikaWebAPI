using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatabaseAccess.Entiteti;
using FluentNHibernate.Mapping;

namespace DatabaseAccess.Mapiranja
{
    internal class EmailZaposlenogMaper : ClassMap<EmailZaposlenog>
    {
        public EmailZaposlenogMaper()
        {

            Table("EMAIL_ZAPOSLENOG");

            Id(x => x.Id).Column("ID").GeneratedBy.Sequence("EMAIL_ZAPOSLENOG_ID_SEQ");

            Map(x => x.Email).Column("EMAIL");

            References(x => x.Zaposlen).Column("JMBG_ZAPOSLENOG").LazyLoad();

        }
    }
}

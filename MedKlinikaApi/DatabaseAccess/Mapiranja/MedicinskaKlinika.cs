using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatabaseAccess.Entiteti;
using FluentNHibernate.Mapping;

namespace DatabaseAccess.Mapiranja
{
    internal class MedicinskaSestraMaper : SubclassMap<MedicinskaSestra>
    {
        public MedicinskaSestraMaper()
        {
            Table("MEDICINSKA_SESTRA");

            KeyColumn("JMBG");

            Map(x => x.OblastRada).Column("OBLAST_RADA");
            Map(x => x.Sertifikat).Column("SERTIFIKAT");
        }
    }
}

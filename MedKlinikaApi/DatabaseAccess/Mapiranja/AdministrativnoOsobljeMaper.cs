using FluentNHibernate.Mapping;
using DatabaseAccess.Entiteti;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseAccess.Mapiranja
{
    internal class AdministrativnoOsobljeMaper : SubclassMap<AdministrativnoOsoblje>
    {
        public AdministrativnoOsobljeMaper()
        {
            Table("ADMINISTRATIVNO_OSOBLJE");

            KeyColumn("JMBG");


        }
    }
}

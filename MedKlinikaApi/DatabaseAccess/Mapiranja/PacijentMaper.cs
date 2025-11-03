using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatabaseAccess.Entiteti;
using FluentNHibernate.Mapping;

namespace DatabaseAccess.Mapiranja
{
    internal class PacijentMaper : ClassMap<Pacijent>
    {
        public PacijentMaper()
        {
            Table("PACIJENT");
            Id(x => x.IdKartona).Column("ID_KARTONA").GeneratedBy.Sequence("PACIJENT_ID_SEQ");

            Map(x => x.Adresa).Column("ADRESA");
            Map(x => x.Pol).Column("POL");
            Map(x => x.Ime).Column("IME");
            Map(x => x.Prezime).Column("PREZIME");
            Map(x => x.DatumRodjenja).Column("DATUM_RODJENJA");

            References(x => x.Lekar).Column("JMBG_LEKARA").LazyLoad();
            HasMany(x => x.Racuni).KeyColumn("ID_KARTONA").LazyLoad().Cascade.All().Inverse();
            HasOne(x => x.RFZO).PropertyRef(x => x.Pacijent);
            HasOne(x => x.PrivatnoOsiguranje).PropertyRef(x => x.Pacijent);
            HasMany(x => x.Pregledi).KeyColumn("ID_KARTONA").LazyLoad().Cascade.All().Inverse();
            HasMany(x => x.Termini).KeyColumn("ID_KARTONA").LazyLoad().Cascade.All().Inverse();
            HasMany(x => x.Telefons).KeyColumn("ID_KARTONA").LazyLoad().Cascade.All().Inverse();
            HasMany(x => x.Emails).KeyColumn("ID_KARTONA").LazyLoad().Cascade.All().Inverse();
        }
    }
}

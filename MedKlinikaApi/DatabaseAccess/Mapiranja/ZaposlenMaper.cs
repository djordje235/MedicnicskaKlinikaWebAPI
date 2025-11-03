using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatabaseAccess.Entiteti;
using FluentNHibernate.Mapping;

namespace DatabaseAccess.Mapiranja
{
    public class ZaposlenMaper : ClassMap<Zaposlen>
    {

        public ZaposlenMaper()
        {
            Table("ZAPOSLEN");

            Id(x => x.JMBG).Column("JMBG").GeneratedBy.Assigned();

            Map(x => x.DatumZaposlenja).Column("DATUM_ZAPOSLENJA");

            Map(x => x.Pozicija).Column("POZICIJA");

            Map(x => x.DatumRodjenja).Column("DATUM_RODJENJA");

            Map(x => x.Ime).Column("IME");

            Map(x => x.Prezime).Column("PREZIME");

            Map(x => x.Adresa).Column("ADRESA");

            Map(x => x.Smena).Column("SMENA");

            References(x => x.AdresaLokacije).Column("ADRESA_LOKACIJE").LazyLoad();

            HasManyToMany(x => x.Odeljenja).Table("RADI_U").ParentKeyColumn("JMBG_ZAPOSLENOG").ChildKeyColumn("NAZIV_ODELJENJA").LazyLoad();

            HasMany(x => x.Telefons).KeyColumn("JMBG_ZAPOSLENOG").LazyLoad().Cascade.All().Inverse();

            HasMany(x => x.Emails).KeyColumn("JMBG_ZAPOSLENOG").LazyLoad().Cascade.All().Inverse();

        }

    }
}

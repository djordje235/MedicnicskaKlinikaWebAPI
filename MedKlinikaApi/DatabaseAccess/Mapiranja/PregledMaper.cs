using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatabaseAccess.Entiteti;
using FluentNHibernate.Mapping;

namespace DatabaseAccess.Mapiranja
{
    internal class PregledMaper : ClassMap<Pregled>
    {
        public PregledMaper()
        {
            Table("PREGLED");
            Id(x => x.IdPregleda).Column("ID_PREGLEDA").GeneratedBy.Sequence("PREGLED_ID_SEQ");

            Map(x => x.Datum).Column("DATUM");
            Map(x => x.Vreme).Column("VREME");
            Map(x => x.OpisTegoba).Column("OPIS_TEGOBA");
            Map(x => x.Dijagnoza).Column("DIJAGNOZA");
            Map(x => x.Terapija).Column("TERAPIJA");
            Map(x => x.PreporukaZaLecenje).Column("PREPORUKA_ZA_LECENJE");
            Map(x => x.VrstaPregleda).Column("VRSTA_PREGLEDA");

            References(x => x.Pacijent).Column("ID_KARTONA").LazyLoad();
            References(x => x.Lekar).Column("JMBG_LEKARA").LazyLoad();
            References(x => x.Odeljenje).Column("NAZIV_ODELJENJA").LazyLoad();
            References(x => x.Termin, "ID_TERMINA").Unique();
            HasMany(x => x.LaboratorijskaAnaliza).KeyColumn("ID_PREGLEDA").LazyLoad().Cascade.All().Inverse();
            References(x => x.DodatniPregled).Column("ID_DODATNOG_PREGLEDA").Cascade.All();
        }
    }
}

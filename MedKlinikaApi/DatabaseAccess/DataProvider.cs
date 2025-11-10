using DatabaseAccess.DTOs;
using DatabaseAccess.Entiteti;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NHibernate.Linq;
using NHibernate.Util;

namespace DatabaseAccess
{
    public static class DataProvider
    {

        public static void dodajAdministrativnoOsoblje(AdministrativnoOsobljeView a, List<string> emails, List<string> telefons, List<string> odeljenja, string AdresaLokacije)
        {
            ISession s = DataLayer.GetSession();

            AdministrativnoOsoblje ad = new AdministrativnoOsoblje();


            ad.Adresa = a.Adresa;
            ad.DatumRodjenja = a.DatumRodjenja;
            var loc = s.Load<Lokacija>(AdresaLokacije);
            ad.AdresaLokacije = loc;
            //ad.AdresaLokacije = a.AdresaLokacije;
            ad.Pozicija = a.Pozicija;
            ad.JMBG = a.JMBG;
            ad.DatumZaposlenja = a.DatumZaposlenja;
            ad.Pozicija = a.Pozicija;
            ad.Ime = a.Ime;
            ad.Prezime = a.Prezime;
            ad.Smena = a.Smena;


            foreach (var item in odeljenja)
            {
                var od = s.Load<Odeljenje>(item);
                ad.Odeljenja.Add(od);
            }

            s.SaveOrUpdate(ad);


            foreach (var item in emails)
            {
                EmailZaposlenog em = new EmailZaposlenog();
                em.Zaposlen = ad;
                em.Email = item;
                s.SaveOrUpdate(em);
            }

            foreach (var item in telefons)
            {
                BrTelefonaZaposlenog tel = new BrTelefonaZaposlenog();
                tel.Zaposlen = ad;
                tel.BrojTelefona = item;
                s.SaveOrUpdate(tel);
            }


            s.Flush();
            s.Close();
        }
    

        public static List<AdministrativnoOsobljeView> prikazOsoblja()
        {
            List<AdministrativnoOsobljeView> admini = new List<AdministrativnoOsobljeView>();

            using (ISession s = DataLayer.GetSession())
            {

                var t = s.Query<AdministrativnoOsoblje>()
                    .Fetch(x => x.AdresaLokacije)
                    .ToList();

                foreach (AdministrativnoOsoblje admin in t)
                {

                    AdministrativnoOsobljeView ad = new AdministrativnoOsobljeView
                    {
                        JMBG = admin.JMBG,
                        DatumZaposlenja = admin.DatumZaposlenja,
                        DatumRodjenja = admin.DatumRodjenja,
                        Pozicija = admin.Pozicija,
                        Ime = admin.Ime,
                        Prezime = admin.Prezime,
                        Adresa = admin.Adresa,
                        Smena = admin.Smena,
                        AdresaLokacije = new LokacijaView
                        {
                            Adresa = admin.AdresaLokacije.Adresa,
                        }
                    };
                    
                    foreach(var email in admin.Emails)
                    {
                        ad.Emails.Add(new EmailZaposlenogView(email));
                    }

                    foreach (var telefon in admin.Telefons)
                    {
                        ad.Telefons.Add(new BrTelefonaZaposlenogView(telefon));
                    }

                    foreach (var odeljenje in admin.Odeljenja)
                    {
                        ad.Odeljenja.Add(new OdeljenjeView
                        {
                            Naziv = odeljenje.Naziv
                        });
                    }
                    admini.Add(ad);
                }
            }

            return admini;
        }

        public static AdministrativnoOsoblje nadjiAdministrativnoOsoblje(long jmbg)
        {
            ISession s = DataLayer.GetSession();
            AdministrativnoOsoblje osoblje = s.Query<AdministrativnoOsoblje>()
                .FirstOrDefault(x => x.JMBG == jmbg);

            if (osoblje != null)
            {
                NHibernateUtil.Initialize(osoblje.Emails);
                NHibernateUtil.Initialize(osoblje.Telefons);
                NHibernateUtil.Initialize(osoblje.Odeljenja);
            }

            s.Close();
            return osoblje;
        }

        public static Odeljenje nadjiOdeljenje(string Naziv)
        {
            ISession s = DataLayer.GetSession();
            Odeljenje odeljenje = s.Query<Odeljenje>()
                                    .FetchMany(x => x.Lokacije)
                                    .Fetch(x => x.GlavniLekar)
                                    .Where(x => x.Naziv == Naziv)
                                    .ToList()
                                    .FirstOrDefault();

            s.Close();
            return odeljenje;
        }

        public static void izmeniAdministrativnoOsoblje(AdministrativnoOsobljeView a, List<string> emails, List<string> telefons, List<string> odeljenja, string AdresaLokacije)
        {
            ISession s = DataLayer.GetSession();

            AdministrativnoOsoblje ad = nadjiAdministrativnoOsoblje(a.JMBG);


            ad.Adresa = a.Adresa;
            ad.DatumRodjenja = a.DatumRodjenja;
            var loc = s.Load<Lokacija>(AdresaLokacije);
            ad.AdresaLokacije = loc;
            //ad.AdresaLokacije = a.AdresaLokacije;
            ad.Pozicija = a.Pozicija;
            ad.JMBG = a.JMBG;
            ad.DatumZaposlenja = a.DatumZaposlenja;
            ad.Pozicija = a.Pozicija;
            ad.Ime = a.Ime;
            ad.Prezime = a.Prezime;
            ad.Smena = a.Smena;


            foreach (var item in odeljenja)
            {
                var od = s.Load<Odeljenje>(item);
                ad.Odeljenja.Add(od);
            }

            s.SaveOrUpdate(ad);


            foreach (var item in emails)
            {
                EmailZaposlenog em = new EmailZaposlenog();
                em.Zaposlen = ad;
                em.Email = item;
                s.SaveOrUpdate(em);
            }

            foreach (var item in telefons)
            {
                BrTelefonaZaposlenog tel = new BrTelefonaZaposlenog();
                tel.Zaposlen = ad;
                tel.BrojTelefona = item;
                s.SaveOrUpdate(tel);
            }


            s.Flush();
            s.Close();
        }

        public static void brisiAdmina(long jmbg)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                AdministrativnoOsoblje admin = s.Load<AdministrativnoOsoblje>(jmbg);
                s.Delete(admin);
                s.Flush();

                s.Close();
            }
            catch (Exception ec)
            {


            }
        }

        public static void dodajMedicinskuSestru(MedicinskaSestraView a, List<string> emails, List<string> telefons, List<string> odeljenja, string AdresaLokacije)
        {
            ISession s = DataLayer.GetSession();

            MedicinskaSestra ad = new MedicinskaSestra();


            ad.Adresa = a.Adresa;
            ad.DatumRodjenja = a.DatumRodjenja;
            var loc = s.Load<Lokacija>(AdresaLokacije);
            ad.AdresaLokacije = loc;
            //ad.AdresaLokacije = a.AdresaLokacije;
            ad.Pozicija = a.Pozicija;
            ad.JMBG = a.JMBG;
            ad.DatumZaposlenja = a.DatumZaposlenja;
            ad.Pozicija = a.Pozicija;
            ad.Ime = a.Ime;
            ad.Prezime = a.Prezime;
            ad.Smena = a.Smena;
            ad.OblastRada = a.OblastRada;
            ad.Sertifikat = a.Sertifikat;

            foreach (var item in odeljenja)
            {
                var od = s.Load<Odeljenje>(item);
                ad.Odeljenja.Add(od);
            }

            s.SaveOrUpdate(ad);


            foreach (var item in emails)
            {
                EmailZaposlenog em = new EmailZaposlenog();
                em.Zaposlen = ad;
                em.Email = item;
                s.SaveOrUpdate(em);
            }

            foreach (var item in telefons)
            {
                BrTelefonaZaposlenog tel = new BrTelefonaZaposlenog();
                tel.Zaposlen = ad;
                tel.BrojTelefona = item;
                s.SaveOrUpdate(tel);
            }


            s.Flush();
            s.Close();
        }

        public static MedicinskaSestra nadjiMedicinskuSestru(long jmbg)
        {
            ISession s = DataLayer.GetSession();
            MedicinskaSestra osoblje = s.Query<MedicinskaSestra>()
                .FirstOrDefault(x => x.JMBG == jmbg);

            if (osoblje != null)
            {
                NHibernateUtil.Initialize(osoblje.Emails);
                NHibernateUtil.Initialize(osoblje.Telefons);
                NHibernateUtil.Initialize(osoblje.Odeljenja);
            }

            s.Close();
            return osoblje;
        }

        public static void izmeniMedicinskuSestru(MedicinskaSestraView a, List<string> emails, List<string> telefons, List<string> odeljenja, string AdresaLokacije)
        {
            ISession s = DataLayer.GetSession();

            MedicinskaSestra ad = nadjiMedicinskuSestru(a.JMBG);


            ad.Adresa = a.Adresa;
            ad.DatumRodjenja = a.DatumRodjenja;
            var loc = s.Load<Lokacija>(AdresaLokacije);
            ad.AdresaLokacije = loc;
            //ad.AdresaLokacije = a.AdresaLokacije;
            ad.Pozicija = a.Pozicija;
            ad.JMBG = a.JMBG;
            ad.DatumZaposlenja = a.DatumZaposlenja;
            ad.Pozicija = a.Pozicija;
            ad.Ime = a.Ime;
            ad.Prezime = a.Prezime;
            ad.Smena = a.Smena;
            ad.Sertifikat = a.Sertifikat;
            ad.OblastRada = a.OblastRada;

            foreach (var item in odeljenja)
            {
                var od = s.Load<Odeljenje>(item);
                ad.Odeljenja.Add(od);
            }

            s.SaveOrUpdate(ad);


            foreach (var item in emails)
            {
                EmailZaposlenog em = new EmailZaposlenog();
                em.Zaposlen = ad;
                em.Email = item;
                s.SaveOrUpdate(em);
            }

            foreach (var item in telefons)
            {
                BrTelefonaZaposlenog tel = new BrTelefonaZaposlenog();
                tel.Zaposlen = ad;
                tel.BrojTelefona = item;
                s.SaveOrUpdate(tel);
            }


            s.Flush();
            s.Close();
        }

        public static void brisiMedicinskuSestru(long jmbg)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                MedicinskaSestra admin = s.Load<MedicinskaSestra>(jmbg);
                s.Delete(admin);
                s.Flush();

                s.Close();
            }
            catch (Exception ec)
            {


            }
        }

        public static List<MedicinskaSestraView> prikaziMedicinskuSestru()
        {
            List<MedicinskaSestraView> admini = new List<MedicinskaSestraView>();

            using (ISession s = DataLayer.GetSession())
            {

                var t = s.Query<MedicinskaSestra>()
                    .Fetch(x => x.AdresaLokacije)
                    .ToList();

                foreach (MedicinskaSestra admin in t)
                {

                    MedicinskaSestraView ad = new MedicinskaSestraView
                    {
                        JMBG = admin.JMBG,
                        DatumZaposlenja = admin.DatumZaposlenja,
                        DatumRodjenja = admin.DatumRodjenja,
                        Pozicija = admin.Pozicija,
                        Ime = admin.Ime,
                        Prezime = admin.Prezime,
                        Adresa = admin.Adresa,
                        Smena = admin.Smena,
                        Sertifikat = admin.Sertifikat,
                        OblastRada = admin.OblastRada,
                        AdresaLokacije = new LokacijaView
                        {
                            Adresa = admin.AdresaLokacije.Adresa,
                        }
                    };

                    foreach (var email in admin.Emails)
                    {
                        ad.Emails.Add(new EmailZaposlenogView(email));
                    }

                    foreach (var telefon in admin.Telefons)
                    {
                        ad.Telefons.Add(new BrTelefonaZaposlenogView(telefon));
                    }

                    foreach (var odeljenje in admin.Odeljenja)
                    {
                        ad.Odeljenja.Add(new OdeljenjeView
                        {
                            Naziv = odeljenje.Naziv
                        });
                    }
                    admini.Add(ad);
                }
            }

            return admini;
        }

        public static void dodajLaboranta(LaborantView a, List<string> emails, List<string> telefons, List<string> odeljenja, string AdresaLokacije)
        {
            ISession s = DataLayer.GetSession();

            Laborant ad = new Laborant();


            ad.Adresa = a.Adresa;
            ad.DatumRodjenja = a.DatumRodjenja;
            var loc = s.Load<Lokacija>(AdresaLokacije);
            ad.AdresaLokacije = loc;
            //ad.AdresaLokacije = a.AdresaLokacije;
            ad.Pozicija = a.Pozicija;
            ad.JMBG = a.JMBG;
            ad.DatumZaposlenja = a.DatumZaposlenja;
            ad.Pozicija = a.Pozicija;
            ad.Ime = a.Ime;
            ad.Prezime = a.Prezime;
            ad.Smena = a.Smena;
            ad.OblastRada = a.OblastRada;
            ad.Sertifikat = a.Sertifikat;

            foreach (var item in odeljenja)
            {
                var od = s.Load<Odeljenje>(item);
                ad.Odeljenja.Add(od);
            }

            s.SaveOrUpdate(ad);


            foreach (var item in emails)
            {
                EmailZaposlenog em = new EmailZaposlenog();
                em.Zaposlen = ad;
                em.Email = item;
                s.SaveOrUpdate(em);
            }

            foreach (var item in telefons)
            {
                BrTelefonaZaposlenog tel = new BrTelefonaZaposlenog();
                tel.Zaposlen = ad;
                tel.BrojTelefona = item;
                s.SaveOrUpdate(tel);
            }


            s.Flush();
            s.Close();
        }

        public static Laborant nadjiLaboranta(long JMBG)
        {
            ISession s = DataLayer.GetSession();
            Laborant laborant = s.Query<Laborant>().FirstOrDefault(x => x.JMBG == JMBG);

            if (laborant != null)
            {
                NHibernateUtil.Initialize(laborant.Emails);
                NHibernateUtil.Initialize(laborant.Telefons);
                NHibernateUtil.Initialize(laborant.Odeljenja);
            }

            s.Close();
            return laborant;
        }

        public static void izmeniLaboranta(LaborantView a, List<string> emails, List<string> telefons, List<string> odeljenja, string AdresaLokacije)
        {
            ISession s = DataLayer.GetSession();

            Laborant ad = nadjiLaboranta(a.JMBG);


            ad.Adresa = a.Adresa;
            ad.DatumRodjenja = a.DatumRodjenja;
            var loc = s.Load<Lokacija>(AdresaLokacije);
            ad.AdresaLokacije = loc;
            //ad.AdresaLokacije = a.AdresaLokacije;
            ad.Pozicija = a.Pozicija;
            ad.JMBG = a.JMBG;
            ad.DatumZaposlenja = a.DatumZaposlenja;
            ad.Pozicija = a.Pozicija;
            ad.Ime = a.Ime;
            ad.Prezime = a.Prezime;
            ad.Smena = a.Smena;
            ad.Sertifikat = a.Sertifikat;
            ad.OblastRada = a.OblastRada;

            foreach (var item in odeljenja)
            {
                var od = s.Load<Odeljenje>(item);
                ad.Odeljenja.Add(od);
            }

            s.SaveOrUpdate(ad);


            foreach (var item in emails)
            {
                EmailZaposlenog em = new EmailZaposlenog();
                em.Zaposlen = ad;
                em.Email = item;
                s.SaveOrUpdate(em);
            }

            foreach (var item in telefons)
            {
                BrTelefonaZaposlenog tel = new BrTelefonaZaposlenog();
                tel.Zaposlen = ad;
                tel.BrojTelefona = item;
                s.SaveOrUpdate(tel);
            }


            s.Flush();
            s.Close();
        }

        public static void brisiLaboranta(long jmbg)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Laborant admin = s.Load<Laborant>(jmbg);
                s.Delete(admin);
                s.Flush();

                s.Close();
            }
            catch (Exception ec)
            {


            }
        }

        public static List<LaborantView> prikaziLaboranta()
        {
            List<LaborantView> admini = new List<LaborantView>();

            using (ISession s = DataLayer.GetSession())
            {

                var t = s.Query<Laborant>()
                    .Fetch(x => x.AdresaLokacije)
                    .ToList();

                foreach (Laborant admin in t)
                {

                    LaborantView ad = new LaborantView
                    {
                        JMBG = admin.JMBG,
                        DatumZaposlenja = admin.DatumZaposlenja,
                        DatumRodjenja = admin.DatumRodjenja,
                        Pozicija = admin.Pozicija,
                        Ime = admin.Ime,
                        Prezime = admin.Prezime,
                        Adresa = admin.Adresa,
                        Smena = admin.Smena,
                        Sertifikat = admin.Sertifikat,
                        OblastRada = admin.OblastRada,
                        AdresaLokacije = new LokacijaView
                        {
                            Adresa = admin.AdresaLokacije.Adresa,
                        }
                    };

                    foreach (var email in admin.Emails)
                    {
                        ad.Emails.Add(new EmailZaposlenogView(email));
                    }

                    foreach (var telefon in admin.Telefons)
                    {
                        ad.Telefons.Add(new BrTelefonaZaposlenogView(telefon));
                    }

                    foreach (var odeljenje in admin.Odeljenja)
                    {
                        ad.Odeljenja.Add(new OdeljenjeView
                        {
                            Naziv = odeljenje.Naziv
                        });
                    }
                    admini.Add(ad);
                }
            }

            return admini;
        }

        public static Lekar nadjiLekara(long JMBG)
        {
            ISession s = DataLayer.GetSession();
            Lekar lekar = s.Query<Lekar>().FirstOrDefault(x => x.JMBG == JMBG);

            if (lekar != null)
            {
                NHibernateUtil.Initialize(lekar.Emails);
                NHibernateUtil.Initialize(lekar.Telefons);
                NHibernateUtil.Initialize(lekar.Odeljenja);
            }

            s.Close();
            return lekar;
        }

        public static LaboratorijskaAnaliza nadjiLaboratorijskuAnalizu(int id)
        {
            ISession s = DataLayer.GetSession();
            LaboratorijskaAnaliza lab = s.Query<LaboratorijskaAnaliza>()
            .Fetch(x => x.Pacijent)
            .Fetch(x => x.Laborant)
            .Fetch(x => x.Pregled)
            .FirstOrDefault(x => x.IdAnalize == id);

            s.Close();
            return lab;
        }

        public static Pregled nadjiPregled(int id)
        {
            ISession s = DataLayer.GetSession();
            Pregled pregled = s.Query<Pregled>().FirstOrDefault(x => x.IdPregleda == id);
            s.Close();
            return pregled;
        }

        public static Pacijent nadjiPacijenta(int idKartona)
        {
            ISession s = DataLayer.GetSession();
            Pacijent p = s.Query<Pacijent>().FirstOrDefault(x => x.IdKartona == idKartona);

            if (p != null)
            {
                NHibernateUtil.Initialize(p.Emails);
                NHibernateUtil.Initialize(p.Telefons);
            }
            s.Close();
            return p;
        }

        public static void dodajLaboratorijskuAnalizu(LaboratorijskaAnalizaView l, bool f,int idKartona, long jmbgLaboranta, int idPregleda)
        {
            try
            {
                LaboratorijskaAnaliza lab = nadjiLaboratorijskuAnalizu(l.IdAnalize);
                using (ISession s = DataLayer.GetSession())
                {

                    if (f)
                    {
                        lab.Pacijent = nadjiPacijenta(idKartona);
                        lab.VrstaAnalize = l.VrstaAnalize;
                        lab.DatumUzorkovanja = l.DatumUzorkovanja;
                        lab.Vreme = l.Vreme;
                        lab.Rezultat = l.Rezultat;
                        lab.ReferentnaVrednost = l.ReferentnaVrednost;
                        lab.Komentar = l.Komentar;
                        lab.Laborant = nadjiLaboranta(jmbgLaboranta);
                        lab.Pregled = nadjiPregled(idPregleda);
                    }
                    else
                    {
                        lab = new LaboratorijskaAnaliza
                        {
                            Pacijent = nadjiPacijenta(idKartona),
                            VrstaAnalize = l.VrstaAnalize,
                            DatumUzorkovanja = l.DatumUzorkovanja,
                            Vreme = l.Vreme,
                            Rezultat = l.Rezultat,
                            ReferentnaVrednost = l.ReferentnaVrednost,
                            Komentar = l.Komentar,
                            Laborant = nadjiLaboranta(jmbgLaboranta),
                            Pregled = nadjiPregled(idPregleda),
                        };
                    }
                    ;
                    s.SaveOrUpdate(lab);
                    s.Flush();
                    s.Close();
                }
            }
            catch (Exception ex)
            {
                
            }
        }

        public static List<LaboratorijskaAnalizaView> prikazLaboratorijskeAnalize()
        {
            List<LaboratorijskaAnalizaView> labovi = new List<LaboratorijskaAnalizaView>();

            using (ISession s = DataLayer.GetSession())
            {
                var r = s.Query<LaboratorijskaAnaliza>().Fetch(x => x.Pacijent).Fetch(x => x.Pregled).Fetch(x => x.Laborant);

                foreach (LaboratorijskaAnaliza lab in r)
                {
                    labovi.Add(new LaboratorijskaAnalizaView
                    {
                        IdAnalize = lab.IdAnalize,
                        VrstaAnalize = lab.VrstaAnalize,
                        Rezultat = lab.Rezultat,
                        ReferentnaVrednost = lab.ReferentnaVrednost,
                        Komentar = lab.Komentar,
                        DatumUzorkovanja = lab.DatumUzorkovanja,
                        Vreme = lab.Vreme,

                        Pacijent = new PacijentView
                        {
                            IdKartona = lab.Pacijent.IdKartona,
                            Ime = lab.Pacijent.Ime,
                            Prezime = lab.Pacijent.Prezime
                        },

                        Laborant = new LaborantView
                        {
                            JMBG = lab.Laborant.JMBG,
                            Ime = lab.Laborant.Ime,
                            Prezime = lab.Laborant.Prezime
                        },
                        Pregled = new PregledView
                        {
                            VrstaPregleda = lab.Pregled.VrstaPregleda
                        }
                    });
                }
            }
            return labovi;
        }

        public static void brisiLaboratorijskuAnalizu(int id)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                LaboratorijskaAnaliza t = s.Load<LaboratorijskaAnaliza>(id);

                s.Delete(t);
                s.Flush();

                s.Close();
            }
            catch (Exception ec)
            {

            }
        }

        public static void dodajLekara(LekarView a, List<string> emails, List<string> telefons, List<string> odeljenja, string AdresaLokacije)
        {
            ISession s = DataLayer.GetSession();

            Lekar ad = new Lekar();


            ad.Adresa = a.Adresa;
            ad.DatumRodjenja = a.DatumRodjenja;
            var loc = s.Load<Lokacija>(AdresaLokacije);
            ad.AdresaLokacije = loc;
            //ad.AdresaLokacije = a.AdresaLokacije;
            ad.Pozicija = a.Pozicija;
            ad.JMBG = a.JMBG;
            ad.DatumZaposlenja = a.DatumZaposlenja;
            ad.Pozicija = a.Pozicija;
            ad.Ime = a.Ime;
            ad.Prezime = a.Prezime;
            ad.Smena = a.Smena;
            ad.Specijalizacija = a.Specijalizacija;
            ad.BrLicence = a.BrLicence;

            foreach (var item in odeljenja)
            {
                var od = s.Load<Odeljenje>(item);
                ad.Odeljenja.Add(od);
            }

            s.SaveOrUpdate(ad);


            foreach (var item in emails)
            {
                EmailZaposlenog em = new EmailZaposlenog();
                em.Zaposlen = ad;
                em.Email = item;
                s.SaveOrUpdate(em);
            }

            foreach (var item in telefons)
            {
                BrTelefonaZaposlenog tel = new BrTelefonaZaposlenog();
                tel.Zaposlen = ad;
                tel.BrojTelefona = item;
                s.SaveOrUpdate(tel);
            }


            s.Flush();
            s.Close();
        }

        public static void izmeniLekara(LekarView a, List<string> emails, List<string> telefons, List<string> odeljenja, string AdresaLokacije)
        {
            ISession s = DataLayer.GetSession();

            Lekar ad = nadjiLekara(a.JMBG);


            ad.Adresa = a.Adresa;
            ad.DatumRodjenja = a.DatumRodjenja;
            var loc = s.Load<Lokacija>(AdresaLokacije);
            ad.AdresaLokacije = loc;
            //ad.AdresaLokacije = a.AdresaLokacije;
            ad.Pozicija = a.Pozicija;
            ad.JMBG = a.JMBG;
            ad.DatumZaposlenja = a.DatumZaposlenja;
            ad.Pozicija = a.Pozicija;
            ad.Ime = a.Ime;
            ad.Prezime = a.Prezime;
            ad.Smena = a.Smena;
            ad.Specijalizacija = a.Specijalizacija;
            ad.BrLicence = a.BrLicence;

            foreach (var item in odeljenja)
            {
                var od = s.Load<Odeljenje>(item);
                ad.Odeljenja.Add(od);
            }

            s.SaveOrUpdate(ad);


            foreach (var item in emails)
            {
                EmailZaposlenog em = new EmailZaposlenog();
                em.Zaposlen = ad;
                em.Email = item;
                s.SaveOrUpdate(em);
            }

            foreach (var item in telefons)
            {
                BrTelefonaZaposlenog tel = new BrTelefonaZaposlenog();
                tel.Zaposlen = ad;
                tel.BrojTelefona = item;
                s.SaveOrUpdate(tel);
            }


            s.Flush();
            s.Close();
        }

        public static void brisiLekara(long jmbg)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Lekar admin = s.Load<Lekar>(jmbg);
                s.Delete(admin);
                s.Flush();

                s.Close();
            }
            catch (Exception ec)
            {


            }
        }

        public static List<LekarView> prikaziLekara()
        {
            List<LekarView> admini = new List<LekarView>();

            using (ISession s = DataLayer.GetSession())
            {

                var t = s.Query<Lekar>()
                    .Fetch(x => x.AdresaLokacije)
                    .ToList();

                foreach (Lekar admin in t)
                {

                    LekarView ad = new LekarView
                    {
                        JMBG = admin.JMBG,
                        DatumZaposlenja = admin.DatumZaposlenja,
                        DatumRodjenja = admin.DatumRodjenja,
                        Pozicija = admin.Pozicija,
                        Ime = admin.Ime,
                        Prezime = admin.Prezime,
                        Adresa = admin.Adresa,
                        Smena = admin.Smena,
                        Specijalizacija = admin.Specijalizacija,
                        BrLicence = admin.BrLicence,
                        AdresaLokacije = new LokacijaView
                        {
                            Adresa = admin.AdresaLokacije.Adresa,
                        }
                    };

                    foreach (var email in admin.Emails)
                    {
                        ad.Emails.Add(new EmailZaposlenogView(email));
                    }

                    foreach (var telefon in admin.Telefons)
                    {
                        ad.Telefons.Add(new BrTelefonaZaposlenogView(telefon));
                    }

                    foreach (var odeljenje in admin.Odeljenja)
                    {
                        ad.Odeljenja.Add(new OdeljenjeView
                        {
                            Naziv = odeljenje.Naziv
                        });
                    }
                    admini.Add(ad);
                }
            }

            return admini;
        }

        public static Lokacija nadjiLokaciju(string Adresa)
        {
            ISession s = DataLayer.GetSession();
            Lokacija lokacija = s.Query<Lokacija>().FirstOrDefault(x => x.Adresa == Adresa);
            s.Close();
            return lokacija;
        }

        public static void dodajLokaciju(LokacijaView l, bool f)
        {
            try
            {
                Lokacija lokacija;
                ISession s = DataLayer.GetSession();

                if (f)
                {
                    lokacija = nadjiLokaciju(l.Adresa);
                    lokacija.Adresa = l.Adresa;
                    lokacija.RadnoVreme = l.RadnoVreme;
                }
                else
                {
                    lokacija = new Lokacija();
                    lokacija.Adresa = l.Adresa;
                    lokacija.RadnoVreme = l.RadnoVreme;
                }



                s.SaveOrUpdate(lokacija);
                s.Flush();
                s.Close();
            }
            catch (Exception ex)
            {
            }
        }
        public static void brisiLokaciju(string adresa)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Lokacija t = s.Load<Lokacija>(adresa);
                t.Zaposleni.Clear();
                t.Odeljenja.Clear();
                s.Delete(t);
                s.Flush();

                s.Close();
            }
            catch (Exception ec)
            {

            }
        }

        public static List<LokacijaView> prikazLokacije()
        {
            List<LokacijaView> lokacije = new List<LokacijaView>();

            using (ISession s = DataLayer.GetSession())
            {
                var r = s.Query<Lokacija>();

                foreach (Lokacija lokacija in r)
                {
                    lokacije.Add(new LokacijaView
                    {
                        Adresa = lokacija.Adresa,
                        RadnoVreme = lokacija.RadnoVreme
                    });
                }
            }
            return lokacije;
        }

        public static void dodajOdeljenje(OdeljenjeView o,long jmbgGlavnogLekara,List<string> adresa, bool f)
        {
            try
            {
                Odeljenje od;
                Lekar glavni = nadjiLekara(jmbgGlavnogLekara);
                if(glavni.Odeljenje != null && !f)
                {
                    return;
                }
                List<Lokacija> lokacija = new List<Lokacija>();
                foreach (string s in adresa)
                {
                lokacija.Add(nadjiLokaciju(s));
                }

                using (ISession s = DataLayer.GetSession())
                {

                    if (f)
                    {
                        od = nadjiOdeljenje(o.Naziv);
                    }
                    else
                    {
                        od = new Odeljenje();
                    }



                    od.Naziv = o.Naziv;
                    od.BrProstorije = o.BrProstorije;
                    od.RadnoVreme = o.RadnoVreme;
                    od.GlavniLekar = glavni;
                    od.Lokacije = lokacija;

                    s.SaveOrUpdate(od);
                    s.Flush();
                    s.Close();
                }
            }
            catch (Exception ex)
            {

            }

        }

        public static void brisiOdeljenje(string id)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Odeljenje t = s.Load<Odeljenje>(id);

                s.Delete(t);
                s.Flush();

                s.Close();
            }
            catch (Exception ec)
            {

            }
        }

        public static List<OdeljenjeView> prikazOdeljenja()
        {
            List<OdeljenjeView> odeljenja = new List<OdeljenjeView>();

            using (ISession s = DataLayer.GetSession())
            {
                var r = s.Query<Odeljenje>().Fetch(x => x.GlavniLekar).Fetch(x => x.Lokacije).ToList();



                foreach (Odeljenje odeljenje in r)
                {
                    odeljenja.Add(new OdeljenjeView
                    {
                        Naziv = odeljenje.Naziv,
                        RadnoVreme = odeljenje.RadnoVreme,
                        BrProstorije = odeljenje.BrProstorije,
                        GlavniLekar = new LekarView
                        {
                            JMBG = odeljenje.GlavniLekar.JMBG,
                            Ime = odeljenje.GlavniLekar.Ime,
                            Prezime = odeljenje.GlavniLekar.Prezime
                        },
                    });
                }
            }
            return odeljenja;
        }

        public static Termin nadjiTermin(int idTermina)
        {
            ISession s = DataLayer.GetSession();
            Termin termin = s.Query<Termin>().FirstOrDefault(x => x.IdTermina == idTermina);
            s.Close();
            return termin;
        }

        public static void dodajTermin(TerminView ter,int idKartona,long jmbgLekara,string nazivOdeljenja, bool f)
        {
            try
            {
                Termin termin = nadjiTermin(ter.IdTermina);

                Pacijent pacijent = nadjiPacijenta(idKartona);

                Lekar lekar = nadjiLekara(jmbgLekara);

                Odeljenje odeljenje = nadjiOdeljenje(nazivOdeljenja);
                using (ISession s = DataLayer.GetSession())
                {


                    if (f)
                    {
                        termin.Datum = ter.Datum;
                        termin.Vreme = ter.Vreme;
                        termin.Pacijent = pacijent;
                        termin.Lekar = lekar;
                        termin.Odeljenje = odeljenje;
                    }
                    else
                    {
                        termin = new Termin
                        {
                            Datum = ter.Datum,
                            Vreme = ter.Vreme,
                            Pacijent = pacijent,
                            Lekar = lekar,
                            Odeljenje = odeljenje,
                        };
                    }

                    s.SaveOrUpdate(termin);
                    s.Flush();
                    s.Close();
                }
            }
            catch (Exception ex)
            {

            }
        }

        public static void brisiTermin(int id)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Termin t = s.Load<Termin>(id);

                s.Delete(t);
                s.Flush();

                s.Close();
            }
            catch (Exception ec)
            {

            }
        }

        public static List<TerminView> prikazTermina()
        {
            List<TerminView> termini = new List<TerminView>();

            using (ISession s = DataLayer.GetSession())
            {

                var t = s.Query<Termin>()
                    .Fetch(x => x.Pacijent)
                    .Fetch(x => x.Lekar)
                    .Fetch(x => x.Odeljenje)
                    .ToList();

                foreach (Termin termin in t)
                {

                    termini.Add(new TerminView
                    {
                        IdTermina = termin.IdTermina,
                        Datum = termin.Datum,
                        Vreme = termin.Vreme,
                        Pacijent = new PacijentView
                        {
                            IdKartona = termin.Pacijent.IdKartona,
                            Ime = termin.Pacijent.Ime,
                            Prezime = termin.Pacijent.Prezime
                        },
                        Lekar = new LekarView
                        {
                            JMBG = termin.Lekar.JMBG,
                            Ime = termin.Lekar.Ime,
                            Prezime = termin.Lekar.Prezime
                        },
                        Odeljenje = new OdeljenjeView
                        {
                            Naziv = termin.Odeljenje.Naziv
                        }
                    });
                }
            }

            return termini;
        }

        public static void dodajPacijenta(PacijentView a, List<string> emails, List<string> telefons, long jmbgLekara)
        {
            ISession s = DataLayer.GetSession();

            Pacijent ad = new Pacijent();

            ad.Adresa = a.Adresa;
            ad.DatumRodjenja = a.DatumRodjenja;
            ad.Pol = a.Pol;
            ad.Ime = a.Ime;
            ad.Prezime = a.Prezime;
            ad.Lekar = nadjiLekara(jmbgLekara);

            s.SaveOrUpdate(ad);

            foreach (var item in emails)
            {
                EmailPacijenta em = new EmailPacijenta();
                em.Pacijent = ad;
                em.Email = item;
                s.SaveOrUpdate(em);
            }

            foreach (var item in telefons)
            {
                BrTelefonaPacijenta tel = new BrTelefonaPacijenta();
                tel.Pacijent = ad;
                tel.BrojTelefona = item;
                s.SaveOrUpdate(tel);
            }


            s.Flush();
            s.Close();
        }


        public static List<PacijentView> prikazPacijenta()
        {
            List<PacijentView> admini = new List<PacijentView>();

            using (ISession s = DataLayer.GetSession())
            {

                var t = s.Query<Pacijent>()
                    .Fetch(x => x.Adresa)
                    .ToList();

                foreach (Pacijent admin in t)
                {

                    PacijentView ad = new PacijentView
                    {
                        IdKartona = admin.IdKartona,
                        DatumRodjenja = admin.DatumRodjenja,
                        Pol = admin.Pol,
                        Ime = admin.Ime,
                        Prezime = admin.Prezime,
                        Adresa = admin.Adresa,
                        Lekar = new LekarView
                        {
                            Ime = admin.Lekar.Ime,
                            Prezime = admin.Lekar.Prezime,
                        }
                    };

                    foreach (var email in admin.Emails)
                    {
                        ad.Emails.Add(new EmailPacijentaView(email));
                    }

                    foreach (var telefon in admin.Telefons)
                    {
                        ad.Telefons.Add(new BrTelefonaPacijentaView(telefon));
                    }

                    admini.Add(ad);
                }
            }

            return admini;
        }
        public static void izmeniPacijenta(PacijentView a, List<string> emails, List<string> telefons, long jmbgLekara, int idKartona)
        {
            ISession s = DataLayer.GetSession();

            Pacijent ad = nadjiPacijenta(idKartona);


            ad.Adresa = a.Adresa;
            ad.DatumRodjenja = a.DatumRodjenja;
            ad.Pol = a.Pol;
            ad.Ime = a.Ime;
            ad.Prezime = a.Prezime;
            ad.Lekar = nadjiLekara(jmbgLekara);


            s.SaveOrUpdate(ad);


            foreach (var item in emails)
            {
                EmailPacijenta em = new EmailPacijenta();
                em.Pacijent = ad;
                em.Email = item;
                s.SaveOrUpdate(em);
            }

            foreach (var item in telefons)
            {
                BrTelefonaPacijenta tel = new BrTelefonaPacijenta();
                tel.Pacijent = ad;
                tel.BrojTelefona = item;
                s.SaveOrUpdate(tel);
            }


            s.Flush();
            s.Close();
        }

        public static void brisiPacijenta(int id)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Pacijent admin = s.Load<Pacijent>(id);
                s.Delete(admin);
                s.Flush();

                s.Close();
            }
            catch (Exception ec)
            {


            }
        }

        public static RFZO nadjiRFZO(int idOsiguranja)
        {
            ISession s = DataLayer.GetSession();
            RFZO rfzo = s.Query<RFZO>().FirstOrDefault(x => x.IdOsiguranja == idOsiguranja);
            s.Close();
            return rfzo;
        }

        public static void dodajRFZO(RFZOView r, bool f,int idKartona)
        {
            try
            {
                RFZO rfzo = nadjiRFZO(r.IdOsiguranja);
                Pacijent pacijent = nadjiPacijenta(idKartona);
                if(pacijent.RFZO != null && pacijent.PrivatnoOsiguranje != null)
                {
                    return;
                }
                using (ISession s = DataLayer.GetSession())
                {

                    if (f)
                    {
                        rfzo.IdOsiguranja = r.IdOsiguranja;
                        rfzo.Pacijent = pacijent;
                    }
                    else
                    {
                        rfzo = new RFZO
                        {
                            IdOsiguranja = r.IdOsiguranja,
                            Pacijent = pacijent,
                        };
                    }
                    s.SaveOrUpdate(rfzo);
                    s.Flush();
                    s.Close();
                }
            }
            catch (Exception ex)
            {

            }

        }

        public static void brisiRFZO(int id)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                RFZO t = s.Load<RFZO>(id);

                s.Delete(t);
                s.Flush();

                s.Close();
            }
            catch (Exception ec)
            {

            }
        }

        public static List<RFZOView> prikazRFZO()
        {
            List<RFZOView> rfzos = new List<RFZOView>();

            using (ISession s = DataLayer.GetSession())
            {
                var r = s.Query<RFZO>().Fetch(x => x.Pacijent);

                foreach (RFZO rfzo in r)
                {
                    rfzos.Add(new RFZOView
                    {
                        IdOsiguranja = rfzo.IdOsiguranja,
                        Pacijent = new PacijentView
                        {
                            IdKartona = rfzo.Pacijent.IdKartona,
                            Ime = rfzo.Pacijent.Ime,
                            Prezime = rfzo.Pacijent.Prezime
                        }
                    });
                }
            }
            return rfzos;
        }

        public static PrivatnoOsiguranje nadjiPrivatnoOsiguranje(int idOsiguranja)
        {
            ISession s = DataLayer.GetSession();
            PrivatnoOsiguranje osiguranje = s.Query<PrivatnoOsiguranje>().FirstOrDefault(x => x.IdOsiguranja == idOsiguranja);
            s.Close();
            return osiguranje;
        }

        public static void dodajPrivatnoOsiguranje(PrivatnoOsiguranjeView p, bool f,int idKartona)
        {
            try
            {
                PrivatnoOsiguranje osiguranje = nadjiPrivatnoOsiguranje(p.IdOsiguranja);
                Pacijent pacijent = nadjiPacijenta(idKartona);
                if (pacijent.RFZO != null && pacijent.PrivatnoOsiguranje != null)
                {
                    return;
                }
                using (ISession s = DataLayer.GetSession())
                {
                    if (f)
                    {
                        osiguranje.BrPolise = p.BrPolise;
                        osiguranje.OsiguravajucaKuca = p.OsiguravajucaKuca;
                        osiguranje.Pacijent = pacijent;
                    }
                    else
                    {
                        osiguranje = new PrivatnoOsiguranje
                        {
                            BrPolise = p.BrPolise,
                            OsiguravajucaKuca = p.OsiguravajucaKuca,
                            Pacijent = pacijent,
                        };
                    }

                    s.SaveOrUpdate(osiguranje);
                    s.Flush();
                    s.Close();
                }
            }
            catch (Exception ex)
            {
            }
        }

        public static void brisiPrivatnoOsiguranje(int id)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                PrivatnoOsiguranje t = s.Load<PrivatnoOsiguranje>(id);

                s.Delete(t);
                s.Flush();

                s.Close();
            }
            catch (Exception ec)
            {

            }
        }

        public static List<PrivatnoOsiguranjeView> prikazPrivatnogOsiguranja()
        {
            List<PrivatnoOsiguranjeView> osiguranja = new List<PrivatnoOsiguranjeView>();

            using (ISession s = DataLayer.GetSession())
            {
                var r = s.Query<PrivatnoOsiguranje>().Fetch(x => x.Pacijent);

                foreach (PrivatnoOsiguranje osiguranje in r)
                {
                    osiguranja.Add(new PrivatnoOsiguranjeView
                    {
                        IdOsiguranja = osiguranje.IdOsiguranja,
                        OsiguravajucaKuca = osiguranje.OsiguravajucaKuca,
                        BrPolise = osiguranje.BrPolise,
                        Pacijent = new PacijentView
                        {
                            IdKartona = osiguranje.Pacijent.IdKartona,
                            Ime = osiguranje.Pacijent.Ime,
                            Prezime = osiguranje.Pacijent.Prezime
                        }
                    });
                }
            }
            return osiguranja;
        }

        public static Racun nadjiRacun(int Id)
        {
            ISession s = DataLayer.GetSession();
            Racun racun = s.Query<Racun>().FirstOrDefault(x => x.Id == Id);
            s.Close();
            return racun;
        }
        public static void dodajRacun(RacunView r, bool f,long jmbgLekara,int idKartona)
        {
            try
            {
                Racun racun = nadjiRacun(r.Id);
                Lekar lekar = nadjiLekara(jmbgLekara);
                Pacijent pacijent = nadjiPacijenta(idKartona);
                using (ISession s = DataLayer.GetSession())
                {
                    if (f)
                    {
                        racun.Popust = r.Popust;
                        racun.VrstaUsluge = r.VrstaUsluge;
                        racun.Datum = r.Datum;
                        racun.Cena = r.Cena;
                        racun.Lekar = lekar;
                        racun.Pacijent = pacijent;
                    }
                    else
                    {
                        racun = new Racun
                        {
                            Popust = r.Popust,
                            VrstaUsluge = r.VrstaUsluge,
                            Datum = r.Datum,
                            Cena = r.Cena,
                            Lekar = lekar,
                            Pacijent = pacijent
                        };
                    }


                    s.SaveOrUpdate(racun);
                    s.Flush();
                    s.Close();
                }
            }
            catch (Exception ex)
            {

            }
        }

        public static void brisiRacun(int id)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Racun t = s.Load<Racun>(id);

                s.Delete(t);
                s.Flush();

                s.Close();
            }
            catch (Exception ec)
            {

            }
        }

        public static List<RacunView> prikazRacuna()
        {
            List<RacunView> racuni = new List<RacunView>();

            using (ISession s = DataLayer.GetSession())
            {
                var r = s.Query<Racun>().Fetch(x => x.Pacijent).Fetch(x => x.Lekar);

                foreach (Racun racun in r)
                {
                    racuni.Add(new RacunView
                    {
                        Id = racun.Id,
                        Popust = racun.Popust,
                        VrstaUsluge = racun.VrstaUsluge,
                        Datum = racun.Datum,
                        Cena = racun.Cena,

                        Pacijent = new PacijentView
                        {
                            IdKartona = racun.Pacijent.IdKartona,
                            Ime = racun.Pacijent.Ime,
                            Prezime = racun.Pacijent.Prezime
                        },

                        Lekar = new LekarView
                        {
                            JMBG = racun.Lekar.JMBG,
                            Ime = racun.Lekar.Ime,
                            Prezime = racun.Lekar.Prezime
                        }
                    });
                }
            }
            return racuni;
        }

        public static Pregled dodajPregled(PregledView p, bool f,int idKartona,long jmbgLekara,int idTermina,string nazivOdeljenja,int idPrethodnogPregleda)
        {
            try
            {
                Pregled dodatni = null;
                Pregled pregled = nadjiPregled(p.IdPregleda);

                Pregled prethodni = nadjiPregled(idPrethodnogPregleda);
                

                Pacijent pacijent = nadjiPacijenta(idKartona);
                Lekar lekar = nadjiLekara(jmbgLekara);
                Termin termin = nadjiTermin(idTermina);
                Odeljenje odeljenje = nadjiOdeljenje(nazivOdeljenja);
                using (ISession s = DataLayer.GetSession())
                {

                    if (f)
                    {


                        pregled.Pacijent = pacijent;
                        pregled.Lekar = lekar;
                        pregled.Termin = termin;
                        pregled.Odeljenje = odeljenje;
                        pregled.Vreme = p.Vreme;
                        pregled.Datum = p.Datum;
                        pregled.OpisTegoba = p.OpisTegoba;
                        pregled.Dijagnoza = p.Dijagnoza;
                        pregled.PreporukaZaLecenje = p.PreporukaZaLecenje;
                        pregled.Terapija = p.Terapija;
                        pregled.VrstaPregleda = p.VrstaPregleda;
                        s.SaveOrUpdate(pregled);
                        s.Flush();
                    }
                    else
                    {


                        pregled = new Pregled
                        {
                            Pacijent = pacijent,
                            Lekar = lekar,
                            Termin = termin,
                            Odeljenje = odeljenje,
                            Vreme = p.Vreme,
                            Datum = p.Datum,
                            OpisTegoba = p.OpisTegoba,
                            Dijagnoza = p.Dijagnoza,
                            PreporukaZaLecenje = p.PreporukaZaLecenje,
                            Terapija = p.Terapija,
                            VrstaPregleda = p.VrstaPregleda,

                        };
                        if(prethodni != null)
                        {
                            prethodni.DodatniPregled = pregled;
                            s.SaveOrUpdate(prethodni);
                            s.Flush();
                        }
                        else
                        {
                            s.SaveOrUpdate(pregled);
                            s.Flush();
                        }
                    }

                    s.Close();
                    return pregled;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }


        public static void brisiPregled(int id)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Pregled pregled = s.Load<Pregled>(id);
                if (pregled.DodatniPregled != null)
                {
                    Pregled dodatni = s.Load<Pregled>(pregled.DodatniPregled.IdPregleda);
                    s.Delete(dodatni);
                }
                s.Delete(pregled);
                s.Flush();

                s.Close();
            }
            catch (Exception ec)
            {


            }
        }

        public static List<PregledView> prikazPregleda()
        {
            List<PregledView> pregledi = new List<PregledView>();

            using (ISession s = DataLayer.GetSession())
            {

                var t = s.Query<Pregled>()
                    .Fetch(x => x.Pacijent)
                    .Fetch(x => x.Lekar)
                    .Fetch(x => x.Odeljenje)
                    .Fetch(x => x.Termin)
                    .ToList();

                foreach (Pregled pregled in t)
                {

                    pregledi.Add(new PregledView
                    {
                        IdPregleda = pregled.IdPregleda,
                        Datum = pregled.Datum,
                        Vreme = pregled.Vreme,
                        OpisTegoba = pregled.OpisTegoba,
                        Dijagnoza = pregled.Dijagnoza,
                        Terapija = pregled.Terapija,
                        PreporukaZaLecenje = pregled.PreporukaZaLecenje,
                        VrstaPregleda = pregled.VrstaPregleda,
                        Pacijent = new PacijentView
                        {
                            IdKartona = pregled.Pacijent.IdKartona,
                            Ime = pregled.Pacijent.Ime,
                            Prezime = pregled.Pacijent.Prezime
                        },
                        Lekar = new LekarView
                        {
                            JMBG = pregled.Lekar.JMBG,
                            Ime = pregled.Lekar.Ime,
                            Prezime = pregled.Lekar.Prezime
                        },
                        Odeljenje = new OdeljenjeView
                        {
                            Naziv = pregled.Odeljenje.Naziv
                        },
                        Termin = new TerminView
                        {
                            Datum = pregled.Termin.Datum,
                            Vreme = pregled.Termin.Vreme
                        },

                    });
                }
            }

            return pregledi;
        }

        public static Placanje nadjiPlacanje(int Id)
        {
            ISession s = DataLayer.GetSession();
            Placanje placanje = s.Query<Placanje>().FirstOrDefault(x => x.IdPlacanja == Id);
            s.Close();
            return placanje;
        }

        public static void dodajPlacanje(PlacanjeView p, bool f,int idRFZO, int idPrivatnogOsiguranja, int idRacuna)
        {
            try
            {
                Placanje placanje = nadjiPlacanje(p.IdPlacanja);
                RFZO rfzo = nadjiRFZO(idRFZO);
                PrivatnoOsiguranje priv = nadjiPrivatnoOsiguranje(idPrivatnogOsiguranja);
                Racun racun = nadjiRacun(idRacuna);

                if(racun.Placanje != null && !f)
                {
                    return;
                }
                using (ISession s = DataLayer.GetSession())
                {

                    if (f)
                    {
                        placanje.ProcenatPacijenta = p.ProcenatPacijenta;
                        placanje.NacinPlacanja = p.NacinPlacanja;
                        placanje.PlatioPacijent = p.PlatioPacijent;
                        placanje.Racun = racun;
                        placanje.PrivatnoOsiguranje = priv;
                        placanje.RFZO = rfzo;
                    }
                    else
                    {
                        placanje = new Placanje
                        {
                            ProcenatPacijenta = p.ProcenatPacijenta,
                            NacinPlacanja = p.NacinPlacanja,
                            PlatioPacijent = p.PlatioPacijent,
                            Racun = racun,
                            PrivatnoOsiguranje = priv,
                            RFZO = rfzo,
                        };
                    }




                    s.SaveOrUpdate(placanje);
                    s.Flush();
                    s.Close();
                }
            }
            catch (Exception ex)
            {

            }
        }

        public static void brisiPlacanje(int id)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Placanje t = s.Load<Placanje>(id);

                s.Delete(t);
                s.Flush();

                s.Close();
            }
            catch (Exception ec)
            {

            }
        }

        public static List<PlacanjeView> prikazPlacanja()
        {
            List<PlacanjeView> placanja = new List<PlacanjeView>();

            using (ISession s = DataLayer.GetSession())
            {
                var r = s.Query<Placanje>().Fetch(x => x.Racun).Fetch(x => x.RFZO).Fetch(x => x.PrivatnoOsiguranje).ToList();



                foreach (Placanje placanje in r)
                {
                    placanja.Add(new PlacanjeView
                    {
                        IdPlacanja = placanje.IdPlacanja,
                        ProcenatPacijenta = placanje.ProcenatPacijenta,
                        NacinPlacanja = placanje.NacinPlacanja,
                        PlatioPacijent = placanje.PlatioPacijent,

                        Racun = new RacunView
                        {
                            Id = placanje.Racun.Id,
                            VrstaUsluge = placanje.Racun.VrstaUsluge,
                        },
                        PrivatnoOsiguranje = placanje.PrivatnoOsiguranje != null ? new PrivatnoOsiguranjeView
                        {
                            IdOsiguranja = placanje.PrivatnoOsiguranje.IdOsiguranja,
                            OsiguravajucaKuca = placanje.PrivatnoOsiguranje.OsiguravajucaKuca,
                            BrPolise = placanje.PrivatnoOsiguranje.BrPolise
                        } : null,
                        RFZO = placanje.RFZO != null ? new RFZOView
                        {
                            IdOsiguranja = placanje.RFZO.IdOsiguranja,

                        } : null
                    });
                }
            }
            return placanja;
        }
    }
}

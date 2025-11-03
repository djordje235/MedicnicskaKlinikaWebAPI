using DatabaseAccess.DTOs;
using DatabaseAccess.Entiteti;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseAccess
{
    public static class DataProvider
    {
        public static void dodajAdministrativnoOsoblje(AdministrativnoOsobljeView a, List<string> emails, List<string> telefons, List<string> odeljenja,string AdresaLokacije)
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
    }
}

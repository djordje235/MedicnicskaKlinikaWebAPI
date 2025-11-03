using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatabaseAccess.Mapiranja;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace DatabaseAccess
{
    class DataLayer
    {
        private static ISessionFactory _factory = null;
        private static object objLock = new object();



        public static ISession GetSession()
        {

            if (_factory == null)
            {
                lock (objLock)
                {
                    if (_factory == null)
                        _factory = CreateSessionFactory();
                }
            }

            return _factory.OpenSession();
        }


        private static ISessionFactory CreateSessionFactory()
        {
            try
            {
                var cfg = OracleManagedDataClientConfiguration.Oracle10
                .ShowSql()
                .ConnectionString(c =>
                    c.Is("Data Source=gislab-oracle.elfak.ni.ac.rs:1521/SBP_PDB;User Id=S19376;Password=S19376"));

                return Fluently.Configure()
                    .Database(cfg)
                    .Mappings(m => m.FluentMappings.AddFromAssemblyOf<ZaposlenMaper>())
                    .BuildSessionFactory();
            }
            catch (Exception ec)
            {
                //System.Windows.Forms.MessageBox.Show(
                //   $"Greška pri kreiranju SessionFactory:\n\n{ec.Message}\n\nDetalji:\n{ec.StackTrace}\n\nInnerException:\n{ec.InnerException?.Message}\n\nInner Inner:\n{ec.InnerException?.InnerException?.Message}"
                //);
                Console.Error.WriteLine(ec.Message);
                return null;
            }

        }
    }
}
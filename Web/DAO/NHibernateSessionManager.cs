using System;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Tool.hbm2ddl;
using Web.Dominio;
using log4net;
using log4net.Config;

namespace Web.DAO
{
	public class NHibernateSessionManager
	{
		private static readonly log4net.ILog log = log4net.LogManager.GetLogger (System.Reflection.MethodBase.GetCurrentMethod ().DeclaringType);

		private Configuration Config;
		private ISessionFactory SessionFactory;
		private ISession Session;
					
		public NHibernateSessionManager ()
		{
			log.Debug("Inicializando hibernate2232313");
			log.Debug("Cargando fichero"+AppDomain.CurrentDomain.BaseDirectory);
			Config = new Configuration ();
			
			Configure ();
			SessionFactory = Config.BuildSessionFactory ();
		}
		
		private void Configure ()
		{
//			Config.Configure("./hibernate.cfg.xml");
			log.Debug("Cargando fichero"+AppDomain.CurrentDomain.BaseDirectory);
			Config.Configure(AppDomain.CurrentDomain.BaseDirectory + "hibernate.cfg.xml");

			Config.AddAssembly("Web");
		}
		
		public ISession OpenSession ()
		{
			if (Session == null) {
				Session = SessionFactory.OpenSession ();
			}
			return Session;
		}
		
		public void CloseSession ()
		{
			if (Session != null && Session.IsOpen) {
				Session.Flush ();
				Session.Close ();
			}
			
			Session = null;
			
		}
		
			
	}
}


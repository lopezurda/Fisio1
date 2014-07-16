using System;
using System.IO;
using System.Web;
using System.Web.UI;
using Web.Dominio;
using Web.DAO;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Tool.hbm2ddl;
using Web;
using log4net;
using log4net.Config;


namespace Web
{
	
	
	public partial class Default : System.Web.UI.Page
	{
		private static readonly log4net.ILog log = log4net.LogManager.GetLogger (System.Reflection.MethodBase.GetCurrentMethod ().DeclaringType);
		
		
		public Default ()
		{

			FileInfo log4netFile=new FileInfo(AppDomain.CurrentDomain.BaseDirectory + "log4net.xml");
			log.Debug("Cargando fichero"+log4netFile.Name);
			XmlConfigurator.Configure(log4netFile);
		}

		protected void Page_Load (object sender, EventArgs e)
		{
			
			log.Info ("Cargando pagina");
		}
		
		protected void okf_Click (object sender, EventArgs e)
		{
			
			log.Info ("Cargando pagina");
		}
		
	}
}


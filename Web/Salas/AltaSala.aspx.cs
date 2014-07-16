using System;
using System.Web;
using System.Web.UI;
using log4net;
using Web.Dominio;
using Web.DAO;

namespace Web
{
	public partial class AltaSala : System.Web.UI.Page
	{
		private static readonly log4net.ILog log = log4net.LogManager.GetLogger (System.Reflection.MethodBase.GetCurrentMethod ().DeclaringType);
		
		protected void btnGrabar_Click (object sender, EventArgs e)
		{
			log.Info("Inicio AltaSala......");
			NHibernateSessionManager sessionManager = new NHibernateSessionManager ();		
			IDao<Sala > salaDao = new Dao<Sala> (sessionManager); 
			
			log.Debug ("Completamos sala");
			Sala sala = new Sala ();
			sala.Nombre = txtNombre.Text;
			sala.Descripcion=txtDescripcion.Text;
			sala.Habilitada=chkHabilitadoAltaSala.Checked;

			log.Debug ("Guardando Sala.......");
			salaDao.SaveOrUpdate (sala);
			log.Debug ("Sala guardada OK");
			lblResultadoOperacion.Text="Sala guardada correctamente.";
		}	
		
	}
}


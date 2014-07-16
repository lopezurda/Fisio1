using System;
using System.Web;
using System.Web.UI;
using NHibernate;
using NHibernate.Criterion;
using Web.Dominio;
using Web.DAO;
using log4net;
using System.Collections.Generic;

[assembly: log4net.Config.XmlConfigurator(Watch=true)]
namespace Web
{
	public partial class BusquedaPersona : System.Web.UI.Page
	{
		private static readonly log4net.ILog log = log4net.LogManager.GetLogger (System.Reflection.MethodBase.GetCurrentMethod ().DeclaringType);
		
		
		protected void btnBuscar_Click (object sender, EventArgs e)
		{
			log.Info ("Inicio busqueda de personas");
			
			NHibernateSessionManager SessionManager = new NHibernateSessionManager ();	
			ISession session = SessionManager.OpenSession ();
			
			bool buscar = false;
			ICriteria criteriaPersona = session.CreateCriteria (typeof(Persona));
			string nombre = txtNombre.Text;
			if (nombre != null && !nombre.Equals ("")) {
				criteriaPersona.Add (Expression.Eq ("Nombre", nombre));
				log.Debug ("Añadido criteria de nombre: " + nombre);
				buscar = true;
			}
			string nif = txtNIF.Text;
			if (nif != null && !nif.Equals ("")) {
				criteriaPersona.Add (Expression.Eq ("NIF", nif));
				log.Debug ("Añadido criteria de NIF: " + nif);
				buscar = true;
			}	
			IList<Persona > resultado = null;
			
			if (buscar) {				
				resultado = criteriaPersona.List<Persona> ();
				log.Info ("Recuperadas " + resultado.Count + " personas");
				Context.Items.Add ("personasRecuperadas", resultado);
				Server.Transfer ("~/Personas/MostrarPersona.aspx");
//				Response.Redirect ("MostrarPersona.aspx");
			} else {
				
			}
			
			log.Info ("Fin busqueda de persona");
			
		}
		
	}
}


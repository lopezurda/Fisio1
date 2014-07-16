using System;
using System.Web;
using System.Web.UI;
using NHibernate;
using NHibernate.Criterion;
using Web.Dominio;
using Web.DAO;
using log4net;
using log4net.Config;
using System.Collections.Generic;

namespace Web.Fisioterapeutas
{
	public partial class BusquedaFisioterapeuta : System.Web.UI.Page
	{
		private static readonly log4net.ILog log = log4net.LogManager.GetLogger (System.Reflection.MethodBase.GetCurrentMethod ().DeclaringType);
		
		public BusquedaFisioterapeuta ()
		{

		}
		
		protected void btnBuscarFisioterapeuta_Click (object sender, EventArgs e)
		{	

			log.Info ("Inicio busqueda de fisioterapeuta");
			
			NHibernateSessionManager SessionManager = new NHibernateSessionManager ();	
			ISession session = SessionManager.OpenSession ();
			
			bool buscar = false;
			ICriteria criteriaFisioterapeuta = session.CreateCriteria (typeof(Fisioterapeuta));
			criteriaFisioterapeuta.CreateAlias("DatosPersonales","DatosPersonales");
			string nombre = txtNombre.Text;
			if (nombre != null && !nombre.Equals ("")) {
				criteriaFisioterapeuta.Add (Expression.Eq ("DatosPersonales.Nombre", nombre));
				log.Debug ("Añadido criteria de nombre: " + nombre);
				buscar = true;
			}
			string apellido1 = txtApellido1.Text;
			if (apellido1 != null && !apellido1.Equals ("")) {
				criteriaFisioterapeuta.Add (Expression.Eq ("DatosPersonales.Apellido1", apellido1));
				log.Debug ("Añadido criteria de apellido1: " + nombre);
				buscar = true;
			}
			string apellido2 = txtApellido2.Text;
			if (apellido2 != null && !apellido2.Equals ("")) {
				criteriaFisioterapeuta.Add (Expression.Eq ("DatosPersonales.Apellido2", apellido2));
				log.Debug ("Añadido criteria de apellido1: " + nombre);
				buscar = true;
			}
			string nif = txtNIF.Text;
			if (nif != null && !nif.Equals ("")) {
				criteriaFisioterapeuta.Add (Expression.Eq ("DatosPersonales.NIF", nif));
				log.Debug ("Añadido criteria de NIF: " + nif);
				buscar = true;
			}	
			IList<Fisioterapeuta> resultado = null;
			
			if (buscar) {				
				resultado = criteriaFisioterapeuta.List<Fisioterapeuta> ();
				log.Info ("Recuperados " + resultado.Count + " fisioterapeutas");
				if(resultado.Count>0){
//					Context.Items.Add ("pacientesRecuperados", resultado);
					Session["fisioterapeutasRecuperados"] = resultado;
//					Server.Transfer ("~/Fisioterapeutas/MostrarFisioterapeuta.aspx",false);
					Response.Redirect ("~/Fisioterapeutas/MostrarFisioterapeuta.aspx");
				}
				else{
					log.Info ("Fin busqueda de fisioterapeuta");	
				}

			}
			
			
		}	
	}
}


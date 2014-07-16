using System;
using NHibernate;
using System.Collections.Generic;
using System.Web.UI.WebControls;
using Web.DAO;

namespace Web.Dominio
{
	public class Fisioterapeuta
	{
		private static readonly log4net.ILog log = log4net.LogManager.GetLogger (System.Reflection.MethodBase.GetCurrentMethod ().DeclaringType);
		
		public Fisioterapeuta ()
		{	
			
		}
		
		public Fisioterapeuta (int id)
		{
			this.Id = id;
		}
		
		
		public virtual int Id { get;set; }	
		public virtual int NumeroColegiado { get;set; }	
		public virtual DateTime FechaIngreso { get; set; }
		public virtual DateTime FechaBaja { get; set; }
		public virtual DateTime FechaTitulacion { get; set; }
		public virtual Persona DatosPersonales { get; set; }
		public virtual Titulacion Titulacion { get; set; }
		public virtual TipoContrato TipoContrato { get; set; }
		public virtual ProyectoContratacion ProyectoContratacion { get; set; }
		
		public static ListItem[] getFisioterapeutasActivos(){
			NHibernateSessionManager sessionManager = new NHibernateSessionManager ();
			ISession session=sessionManager.OpenSession();
			IQuery query=session.GetNamedQuery("getFisioterapeutasActivos");	
			IList<Fisioterapeuta> fisioterapeutas=query.List<Fisioterapeuta>();
			log.Debug("Recuperados "+fisioterapeutas.Count+" fisioterapeutas vigentes para la fecha: "+DateTime.Now);
			
			ListItem[] fisioterapeutasCombo=new ListItem[fisioterapeutas.Count];
			int i=0;
			foreach(Fisioterapeuta fisioterapeuta in fisioterapeutas){
				fisioterapeutasCombo[i++]=new ListItem(fisioterapeuta.DatosPersonales.Nombre,fisioterapeuta.Id.ToString());				
			}
			
			return fisioterapeutasCombo;
		}
			
	}
}

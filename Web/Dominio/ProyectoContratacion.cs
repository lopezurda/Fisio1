using System;
using NHibernate;
using System.Collections.Generic;
using System.Web.UI.WebControls;
using Web.DAO;

namespace Web.Dominio
{
	public class ProyectoContratacion
	{
		private static readonly log4net.ILog log = log4net.LogManager.GetLogger (System.Reflection.MethodBase.GetCurrentMethod ().DeclaringType);
		
		public ProyectoContratacion ()
		{
		}
		
		public ProyectoContratacion (int id)
		{
			this.Id = id;
		}
		
		
		public virtual int Id { get;set; }		
		public virtual string Nombre { get; set; }
		public virtual DateTime FechaInicio { get; set; }
		public virtual DateTime FechaFin { get; set; }
		public virtual EntidadFinanciadora EntidadFinanciadora { get; set; }
		
		private static NHibernateSessionManager sessionManager = new NHibernateSessionManager ();
		
		//Recupera todas los proyectos de contratación.
		public static ListItem[] getProyectosContratacion(){			
			
			IDao<ProyectoContratacion> proyectosContratacionDao = new Dao<ProyectoContratacion> (sessionManager); 
			IList<ProyectoContratacion> proyectosContratacion=(proyectosContratacionDao.GetAll<ProyectoContratacion>()) as IList<ProyectoContratacion>;
				
			ListItem[] proyectosContratacionCombo=new ListItem[proyectosContratacion.Count];
			for(int i=0;i<proyectosContratacion.Count;i++){
				proyectosContratacionCombo[i]=new ListItem(proyectosContratacion[i].Nombre,proyectosContratacion[i].Id.ToString());				
			}
			
			return proyectosContratacionCombo;
		}
		
		//Recupera todas los proyectos de contratación.
		public static IList<ProyectoContratacion> getProyectosContratacionVigentes(){
			
			ISession session=sessionManager.OpenSession();
			IQuery query=session.GetNamedQuery("getProyectosContratacionVigentes");	
			DateTime fechaActual=DateTime.Now;
			query.SetDateTime("fechaActual",fechaActual);			
			IList<ProyectoContratacion> proyectosContratacion=query.List<ProyectoContratacion>();
			log.Debug("Recuperados "+proyectosContratacion.Count+" proyectos de contratación vigentes para la fecha: "+fechaActual);
			
			return proyectosContratacion;
		}
	}
}


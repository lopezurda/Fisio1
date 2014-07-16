using System;
using NHibernate;
using System.Collections.Generic;
using System.Web.UI.WebControls;
using Web.DAO;


namespace Web.Dominio
{
	public class Cita
	{
		
		private static readonly log4net.ILog log = log4net.LogManager.GetLogger (System.Reflection.MethodBase.GetCurrentMethod ().DeclaringType);
		
		public Cita ()
		{
			
		}
		
		public virtual int Id { get;set; }
		public virtual DateTime Fecha { get;set; }
		public virtual HistoriaClinica HistoriaClinica { get;set; }
		public virtual Fisioterapeuta Fisioterapeuta { get;set; }
		public virtual Sala Sala { get;set; }
		
		public static IList<Cita> getCitasByDia(DateTime fechaBusqueda){
			NHibernateSessionManager sessionManager = new NHibernateSessionManager ();
			ISession session=sessionManager.OpenSession();			
			IQuery query=session.GetNamedQuery("getCitasByDia");
			TimeSpan resetDate=new TimeSpan(0,0,0);			
			fechaBusqueda=fechaBusqueda.Date+resetDate;
			query.SetDateTime("fechaInicioDia",fechaBusqueda);
			resetDate=new TimeSpan(23,59,59);			
			fechaBusqueda=fechaBusqueda.Date+resetDate;
			query.SetDateTime("fechaFinDia",fechaBusqueda);			
			
			IList<Cita> citas=query.List<Cita>();
			log.Debug("Recuperados "+citas.Count+" para la fecha: "+fechaBusqueda);
			
			return citas;
		}

	}
}


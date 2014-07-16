using System;
using NHibernate;
using System.Collections.Generic;
using System.Web.UI.WebControls;
using Web.DAO;

namespace Web.Dominio
{
	public class Sala
	{
		private static readonly log4net.ILog log = log4net.LogManager.GetLogger (System.Reflection.MethodBase.GetCurrentMethod ().DeclaringType);
		
		
		//Constructor
		public Sala ()
		{

		}
		
		public Sala (int id)
		{
			this.Id = id;
		}
					
		public virtual int Id { get;set; }		
		public virtual String Nombre { get; set; }
		public virtual String Descripcion { get; set; }
		public virtual Boolean Habilitada { get; set; }
		
		
		public static ListItem[] getComboSalasActivas(){
	
			IList<Sala> salas=getSalasActivas();
			
			ListItem[] salasCombo=new ListItem[salas.Count];
			int i=0;
			foreach(Sala sala in salas){
				salasCombo[i++]=new ListItem(sala.Nombre,sala.Id.ToString());				
			}
			
			return salasCombo;
		}
		
		public static IList<Sala> getSalasActivas(){
			NHibernateSessionManager sessionManager = new NHibernateSessionManager ();
			ISession session=sessionManager.OpenSession();
			IQuery query=session.GetNamedQuery("getSalasHabilitadas");	
			IList<Sala> salas=query.List<Sala>();
			log.Debug("Recuperadas "+salas.Count+" salas hablitidas.");
			return salas;
		}
	}
}


using System;
using Web.DAO;
using System.Collections.Generic;
using System.Web.UI.WebControls;

namespace Web.Dominio
{
	public class Estudios
	{
	
		public virtual int Id { get;set; }		
		public virtual string Nombre { get; set; }		
	
		public Estudios ()
		{
		}
		
		public Estudios (int id)
		{
			this.Id = id;
		}
			
		public static ListItem[] getEstudios(){
			NHibernateSessionManager sessionManager = new NHibernateSessionManager ();
			
			IDao<Estudios> estudiosDao = new Dao<Estudios> (sessionManager); 
			IList<Estudios> estudios=(estudiosDao.GetAll<Estudios>()) as IList<Estudios>;
				
			ListItem[] estudiosCombo=new ListItem[estudios.Count];
			for(int i=0;i<estudios.Count;i++){
				estudiosCombo[i]=new ListItem(estudios[i].Nombre,estudios[i].Id.ToString());				
			}
			
			return estudiosCombo;
		}
	}
}


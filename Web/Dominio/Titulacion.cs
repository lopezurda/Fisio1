using System;
using Web.DAO;
using System.Collections.Generic;
using System.Web.UI.WebControls;

namespace Web.Dominio
{
	public class Titulacion
	{
		public Titulacion ()
		{
		}
		
		public Titulacion (int id)
		{
			this.Id = id;
		}		
		
		public virtual int Id { get;set; }		
		public virtual string Nombre { get; set; }
		
		//Recupera todas las titulaciones
		public static ListItem[] getTitulaciones(){
			NHibernateSessionManager sessionManager = new NHibernateSessionManager ();
			
			IDao<Titulacion> titulacionesDao = new Dao<Titulacion> (sessionManager); 
			IList<Titulacion> titulaciones=(titulacionesDao.GetAll<Titulacion>()) as IList<Titulacion>;
				
			ListItem[] titulacionesCombo=new ListItem[titulaciones.Count];
			for(int i=0;i<titulaciones.Count;i++){
				titulacionesCombo[i]=new ListItem(titulaciones[i].Nombre,titulaciones[i].Id.ToString());				
			}
			
			return titulacionesCombo;
		}
	}
}


using System;
using Web.DAO;
using System.Collections.Generic;
using System.Web.UI.WebControls;

namespace Web.Dominio
{
	public class GrupoTratamiento
	{
		public GrupoTratamiento ()
		{
		}
		
		public virtual int Id { get;set; }		
		public virtual string Nombre { get; set; }
		public virtual int SesionesPorDefecto { get;set; }
		public virtual int Sesiones { get;set; }
		
		
		public static ListItem[] getGruposTratamiento(){
			NHibernateSessionManager sessionManager = new NHibernateSessionManager ();
			IDao<GrupoTratamiento> grupoTratamientoDao = new Dao<GrupoTratamiento> (sessionManager); 
			IList<GrupoTratamiento> gruposTratamiento=(grupoTratamientoDao.GetAll<GrupoTratamiento>()) as IList<GrupoTratamiento>;
				
			ListItem[] gruposTratamientoCombo=new ListItem[gruposTratamiento.Count];
			for(int i=0;i<gruposTratamiento.Count;i++){
				gruposTratamientoCombo[i]=new ListItem(gruposTratamiento[i].Nombre,gruposTratamiento[i].Id.ToString());				
			}
			
			return gruposTratamientoCombo;
		}
	}
}


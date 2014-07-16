using System;
using Web.DAO;
using System.Collections.Generic;
using System.Web.UI.WebControls;

namespace Web.Dominio
{
	public class TipoContrato
	{
		public TipoContrato ()
		{
		}
		
		public TipoContrato (int id)
		{
			this.Id = id;
		}
		
		
		public virtual int Id { get;set; }		
		public virtual string Nombre { get; set; }
		
		//Recupera todas las titulaciones
		public static ListItem[] getTiposContrato(){
			NHibernateSessionManager sessionManager = new NHibernateSessionManager ();
			
			IDao<TipoContrato> tiposContratoDao = new Dao<TipoContrato> (sessionManager); 
			IList<TipoContrato> tiposContrato=(tiposContratoDao.GetAll<TipoContrato>()) as IList<TipoContrato>;
				
			ListItem[] tiposContratoCombo=new ListItem[tiposContrato.Count];
			for(int i=0;i<tiposContrato.Count;i++){
				tiposContratoCombo[i]=new ListItem(tiposContrato[i].Nombre,tiposContrato[i].Id.ToString());				
			}
			
			return tiposContratoCombo;
		}
	}
}


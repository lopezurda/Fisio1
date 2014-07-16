using Web.DAO;
using System.Collections.Generic;
using System.Web.UI.WebControls;

namespace Web.Dominio
{
	public class Provincia
	{
		public Provincia ()
		{
		}
		public Provincia (int id)
		{
			this.Id = id;
		}
		
		
		public virtual int Id { get;set; }		
		public virtual string Nombre { get; set; }
		public const int PROVINCIA_MADRID=27; 
		
		public static ListItem[] getProvincias(){
			NHibernateSessionManager sessionManager = new NHibernateSessionManager ();		

			IDao<Provincia> provinciasDao = new Dao<Provincia> (sessionManager); 
			IList<Provincia> provincias=(provinciasDao.GetAll<Provincia>()) as IList<Provincia>;
			
			
			ListItem[] provinciasCombo=new ListItem[provincias.Count];
			
			for(int i=0;i<provincias.Count;i++){
				int idProvincia=provincias[i].Id;
				provinciasCombo[i]=new ListItem(provincias[i].Nombre,idProvincia.ToString());				
			}
			
			return provinciasCombo;
		}
	}
}


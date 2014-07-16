using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;
using Web.DAO;
using NHibernate;

namespace Web.Dominio
{
	public class Estudio
	{		
		public virtual int Id { get;set; }
		public virtual string Nombre { get;set; }
		public virtual GrupoTratamiento GrupoTratamiento{ get;set; }
		
		static NHibernateSessionManager sessionManager = new NHibernateSessionManager ();
		
		public Estudio ()
		{
		}
		
		public Estudio (int id)
		{
			this.Id = id;
		}
		
		
		public static ListItem[] getEstudios(){			
			
			IDao<Estudio> estudioDao = new Dao<Estudio> (sessionManager); 
			IList<Estudio> estudios=(estudioDao.GetAll<Estudio>()) as IList<Estudio>;
				
			ListItem[] estudiosCombo=new ListItem[estudios.Count];
			for(int i=0;i<estudios.Count;i++){
				estudiosCombo[i]=new ListItem(estudios[i].Nombre,estudios[i].Id.ToString());				
			}
			
			return estudiosCombo;
		}
		
		public static GrupoTratamiento getGrupoTratamiento(int idEstudio){
			ISession session=sessionManager.OpenSession();
			IQuery query=session.GetNamedQuery("getGrupoTratamientoFromEstudio");			
			query.SetInt32("id",idEstudio);			
			GrupoTratamiento grupoTratamiento=query.UniqueResult<GrupoTratamiento>();
			
			return grupoTratamiento;
		}
	}
}


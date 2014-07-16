using System;
using System.Collections.Generic;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Tool.hbm2ddl;
using Web;

namespace Web.DAO
{
	public class Dao<T> : IDao<T>
	{
		private NHibernateSessionManager SessionManager;
	
		
		public Dao (NHibernateSessionManager sessionManager)
		{
		
			this.SessionManager = sessionManager;
		
		}
		
		public ISession GetSession ()
		{
			return SessionManager.OpenSession();
		}
		
		
		  public T GetById(int id) {

		    ISession session = GetSession();	 
		
		    return session.Get<T>(id);
		
		  }
		
		
		  public T SaveOrUpdate (T entity)
		{

			ISession session = GetSession ();
		
			session.SaveOrUpdate (entity);	
			
			SessionManager.CloseSession();
		
			return entity;
		
		}
		
		 
		
		  public void Delete(T entity) {
		
		    ISession session = GetSession();
		
		    session.Delete(entity);
			
			SessionManager.CloseSession();
		
		  }

		public IList<T> GetAll<T> () where T : class
		{
			ISession session = GetSession ();
			ICriteria criteria = session.CreateCriteria<T>();
            return criteria.List<T>();
		}
	}
}


/*
public abstract class GenericNHibernateDAO : GenericDAO

{

  /// Could be set using contruction injection IoC

  public GenericNHibernateDAO(ISessionManager sessionManager) {

    this.sessionManager = sessionManager;

  }

 

  public T GetById(IdDataType id, bool shouldLock) {

    ISession session = GetSession();

    T entity;

 

    if (shouldLock) {

      entity = (T) session.Load(persitentType, id, LockMode.Upgrade);

    }

    else {

      entity = (T) session.Load(persitentType, id);

    }

 

    return entity;

  }

 

  public List GetAll() {

    return GetByCriteria();

  }

 

  protected List GetByCriteria(params ICriterion[] criterion) {

    ISession session = GetSession();

    ICriteria criteria = session.CreateCriteria(persitentType);

    

    foreach (ICriterion criterium in criterion) {

      criteria.Add(criterium);

    }

    

    GenericUtils genericUtils = new GenericUtils();

    return genericUtils.ConvertToGenericList(criteria.List());

  }

 

  public List GetByExample(T exampleInstance, string[] propertiesToExclude) {

    ISession session = GetSession();

    ICriteria criteria = session.CreateCriteria(persitentType);

    Example example = Example.Create(exampleInstance);

 

    foreach (string propertyToExclude in propertiesToExclude) {

      example.ExcludeProperty(propertyToExclude);

    }

 

    criteria.Add(example);

 

    GenericUtils genericUtils = new GenericUtils();

    return genericUtils.ConvertToGenericList(criteria.List());

  }

 

  public T SaveOrUpdate(T entity) {

    ISession session = GetSession();

    session.SaveOrUpdate(entity);

 

    return entity;

  }

 

  public void Delete(T entity) {

    ISession session = GetSession();

    session.Delete(entity);

  }

 

  private ISession GetSession() {

    Check.Require(sessionManager != null, "sessionManager was not set");

    return sessionManager.OpenSession();

  }

 

  private Type persitentType = typeof(T);

  private ISessionManager sessionManager;

}
*/
 
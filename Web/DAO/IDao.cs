using System;
using System.Collections.Generic;
using NHibernate;

namespace Web.DAO
{
	public interface IDao<T>
	{
		ISession GetSession();
		
		T GetById(int id);

	  	IList<T> GetAll<T>() where T : class;
	
	  	T SaveOrUpdate(T entity);
	
	  	void Delete(T entity);
	}
}




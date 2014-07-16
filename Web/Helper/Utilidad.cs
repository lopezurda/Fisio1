using System;
using System.Web;
using System.Linq;
using System.Data;
using System.Reflection;
using System.Collections.Generic;

namespace Web.Helper
{
	public abstract class Utilidad
	{
		private static readonly log4net.ILog log = log4net.LogManager.GetLogger (System.Reflection.MethodBase.GetCurrentMethod ().DeclaringType);
				
		public Utilidad ()
		{
		}
		
		public static DateTime ParsearFecha(String fecha){
			String[] camposFecha = fecha.Split ('/');
			int dia = 0;
			int mes = 0;
			int anyo = 0;
			
			for (int i=0; i<camposFecha.Length; i++) {
				dia = Convert.ToInt32 (camposFecha [0]);
				mes = Convert.ToInt32 (camposFecha [1]);
				anyo = Convert.ToInt32 (camposFecha [2]);
			}
			DateTime fechaFormateada = new DateTime (anyo, mes, dia);
			
			return fechaFormateada;
		}
		
		//Convierte una lista en una DataTable para poder rellenar tablas
		public static DataTable ToDataTable<T>(IEnumerable<T> items)
        {
            DataTable tb = new DataTable(typeof(T).Name);

            PropertyInfo[] props = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);

            foreach (PropertyInfo prop in props)
                tb.Columns.Add(prop.Name, prop.PropertyType);

            foreach (T item in items)
            {
                object[] values = new object[props.Length];

                for (int i = 0; i < props.Length; i++)
                    values[i] = props[i].GetValue(item, null);

                tb.Rows.Add(values);
            }
			log.Debug("Convertidos "+tb.Rows.Count+" registros");
            return tb;
        }
	}
}


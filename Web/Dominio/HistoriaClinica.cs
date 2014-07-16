using System;
using Web.DAO;
using System.Collections.Generic;
using System.Web.UI.WebControls;

namespace Web.Dominio
{
	public class HistoriaClinica
	{
		public HistoriaClinica ()
		{
		}
				
		public virtual string NumeroHistoria { get;set; }		
		public virtual Paciente Paciente { get; set; }		
		public virtual IList<Cita> Citas { get; set; }

	}
}


using System;

namespace Web.Dominio
{
	public class EstadoPaciente
	{
		public EstadoPaciente ()
		{
		}
		
		public EstadoPaciente (int id)
		{
			this.Id = id;
		}		
		
		public virtual int Id { get;set; }		
		public virtual string Nombre { get; set; }	
	}
}


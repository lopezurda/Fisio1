using System;
using Web.Dominio;

namespace Web.Dominio
{
	
	
	public class Persona
	{	
		public Persona(){}

		public virtual int Id { get;set; }		
		public virtual string Nombre { get; set; }
		public virtual string Apellido1 { get; set; }
		public virtual string Apellido2 { get; set; }
	    public virtual string NIF { get; set; }
		public virtual string TelefonoFijo { get;set; }
		public virtual string TelefonoMovil { get;set; }
		public virtual string Email { get;set; }
		public virtual DateTime FechaNacimiento { get; set; }
		public virtual Direccion Direccion { get; set; }

	}
}


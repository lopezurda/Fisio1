using System;
using Web.Dominio;

namespace Web.Dominio
{
	public class Paciente
	{
		public Paciente ()
		{
			
		}
		
		public virtual int Id { get;set; }
		public virtual string Aficiones { get;set; }
		public virtual string Profesion { get;set; }
		public virtual bool Baja { get;set; }
		public virtual HistoriaClinica HistoriaClinica { get;set; }
		public virtual Estudios Estudios { get;set; }
		public virtual Persona DatosPersonales { get;set; }
		public virtual Estudio Estudio { get;set; }
		public virtual EstadoPaciente EstadoPaciente {get;set;}		

	}
}


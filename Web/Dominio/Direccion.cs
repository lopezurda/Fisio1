using System;

namespace Web.Dominio
{	

	public class Direccion
	{
		
		public Direccion ()
		{

		}
		
/*		
		private string Id;
		private string Name;
		private string Description;
		private int  Quantity;
		private int  Warningap;
*/			
		public virtual int Id { get;set; }		
		public virtual string Via { get; set; }
		public virtual int Numero { get; set; }
		public virtual string RestoDireccion { get; set; }
	    public virtual string CP { get; set; }
		public virtual string Localidad { get; set; }
		public virtual Provincia Provincia { get; set; }	
	}
}


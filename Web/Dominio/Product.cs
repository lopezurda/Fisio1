using System;

namespace Web.Dominio
{

	
	public class Product
	{
/*		
		private string Id;
		private string Name;
		private string Description;
		private int  Quantity;
		private int  Warningap;
*/			
		public virtual int Id { 
			get; 
			set;
		}
		public virtual string Name { get; set; }
	    public virtual string Description { get; set; }
	    public virtual int Quantity { get; set; }
		public virtual int WarningGap { get; set; }
//		public DateTime RepositionDa { get; set; }
		}
}


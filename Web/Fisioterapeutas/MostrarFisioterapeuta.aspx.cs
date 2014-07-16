using System;
using System.Web;
using System.Web.UI;
using log4net;
using System.Collections;
using System.Collections.Generic;
using Web.Dominio;

namespace Web.Fisioterapeutas
{
	public partial class MostrarFisioterapeuta : System.Web.UI.Page
	{
		private static readonly log4net.ILog log = log4net.LogManager.GetLogger (System.Reflection.MethodBase.GetCurrentMethod ().DeclaringType);
		
		protected void Page_Load (object sender, EventArgs e)
		{
			
			log.Info ("Mostrando fisioterapeuta");
			IList<Fisioterapeuta > fisioterapeutas = (Session["fisioterapeutasRecuperados"]) as IList<Fisioterapeuta>;
			Fisioterapeuta fisioterapeuta = fisioterapeutas [0];
			txtNumeroColegiado.Text=fisioterapeuta.NumeroColegiado.ToString();
			Titulacion titulacion=fisioterapeuta.Titulacion;
			txtTitulacion.Text=titulacion.Nombre;
			TipoContrato tipoContrato=fisioterapeuta.TipoContrato;
			txtTipoContrato.Text=tipoContrato.Nombre;
			txtFechaIngreso.Text=fisioterapeuta.FechaIngreso.ToString("dd/MM/yyyy");
			txtFechaTitulacion.Text=fisioterapeuta.FechaTitulacion.ToString("dd/MM/yyyy");
			DateTime fechaBaja=fisioterapeuta.FechaBaja;
			if(fechaBaja!=DateTime.MinValue){
				txtFechaBaja.Text=fechaBaja.ToString("dd/MM/yyyy");
			}
			
			Persona datosPersonales=fisioterapeuta.DatosPersonales;
			txtNombre.Text = datosPersonales.Nombre;
			txtApellido1.Text = datosPersonales.Apellido1;
			txtApellido2.Text = datosPersonales.Apellido2;
			txtFechaNacimiento.Text = datosPersonales.FechaNacimiento.ToString("dd/MM/yyyy");
			txtNIF.Text = datosPersonales.NIF;
			txtEmail.Text=datosPersonales.Email;
			txtTelefonoMovil.Text=datosPersonales.TelefonoMovil;
			txtTelefonoFijo.Text=datosPersonales.TelefonoFijo;
			Direccion direccion = datosPersonales.Direccion;
			txtCP.Text = direccion.CP;
			txtLocalidad.Text = direccion.Localidad;
			txtNumeroVia.Text = direccion.Numero.ToString();
			txtProvincia.Text = direccion.Provincia.Nombre;
			txtRestoDireccion.Text = direccion.RestoDireccion;
			txtVia.Text=direccion.Via;
			log.Info ("Fisioterapeuta mostrado");
		}
		
		protected void btnDarCita_Click (object sender, EventArgs e)
		{
		}
		protected void btnDarBaja_Click (object sender, EventArgs e)
		{
		}
		protected void btnDarAlta_Click (object sender, EventArgs e)
		{
		}
	}
}


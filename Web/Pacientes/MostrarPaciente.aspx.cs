using System;
using System.Web;
using System.Web.UI;
using log4net;
using System.Collections;
using System.Collections.Generic;
using Web.Dominio;

namespace Web
{
	public partial class MostrarPaciente : System.Web.UI.Page
	{
		
		private static readonly log4net.ILog log = log4net.LogManager.GetLogger (System.Reflection.MethodBase.GetCurrentMethod ().DeclaringType);
		private Paciente pacienteSeleccionado;
		
		protected void Page_Load (object sender, EventArgs e)
		{
			
			log.Info ("Mostrando paciente");
			IList<Paciente > pacientes = (Session["pacientesRecuperados"]) as IList<Paciente>;
//			IList<Paciente > pacientes = Context.Items ["pacientesRecuperados"] as IList<Paciente>;
			pacienteSeleccionado = pacientes [0];
			Persona datosPersonales=pacienteSeleccionado.DatosPersonales;
			txtNombre.Text = datosPersonales.Nombre;
			txtApellido1.Text = datosPersonales.Apellido1;
			txtApellido2.Text = datosPersonales.Apellido2;
			txtFechaNacimiento.Text = datosPersonales.FechaNacimiento.ToString("dd/MM/yyyy");
			txtNIF.Text = datosPersonales.NIF;
			Direccion direccion = datosPersonales.Direccion;
			txtCP.Text = direccion.CP;
			txtLocalidad.Text = direccion.Localidad;
			txtNumeroVia.Text = direccion.Numero.ToString();
			Provincia provincia=direccion.Provincia;
			txtProvincia.Text= provincia.Nombre;
			txtRestoDireccion.Text = direccion.RestoDireccion;
			txtVia.Text=direccion.Via;
			log.Info ("Paciente mostrado");
		}
		
		protected void btnDarCita_Click (object sender, EventArgs e)
		{
			log.Info ("Paciente seleccionado: "+pacienteSeleccionado);
			Session["pacienteDarCita"] = pacienteSeleccionado;
//			Server.Transfer ("~/Citas/DarCita.aspx",false);
			Response.Redirect ("~/Citas/DarCita.aspx");
		}
		
		protected void btnVerHistorial_Click (object sender, EventArgs e)
		{
		}
		
	}
}


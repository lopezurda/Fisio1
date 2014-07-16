using System;
using System.Web;
using System.Web.UI;
using NHibernate;
using Web.DAO;
using Web.Dominio;
using Web.Helper;
using log4net;
using log4net.Config;
using System.Collections.Generic;
using System.Web.UI.WebControls;

namespace Web
{
	public partial class AltaPaciente : System.Web.UI.Page
	{
		private static readonly log4net.ILog log = log4net.LogManager.GetLogger (System.Reflection.MethodBase.GetCurrentMethod ().DeclaringType);

		
		public AltaPaciente ()
		{
		}

		protected void Page_Load (object sender, EventArgs e)
		{
			log.Info ("Carga de estudios... ");
			if (!IsPostBack)
   			{
				//Se carga el combo de estudios.
				ListItem[] estudios=Estudios.getEstudios();
				ddlEstudios.Items.AddRange(estudios);
				//Se carga el combo de provincias y se selecciona Madrid por defecto.
				ListItem[] provincias=Provincia.getProvincias();
				ddlProvincias.Items.AddRange(provincias);
				ddlProvincias.SelectedIndex=Provincia.PROVINCIA_MADRID;
			}
		}
		
		
		protected void btnGrabar_Click (object sender, EventArgs e)
		{	

			log.Info ("Inicio Grabado Persona");
			NHibernateSessionManager sessionManager = new NHibernateSessionManager ();		
			IDao<Paciente > pacienteDao = new Dao<Paciente> (sessionManager); 
			// Se completan los datos del paciente
			log.Debug ("Completamos Persona");
			Paciente paciente=new Paciente();		
			paciente.Aficiones=txtAficiones.Text;
			paciente.Profesion=txtProfesion.Text;			
			
			Estudios estudios=new Estudios();
			estudios.Id=Convert.ToInt32(ddlEstudios.SelectedValue);
			paciente.Estudios=estudios;		
				
			Persona datosPersonales = new Persona ();
			datosPersonales.Nombre = txtNombre.Text;
			datosPersonales.Apellido1 = txtApellido1.Text;
			datosPersonales.Apellido2 = txtApellido2.Text;
			datosPersonales.NIF = txtNIF.Text;
			string fechaNacimientoFormulario = txtFechaNacimiento.Text;			
			DateTime fechaNacimiento = Utilidad.ParsearFecha(fechaNacimientoFormulario);
			datosPersonales.FechaNacimiento = fechaNacimiento; 
		
			log.Debug ("Completamos Direccion");
			Direccion direccion = new Direccion ();
			direccion.Via = txtVia.Text;
			direccion.Numero = Convert.ToInt16 (txtNumeroVia.Text);
			direccion.RestoDireccion = txtRestoDireccion.Text;
			direccion.CP = txtCP.Text;
			direccion.Localidad = txtLocalidad.Text;
			
			Provincia provincia=new Provincia();
			provincia.Id=Convert.ToInt32(ddlProvincias.SelectedValue);	
			direccion.Provincia = provincia;
			log.Debug ("Asignamos la Direccion de la Persona");
			datosPersonales.Direccion = direccion;
			
			datosPersonales.Email=txtEmail.Text;
			datosPersonales.TelefonoFijo=txtTelefonoFijo.Text;
			datosPersonales.TelefonoMovil=txtTelefonoMovil.Text;
			
			paciente.DatosPersonales=datosPersonales;
			
			HistoriaClinica historiaClinica=new HistoriaClinica();
			historiaClinica.NumeroHistoria=txtNumeroHistoria.Text;
			
			paciente.HistoriaClinica=historiaClinica;

			//Se graba el paciente
			log.Debug ("Guardando Paciente.......");
			paciente=pacienteDao.SaveOrUpdate (paciente);
			Session["paciente"] = paciente;
			Response.Redirect ("~/Pacientes/InicioTratamiento.aspx");
			log.Info ("Paciente guardado OK.");
		}	
		
	}
}




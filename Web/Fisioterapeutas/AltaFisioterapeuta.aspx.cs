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
	public partial class AltaFisioterapeuta : System.Web.UI.Page
	{
		
		private static readonly log4net.ILog log = log4net.LogManager.GetLogger (System.Reflection.MethodBase.GetCurrentMethod ().DeclaringType);

		protected void Page_Load (object sender, EventArgs e)
		{
			
			if (!IsPostBack)
   			{
				log.Debug ("Carga de tipos de contrato... ");
				ListItem[] tiposContrato=TipoContrato.getTiposContrato();
				ddlTiposContrato.Items.AddRange(tiposContrato);
				
				log.Debug ("Carga de titulaciones... ");
				ListItem[] titulaciones=Titulacion.getTitulaciones();
				ddlTitulaciones.Items.AddRange(titulaciones);
				
				//Se recuperan los proyectos de contratación vigentes y se cargan en el combo, se hace asi para poder ver el detalle. 
				log.Debug ("Carga de proyectos de contratación vigentes... ");
				IList<ProyectoContratacion> proyectosContratacion=ProyectoContratacion.getProyectosContratacionVigentes();

				ListItem[] proyectosContratacionCombo=new ListItem[proyectosContratacion.Count];
				for(int i=0;i<proyectosContratacion.Count;i++){
					proyectosContratacionCombo[i]=new ListItem(proyectosContratacion[i].Nombre,proyectosContratacion[i].Id.ToString());				
				}
				ddlProyectoContratacion.Items.AddRange(proyectosContratacionCombo);
				
				
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
			IDao<Fisioterapeuta> fisioterapeutaDao = new Dao<Fisioterapeuta> (sessionManager); 
			// Se completan los datos del paciente
			log.Debug ("Completamos Persona");
			Fisioterapeuta fisioterapeuta=new Fisioterapeuta(); 
			
			string fechaIngresoFormulario = txtFechaIngreso.Text;			
			DateTime fechaIngreso=Utilidad.ParsearFecha(fechaIngresoFormulario);			
			fisioterapeuta.FechaIngreso=fechaIngreso;
			fisioterapeuta.NumeroColegiado=Convert.ToInt32(txtNumeroColegiado.Text);
			
			string fechaTitulacionFormulario = txtFechaTitulacion.Text;			
			DateTime fechaTitulacion=Utilidad.ParsearFecha(fechaTitulacionFormulario);			
			fisioterapeuta.FechaTitulacion=fechaTitulacion;
			
			Titulacion titulacion=new Titulacion();
			titulacion.Id=Convert.ToInt16 (ddlTitulaciones.SelectedItem.Value);
			fisioterapeuta.Titulacion=titulacion;
			
			TipoContrato tipoContrato=new TipoContrato();
			tipoContrato.Id=Convert.ToInt16(ddlTiposContrato.SelectedItem.Value);
			fisioterapeuta.TipoContrato=tipoContrato;

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
			
			fisioterapeuta.DatosPersonales=datosPersonales;

			//Se graba el paciente
			log.Debug ("Guardando Fisioterapeuta.......");
			fisioterapeuta=fisioterapeutaDao.SaveOrUpdate (fisioterapeuta);
			log.Info ("Fisioterapeuta guardado OK.");
		}	
	}
}


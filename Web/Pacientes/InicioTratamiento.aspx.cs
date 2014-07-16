using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using log4net;
using System.Collections;
using Web.Dominio;
using Web.DAO;

namespace Web.Pacientes
{
	public partial class InicioTratamiento : System.Web.UI.Page
	{
				
		private static readonly log4net.ILog log = log4net.LogManager.GetLogger (System.Reflection.MethodBase.GetCurrentMethod ().DeclaringType);
		
		protected void Page_Load (object sender, EventArgs e)
		{
			
			log.Info ("Inicio tratamiento....");
			if(!IsPostBack){
				Paciente paciente = (Session["paciente"]) as Paciente;
			
				string etiquetaTitulo=lblBusquedaPaciente.Text;
				if(paciente!=null){
					lblBusquedaPaciente.Text=etiquetaTitulo+paciente.DatosPersonales.Nombre+" "+paciente.DatosPersonales.Apellido1;
				}
				else{
					lblBusquedaPaciente.Text=etiquetaTitulo+" yo";
				}
				
				
				NHibernateSessionManager sessionManager = new NHibernateSessionManager ();		
				
				IDao<Fisioterapeuta> fisioterapeutaDao = new Dao<Fisioterapeuta> (sessionManager); 
				IList<Fisioterapeuta> fisioterapeutas=(fisioterapeutaDao.GetAll<Fisioterapeuta>()) as IList<Fisioterapeuta>;
				
				for(int i=0;i<fisioterapeutas.Count;i++){
					string nombreFisioterapeuta=fisioterapeutas[i].DatosPersonales.Nombre+" "+fisioterapeutas[i].DatosPersonales.Apellido1+" "+fisioterapeutas[i].DatosPersonales.Apellido2;
					ddlFisioterapeuta.Items.Add(new ListItem(nombreFisioterapeuta,fisioterapeutas[i].Id.ToString()));				
				}
				//Se carga el combo de estudios.
				ListItem[] estudios=Estudio.getEstudios();
				ddlEstudio.Items.AddRange(estudios);
			
				setGrupoTratamientoSeleccionado(ddlEstudio.SelectedValue);
			}
		}
		
		protected void ddlEstudio_SelectedIndexChanged(object sender, EventArgs e)
        {			
			setGrupoTratamientoSeleccionado(ddlEstudio.SelectedValue);
		}
		
		protected void btnTerminar_Click (object sender, EventArgs e)
		{
			log.Info("Paciente dado de alta sin cita.");
			Response.Redirect ("~/Default.aspx");
		}
		
		protected void btnDarCita_Click (object sender, EventArgs e)
		{
		}
		
		private void setGrupoTratamientoSeleccionado(string idEstudio){
			int idEstudioSeleccionado=Convert.ToInt16(idEstudio);
			GrupoTratamiento grupoTratamientoSeleccionado=Estudio.getGrupoTratamiento(idEstudioSeleccionado);
			
			txtGrupoTratamiento.Text=grupoTratamientoSeleccionado.Nombre;
			txtNumeroSesionesDefecto.Text=grupoTratamientoSeleccionado.SesionesPorDefecto.ToString();
			txtNumeroSesiones.Text="";
		}
		
	}
}


using System;
using System.Web;
using System.Web.UI;
using System.Data;
using System.ComponentModel;
using NHibernate;
using NHibernate.Criterion;
using Web.Dominio;
using Web.DAO;
using Web.Helper;
using log4net;
using log4net.Config;
using System.Collections.Generic;
using System.Web.UI.WebControls;

namespace Web.Pacientes
{
	public partial class BusquedaPacientes : System.Web.UI.Page
	{
		
		private static readonly log4net.ILog log = log4net.LogManager.GetLogger (System.Reflection.MethodBase.GetCurrentMethod ().DeclaringType);

		
		public BusquedaPacientes ()
		{
			
		}
		
		protected void Page_Load (object sender, EventArgs e)
		{
		
			log.Info ("Inicio carga inicial busqueda de pacientes....");
			
			if(!IsPostBack){
				log.Debug("DataSource: "+resutadoBusquedaPAcientesGridView.SelectedDataKey);
				//Carga del combo de estudios.
				ListItem[] estudios=Estudio.getEstudios();
				ddlEstudio.Items.AddRange(estudios);
				//Carga de los grupos de tratamiento
				ListItem[] gruposTratamiento=GrupoTratamiento.getGruposTratamiento();
				ddlGruposTratamiento.Items.AddRange(gruposTratamiento);
				
				ListItem[] estadosPaciente=new ListItem[2];
				estadosPaciente[0]=new ListItem("Alta","1");
				estadosPaciente[1]=new ListItem("Baja","0");
				ddlEstadoPaciente.Items.AddRange(estadosPaciente);
			}
		}
		
		protected void btnBuscarPaciente_Click (object sender, EventArgs e)
		{	

			log.Info ("Inicio busqueda de pacientes");
			
			NHibernateSessionManager SessionManager = new NHibernateSessionManager ();	
			ISession session = SessionManager.OpenSession ();
			
			bool buscar = false;
			ICriteria criteriaPaciente = session.CreateCriteria (typeof(Paciente));
			criteriaPaciente.CreateAlias("HistoriaClinica","HistoriaClinica");
			criteriaPaciente.CreateAlias("DatosPersonales","DatosPersonales");
			string nombre = txtNombre.Text;
			if (nombre != null && !nombre.Equals ("")) {
				criteriaPaciente.Add (Expression.Eq ("DatosPersonales.Nombre", nombre));
				log.Debug ("Añadido criteria de nombre: " + nombre);
				buscar = true;
			}
			string apellido1 = txtApellido1.Text;
			if (apellido1 != null && !apellido1.Equals ("")) {
				criteriaPaciente.Add (Expression.Eq ("DatosPersonales.Apellido1", apellido1));
				log.Debug ("Añadido criteria de apellido1: " + apellido1);
				buscar = true;
			}
			string apellido2 = txtApellido2.Text;
			if (apellido2 != null && !apellido2.Equals ("")) {
				criteriaPaciente.Add (Expression.Eq ("DatosPersonales.Apellido2", apellido2));
				log.Debug ("Añadido criteria de apellido2: " + apellido2);
				buscar = true;
			}
			string nif = txtNIF.Text;
			if (nif != null && !nif.Equals ("")) {
				criteriaPaciente.Add (Expression.Eq ("DatosPersonales.NIF", nif));
				log.Debug ("Añadido criteria de NIF: " + nif);
				buscar = true;
			}	
			string historiaClinica = txtHistoriaClinica.Text;
			if (historiaClinica != null && !historiaClinica.Equals ("")) {
				criteriaPaciente.Add (Expression.Eq ("HistoriaClinica.NumeroHistoria", historiaClinica));
				log.Debug ("Añadido criteria de historia clinica: " + historiaClinica);
				buscar = true;
			}
			
			IList<Paciente> resultado = null;
			
			if (buscar) {				
				resultado = criteriaPaciente.List<Paciente> ();
				log.Info ("Recuperadas " + resultado.Count + " pacientes");
				if(resultado.Count==0){
//					resultadoBusquedaPacientesPanel.Visible=true;
//					resutadoBusquedaPAcientesGridView.DataBind();
					lblErrorBusqueda.Text="No se han encontrado pacientes con ese filtro. Inténtelo con otros filtros.";
				}
				else if(resultado.Count==1){
					
					Session["pacientesRecuperados"] = resultado;
					Response.Redirect ("~/Pacientes/MostrarPaciente.aspx");
				}
				else{
//					foreach(Paciente paciente in resultado){
//						BoundField columna=new BoundField ();
//						DataRow fila=new DataRow(DataRowBuilder builder);
//						string[] contenidoFila={paciente.DatosPersonales.Nombre,paciente.DatosPersonales.Apellido1};
//						fila.ItemArray=contenidoFila;
//						resutadoBusquedaPAcientesGridView.Columns.Add(fi);
//						log.Debug("Nombre: "+paciente.DatosPersonales.Nombre);
//					}
					
				//	resutadoBusquedaPAcientesGridView.DataSourceID=resultado;
					BusquedaPacientesController.PacientesItems=resultado as List<Paciente>;
					resutadoBusquedaPAcientesGridView.DataBind();
					log.Info ("Fin busqueda de pacientes");	
				}

			}			
		}
		
		protected void ddlEstudio_SelectedIndexChanged(object sender, EventArgs e)
        {			
//			setGrupoTratamientoSeleccionado(ddlEstudio.SelectedValue);
		}
	
	}
}


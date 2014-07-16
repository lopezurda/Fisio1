using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Web.Dominio;
using NHibernate;
using System.Collections.Generic;
using Web.DAO;
using Gaia.WebWidgets.Extensions;

namespace Citas
{
	public partial class DarCita : System.Web.UI.Page
	{
		
		private static readonly log4net.ILog log = log4net.LogManager.GetLogger (System.Reflection.MethodBase.GetCurrentMethod ().DeclaringType);
		
		private const int TIPO_TRAMO_HORARIO_MEDIA_HORA=0;
		private const int TIPO_TRAMO_HORARIO_HORA=1;
		
		private static NHibernateSessionManager sessionManager = new NHibernateSessionManager ();
		private Cita citaSeleccionada;
		private Paciente pacienteSeleccionado;
		
		protected void Page_Load(object sender, EventArgs e)
		{
			log.Info ("Dar cita a paciente");
			
			if (!IsPostBack){
				rbTipoCita.SelectedIndex=0;
				cargarTramosHorarios(TIPO_TRAMO_HORARIO_MEDIA_HORA);
				log.Debug ("Carga de fisioterapeutas... ");
				ListItem[] fisioterapeutas=Fisioterapeuta.getFisioterapeutasActivos();
				ddlFisio.Items.AddRange(fisioterapeutas);
				ListItem[] salas=Sala.getComboSalasActivas();
				ddlSalas.Items.AddRange(salas);
//		 		pnlTablaCitas.Visible=true;
				//Se crean las etiquetas con los fisioterapeutas
				TabControl etiquetasCitas=new TabControl();
				etiquetasCitas.ForceDynamicRendering=true;
				GridView tablaCitas=crearTablaCitas();
				foreach(ListItem fisioterapeuta in fisioterapeutas ){
					String nombreFisioterapeuta=fisioterapeuta.Text;
					TabView etiquetaFisioterapeuta=new TabView();
					etiquetaFisioterapeuta.Caption=nombreFisioterapeuta;					
					etiquetaFisioterapeuta.Controls.Add(tablaCitas);
					Label label=new Label();
					label.Text="pepe";
					etiquetaFisioterapeuta.Controls.Add(label);
					etiquetasCitas.Controls.Add(etiquetaFisioterapeuta);
				}
//				pnlDarCita.Controls.Add(etiquetasCitas);				
			}
			
						
			pacienteSeleccionado = (Session["pacienteDarCita"]) as Paciente;
			log.Info("Paciente recuperado: "+pacienteSeleccionado.Id);
			if(pacienteSeleccionado!=null)
			{
				Persona datosPersonales=pacienteSeleccionado.DatosPersonales;
				String nombre=datosPersonales.Nombre;
				String apellido1=datosPersonales.Apellido1;
				String apellido2=datosPersonales.Apellido2;
				
				txtPaciente.Text=nombre+" "+apellido1+" "+apellido2;
			}
		}
		
		//Crea la tabla
		private GridView crearTablaCitas(){
			GridView tablaCitas=new GridView();
			tablaCitas.EmptyDataText="No hay nada";
			tablaCitas.AutoGenerateColumns=false;
			BoundField columna9=new BoundField();
			columna9.DataField="Id";
			columna9.HeaderText="Id";
			tablaCitas.Columns.Add(columna9);
			Fisioterapeuta[] fisios=new Fisioterapeuta[1];
			Fisioterapeuta fisio=new Fisioterapeuta();
			fisio.Id=10;
			fisios[0]=fisio;
			tablaCitas.DataSource=fisios;
			tablaCitas.DataBind();
			return tablaCitas;
		}
		
		
		protected void dptFechaCita_FechaCitaModificada(object sender, EventArgs e)
		{
//			DateTime fechaActual=dtpFechaCita.Value.Value;
//			log.Debug("Fecha: "+fechaActual.ToString("dd/MM/yyyy HH:mm"));
//			ISession session=sessionManager.OpenSession();
//			IQuery query=session.GetNamedQuery("getCitasByDia");	
//			TimeSpan horaInicial=new TimeSpan(0,0,1);
//			fechaActual=fechaActual+horaInicial;
//			log.Debug("Fecha inicio dia: "+fechaActual);
//			query.SetDateTime("fechaInicioDia",fechaActual);
//			TimeSpan horaFinal=new TimeSpan(23,59,59);
//			fechaActual=fechaActual+horaFinal;
//			log.Debug("Fecha fin dia: "+fechaActual);
//			query.SetDateTime("fechaFinDia",fechaActual);
//			IList<Cita> citasDia=query.List<Cita>();
//			log.Debug("Recuperados "+citasDia.Count+" citas para la fecha: "+fechaActual);
//			pnlTablaCitas.Visible=true;
	//		txtFechaCita.Text = "Date and time selected: " + (dtpFechaCita.Value.HasValue? dtpFechaCita.Value.Value.ToString(zFormat.Text): "No date set");
		}
	
		//Carga el combo de tramos horarios
		private void cargarTramosHorarios(int tipoTramoHorario){
			ListItem[] tramosHorarios=null;
			if(tipoTramoHorario==TIPO_TRAMO_HORARIO_MEDIA_HORA){
				tramosHorarios=new ListItem[21];
			}else{
				tramosHorarios=new ListItem[11];
			}
			
			int indiceTramoHorario=0;
			ListItem tramoHorario=new ListItem("Elija Tramo","0");
			tramosHorarios[indiceTramoHorario++]=tramoHorario;
			for(int i=9;i<19;i++){
				string textoTramoHorario=i+":00";
				tramoHorario=new ListItem(textoTramoHorario);
				tramosHorarios[indiceTramoHorario++]=tramoHorario;
				if(tipoTramoHorario==TIPO_TRAMO_HORARIO_MEDIA_HORA){
					textoTramoHorario=i+":30";
					tramoHorario=new ListItem(textoTramoHorario);
					tramosHorarios[indiceTramoHorario++]=tramoHorario;
				}
			}
			log.Debug("Completados "+indiceTramoHorario+" tramos horarios.");
			ddlHoraCita.Items.AddRange(tramosHorarios);
		}
		
		
		protected void rbTipoCita_OnSelectedIndexChanged(object sender, EventArgs e)
		{
			log.Debug("Modificado tipo de tramo horario"+rbTipoCita.SelectedIndex);
			ddlHoraCita.Items.Clear();
			if(rbTipoCita.SelectedIndex==1){
				cargarTramosHorarios(TIPO_TRAMO_HORARIO_HORA);
			}else{
				cargarTramosHorarios(TIPO_TRAMO_HORARIO_MEDIA_HORA);
			}
				
		}
		
		protected void btnBuscarCitas_Click(object sender, EventArgs e)
		{
			log.Info("Buscando Cita");
			DateTime fechaBusqueda=(DateTime)dtpFechaCita.Value;
			IList<Cita> citasDia=Cita.getCitasByDia(fechaBusqueda);
		}
		
		protected void btnGrabar_Click(object sender, EventArgs e)
		{
			log.Info("Grabando Cita");
			Cita cita=new Cita();
			DateTime fechaBusqueda=(DateTime)dtpFechaCita.Value;
			cita.Fecha=fechaBusqueda;
//			int idFisioterapeuta=Convert.ToInt32(ddlFisioterapeutas.SelectedValue);
//			cita.Fisioterapeuta=new Fisioterapeuta(idFisioterapeuta);
			int idSala=Convert.ToInt32(ddlSalas.SelectedValue);
			cita.Sala=new Sala(idSala);
//			HistoriaClinica historiaClinica=pacienteSeleccionado.HistoriaClinica;
//			IList<Cita> citas=historiaClinica.Citas;
//			if(citas==null){
//				citas=new List<Cita>();
//			}
//			citas.Add(cita);
//			historiaClinica.Citas=citas;
//			pacienteSeleccionado.HistoriaClinica=historiaClinica;
//			IDao<Paciente> pacienteDao = new Dao<Paciente> (sessionManager);
//			pacienteDao.SaveOrUpdate(pacienteSeleccionado);
//			cita.HistoriaClinica=historiaClinica;
			
			IDao<Cita> citaDao = new Dao<Cita> (sessionManager);
			citaDao.SaveOrUpdate(cita);
		}
		
		protected void btnBuscarPaciente_Click(object sender, EventArgs e)
		{
			log.Info("Buscando Paiente");
		}
		

		
	}
}


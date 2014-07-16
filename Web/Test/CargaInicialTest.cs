using System;
using NUnit.Framework;
using NHibernate.Cfg;
using NHibernate;
using Web.DAO;
using Web.Dominio;
using log4net;
using log4net.Config;

namespace Web
{
	[TestFixture()]
	public class CargaInicialTest
	{
				// Create a logger for use in this class
		private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
		
		private Configuration cfg;
		private NHibernateSessionManager sessionManager;
		
		
		[SetUp()]
		public void Init()
		{
			//Configuración del log4net
			BasicConfigurator.Configure();
			log.Info("Inicio carga inicial de BBDD....");
			log.Info ("Iniciando configuracion hibernate");	
			cfg = new Configuration();
			
            cfg.Configure("hibernate.cfg.xml");
            cfg.AddAssembly("Web");
			
			sessionManager = new NHibernateSessionManager ();
			log.Info ("Configuracion hibernate finalizada");
		}
		
		[Test()]
		public void CargaGruposTratamiento ()
		{
			log.Info("Creando datos de grupos de tratamiento....");
			GrupoTratamiento grupoTratamiento=new GrupoTratamiento();
			grupoTratamiento.Nombre="Grupo1";
			grupoTratamiento.SesionesPorDefecto=1;
			
			IDao<GrupoTratamiento> grupoTratamientoDao = new Dao<GrupoTratamiento>(sessionManager); 
			grupoTratamientoDao.SaveOrUpdate(grupoTratamiento);
			
			grupoTratamiento=new GrupoTratamiento();
			grupoTratamiento.Nombre="Grupo2";
			grupoTratamiento.SesionesPorDefecto=2;

			grupoTratamientoDao.SaveOrUpdate(grupoTratamiento);
			log.Info("Datos de grupos de tratamiento creados OK....");
			

		}
		
		[Test()]
		public void CargaEstudios ()
		{
			log.Info("Creando datos de estudios....");
			IDao<Estudios> estudiosDao = new Dao<Estudios>(sessionManager); 
			Estudios estudios=new Estudios();
			estudios.Nombre="Sin Estudios";
			estudiosDao.SaveOrUpdate(estudios);
			
			estudios=new Estudios();
			estudios.Nombre="Ballicherato";
			estudiosDao.SaveOrUpdate(estudios);
			
			estudios=new Estudios();
			estudios.Nombre="Formación Profesional";
			estudiosDao.SaveOrUpdate(estudios);
			
			estudios=new Estudios();
			estudios.Nombre="Universitarios";
			estudiosDao.SaveOrUpdate(estudios);

			log.Info("Datos de estudios creados OK....");
		}
		
		[Test()]
		public void CargaTitulaciones()
		{
			log.Info("Creando datos de titulaciones....");
			IDao<Titulacion> titulacionDao = new Dao<Titulacion>(sessionManager); 
			Titulacion titulacion=new Titulacion();
			titulacion.Nombre="Diplomado";
			titulacionDao.SaveOrUpdate(titulacion);
			
			titulacion=new Titulacion();
			titulacion.Nombre="Licenciado";
			titulacionDao.SaveOrUpdate(titulacion);

			log.Info("Datos de titulaciones creados OK....");
		}
		
		[Test()]
		public void CargaTiposContrato()
		{
			log.Info("Creando datos de titulaciones....");
			IDao<TipoContrato> tipoContratoDao = new Dao<TipoContrato>(sessionManager); 
			TipoContrato tipoContrato=new TipoContrato();
			tipoContrato.Nombre="Beca";
			tipoContratoDao.SaveOrUpdate(tipoContrato);
			
			tipoContrato=new TipoContrato();
			tipoContrato.Nombre="Media Jornada";
			tipoContratoDao.SaveOrUpdate(tipoContrato);

			log.Info("Datos de titulaciones creados OK....");
		}
		
		[Test()]
		public void CargaEstadoPaciente()
		{
			log.Info("Creando estado de paciente....");
			IDao<EstadoPaciente> estadoPacienteDao = new Dao<EstadoPaciente>(sessionManager); 
			EstadoPaciente estadoPaciente=new EstadoPaciente();
			estadoPaciente.Nombre="Activo";
			estadoPacienteDao.SaveOrUpdate(estadoPaciente);
			
			estadoPaciente=new EstadoPaciente();
			estadoPaciente.Nombre="Baja";
			estadoPacienteDao.SaveOrUpdate(estadoPaciente);
			
			estadoPaciente=new EstadoPaciente();
			estadoPaciente.Nombre="Abandono";
			estadoPacienteDao.SaveOrUpdate(estadoPaciente);
			
			estadoPaciente=new EstadoPaciente();
			estadoPaciente.Nombre="Exclusión";
			estadoPacienteDao.SaveOrUpdate(estadoPaciente);

			log.Info("Datos de estado de paciente creados OK....");
		}
		
		[Test()]
		public void CargaGruposTratamientosEstudios()
		{
			log.Info("Creando grupos de tratamientos de estudios....");
			IDao<Estudio> estudioDao = new Dao<Estudio>(sessionManager); 
			GrupoTratamiento grupoTratamiento=new GrupoTratamiento();
			grupoTratamiento.Id=1;
			Estudio estudio=new Estudio();
			estudio.Nombre="Estudio 1";
			estudio.GrupoTratamiento=grupoTratamiento;
			estudioDao.SaveOrUpdate(estudio);
			
			grupoTratamiento=new GrupoTratamiento();
			grupoTratamiento.Id=2;
			estudio=new Estudio();
			estudio.Nombre="Estudio 2";
			estudio.GrupoTratamiento=grupoTratamiento;
			estudioDao.SaveOrUpdate(estudio);
	

			log.Info("Datos de grupos de tratamiento de estudios creados OK....");
		}

		[Test()]
		public void CargaEntidadesFinanciadoras()
		{
			log.Info("Creando entidades financiadoras ....");
			IDao<EntidadFinanciadora> entidadFinanciadoraDao = new Dao<EntidadFinanciadora>(sessionManager); 
			EntidadFinanciadora entidadFinanciadora=new EntidadFinanciadora();
			entidadFinanciadora.Nombre="Entidad Financiadora 1";
			entidadFinanciadoraDao.SaveOrUpdate(entidadFinanciadora);

			entidadFinanciadora=new EntidadFinanciadora();
			entidadFinanciadora.Nombre="Entidad Financiadora 2";
			entidadFinanciadoraDao.SaveOrUpdate(entidadFinanciadora);
	
			log.Info("Datos de entidades financiadoras creados OK....");
		}
		
		[Test()]
		public void CargaProyectosContratacion()
		{
			log.Info("Creando proyectos de contratación ....");
			IDao<ProyectoContratacion> proyectoContratacionDao = new Dao<ProyectoContratacion>(sessionManager); 
			ProyectoContratacion proyectoContratacion=new ProyectoContratacion();
			proyectoContratacion.Nombre="Proyecto Contratacion 1";
			DateTime fechaInicio=new DateTime(2012,4,1);
			DateTime fechaFin=new DateTime(2012,4,15);
			log.Debug("Fecha inicio: "+fechaInicio+" Fecha Fin: "+fechaFin);
			proyectoContratacion.FechaInicio=fechaInicio;
			proyectoContratacion.FechaFin=fechaFin;
			EntidadFinanciadora entidadFinanciadora=new EntidadFinanciadora();
			entidadFinanciadora.Id=1;
			proyectoContratacion.EntidadFinanciadora=entidadFinanciadora;
			
			proyectoContratacionDao.SaveOrUpdate(proyectoContratacion);

			proyectoContratacion=new ProyectoContratacion();
			proyectoContratacion.Nombre="Proyecto Contratacion 2";
			fechaInicio=new DateTime(2012,4,7);
			fechaFin=new DateTime(2012,4,30);
			log.Debug("Fecha inicio: "+fechaInicio+" Fecha Fin: "+fechaFin);
			proyectoContratacion.FechaInicio=fechaInicio;
			proyectoContratacion.FechaFin=fechaFin;
			entidadFinanciadora=new EntidadFinanciadora();
			entidadFinanciadora.Id=2;
			proyectoContratacion.EntidadFinanciadora=entidadFinanciadora;	
			
			proyectoContratacionDao.SaveOrUpdate(proyectoContratacion);
			
			log.Info("Datos de proyectos de contratación creados OK....");
		}	

		[Test()]
		public void CargaSalas()
		{
			log.Info("Carga inicial de salas....");
			IDao<Sala> salaDao = new Dao<Sala>(sessionManager);
			Sala sala1=new Sala();
			sala1.Descripcion="Descripcion sala 1";
			sala1.Habilitada=true;
			sala1.Nombre="Sala1";
			salaDao.SaveOrUpdate(sala1);
			Sala sala2=new Sala();
			sala1.Descripcion="Descripcion sala 2";
			sala1.Habilitada=false;
			sala1.Nombre="Sala2";
			salaDao.SaveOrUpdate(sala2);
			Sala sala3=new Sala();
			sala1.Descripcion="Descripcion sala 3";
			sala1.Habilitada=true;
			sala1.Nombre="Sala3";
			salaDao.SaveOrUpdate(sala3);
			log.Info("Carga inicial de salas OK.");
		}
		
		[TearDown()]
		public void TearDown()
		{
			log.Info("Fin carga inicial de BBDD OK.");
		}
	}
}


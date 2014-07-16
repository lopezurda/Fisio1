using System;
using System.Collections.Generic;
using NUnit.Framework;
using log4net;
using log4net.Config;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Tool.hbm2ddl;
using Web.DAO;
using Web.Dominio;

namespace Web.Test
{
	[TestFixture()]
	public class HibernateTest
	{
		// Create a logger for use in this class
		private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
		
		private Configuration cfg;
		
		[SetUp()]
		public void Init()
		{
			//Configuración del log4net
			BasicConfigurator.Configure();
			cfg = new Configuration();
			
            cfg.Configure("../hibernate.cfg.xml");
            cfg.AddAssembly("Web");
		}
		
		
		[Test()]
		public void CreateSQLSchema ()
		{
			//Configuración del log4net
//			BasicConfigurator.Configure();
			log.Info("Inicio creación de esquema de BBDD....");
			
//			var cfg = new Configuration();
//            cfg.Configure("../hibernate.cfg.xml");
//            cfg.AddAssembly("Web");
            
            var schemaExport=new SchemaExport(cfg);
			
			schemaExport.SetDelimiter(";");
			schemaExport.SetOutputFile("/Users/lopezurda/Proyectos/PFC/fisio-web.sql");
			schemaExport.Create(true, false);
			
			
			log.Info("Esquema creado OK.");

		}
		
		[Test()]
		public void CreateBBDDSchemaCase ()
		{
			//Configuración del log4net
//			BasicConfigurator.Configure();
			log.Info("Inicio creación de esquema de BBDD....");
			
//			var cfg = new Configuration();
//            cfg.Configure("../hibernate.cfg.xml");
//            cfg.AddAssembly("Web");
            
            var schemaExport=new SchemaExport(cfg);
			
			schemaExport.SetDelimiter(";");
			schemaExport.SetOutputFile("/Users/lopezurda/Proyectos/PFC/fisio-web.sql");
			schemaExport.Create(true, true);
			
			
			log.Info("Esquema creado OK.");

		}
		
		[Test()]
		public void TestNamedQuery ()
		{
			NHibernateSessionManager sessionManager = new NHibernateSessionManager();
			ISession session=sessionManager.OpenSession();
			
			log.Info("Recuperando grupo de tratamiento de un estudio");
			IQuery query=session.GetNamedQuery("getGrupoTratamientoFromEstudio");			
			query.SetInt32("id",1);			
			GrupoTratamiento grupoTratamiento=query.UniqueResult<GrupoTratamiento>();			
			log.Info("Grupo Tratamiento recuperado: "+grupoTratamiento.Nombre);	
			
			log.Info("Recuperando proyectos de contratación vigentes");
			query=session.GetNamedQuery("getProyectosContratacionVigentes");	
			DateTime fechaActual=new DateTime(2012,4,30);
			query.SetDateTime("fechaActual",fechaActual);			
			IList<ProyectoContratacion> proyectosContratacion=query.List<ProyectoContratacion>();
			log.Info("Recuperados "+proyectosContratacion.Count+" proyectos de contratación vigentes para la fecha: "+fechaActual);
			foreach (ProyectoContratacion proyectoContratacion in proyectosContratacion){
				log.Info("Proyecto Contratacion: "+proyectoContratacion.Nombre+
				         " Fecha inicio: "+proyectoContratacion.FechaInicio+" Fecha Fin: "+proyectoContratacion.FechaFin);
			}

		}
		
		[Test()]
		public void TestOneToMany ()
		{
			NHibernateSessionManager sessionManager = new NHibernateSessionManager();
			IDao<Cita> citaDao = new Dao<Cita> (sessionManager);
			IDao<Paciente> pacienteDao = new Dao<Paciente> (sessionManager);
			
			log.Info("Recuperando paciente");
			Paciente paciente=pacienteDao.GetById(1);
			
			Cita cita=new Cita();
			cita.Fecha=DateTime.Now;
			cita.Sala=new Sala(1);
			
			HistoriaClinica historiaClinica=paciente.HistoriaClinica;
			IList<Cita> citas=historiaClinica.Citas;
			log.Info("Numero de citas "+citas.Count);
			
			
			cita.HistoriaClinica=historiaClinica;
			
			cita=citaDao.SaveOrUpdate(cita);
			log.Info("Cita grabada con id: "+cita.Id);
			
			citas=historiaClinica.Citas;
			log.Info("Numero de citas "+citas.Count);

		}		
	}
}


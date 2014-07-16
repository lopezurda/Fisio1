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
	public class CargaOpcionalDatosTest
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
		public void CargaFisioterapeutas()
		{
			Fisioterapeuta fisioTerapeuta=new Fisioterapeuta();
			Persona datosPersonales=new Persona();
			datosPersonales.Apellido1="Ape1";
			datosPersonales.Apellido2="Ape2";
			Direccion direccion=new Direccion();
			direccion.CP="28100";
			direccion.Localidad="Alcobendas";
			direccion.Numero=98;
			direccion.Provincia=new Provincia(28);
			direccion.RestoDireccion="Resto";
			direccion.Via="Calle";
			datosPersonales.Direccion=direccion;
			datosPersonales.Email="lop@uah.es";
			datosPersonales.FechaNacimiento=new DateTime(1975,1,12);
			datosPersonales.NIF="1";
			datosPersonales.Nombre="Fisio1";
			datosPersonales.TelefonoFijo="9111111";
			datosPersonales.TelefonoMovil="6612323";
			fisioTerapeuta.DatosPersonales=datosPersonales;
			fisioTerapeuta.FechaIngreso=new DateTime(2006,6,4);
			fisioTerapeuta.FechaTitulacion=new DateTime(2006,5,5);
			fisioTerapeuta.NumeroColegiado=123456;
			fisioTerapeuta.ProyectoContratacion=new ProyectoContratacion(1);
			fisioTerapeuta.TipoContrato=new TipoContrato(1);
			fisioTerapeuta.Titulacion=new Titulacion(1);
			
			IDao<Fisioterapeuta> fisioterapeutaDAO = new Dao<Fisioterapeuta>(sessionManager); 
			fisioterapeutaDAO.SaveOrUpdate(fisioTerapeuta);	
		}

		
		[Test()]
		public void CargaPaciente()
		{
			Paciente paciente=new Paciente();
			Persona datosPersonales=new Persona();
			datosPersonales.Apellido1="Ape1";
			datosPersonales.Apellido2="Ape2";
			Direccion direccion=new Direccion();
			direccion.CP="28100";
			direccion.Localidad="Alcobendas";
			direccion.Numero=98;
			direccion.Provincia=new Provincia(28);
			direccion.RestoDireccion="Resto";
			direccion.Via="Calle";
			datosPersonales.Direccion=direccion;
			datosPersonales.Email="lop@uah.es";
			datosPersonales.FechaNacimiento=new DateTime(1975,1,12);
			datosPersonales.NIF="1";
			datosPersonales.Nombre="Pciente 1";
			datosPersonales.TelefonoFijo="9111111";
			datosPersonales.TelefonoMovil="6612323";
			paciente.DatosPersonales=datosPersonales;
			paciente.Aficiones="Aficion";
			paciente.EstadoPaciente=new EstadoPaciente(2);
			paciente.Estudio=new Estudio(2);
			paciente.Estudios=new Estudios(2);
			paciente.Profesion="Profesion";	
			HistoriaClinica historiaClinica=new HistoriaClinica();
			historiaClinica.NumeroHistoria="2";
			paciente.HistoriaClinica=historiaClinica;
			IDao<Paciente> pacienteDAO = new Dao<Paciente>(sessionManager); 
			pacienteDAO.SaveOrUpdate(paciente);	
		}
		
		[TearDown()]
		public void TearDown()
		{
			log.Info("Fin carga inicial de BBDD OK.");
		}
	}
}


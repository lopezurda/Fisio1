<%@ Page Language="C#" Inherits="Web.MostrarPaciente" MasterPageFile="~/Plantillas/PlantillaMaestra.master" %>


<asp:Content ContentPlaceHolderID="menuVertical" ID="menuVerticalContent" runat="server">	
	<asp:Menu ID="MenuPersonaVertical" runat="server" Orientation="Vertical">
		<StaticMenuStyle CssClass="primaryStaticMenuVertical"/>
        <StaticMenuItemStyle CssClass="primaryStaticMenuItemVertical"/>
        <StaticHoverStyle CssClass="primaryStaticHoverVertical"/>
        <DynamicMenuStyle CssClass="primaryDynamicMenuVertical" />
        <DynamicMenuItemStyle CssClass="primaryDynamicMenuItemVertical"/>
        <DynamicHoverStyle CssClass="primaryDynamicHoverVertical"/>
		<Items>							
			<asp:MenuItem NavigateUrl="~/Pacientes/BusquedaPaciente.aspx" Text="Consulta" Value="1" />
			<asp:MenuItem Text="Alta" Value="2" Selected="true"/>				
		</Items>
	</asp:Menu>
</asp:Content>
<asp:Content ContentPlaceHolderID="contenido" ID="contenidoContent" runat="server">
	<div id="divDatosPaciente">
		<gaia:Label ID="lblMostrarPaciente" runat="server" Text="Paciente Seleccionado"/>
		<br>
		<gaia:Label id="lblNombre" Runat="server" text="Nombre:"/>
		<gaia:TextBox id="txtNombre" Runat="server" Enabled="false"/>

		<gaia:Label id="lblApellido1" Runat="server" text="Apellido1:"/>
		<gaia:TextBox id="txtApellido1" Runat="server" Enabled="false"/>
		
		<gaia:Label id="lblApellido2" Runat="server" text="Apellido2:"/>
		<gaia:TextBox id="txtApellido2" Runat="server" Enabled="false"/>
		<br>
		<gaia:Label id="lblNIF" Runat="server" text="NIF:"/>
		<gaia:TextBox id="txtNIF" Runat="server" Enabled="false"/>							
		
		<gaia:Label id="lblFechaNacimiento" Runat="server" text="Fecha de Nacimiento(dd/mm/aaaa):"/>
		<gaia:TextBox id="txtFechaNacimiento" Runat="server" Enabled="false"/>
		<br>
		<gaia:Label id="lblVia" Runat="server" text="Via:"/>
		<gaia:TextBox id="txtVia" Runat="server" Enabled="false"/>
		
		<gaia:Label id="lblNumero" Runat="server" text="Numero:"/>
		<gaia:TextBox id="txtNumeroVia" Runat="server" Enabled="false"/>
		
		<gaia:Label id="lblRestoDireccion" Runat="server" text="Resto de la Direccion:"/>
		<gaia:TextBox id="txtRestoDireccion" Runat="server" Enabled="false"/>
		<br>
		<gaia:Label id="lblLocalidad" Runat="server" text="Localidad:"/>
		<gaia:TextBox id="txtLocalidad" Runat="server" Enabled="false"/>
		
		<gaia:Label id="lblCP" Runat="server" text="Codigo Postal:"/>
		<gaia:TextBox id="txtCP" Runat="server" Enabled="false"/>
		
		<gaia:Label id="lblProvincia" Runat="server" text="Provincia:"/>
		<gaia:TextBox id="txtProvincia" Runat="server" Enabled="false"/>
		<br>
		<div id="divBotoneraCentrada">
			<gaia:Button ID="btnDarCita" runat="server" Text="Dar Cita" OnClick="btnDarCita_Click" />
	
			<gaia:Button ID="btnVerHistorial" runat="server" Text="Ver Historial" OnClick="btnVerHistorial_Click" />
		</div>
	</div>
</asp:Content>



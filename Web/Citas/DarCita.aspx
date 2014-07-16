<%@ Page Language="C#" Inherits="Citas.DarCita" MasterPageFile="~/Plantillas/PlantillaMaestra.master" %>
<%@ MasterType VirtualPath="~/Plantillas/PlantillaMaestra.master" %>
<asp:Content ContentPlaceHolderID="menuVertical" id="menuVerticalContent" runat="server">
	<asp:Menu id="MenuCitaVertical" runat="server" Orientation="Vertical">
       <StaticMenuStyle CssClass="primaryStaticMenuVertical"/>
        <StaticMenuItemStyle CssClass="primaryStaticMenuItemVertical"/>
        <StaticHoverStyle CssClass="primaryStaticHoverVertical"/>
        <DynamicMenuStyle CssClass="primaryDynamicMenuVertical" />
        <DynamicMenuItemStyle CssClass="primaryDynamicMenuItemVertical"/>
        <DynamicHoverStyle CssClass="primaryDynamicHoverVertical"/>
		<Items>
			<asp:MenuItem Text="Dar Cita" Value="1" Selected="true"/>
		</Items>
	</asp:Menu>
</asp:Content>
<asp:Content ContentPlaceHolderID="contenido" id="contenidoContent" runat="server">
	<div id="divDatosCita">		
		<gaia:Label ID="lblDarCita" Runat="server" Text="Dar Cita"/>
			<br>
			<gaia:Label ID="lblPaciente" Runat="server" Text="Paciente:"/>
			<gaia:TextBox ID="txtPaciente" Runat="server" Enabled="false"/>
			<br>
			<gaia:Label ID="lblFisioterapeuta" Runat="server" Text="Fisioterapeuta:"/>		
			<gaia:DropDownList ID="ddlFisio" Runat="server" AutoPostBack="true"/>
			<gaia:Label ID="lblSala" Runat="server" Text="Sala:"/>		
			<gaia:DropDownList ID="ddlSalas" Runat="server" AutoPostBack="true"/>
			<br>
			<gaia:Label ID="lblTipoCita" Runat="server" Text="Tipo Cita:"/>
			<gaia:RadioButtonList ID="rbTipoCita" Runat="server" AutoPostBack="true" OnSelectedIndexChanged="rbTipoCita_OnSelectedIndexChanged">
				<asp:ListItem>30 minutos</asp:ListItem>
				<asp:ListItem>1 hora</asp:ListItem>
			</gaia:RadioButtonList>
			<gaia:Label ID="lblHoraCita" Runat="server" Text="Hora Cita:"/>		
			<gaia:DropDownList ID="ddlHoraCita" Runat="server" AutoPostBack="True"/>
			<br>
			<gaia:Label id="lblFechaCita" Runat="server" Text="Fecha Cita:"/>
			<gaia:DateTimePicker ID="dtpFechaCita" Runat="server" Width="150px" Format="dd/MM/yyyy" Culture="es-ES"
					FirstDayOfWeek="Monday" HasTimePart="false" OnSelectedDateChanged="dptFechaCita_FechaCitaModificada" />

	
		<gaia:Button ID="btnBuscarCitas" Runat="server" Text="Buscar Cita" OnClick="btnBuscarCitas_Click" />

		<gaia:Button ID="btnGrabar" Runat="server" Text="Grabar" OnClick="btnGrabar_Click" />
	</div>
</asp:Content>



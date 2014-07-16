<%@ Page Language="C#" Inherits="Web.AltaPaciente" MasterPageFile="~/Plantillas/PlantillaMaestra.master" %>
<%@ MasterType VirtualPath="~/Plantillas/PlantillaMaestra.master" %>

<asp:Content ContentPlaceHolderID="menuVertical" runat="server">	
	<asp:Menu ID="MenuPersonaPacienteVertical" runat="server" Orientation="Vertical">
		<StaticMenuStyle CssClass="primaryStaticMenuVertical"/>
		        <StaticMenuItemStyle CssClass="primaryStaticMenuItemVertical"/>
		        <StaticHoverStyle CssClass="primaryStaticHoverVertical"/>
		        <DynamicMenuStyle CssClass="primaryDynamicMenuVertical" />
		        <DynamicMenuItemStyle CssClass="primaryDynamicMenuItemVertical"/>
		        <DynamicHoverStyle CssClass="primaryDynamicHoverVertical"/>
				<Items>							
					<asp:MenuItem NavigateUrl="~/Pacientes/BusquedaPacientes.aspx" Text="Consulta" Value="1" />
					<asp:MenuItem Text="Alta" Value="2" Selected="true"/>				
				</Items>
			</asp:Menu>					
</asp:Content>
<asp:Content ContentPlaceHolderID="contenido" runat="server">					
	<div>
		<div id="divTituloSeccion">
			<gaia:Label ID="lblAltaPaciente" runat="server">Alta Paciente</gaia:Label>
		</div>
		<div id="divDatosAltaPaciente1">
			<div>
				<asp:Label id="lblNumeroHistoria" Runat="server" text="Numero Historia:"></asp:Label>
				<gaia:TextBox id="txtNumeroHistoria" Runat="server"/>
				<gaia:RequiredFieldValidator ID="RequiredNumeroHistoriaAltaPaciente" runat="server" ControlToValidate="txtNombre" ErrorMessage="Introduzca Nombre">*
				</gaia:RequiredFieldValidator>
			</div>
			<div>
				<asp:Label id="lblNombre" Runat="server" text="Nombre:"></asp:Label>
				<gaia:TextBox id="txtNombre" Runat="server"/>
				<gaia:RequiredFieldValidator ID="RequiredNombreAltaPaciente" runat="server" ControlToValidate="txtNombre" ErrorMessage="Introduzca Nombre">*
				</gaia:RequiredFieldValidator>
			</div>
			<div>
				<asp:Label id="lblApellido1" Runat="server" text="Apellido1:"></asp:Label>
				<gaia:TextBox id="txtApellido1" Runat="server"/>
				<gaia:RequiredFieldValidator ID="RequiredApellido1AltaPaciente" runat="server" ControlToValidate="txtApellido1" ErrorMessage="Introduzca Primer Apellido">*
				</gaia:RequiredFieldValidator>
			</div>
			<div>
				<asp:Label id="lblApellido2" Runat="server" text="Apellido2:"></asp:Label>
				<gaia:TextBox id="txtApellido2" Runat="server"/>
			</div>
			<div>
				<asp:Label id="lblNIF" Runat="server" text="NIF:"></asp:Label>
				<gaia:TextBox id="txtNIF" Runat="server"/>																								
				<gaia:RequiredFieldValidator ID="RequiredNIFAltaPaciente" runat="server" ControlToValidate="txtNIF" ErrorMessage="Introduzca NIF">*
				</gaia:RequiredFieldValidator>
			</div>
			<div>
				<asp:Label id="lblFechaNacimiento" Runat="server" text="Fecha de Nacimiento(dd/mm/aaaa):"></asp:Label>
				<gaia:TextBox id="txtFechaNacimiento" Runat="server"/>
				<gaia:RequiredFieldValidator ID="RequiredFechaNacimientoAltaPaciente" runat="server" ControlToValidate="txtFechaNacimiento" ErrorMessage="Introduzca Fecha de Nacimiento">*
				</gaia:RequiredFieldValidator>
			</div>					
			<div>
			 	<asp:Label id="lblTelefonoFijo" Runat="server" text="Teléfono Fijo:"></asp:Label>
				<gaia:TextBox id="txtTelefonoFijo" Runat="server"/>
			</div>
			<div>
				<asp:Label id="lblTelefonoMovil" Runat="server" text="Teléfono Móvil:"></asp:Label>
				<gaia:TextBox id="txtTelefonoMovil" Runat="server"/>
			</div>
			<div>
				<asp:Label id="lblEmail" Runat="server" text="Email:"></asp:Label>
				<gaia:TextBox id="txtEmail" Runat="server"/>
			</div>
			<div>
				<asp:Label id="lblProfesion" Runat="server" text="Profesion:"></asp:Label>
				<gaia:TextBox id="txtProfesion" Runat="server"/>
			</div>											
			<div>
				<asp:Label id="lblAficiones" Runat="server" text="Aficiones:"></asp:Label>
				<gaia:TextBox id="txtAficiones" Runat="server"/>
				<gaia:RequiredFieldValidator ID="RequiredAficionesAltaPaciente" runat="server" ControlToValidate="txtAficiones" ErrorMessage="Introduzca por lo menos una afición">*
				</gaia:RequiredFieldValidator>
			</div>	
			<div>
				<asp:Label id="lblEstudios" Runat="server" text="Estudios:"></asp:Label>
				<gaia:DropDownList ID="ddlEstudios" runat="server" AutoPostBack="True" Width="150px" />
			</div>
		</div>
		<div id="divDatosAltaPaciente2">	
			<div>
				<asp:Label id="lblVia" Runat="server" text="Via:"></asp:Label>
				<gaia:TextBox id="txtVia" Runat="server"/>
				<gaia:RequiredFieldValidator ID="RequiredViaAltaPaciente" runat="server" ControlToValidate="txtVia" ErrorMessage="Introduzca Via">*
				</gaia:RequiredFieldValidator>
			</div>											
			<div>
				<asp:Label id="lblNumero" Runat="server" text="Numero:"></asp:Label>
				<gaia:TextBox id="txtNumeroVia" Runat="server"/>
				<gaia:RequiredFieldValidator ID="RequiredNumerViaAltaPaciente" runat="server" ControlToValidate="txtNumeroVia" ErrorMessage="Introduzca Número de Vía">*
				</gaia:RequiredFieldValidator>
			</div>	
			<div>
				<asp:Label id="lblRestoDireccion" Runat="server" text="Resto de la Direccion:"></asp:Label>
				<gaia:TextBox id="txtRestoDireccion" Runat="server"/></asp:TableCell>
			</div>	
			<div>
				<asp:Label id="lblLocalidad" Runat="server" text="Localidad:"></asp:Label>
				<gaia:TextBox id="txtLocalidad" Runat="server"/>
				<gaia:RequiredFieldValidator ID="RequiredLocalidadAltaPaciente" runat="server" ControlToValidate="txtLocalidad" ErrorMessage="Introduzca Localidad">*
				</gaia:RequiredFieldValidator>
			</div>											
			<div>
				<asp:Label id="lblCP" Runat="server" text="Codigo Postal:"></asp:Label>
				<gaia:TextBox id="txtCP" Runat="server"/>
				<gaia:RequiredFieldValidator ID="RequiredCP" runat="server" ControlToValidate="txtCP" ErrorMessage="Introduzca Código Postal">*
				</gaia:RequiredFieldValidator>				
			</div>	
			<div>
				<asp:Label id="lblProvincia" Runat="server" text="Provincia:"></asp:Label>
				<gaia:DropDownList ID="ddlProvincias" runat="server" AutoPostBack="True" Width="150px" />
			</div>
		</div>
	</div>
	<div>
		<asp:TableRow>	
			<asp:TableCell>
				<gaia:Button ID="btnGrabar" runat="server" Text="Grabar" OnClick="btnGrabar_Click" />
			</asp:TableCell>
			<asp:TableCell>
				<gaia:ValidationSummary ID="ValidacionAltaPaciente" runat="server" />
			</asp:TableCell>			
		</asp:TableRow>	
	</div>	
</asp:Content>




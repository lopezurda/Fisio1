<%@ Page Language="C#" Inherits="Web.Pacientes.BusquedaPacientes" MasterPageFile="~/Plantillas/PlantillaMaestra.master" %>
<%@ MasterType VirtualPath="~/Plantillas/PlantillaMaestra.master" %>

<asp:Content ContentPlaceHolderID="menuVertical" runat="server">	
	<asp:Menu ID="MenuPacienteVertical" runat="server" Orientation="Vertical">
		<StaticMenuStyle CssClass="primaryStaticMenuVertical"/>
        <StaticMenuItemStyle CssClass="primaryStaticMenuItemVertical"/>
        <StaticHoverStyle CssClass="primaryStaticHoverVertical"/>
        <DynamicMenuStyle CssClass="primaryDynamicMenuVertical" />
        <DynamicMenuItemStyle CssClass="primaryDynamicMenuItemVertical"/>
        <DynamicHoverStyle CssClass="primaryDynamicHoverVertical"/>
		<Items>							
			<asp:MenuItem Text="Consulta" Value="1" Selected="true"/>
			<asp:MenuItem NavigateUrl="~/Pacientes/AltaPaciente.aspx" Text="Alta" Value="2" />				
		</Items>
	</asp:Menu>					
</asp:Content>
<asp:Content ContentPlaceHolderID="contenido" ID="contenido" runat="server">	
	<div>
		<div id="divTituloSeccion">
			<gaia:Label ID="lblBusquedaPaciente" runat="server" Text="Busqueda Paciente"/>
		</div>
		<div id="divDatosBusquedaPAciente">
			<div>
				<gaia:Label ID="lblNIF" runat="server" Text="NIF:"/>
				<gaia:TextBox ID="txtNIF" Runat="server"/>																								
			</div>
			<div>
				<gaia:Label ID="lblNombre" Runat="server" text="Nombre:"/>
				<gaia:TextBox ID="txtNombre" Runat="server"/>
			</div>
			<div>
				<gaia:Label ID="lblApellido1" Runat="server" text="Apellido1:"/>
				<gaia:TextBox ID="txtApellido1" Runat="server"/>
			</div>
			<div>
				<gaia:Label ID="lblApellido2" Runat="server" text="Apellido2:"/>
				<gaia:TextBox ID="txtApellido2" Runat="server"/>
			</div>
			<div>
				<gaia:Label ID="lblHistoriaClinica" Runat="server" text="Historia Clinica:"/>
				<gaia:TextBox ID="txtHistoriaClinica" Runat="server"/>
			</div>
			<div>
				<gaia:Label ID="lblEstudio" Runat="server" text="Estudio: "/>
				<gaia:DropDownList ID="ddlEstudio" Runat="server" AutoPostBack="true"/>
			</div>
			<div>
				<gaia:Label ID="lblGrupoTratamiento" Runat="server" text="Grupo Tratamiento: "/>
				<gaia:DropDownList ID="ddlGruposTratamiento" Runat="server" AutoPostBack="true"/>
			</div>	
			<div>
				<gaia:Label ID="lblEstadoPaciente" Runat="server" text="Estado: "/>
				<gaia:DropDownList ID="ddlEstadoPaciente" Runat="server" AutoPostBack="true"/>
			</div>	
		</div>
	
		<div id="divBotoneraCentrada">	
			<gaia:Button ID="btnGrabar" runat="server" Text="Buscar" OnClick="btnBuscarPaciente_Click" />
		</div>
	</div>
	<div id="divResultadoBusquedaPaciente">
		<gaia:Panel ID="resultadoBusquedaPacientesPanel" runat="server" Visible="true">
	     	<gaia:GridView ID="resutadoBusquedaPAcientesGridView" runat="server" Width="100%" CssClass="~/App_Themes/Gaiax/GridView.css" DataSourceID="busquedaPacientesDataSource"
   				 AllowPaging="True" AllowSorting="True" DataKeyNames="Id" AutoGenerateColumns="False" ShowHeader="true" BorderColor="Black" BorderWidth="1" BackColor="Lavender">
				<Columns>
					<gaia:CommandField ShowSelectButton="true" SelectText="Seleccionar" ShowEditButton="false" EditText="Edit" UpdateText="wewe" />	  							
			   		<gaia:BoundField 
				        DataField="Id" 
				        HeaderText="Id" 
				        SortExpression="Id"
				        ReadOnly="true" Visible="true"/>
						<gaia:TemplateField HeaderText="Nombre">
						    <itemtemplate>
						        <p><%#DataBinder.Eval(Container.DataItem, "DatosPersonales.Nombre")%></p>
						    </itemtemplate>
						</gaia:TemplateField>
						<gaia:TemplateField HeaderText="Apellido 1">
						    <itemtemplate>
						        <p><%#DataBinder.Eval(Container.DataItem, "DatosPersonales.Apellido1")%></p>
						    </itemtemplate>
						</gaia:TemplateField>
						<gaia:TemplateField HeaderText="Apellido 2">
						    <itemtemplate>
						        <p><%#DataBinder.Eval(Container.DataItem, "DatosPersonales.Apellido2")%></p>
						    </itemtemplate>
						</gaia:TemplateField>
						<gaia:TemplateField HeaderText="Estudio">
						    <itemtemplate>
						        <p><%#DataBinder.Eval(Container.DataItem, "Estudio.Nombre")%></p>
						    </itemtemplate>
						</gaia:TemplateField>	
						<gaia:TemplateField HeaderText="Numero Historia">
						    <itemtemplate>
						        <p><%#DataBinder.Eval(Container.DataItem, "HistoriaClinica.NumeroHistoria")%></p>
						    </itemtemplate>
						</gaia:TemplateField>							
				</Columns> 
			</gaia:GridView>
			<asp:ObjectDataSource 
				EnablePaging="False" 
				TypeName="Web.Pacientes.BusquedaPacientesController"
				ID="busquedaPacientesDataSource" 
				runat="server" 
				SelectMethod="ListAsDataTable"
				UpdateMethod="Select"/>
		</gaia:Panel>
	</div>
	<div id="divSeccionError">
		<gaia:Label ID="lblErrorBusqueda" runat="server" Text=""/>
	</div>

	<gaia:ValidationSummary ID="ValidacionBusquedaPaciente" runat="server" />

</asp:Content>
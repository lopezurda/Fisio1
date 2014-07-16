<%@ Page Language="C#" Inherits="Web.InicioSalas" MasterPageFile="~/Plantillas/PlantillaMaestra.master" %>
<%@ MasterType VirtualPath="~/Plantillas/PlantillaMaestra.master" %>
<asp:Content ContentPlaceHolderID="menuVertical" ID="menuVerticalContent" runat="server">
	<gaia:Panel id="pnlMenuVertical"  
			 style=" POSITION: relative;" 
			 Height="225px" 
	         Width="75px"			
	         runat="server"           
			 BackColor="LightGreen">
	
			<asp:Menu ID="MenuSalaVertical" runat="server" Orientation="Vertical">
				<Items>							
					<asp:MenuItem Text="Consulta" Value="1"/>			
				</Items>
			</asp:Menu>
		</gaia:Panel>	
</asp:Content>
<asp:Content ContentPlaceHolderID="contenido" ID="contenidoContent" runat="server">
	<gaia:Panel id="pnlInicioSala" 
       style="POSITION: relative" 
	         runat="server" 
	         Height="225px" 
	         Width="800px"			
			 BorderStyle="Dotted" BorderWidth="1">
	<asp:Table HorizontalAlign="Center">
		<asp:TableRow>	
			<asp:TableCell HorizontalAlign="Center">
				<gaia:Label ID="lblAltaSala" runat="server">Inicio Sala</gaia:Label>
			</asp:TableCell>						 
		</asp:TableRow>	
	</asp:Table>		
	<asp:Table id="tblAltaSala" runat="server">
			<asp:TableRow>
				<asp:TableCell>				
					<gaia:Panel id="pnlDatosSala"
				         style="POSITION: relative" 
				         runat="server" 
				         Height="175px" 
				         Width="400px"
						 BackColor="BlanchedAlmond"
						 BorderStyle="Dotted" BorderWidth="1">
						<gaia:GridView 
								ID="salasInicioGrid" 
								runat="server" 
								Width="100%" 
								AllowPaging="True" 
								AllowSorting="True"
								DataKeyNames="Id"
								DataSourceID="salasInicioDataSource" 
								AutoGenerateColumns="False"
								EmptyDataText="No se han encontrado salas">
							<Columns>
								<gaia:CommandField ShowSelectButton="true" SelectText="Dar Cita"/>
								<gaia:BoundField DataField="Nombre" HeaderText="Nombre" SortExpression="Nombre" ReadOnly="true" />
								<gaia:BoundField DataField="Descripcion" HeaderText="Descripción" ControlStyle-Width="30px" />
								<gaia:CheckBoxField DataField="Habilitada" HeaderText="Habilitada" SortExpression="Habilitada" ItemStyle-HorizontalAlign="Center" />
							</Columns>
						</gaia:GridView>
					</gaia:Panel>
					<asp:ObjectDataSource id="salasInicioDataSource" 
						EnablePaging="False" 
						TypeName="Web.Salas.InicioSalasController"
						runat="server" 
						SelectMethod="ListAsDataTable">
					</asp:ObjectDataSource>
				</asp:TableCell>
			</asp:TableRow>
	
		</asp:Table>
		<asp:Table HorizontalAlign="Center">
			<asp:TableRow>	
				<asp:TableCell>
					<gaia:Label ID="lblResultadoOperacion" runat="server"/>
				</asp:TableCell>						 
			</asp:TableRow>
		</asp:Table>	
	</gaia:Panel>	
</asp:Content>



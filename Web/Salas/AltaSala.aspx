<%@ Page Language="C#" Inherits="Web.AltaSala" MasterPageFile="~/Plantillas/PlantillaMaestra.master" %>
<%@ MasterType VirtualPath="~/Plantillas/PlantillaMaestra.master" %>
<asp:Content ContentPlaceHolderID="menuVertical" ID="menuVerticalContent" runat="server">
   <gaia:ValidationSummary ID="ValidacionAltaSala" runat="server" />
	
	<gaia:Panel id="pnlMenuVertical"  
			 style=" POSITION: relative;" 
			 Height="225px" 
	         Width="75px"			
	         runat="server"           
			 BackColor="LightGreen">
	
			<asp:Menu ID="MenuSalaVertical" runat="server" Orientation="Vertical">
				<Items>							
					<asp:MenuItem Text="Alta" Value="1" Selected="true"/>
					<asp:MenuItem NavigateUrl="~/Salas/BusquedaSala.aspx" Text="Consulta" Value="2" />
					<asp:MenuItem NavigateUrl="~/Salas/ModificacionSala.aspx" Text="Modificación" Value="3" />				
				</Items>
			</asp:Menu>
		</gaia:Panel>	
</asp:Content>
<asp:Content ContentPlaceHolderID="contenido" ID="contenidoContent" runat="server">
	<gaia:Panel id="pnlAltaSala" 
	         style="POSITION: relative" 
	         runat="server" 
	         Height="225px" 
	         Width="800px"			
			 BorderStyle="Dotted" BorderWidth="1">
	<asp:Table HorizontalAlign="Center">
		<asp:TableRow>	
			<asp:TableCell HorizontalAlign="Center">
				<gaia:Label ID="lblAltaSala" runat="server">Alta Sala</gaia:Label>
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
						<asp:Table id="tblDatosSala" runat="server">
							<asp:TableRow >
						       	<asp:TableCell><asp:Label id="lblNombre" Runat="server" text="Nombre:"/></asp:TableCell>
						       	<asp:TableCell>
									<gaia:TextBox id="txtNombre" Runat="server"/>
									<gaia:RequiredFieldValidator ID="RequiredNombreAltaSala" runat="server" ControlToValidate="txtNombre" ErrorMessage="Introduzca Nombre">*
									</gaia:RequiredFieldValidator>
								</asp:TableCell>
							</asp:TableRow>
						    <asp:TableRow>		
								<asp:TableCell><asp:Label id="lblDescripcion" Runat="server" text="Descripcion:"/></asp:TableCell>
							    <asp:TableCell>
									<gaia:TextBox id="txtDescripcion" Runat="server" TextMode="MultiLine" Rows="3"/>
									<gaia:RequiredFieldValidator ID="RequiredDescripcionAltaSala" runat="server" ControlToValidate="txtDescripcion" ErrorMessage="Introduzca Descripción">*
									</gaia:RequiredFieldValidator>
								</asp:TableCell>
						    </asp:TableRow>		
							<asp:TableRow>
						       	<asp:TableCell><asp:Label id="lblHabilitado" Runat="server" text="Habilitada:"/></asp:TableCell>
								<asp:TableCell>
						       		<gaia:Checkbox id="chkHabilitadoAltaSala" Runat="server" Checked="true"/>
								</asp:TableCell>
						    </asp:TableRow>						
						</asp:Table>
					</gaia:Panel>
				</asp:TableCell>
			</asp:TableRow>
	
		</asp:Table>
		<asp:Table HorizontalAlign="Center">
			<asp:TableRow>	
				<asp:TableCell>
					<gaia:Button ID="btnGrabar" runat="server" Text="Grabar" OnClick="btnGrabar_Click" />
				</asp:TableCell>						 
			</asp:TableRow>	
			<asp:TableRow>	
				<asp:TableCell>
					<gaia:Label ID="lblResultadoOperacion" runat="server"/>
				</asp:TableCell>						 
			</asp:TableRow>
		</asp:Table>	
	</gaia:Panel>
	
</asp:Content>



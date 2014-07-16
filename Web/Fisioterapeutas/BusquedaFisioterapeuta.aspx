<%@ Page Language="C#" Inherits="Web.Fisioterapeutas.BusquedaFisioterapeuta" MasterPageFile="~/Plantillas/PlantillaMaestra.master" %>
<%@ MasterType VirtualPath="~/Plantillas/PlantillaMaestra.master" %>
<asp:Content ContentPlaceHolderID="menuVertical" ID="menuVerticalContent" runat="server">
   <gaia:ValidationSummary ID="ValidacionBusquedaFisioterapeuta" runat="server" />
	
	<gaia:Panel id="pnlMenuVertical"  
			 style=" POSITION: relative;" 
			 Height="225px" 
	         Width="75px"			
	         runat="server"           
			 BackColor="LightGreen">
	
			<asp:Menu ID="MenuFisioterapeutaVertical" runat="server" Orientation="Vertical">
				<Items>							
					<asp:MenuItem Text="Consulta" Value="1" Selected="true"/>
					<asp:MenuItem NavigateUrl="~/Fisioterapeutas/AltaFisioterapeuta.aspx" Text="Alta" Value="2" />				
				</Items>
			</asp:Menu>
		</gaia:Panel>		
</asp:Content>
<asp:Content ContentPlaceHolderID="contenido" ID="contenidoContent" runat="server">
	<gaia:Panel id="pnlBusquedaFisioterapeuta" 
	         style="POSITION: relative" 
	         runat="server" 
	         Height="225px" 
	         Width="800px"			
			 BorderStyle="Dotted" BorderWidth="1">
	<asp:Table HorizontalAlign="Center">
		<asp:TableRow>	
			<asp:TableCell HorizontalAlign="Center">
				<gaia:Label ID="lblBusquedaFisioterapeuta" runat="server">Busqueda Fisioterapeuta</gaia:Label>
			</asp:TableCell>						 
		</asp:TableRow>	
	</asp:Table>		
	<asp:Table id="tblBusquedaFisioterapeuta" runat="server">
			<asp:TableRow>
				<asp:TableCell>
					<gaia:Panel id="pnlDatosFisioterapeuta"
				         style="POSITION: relative" 
				         runat="server" 
				         Height="175px" 
				         Width="400px"
						 BackColor="BlanchedAlmond"
						 BorderStyle="Dotted" BorderWidth="1">
						<asp:Table id="tblDatosFisioterapeuta" runat="server">
	
							<asp:TableRow >
								<asp:TableCell>
									<asp:Table id="tblDatosParticulares" runat="server">
										<asp:TableRow>
											<asp:TableCell><asp:Label id="lblNIF" Runat="server" text="NIF:"></asp:Label></asp:TableCell>
											<asp:TableCell>
												<gaia:TextBox id="txtNIF" Runat="server"/>	
											</asp:TableCell>
										</asp:TableRow>	
										<asp:TableRow >
									       	<asp:TableCell><asp:Label id="lblNombre" Runat="server" text="Nombre:"></asp:Label></asp:TableCell>
									       	<asp:TableCell>
												<gaia:TextBox id="txtNombre" Runat="server"/>
											</asp:TableCell>
										</asp:TableRow>
									    <asp:TableRow>		
									       <asp:TableCell><asp:Label id="lblApellido1" Runat="server" text="Apellido1:"></asp:Label></asp:TableCell>
									       <asp:TableCell>
												<gaia:TextBox id="txtApellido1" Runat="server"/>
											</asp:TableCell>
									    </asp:TableRow>		
									    <asp:TableRow>
									       <asp:TableCell><asp:Label id="lblApellido2" Runat="server" text="Apellido2:"></asp:Label></asp:TableCell>
									       <asp:TableCell><gaia:TextBox id="txtApellido2" Runat="server"/></asp:TableCell>
									    </asp:TableRow>				
									</asp:Table>
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
					<gaia:Button ID="btnGrabar" runat="server" Text="Buscar" OnClick="btnBuscarFisioterapeuta_Click" />
				</asp:TableCell>						 
			</asp:TableRow>	
		</asp:Table>	
	</gaia:Panel>		
</asp:Content>



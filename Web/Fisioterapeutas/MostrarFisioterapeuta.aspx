<%@ Page Language="C#" Inherits="Web.Fisioterapeutas.MostrarFisioterapeuta" MasterPageFile="~/Plantillas/PlantillaMaestra.master" %>
<%@ MasterType VirtualPath="~/Plantillas/PlantillaMaestra.master" %>
<asp:Content ContentPlaceHolderID="menuVertical" ID="menuVerticalContent" runat="server">
	<gaia:Panel id="pnlMenuVertical"  
			 style=" POSITION: relative;" 
			 Height="225px" 
	         Width="75px"			
	         runat="server"           
			 BackColor="LightGreen">
	
			<asp:Menu ID="MenuPersonaVertical" runat="server" Orientation="Vertical">
				<Items>							
					<asp:MenuItem NavigateUrl="~/Personas/BusquedaFisioterapeuta.aspx" Text="Consulta" Value="1" />
					<asp:MenuItem Text="Alta" Value="2" Selected="true"/>				
				</Items>
			</asp:Menu>
		</gaia:Panel>	
</asp:Content>
<asp:Content ContentPlaceHolderID="contenido" ID="contenidoContent" runat="server">
	<gaia:Panel id="pnlMostarFisioterapeuta" 
	         style="POSITION: relative" 
	         runat="server" 
	         Height="350px" 
	         Width="900px"			
			 BorderStyle="Dotted" BorderWidth="1">
	<asp:Table HorizontalAlign="Center">
		<asp:TableRow>	
			<asp:TableCell HorizontalAlign="Center">
				<gaia:Label ID="lblMostarFisioterapeuta" runat="server">Mostrar Fisioterapeuta</gaia:Label>
			</asp:TableCell>						 
		</asp:TableRow>	
	</asp:Table>		
	<asp:Table id="tblMostarFisioterapeuta" runat="server">
			<asp:TableRow>
				<asp:TableCell>
					<gaia:Panel id="pnlDatosFisioterapeuta"
				         style="POSITION: relative" 
				         runat="server" 
				         Height="400px" 
				         Width="400px"
						 BackColor="BlanchedAlmond"
						 BorderStyle="Dotted" BorderWidth="1">
						<asp:Table id="tblDatosFisioterapeuta" runat="server">
							<asp:TableRow >
								<asp:TableCell>
									<asp:Table id="tblDatosPersonales" runat="server">
										<asp:TableRow >
									       	<asp:TableCell><asp:Label id="lblNombre" Runat="server" text="Nombre:"></asp:Label></asp:TableCell>
									       	<asp:TableCell>
												<gaia:TextBox id="txtNombre" Runat="server" Enabled="false" />
											</asp:TableCell>
										</asp:TableRow>
									    <asp:TableRow>		
									       <asp:TableCell><asp:Label id="lblApellido1" Runat="server" text="Apellido1:"></asp:Label></asp:TableCell>
									       <asp:TableCell>
												<gaia:TextBox id="txtApellido1" Runat="server" Enabled="false" />
											</asp:TableCell>
									    </asp:TableRow>		
									    <asp:TableRow>
									       <asp:TableCell><asp:Label id="lblApellido2" Runat="server" text="Apellido2:"></asp:Label></asp:TableCell>
									       <asp:TableCell><gaia:TextBox id="txtApellido2" Runat="server" Enabled="false" /></asp:TableCell>
									    </asp:TableRow>
									    <asp:TableRow>
									       <asp:TableCell><asp:Label id="lblNIF" Runat="server" text="NIF:"></asp:Label></asp:TableCell>
									       <asp:TableCell>
												<gaia:TextBox id="txtNIF" Runat="server" Enabled="false" />																								
											</asp:TableCell>
									    </asp:TableRow>
									    <asp:TableRow>
									       <asp:TableCell><asp:Label id="lblFechaNacimiento" Runat="server" text="Fecha de Nacimiento(dd/mm/aaaa):"></asp:Label></asp:TableCell>
									       <asp:TableCell>
												<gaia:TextBox id="txtFechaNacimiento" Runat="server" Enabled="false" />
											</asp:TableCell>
									    </asp:TableRow>
									    <asp:TableRow>
									       <asp:TableCell><asp:Label id="lblTelefonoFijo" Runat="server" text="Teléfono Fijo:"></asp:Label></asp:TableCell>
									       <asp:TableCell>
												<gaia:TextBox id="txtTelefonoFijo" Runat="server" Enabled="false" />
											</asp:TableCell>
									    </asp:TableRow>
									    <asp:TableRow>
									       <asp:TableCell><asp:Label id="lblTelefonoMovil" Runat="server" text="Teléfono Móvil:"></asp:Label></asp:TableCell>
									       <asp:TableCell>
												<gaia:TextBox id="txtTelefonoMovil" Runat="server" Enabled="false" />
											</asp:TableCell>
									    </asp:TableRow>	
									    <asp:TableRow>
									       <asp:TableCell><asp:Label id="lblEmail" Runat="server" text="Email:"></asp:Label></asp:TableCell>
									       <asp:TableCell>
												<gaia:TextBox id="txtEmail" Runat="server" Enabled="false" />
											</asp:TableCell>
									    </asp:TableRow>	
									    <asp:TableRow>
									       <asp:TableCell><asp:Label id="lblNumeroColegiado" Runat="server" text="Número Colegiado:"></asp:Label></asp:TableCell>
									       <asp:TableCell>
												<gaia:TextBox id="txtNumeroColegiado" Runat="server" Enabled="false" />
											</asp:TableCell>
									    </asp:TableRow>
									    <asp:TableRow>
									       <asp:TableCell><asp:Label id="lblFechaTitulacion" Runat="server" text="Fecha Titulación:"></asp:Label></asp:TableCell>
									       <asp:TableCell>
												<gaia:TextBox id="txtFechaTitulacion" Runat="server" Enabled="false" />
											</asp:TableCell>
									    </asp:TableRow>											
									    <asp:TableRow>
									       <asp:TableCell><asp:Label id="lblFechaIngreso" Runat="server" text="Fecha Ingreso:"></asp:Label></asp:TableCell>
									       <asp:TableCell>
												<gaia:TextBox id="txtFechaIngreso" Runat="server" Enabled="false" />
											</asp:TableCell>
									    </asp:TableRow>	
									    <asp:TableRow>
									       <asp:TableCell><asp:Label id="lblFechaBaja" Runat="server" text="Fecha Baja:"></asp:Label></asp:TableCell>
									       <asp:TableCell>
												<gaia:TextBox id="txtFechaBaja" Runat="server" Enabled="false" />
											</asp:TableCell>
									    </asp:TableRow>	
										<asp:TableRow >
									       	<asp:TableCell><asp:Label id="lblTitulaciones" Runat="server" text="Titulacion:"></asp:Label></asp:TableCell>
									       	<asp:TableCell>
												 <gaia:TextBox id="txtTitulacion" Runat="server" Enabled="false" />									
											</asp:TableCell>
										</asp:TableRow>			
										<asp:TableRow >
									       	<asp:TableCell><asp:Label id="lblTiposContrato" Runat="server" text="Tipo Contrato:"></asp:Label></asp:TableCell>
									       	<asp:TableCell>
												 <gaia:TextBox id="txtTipoContrato" Runat="server" Enabled="false" />
											</asp:TableCell>
										</asp:TableRow>								
									</asp:Table>
								</asp:TableCell>
							</asp:TableRow>
						</asp:Table>
					</gaia:Panel>
				</asp:TableCell>

				<asp:TableCell>
					<gaia:Panel id="pnlDireccionFisioterapeuta" 
				         style="POSITION: relative" 
				         runat="server" 
				         Height="400px" 
				         Width="400px"
						 BackColor="BlanchedAlmond"
						 BorderStyle="Dotted" BorderWidth="1">
						<asp:Table>
							<asp:TableRow>
								<asp:TableCell>
									<asp:Table id="tblDatosdireccion" runat="server">
										<asp:TableRow >
									       <asp:TableCell><asp:Label id="lblVia" Runat="server" text="Via:"></asp:Label></asp:TableCell>
									       <asp:TableCell>
												<gaia:TextBox id="txtVia" Runat="server" Enabled="false"/>
											</asp:TableCell>
										</asp:TableRow>
									    <asp:TableRow>		
									       <asp:TableCell><asp:Label id="lblNumero" Runat="server" text="Numero:"></asp:Label></asp:TableCell>
									       <asp:TableCell>
												<gaia:TextBox id="txtNumeroVia" Runat="server" Enabled="false"/>
											</asp:TableCell>
									    </asp:TableRow>		
									    <asp:TableRow>
									       <asp:TableCell><asp:Label id="lblRestoDireccion" Runat="server" text="Resto de la Direccion:"></asp:Label></asp:TableCell>
									       <asp:TableCell><gaia:TextBox id="txtRestoDireccion" Runat="server" Enabled="false"/></asp:TableCell>
									    </asp:TableRow>
									    <asp:TableRow>
									       <asp:TableCell><asp:Label id="lblLocalidad" Runat="server" text="Localidad:"></asp:Label></asp:TableCell>
									       <asp:TableCell>
												<gaia:TextBox id="txtLocalidad" Runat="server" Enabled="false"/>
											</asp:TableCell>
									    </asp:TableRow>
									    <asp:TableRow>
									       <asp:TableCell><asp:Label id="lblCP" Runat="server" text="Codigo Postal:"></asp:Label></asp:TableCell>
									       <asp:TableCell>
												<gaia:TextBox id="txtCP" Runat="server" Enabled="false"/>
											</asp:TableCell>
									    </asp:TableRow>	
									    <asp:TableRow>
									       <asp:TableCell><asp:Label id="lblProvincia" Runat="server" text="Provincia:"></asp:Label></asp:TableCell>
									       <asp:TableCell>
												<gaia:TextBox id="txtProvincia" Runat="server" Enabled="false"/>
											</asp:TableCell>
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
					<gaia:Button ID="btnDarBaja" runat="server" Text="Dar de Baja" OnClick="btnDarBaja_Click" />
				</asp:TableCell>	
				<asp:TableCell>
					<gaia:Button ID="btnDarCita" runat="server" Text="Dar Cita" OnClick="btnDarCita_Click" />
				</asp:TableCell>
				<asp:TableCell>
					<gaia:Button ID="btnDarAlta" runat="server" Text="Dar de Alta" OnClick="btnDarAlta_Click" />
				</asp:TableCell>		
			</asp:TableRow>	
		
		</asp:Table>	
	</gaia:Panel>		
</asp:Content>



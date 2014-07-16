<%@ Page Language="C#" Inherits="Web.AltaFisioterapeuta" MasterPageFile="~/Plantillas/PlantillaMaestra.master" %>
<%@ MasterType VirtualPath="~/Plantillas/PlantillaMaestra.master" %>
<asp:Content ContentPlaceHolderID="menuVertical" ID="menuVerticalContent" runat="server">
	<gaia:Panel id="pnlMenuVertical"  
			 style=" POSITION: relative;" 
			 Height="350px" 
	         Width="75px"			
	         runat="server"           
			 BackColor="LightGreen">
	
			<asp:Menu ID="MenuFisioterapeutaVertical" runat="server" Orientation="Vertical">
				<Items>							
					<asp:MenuItem NavigateUrl="~/Fisioterapeutas/BusquedaFisioterapeuta.aspx" Text="Consulta" Value="1" />
					<asp:MenuItem Text="Alta" Value="2" Selected="true"/>				
				</Items>
			</asp:Menu>
		</gaia:Panel>		
</asp:Content>
<asp:Content ContentPlaceHolderID="contenido" ID="contenidoContent" runat="server">
	<gaia:Panel id="pnlAltaFisioterapeuta" 
	         style="POSITION: relative" 
	         runat="server" 
	         Height="350px" 
	         Width="900px"			
			 BorderStyle="Dotted" BorderWidth="1">
	<asp:Table HorizontalAlign="Center">
		<asp:TableRow>	
			<asp:TableCell HorizontalAlign="Center">
				<gaia:Label ID="lblAltaFisioterapeuta" runat="server">Alta Fisioterapeuta</gaia:Label>
			</asp:TableCell>						 
		</asp:TableRow>	
	</asp:Table>		
	<asp:Table id="tblAltaFisioterapeuta" runat="server">
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
												<gaia:TextBox id="txtNombre" Runat="server"/>
												<gaia:RequiredFieldValidator ID="RequiredNombreAltaFisioterapeuta" runat="server" ControlToValidate="txtNombre" ErrorMessage="Introduzca Nombre">*
												</gaia:RequiredFieldValidator>
											</asp:TableCell>
										</asp:TableRow>
									    <asp:TableRow>		
									       <asp:TableCell><asp:Label id="lblApellido1" Runat="server" text="Apellido1:"></asp:Label></asp:TableCell>
									       <asp:TableCell>
												<gaia:TextBox id="txtApellido1" Runat="server"/>
												<gaia:RequiredFieldValidator ID="RequiredApellido1AltaFisioterapeuta" runat="server" ControlToValidate="txtApellido1" ErrorMessage="Introduzca Primer Apellido">*
												</gaia:RequiredFieldValidator>
											</asp:TableCell>
									    </asp:TableRow>		
									    <asp:TableRow>
									       <asp:TableCell><asp:Label id="lblApellido2" Runat="server" text="Apellido2:"></asp:Label></asp:TableCell>
									       <asp:TableCell><gaia:TextBox id="txtApellido2" Runat="server"/></asp:TableCell>
									    </asp:TableRow>
									    <asp:TableRow>
									       <asp:TableCell><asp:Label id="lblNIF" Runat="server" text="NIF:"></asp:Label></asp:TableCell>
									       <asp:TableCell>
												<gaia:TextBox id="txtNIF" Runat="server"/>																								
												<gaia:RequiredFieldValidator ID="RequiredNIFAltaFisioterapeuta" runat="server" ControlToValidate="txtNIF" ErrorMessage="Introduzca NIF">*
												</gaia:RequiredFieldValidator>
											</asp:TableCell>
									    </asp:TableRow>
									    <asp:TableRow>
									       <asp:TableCell><asp:Label id="lblFechaNacimiento" Runat="server" text="Fecha de Nacimiento(dd/mm/aaaa):"></asp:Label></asp:TableCell>
									       <asp:TableCell>
												<gaia:TextBox id="txtFechaNacimiento" Runat="server"/>
												<gaia:RequiredFieldValidator ID="RequiredFechaNacimientoAltaFisioterapeuta" runat="server" ControlToValidate="txtFechaNacimiento" ErrorMessage="Introduzca Fecha de Nacimiento">*
												</gaia:RequiredFieldValidator>
											</asp:TableCell>
									    </asp:TableRow>
									    <asp:TableRow>
									       <asp:TableCell><asp:Label id="lblTelefonoFijo" Runat="server" text="Teléfono Fijo:"></asp:Label></asp:TableCell>
									       <asp:TableCell>
												<gaia:TextBox id="txtTelefonoFijo" Runat="server"/>
											</asp:TableCell>
									    </asp:TableRow>
									    <asp:TableRow>
									       <asp:TableCell><asp:Label id="lblTelefonoMovil" Runat="server" text="Teléfono Móvil:"></asp:Label></asp:TableCell>
									       <asp:TableCell>
												<gaia:TextBox id="txtTelefonoMovil" Runat="server"/>
											</asp:TableCell>
									    </asp:TableRow>	
									    <asp:TableRow>
									       <asp:TableCell><asp:Label id="lblEmail" Runat="server" text="Email:"></asp:Label></asp:TableCell>
									       <asp:TableCell>
												<gaia:TextBox id="txtEmail" Runat="server"/>
											</asp:TableCell>
									    </asp:TableRow>	
									    <asp:TableRow>
									       <asp:TableCell><asp:Label id="lblNumeroColegiado" Runat="server" text="Número Colegiado:"></asp:Label></asp:TableCell>
									       <asp:TableCell>
												<gaia:TextBox id="txtNumeroColegiado" Runat="server"/>
												<gaia:RequiredFieldValidator ID="RequiredNuemeroColegiadoFisioterapeuta" runat="server" ControlToValidate="txtNumeroColegiado" ErrorMessage="Introduzca número de colegiado">*
												</gaia:RequiredFieldValidator>
											</asp:TableCell>
									    </asp:TableRow>
									    <asp:TableRow>
									       <asp:TableCell><asp:Label id="lblFechaTitulacion" Runat="server" text="Fecha Titulación:"></asp:Label></asp:TableCell>
									       <asp:TableCell>
												<gaia:TextBox id="txtFechaTitulacion" Runat="server"/>
												<gaia:RequiredFieldValidator ID="RequiredFechaTitulacionFisioterapeuta" runat="server" ControlToValidate="txtFechatitulacion" ErrorMessage="Introduzca fecha de titualcion">*
												</gaia:RequiredFieldValidator>
											</asp:TableCell>
									    </asp:TableRow>											
									    <asp:TableRow>
									       <asp:TableCell><asp:Label id="lblFechaIngreso" Runat="server" text="Fecha Ingreso:"></asp:Label></asp:TableCell>
									       <asp:TableCell>
												<gaia:TextBox id="txtFechaIngreso" Runat="server"/>
												<gaia:RequiredFieldValidator ID="RequiredFechaIngresoFisioterapeuta" runat="server" ControlToValidate="txtFechaIngreso" ErrorMessage="Introduzca fecha de ingreso">*
												</gaia:RequiredFieldValidator>
											</asp:TableCell>
									    </asp:TableRow>	
										<asp:TableRow >
									       	<asp:TableCell><asp:Label id="lblTitulaciones" Runat="server" text="Titulacion:"></asp:Label></asp:TableCell>
									       	<asp:TableCell>
												 <gaia:DropDownList ID="ddlTitulaciones" runat="server" AutoPostBack="True" Width="150px" />
											</asp:TableCell>
										</asp:TableRow>			
										<asp:TableRow >
									       	<asp:TableCell><asp:Label id="lblTiposContrato" Runat="server" text="Tipo Contrato:"></asp:Label></asp:TableCell>
									       	<asp:TableCell>
												 <gaia:DropDownList ID="ddlTiposContrato" runat="server" AutoPostBack="True" Width="150px" />
											</asp:TableCell>
										</asp:TableRow>		
										<asp:TableRow >
									       	<asp:TableCell><asp:Label id="lblProyectoContratacion" Runat="server" text="ProyectoContratacion:"></asp:Label></asp:TableCell>
									       	<asp:TableCell>
												 <gaia:DropDownList ID="ddlProyectoContratacion" runat="server" AutoPostBack="True" Width="150px" />
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
												<gaia:TextBox id="txtVia" Runat="server"/>
												<gaia:RequiredFieldValidator ID="RequiredViaAltaFisioterapeuta" runat="server" ControlToValidate="txtVia" ErrorMessage="Introduzca Via">*
												</gaia:RequiredFieldValidator>
											</asp:TableCell>
										</asp:TableRow>
									    <asp:TableRow>		
									       <asp:TableCell><asp:Label id="lblNumero" Runat="server" text="Numero:"></asp:Label></asp:TableCell>
									       <asp:TableCell>
												<gaia:TextBox id="txtNumeroVia" Runat="server"/>
												<gaia:RequiredFieldValidator ID="RequiredNumerViaAltaFisioterapeuta" runat="server" ControlToValidate="txtNumeroVia" ErrorMessage="Introduzca Número de Vía">*
												</gaia:RequiredFieldValidator>
											</asp:TableCell>
									    </asp:TableRow>		
									    <asp:TableRow>
									       <asp:TableCell><asp:Label id="lblRestoDireccion" Runat="server" text="Resto de la Direccion:"></asp:Label></asp:TableCell>
									       <asp:TableCell><gaia:TextBox id="txtRestoDireccion" Runat="server"/></asp:TableCell>
									    </asp:TableRow>
									    <asp:TableRow>
									       <asp:TableCell><asp:Label id="lblLocalidad" Runat="server" text="Localidad:"></asp:Label></asp:TableCell>
									       <asp:TableCell>
												<gaia:TextBox id="txtLocalidad" Runat="server"/>
												<gaia:RequiredFieldValidator ID="RequiredLocalidadAltaFisioterapeuta" runat="server" ControlToValidate="txtLocalidad" ErrorMessage="Introduzca Localidad">*
												</gaia:RequiredFieldValidator>
											</asp:TableCell>
									    </asp:TableRow>
									    <asp:TableRow>
									       <asp:TableCell><asp:Label id="lblCP" Runat="server" text="Codigo Postal:"></asp:Label></asp:TableCell>
									       <asp:TableCell>
												<gaia:TextBox id="txtCP" Runat="server"/>
												<gaia:RequiredFieldValidator ID="RequiredCP" runat="server" ControlToValidate="txtCP" ErrorMessage="Introduzca Código Postal">*
												</gaia:RequiredFieldValidator>
											</asp:TableCell>
									    </asp:TableRow>	
									    <asp:TableRow>
									       <asp:TableCell><asp:Label id="lblProvincia" Runat="server" text="Provincia:"></asp:Label></asp:TableCell>
									       <asp:TableCell>
												<gaia:DropDownList ID="ddlProvincias" runat="server" AutoPostBack="True" Width="150px" />
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
					<gaia:Button ID="btnGrabar" runat="server" Text="Grabar" OnClick="btnGrabar_Click" />
				</asp:TableCell>
				<asp:TableCell>
					<gaia:ValidationSummary ID="ValidacionAltaFisioterapeuta" runat="server" />
				</asp:TableCell>			
			</asp:TableRow>	
		</asp:Table>	
	</gaia:Panel>	
</asp:Content>



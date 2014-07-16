<%@ Page Language="C#" Inherits="Web.Pacientes.InicioTratamiento" MasterPageFile="~/Plantillas/PlantillaMaestra.master" %>
<%@ MasterType VirtualPath="~/Plantillas/PlantillaMaestra.master" %>

<asp:Content ContentPlaceHolderID="menuVertical" ID="menuVerticalContent" runat="server">
   <gaia:ValidationSummary ID="ValidacionInicioTratamiento" runat="server" />
	
	<gaia:Panel id="pnlMenuVertical"  
			 style=" POSITION: relative;" 
			 Height="225px" 
	         Width="75px"			
	         runat="server"           
			 BackColor="LightGreen">
	
			<asp:Menu ID="MenuPersonaPacienteVertical" runat="server" Orientation="Vertical">
				<Items>							
					<asp:MenuItem NavigateUrl="~/Pacientes/BusquedaPacientes.aspx" Text="Consulta" Value="1" />
					<asp:MenuItem Text="Alta" Value="2" Selected="true"/>				
				</Items>
			</asp:Menu>
		</gaia:Panel>	
	
</asp:Content>
<asp:Content ContentPlaceHolderID="contenido" ID="contenidoContent" runat="server">
	<gaia:Panel id="pnlInicioTratamiento" 
	         style="POSITION: relative" 
	         runat="server" 
	         Height="225px" 
	         Width="800px"			
			 BorderStyle="Dotted" BorderWidth="1">
	<asp:Table HorizontalAlign="Center">
		<asp:TableRow>	
			<asp:TableCell HorizontalAlign="Center">
				<gaia:Label ID="lblBusquedaPaciente" runat="server">Inicio Tratamiento del Paciente</gaia:Label>
			</asp:TableCell>						 
		</asp:TableRow>	
	</asp:Table>		
	<asp:Table id="tblParametrosIncialesInicioTratamiento" runat="server">
			<asp:TableRow>
				<asp:TableCell>
					<gaia:Panel id="pnlParametrosInicialesInicioTratamiento"
				         style="POSITION: relative" 
				         runat="server" 
				         Height="175px" 
				         Width="300px"
						 BackColor="BlanchedAlmond"
						 BorderStyle="Dotted" BorderWidth="1">
						<asp:Table id="tblDatosPaciente" runat="server">
	
							<asp:TableRow >
								<asp:TableCell>
									<asp:Table id="tblDatosParticulares" runat="server">
										<asp:TableRow >
									       	<asp:TableCell><asp:Label id="lblFisioterapeuta" Runat="server" text="Fisioterapeuta:"></asp:Label></asp:TableCell>
									       	<asp:TableCell>
												 <gaia:DropDownList ID="ddlFisioterapeuta" runat="server" AutoPostBack="True" Width="150px" />
											</asp:TableCell>
										</asp:TableRow>	
										<asp:TableRow>
											<asp:TableCell><asp:Label id="lblEstudio" Runat="server" text="Estudio: "></asp:Label></asp:TableCell>
											<asp:TableCell>
												 <gaia:DropDownList ID="ddlEstudio" runat="server" AutoPostBack="True" Width="150px" OnSelectedIndexChanged="ddlEstudio_SelectedIndexChanged" />
											</asp:TableCell>
										</asp:TableRow>
										<asp:TableRow >
											<asp:TableCell><asp:Label id="lblGrupoTratamiento" Runat="server" text="GrupoTratamiento: "></asp:Label></asp:TableCell>											
									       <asp:TableCell>
												<gaia:TextBox id="txtGrupoTratamiento" Runat="server" Enabled="false"/>
											</asp:TableCell>
										</asp:TableRow>	
										<asp:TableRow >
										<asp:TableCell><asp:Label id="lblNumeroSesionesDefecto" Runat="server" text="Número sesiones por defecto: "></asp:Label></asp:TableCell>											
									       <asp:TableCell>
												<gaia:TextBox id="txtNumeroSesionesDefecto" Runat="server" Enabled="false"/>
											</asp:TableCell>
										</asp:TableRow>		
										<asp:TableRow >
											<asp:TableCell><asp:Label id="lblNumeroSesiones" Runat="server" text="Número Sesiones: "></asp:Label></asp:TableCell>											
									       <asp:TableCell>
												<gaia:TextBox id="txtNumeroSesiones" Runat="server"/>
											</asp:TableCell>
										</asp:TableRow>		
									</asp:Table>
								</asp:TableCell>
							</asp:TableRow>
						</asp:Table>
					</gaia:Panel>
				</asp:TableCell>
			
			<asp:TableCell>
					<gaia:Panel id="pnlPrimeraValoracion" 
				         style="POSITION: relative" 
				         runat="server" 
				         Height="175px" 
				         Width="485px"
						 BackColor="BlanchedAlmond"
						 BorderStyle="Dotted" BorderWidth="1">
						<asp:Table>
							<asp:TableRow>
								<asp:TableCell>
									<asp:Table id="tblDatosdireccion" runat="server">
										<asp:TableRow >
									       <asp:TableCell><asp:Label id="lblPrimeraValoracion" Runat="server" text="Primera Valoración:"></asp:Label></asp:TableCell>
										</asp:TableRow>	
										<asp:TableRow >
									       
									       <asp:TableCell>
												<gaia:TextBox id="txtVia" Runat="server" Rows="10" TextMode="MultiLine" Columns="60"/>
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
					<gaia:Button ID="btnDarCita" runat="server" Text="Dar Primera Cita" OnClick="btnDarCita_Click" />
				</asp:TableCell>
				<asp:TableCell>
					<gaia:Button ID="btnTerminar" runat="server" Text="Terminar" OnClick="btnTerminar_Click" />
				</asp:TableCell>						 
			</asp:TableRow>	
		</asp:Table>
	
	</gaia:Panel>		
</asp:Content>



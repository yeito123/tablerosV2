﻿<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="TblEstadosCt.aspx.vb" Inherits="TablerosV2.TblEstadosCt" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxtoolkit" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
	<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
	<title>Estados</title>
	<link rel="stylesheet" href="Bootstrap/css/bootstrap.min.css" />
	<script src="Bootstrap/js/jquery-2.1.4.min.js"></script>
	<script src="Bootstrap/js/bootstrap.min.js"></script>
	<style type="text/css">
		.modalBack {
			background-color: black;
			filter: alpha(opacity=90);
			opacity: 0.8;
			z-index: 10000;
		}

		.resaltar {
			background-color: #FFFFFF;
		}
	</style>
	<script type="text/javascript">
		function salir() {
			alert("mensaje de alerta");
			var obj = document.getElementById("imgDetalle");
			if (obj) {
				obj.click();
			}
		}

		$.expr[':'].icontains = function (obj, index, meta, stack) {
			return (obj.textContent || obj.innerText || jQuery(obj).text() || '').toLowerCase().indexOf(meta[3].toLowerCase()) >= 0;
		};
		$(document).ready(function () {
			$('#buscador').keyup(function () {
				buscar = $(this).val();
				var jo1 = $("#GridCuerpoAsesores").find("tr");
				if (jQuery.trim(buscar) != '') { jo1.parents('tr').hide(); } else { jo1.parents('tr').show(); }

				$('#GridCuerpoAsesores tr').removeClass('resaltar');
				if (jQuery.trim(buscar) != '') {
					$("#GridCuerpoAsesores td:icontains('" + buscar + "')").addClass('resaltar');
					var jo = $("#GridCuerpoAsesores td:icontains('" + buscar + "')").parents('tr');
					jo.show();
				}
			});

			$('.refMensaje').click(function () {
				agencia = "AUTOMONTANA"
				console.log(this.dataset.placas)
				placa = this.dataset.placas
				telefono = "57" + this.dataset.telefono
				mensaje = agencia + " quiere informarle que su vehiculo con placas: " + placa + " se encuentra listo para la entrega."
				//url = "http://API.whatsapp.com://send?phone=" + telefono + "&text=" + mensaje
				//url = "https://web.whatsapp.com://send?phone="+ telefono +"&text=" + mensaje	
				url = "https://web.whatsapp.com://send?text=" + mensaje
				window.open(url, '', '');
				$('#lblPLacaMsg').val(this.dataset.idhd);
				$('#lblMensaje').val(mensaje);
				__doPostBack('btnMsn', '');
			});
		});


	</script>
</head>
<body style="margin-bottom: 0">
	<form id="form1" runat="server" class="form-inline">
		<ajaxtoolkit:ToolkitScriptManager ID="ScripManager1" runat="server"></ajaxtoolkit:ToolkitScriptManager>
		<asp:Button ID="btnMsn" runat="server" Text='GuardaRegistro' Style="display: none;"></asp:Button>
		<asp:HiddenField ID="lblPLacaMsg" runat="server" />
		<asp:HiddenField ID="lblMensaje" runat="server" />
		<asp:HiddenField runat="server" ID="hiddenURLSiguiente" Value="PreciosCT.aspx" />
		<!-- Por codigo en el on_load de la pagina o en el init le pones un valor a ese hidden field -->
		<script type="text/javascript">
			let segundos = 10
			setTimeout(() => { window.location = $('#hiddenURLSiguiente').val() }, segundos * 1000)
		</script>
		<nav class="navbar navbar-default">
			<div class="container-fluid">
				<div class="navbar-header">
					<a class="navbar-brand" href="Inicio.aspx">INICIO</a>
				</div>
				<ul class="nav navbar-nav">
					<li class="active"><a href="tblestados.aspx">Estados</a></li>
					<%--<li><a href="tblRepuestos.aspx">Repuestos</a></li>--%>
				</ul>
				<ul class="nav navbar-nav navbar-right">
					<li><a href="inicio.aspx"><span class="glyphicon glyphicon-arrow-left"></span>Salir</a></li>
				</ul>
			</div>
		</nav>
		<div id="DIvHeader" class="page-header" style="width: 100%; height: 30%; position: relative;">
			<div class="form-inline">
				<h1>Tablero de estados
                    <small>Informacion de las ordenes</small>
				</h1>
				<div id="divContadores" style="position: absolute; left: 60%; top: 4%;">
					<asp:DataGrid runat="server" ID="gridContadorAsesor" CssClass="table table-striped table-condensed"
						AutoGenerateColumns="false" Width="25%" GridLines="None">
						<Columns>
							<asp:BoundColumn DataField="Autorizacion" HeaderText="Autorizacion" ReadOnly="true" Visible="true"></asp:BoundColumn>
							<asp:BoundColumn DataField="CarryOver" HeaderText="Proceso" ReadOnly="true" Visible="true"></asp:BoundColumn>
							<asp:BoundColumn DataField="Repuestos" HeaderText="Repuestos" ReadOnly="true" Visible="true"></asp:BoundColumn>
							<asp:BoundColumn DataField="Calidad" HeaderText="Calidad" ReadOnly="true" Visible="true"></asp:BoundColumn>
							<asp:BoundColumn DataField="Lavado" HeaderText="Lavado" ReadOnly="true" Visible="true"></asp:BoundColumn>
							<asp:BoundColumn DataField="EsperaServicio" HeaderText="Servicio" ReadOnly="true" Visible="true"></asp:BoundColumn>
							<asp:BoundColumn DataField="EnBahia" HeaderText="Iniciado" ReadOnly="true" Visible="true"></asp:BoundColumn>
							<asp:BoundColumn DataField="Terminado" HeaderText="Terminado" ReadOnly="true" Visible="true"></asp:BoundColumn>
						</Columns>
					</asp:DataGrid>
				</div>
			</div>
		</div>
		<div>
			<div id="DivHeader" class="form-inline" style="width: 100%; position: relative; padding: 2em;">
				<div id="divCmdAsesores" class="form-group container">
					<asp:Label runat="server" ID="LblAsesor" CssClass="label" Style="font-size: 1em; color: black;" Text="Asesor:" Visible="false"></asp:Label>
					<asp:DropDownList ID="cmdAsesores" runat="server" CssClass="dropdown form-control" Visible="false"></asp:DropDownList>
					<asp:Button runat="server" ID="btnConsultar" Text="Consultar" CssClass="btn-primary form-control" Visible="false" />
					<div class="col-sm-4 form-inline">
						<div class="form-group">
							<label>Buscar:</label>
							<input name="buscador" id="buscador" class="form-control input-sm" type="text" />
						</div>
					</div>
				</div>
			</div>
			<div id="DivCuerpo" class="auto-style3" style="padding: 2em;">
				<asp:DataGrid runat="server" ID="GridCuerpoAsesores" CssClass="table-responsive table-condensed"
					AutoGenerateColumns="false" Width="100%">
					<HeaderStyle BackColor="#034EC6" ForeColor="White" HorizontalAlign="Center" />
					<ItemStyle ForeColor="Black" HorizontalAlign="Center" />
					<Columns>
						<asp:BoundColumn DataField="noOrden" HeaderText="Orden de Servicio" ReadOnly="true" Visible="true"></asp:BoundColumn>
						<asp:BoundColumn DataField="noPlacas" HeaderText="Placas" ReadOnly="true" Visible="true"></asp:BoundColumn>
						<asp:BoundColumn DataField="Cliente" HeaderText="CLiente" ReadOnly="true" Visible="true"></asp:BoundColumn>
						<asp:BoundColumn DataField="Asesor" HeaderText="Asesor" ReadOnly="true" Visible="false"></asp:BoundColumn>
						<asp:BoundColumn DataField="Fecha_entrada" HeaderText="Fecha Ingreso" ReadOnly="true" Visible="true"></asp:BoundColumn>
						<asp:BoundColumn DataField="Tecnico" HeaderText="Responsable Directo" ReadOnly="true" Visible="true"></asp:BoundColumn>
						<asp:BoundColumn DataField="Status" HeaderText="Estado" ReadOnly="true" Visible="true"></asp:BoundColumn>
						<asp:BoundColumn DataField="idAsesor" HeaderText="IsAsesor" ReadOnly="true" Visible="false"></asp:BoundColumn>
						<asp:BoundColumn DataField="id_hd" HeaderText="Id" ReadOnly="true" Visible="false"></asp:BoundColumn>
						<asp:BoundColumn DataField="alerta" HeaderText="Alerta" ReadOnly="true" Visible="false"></asp:BoundColumn>
						<asp:BoundColumn DataField="Telefono" HeaderText="Telefono" ReadOnly="true" Visible="false"></asp:BoundColumn>
						<asp:TemplateColumn HeaderText="">
							<ItemTemplate>
								<table>
									<tr>
										<td class="col-lg-2">
											<asp:ImageButton runat="server" CssClass="close" ID="imgdet" ImageUrl="~/img/imgDetalle.png" ToolTip="Detalles"
												OnClick="imgdet_Click" Width="15px" Height="15px" />
										</td>
										<td class="col-lg-2">
											<a href="javascript:void(0)"
												class="refMensaje"
												target="_blank"
												data-placas="<%# Eval("NoPlacas") %>"
												data-telefono="<%# Eval("Telefono") %>"
												data-idhd="<%# Eval("id_hd") %>"
												style="font-size: 1em; color: black; text-shadow: none;">M</a>
										</td>
									</tr>
								</table>
							</ItemTemplate>
						</asp:TemplateColumn>
					</Columns>
				</asp:DataGrid>
			</div>
		</div>
		<asp:Button runat="server" ID="btnmodal3"
			Style="display: none" Text="muestramodal" />
		<ajaxtoolkit:ModalPopupExtender ID="mpe" runat="server" TargetControlID="btnmodal3" PopupControlID="PanelDetalle"
			Enabled="true" Drag="true" DropShadow="true" BackgroundCssClass="modalBack">
		</ajaxtoolkit:ModalPopupExtender>
		<asp:Panel runat="server" ID="PanelDetalle" Style="display: none; background: white; width: 100%; height: auto">
			<div class="modal-dialog modal-lg" role="document" style="width: 100%">
				<div class="modal-content">
					<div class="modal-header">
						<asp:Button runat="server" type="button" CssClass="close" data-dismiss="modal" aria-label="Close" Text="x"></asp:Button>
						<h4 class="modal-title" id="myModalLabel">
							<asp:Label runat="server" ID="lblTitulo" Style="background-color">								
							</asp:Label>
							<asp:Label runat="server" ID="lblAsesordet"></asp:Label>
						</h4>
					</div>
					<div class="modal-body">
						<div>
							<div id="dvlform" class="form-group" style="padding: 1em;">
								<asp:Label ID="lblCliente" runat="server" Text="Cliente: "></asp:Label>
								<asp:TextBox ID="txtCliente" runat="server" Text="Nombre CLiente" ReadOnly="true" CssClass="form-control"></asp:TextBox>
								<asp:Label ID="lblTelefono" runat="server" Text="Telefono: "></asp:Label>
								<asp:TextBox ID="txtTelefono" runat="server" Text="Telefono" ReadOnly="true" CssClass="form-control"></asp:TextBox>
								<asp:Label ID="lblIngreso" runat="server" Text="Ingreso: "></asp:Label>
								<asp:TextBox ID="txtIngreso" runat="server" Text="Ingreso" ReadOnly="true" CssClass="form-control"></asp:TextBox>
								<asp:Label ID="lblDiasTaller" runat="server" Text="Dias Taller: "></asp:Label>
								<asp:TextBox ID="txtDiasTaller" runat="server" Text="Dias Taller" ReadOnly="true" CssClass="form-control"></asp:TextBox>
							</div>
							<div id="dlvForm2" class="form-group" style="padding: 1em;">
								<asp:Label ID="lblPlacas" runat="server" Text="Placas: "></asp:Label>
								<asp:TextBox ID="txtPlacas" runat="server" Text="Placas" ReadOnly="true" CssClass="form-control"></asp:TextBox>
								<asp:Label ID="lblNoOrden" runat="server" Text="N° Orden: "></asp:Label>
								<asp:TextBox ID="txtOrden" runat="server" Text="N° Orden" ReadOnly="true" CssClass="form-control"></asp:TextBox>
								<asp:Label ID="lblPromesa" runat="server" Text="P. Entrega: "></asp:Label>
								<asp:TextBox ID="txtPromesa" runat="server" Text="Fecha Promesa" ReadOnly="true" CssClass="form-control"></asp:TextBox>
								<asp:Label ID="lblDiasEstado" runat="server" Text="Dias Estado: "></asp:Label>
								<asp:TextBox ID="txtDiasEstado" runat="server" Text="Dias Estado" ReadOnly="true" CssClass="form-control"></asp:TextBox>
							</div>
						</div>

						<div id="divCuerpoModal" class="auto-style3" style="width: 100%; height: 450px; overflow-y: scroll;">
							<asp:Label Style="display: none;" runat="server" Text="si lo muestra no lo carga"></asp:Label>
							<asp:DataGrid runat="server" ID="GridDetalles" CssClass="table-responsive table-condensed"
								AutoGenerateColumns="false" Width="100%">
								<HeaderStyle BackColor="#034EC6" ForeColor="White" HorizontalAlign="Center" />
								<ItemStyle ForeColor="Black" HorizontalAlign="Center" />
								<Columns>
									<asp:BoundColumn DataField="id" HeaderText="id Chip" ReadOnly="true" Visible="true"></asp:BoundColumn>
									<asp:BoundColumn DataField="fecha_programado" HeaderText="Fecha Programado" ReadOnly="true" Visible="true"></asp:BoundColumn>
									<asp:BoundColumn DataField="hora_programado" HeaderText="Hora Programado" ReadOnly="true" Visible="true"></asp:BoundColumn>
									<asp:BoundColumn DataField="tiempo_programado" HeaderText="Tiempo Programado" ReadOnly="true" Visible="true"></asp:BoundColumn>
									<asp:BoundColumn DataField="Hora_inicio_real" HeaderText="Fecha Inicio Real" ReadOnly="true" Visible="true"></asp:BoundColumn>
									<asp:BoundColumn DataField="Hora_fin_real" HeaderText="Fecha Fin real" ReadOnly="true" Visible="true"></asp:BoundColumn>
									<asp:BoundColumn DataField="duracion" HeaderText="Tiempo real" ReadOnly="true" Visible="true"></asp:BoundColumn>
									<asp:BoundColumn DataField="servicioCapturado" HeaderText="Proceso" ReadOnly="true" Visible="true"></asp:BoundColumn>
									<asp:BoundColumn DataField="tecnico" HeaderText="Encargado" ReadOnly="true" Visible="true"></asp:BoundColumn>
									<asp:BoundColumn DataField="Comentarios" HeaderText="Comentarios" ReadOnly="true" Visible="true"></asp:BoundColumn>
									<asp:BoundColumn DataField="Status" HeaderText="Status" ReadOnly="true" Visible="true"></asp:BoundColumn>
								</Columns>
							</asp:DataGrid>
						</div>
					</div>
				</div>
			</div>
		</asp:Panel>

		<!-- mpe para mensaje -->
		<ajaxtoolkit:ModalPopupExtender ID="mpe2" runat="server" TargetControlID="btnmodal3" PopupControlID="PanelMensaje"
			Enabled="true" Drag="true" DropShadow="true" BackgroundCssClass="modalBack">
		</ajaxtoolkit:ModalPopupExtender>
		<asp:Panel runat="server" ID="PanelMensaje" Style="display: none; background: white; width: 100%; height: auto">
			<div class="modal-dialog modal-lg" role="document" style="width: 100%">
				<div class="modal-content">
					<div class="modal-header">
						<asp:Button runat="server" type="button" CssClass="close" data-dismiss="modal" aria-label="Close" Text="x"></asp:Button>
						<h4 class="modal-title" id="TituloMensaje">
							<asp:Label runat="server" ID="lblTitulo2"></asp:Label>
						</h4>
					</div>
					<div class="modal-body">
						<asp:Label runat="server" ID="lblTexto"></asp:Label>
					</div>
				</div>
			</div>
		</asp:Panel>
		<asp:UpdatePanel ID="pnlPanle" runat="server">
			<ContentTemplate />
			<Triggers>
				<asp:AsyncPostBackTrigger ControlID="btnMsn" EventName="Click" />
			</Triggers>
		</asp:UpdatePanel>
	</form>
</body>
</html>

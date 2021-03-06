<%@ Page Language="VB" AutoEventWireup="false" CodeBehind="RecepcionCitas3b.aspx.vb" Inherits="TablerosV2.RecepcionCitas3b" %>



<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>MAZDA JORGE CORT�S DA LA BIENVENIDA</title>
    <link href="App_Themes/THEME1/StyleSheetRecepcionSeguimiento2.css" rel="stylesheet" />
    <script type="text/javascript" src="JS/jquery-1.9.1.js"></script>
    <script type="text/javascript" src="JS/JavaScriptRecepcionSeguimiento.js"></script>

    <!-- Inicia Relativo a ModalWindowEffects -->
    <link href="res/ModalWindowEffects/css/component.css" rel="stylesheet" />
    <script type="text/javascript" src="res/ModalWindowEffects/js/modernizr.custom.js"></script>
    <!-- classie.js by @desandro: https://github.com/desandro/classie -->
    <script type="text/javascript" src="res/ModalWindowEffects/js/classie.js"></script>
    <script type="text/javascript" src="res/ModalWindowEffects/js/modalEffects.js"></script>
    <!-- Termina Relativo a ModalWindowEffects -->
    
    <style type="text/css">
        @-moz-keyframes mymove {
            0% {
                background-color: red;
            }

            50% {
                background-color: transparent;
            }

            100% {
                background-color: transparent;
            }
        }

        @-webkit-keyframes mymove {
            0% {
                background-color: red;
            }

            50% {
                background-color: transparent;
            }

            100% {
                background-color: transparent;
            }
        }

        @keyframes mymove {
            0% {
                background-color: red;
            }

            50% {
                background-color: transparent;
            }

            100% {
                background-color: transparent;
            }
        }

        @-moz-keyframes mymove2 {
            0% {
                background-color: orange;
            }

            50% {
                background-color: transparent;
            }

            100% {
                background-color: transparent;
            }
        }

        @-webkit-keyframes mymove2 {
            0% {
                background-color: orange;
            }

            50% {
                background-color: transparent;
            }

            100% {
                background-color: transparent;
            }
        }

        @keyframes mymove2 {
            0% {
                background-color: orange;
            }

            50% {
                background-color: transparent;
            }

            100% {
                background-color: transparent;
            }
        }

        .lblArriboDemorado {
            -moz-animation: mymove infinite;
            -o-animation: mymove infinite;
            -webkit-animation: mymove infinite;
            animation: mymove infinite;
            -moz-animation-duration: 2s;
            -o-animation-duration: 2s;
            -webkit-animation-duration: 2s;
            animation-duration: 2s;
        }

        .lblArriboAnticipado {
            -moz-animation: mymove2 infinite;
            -o-animation: mymove2 infinite;
            -webkit-animation: mymove2 infinite;
            animation: mymove2 infinite;
            -moz-animation-duration: 2s;
            -o-animation-duration: 2s;
            -webkit-animation-duration: 2s;
            animation-duration: 2s;
        }
    </style>
    <script type="text/javascript">
        function verificarAnimacion() {
            $(".lblArribo").each(function () {
                if ($(this).html() == "Demorado") {
                    $(this).attr("class", $(this).attr("class") + " lblArriboDemorado")
                } else if ($(this).html() == "Anticipado") {
                    $(this).attr("class", $(this).attr("class") + " lblArriboAnticipado")
                }
            });
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager runat="server" ID="ScriptManager1"
            EnablePartialRendering="true" AsyncPostBackTimeout="600" />
        <!-- Este Timer es para dg1, dgLibres y modal -->
        <asp:Timer ID="Timer1" runat="server" Interval="20000"></asp:Timer>
            <asp:Timer ID="Timer13" runat="server" Interval="12000"></asp:Timer>




        <div class="cssHeader000">
            BIENVENIDOS CLIENTES MAZDA JORGE CORT�S
        </div>


        <table class="cssTable001">
            <thead>
                <tr>
                    <th align="left" style="font-size: 15pt">ENTREGAS</th>
                    <th align="left" style="font-size: 15pt">&nbsp;</th>
                </tr>
            </thead>
            <tbody>

                <tr>

                    <td valign="top" rowspan="1" class="frmclass">

                        <asp:UpdatePanel ID="UPGUARDAV" runat="server" UpdateMode="Conditional">

                            <ContentTemplate>
                                <asp:Timer ID="Timer11" Interval="20000" Enabled="true" runat="server">
                                </asp:Timer>
                                <input type="text" runat="server" id="nreloj" name="nreloj" size="20"
                                    style="position: absolute; top: 15px; left: 1350px; color: white;" />
                                 <asp:DataGrid ID="dg1" runat="server" AutoGenerateColumns="False" CssClass="cssTable000"
                                    AllowPaging="true" PageSize="10" Width="1000px" GridLines="none">

                                    <Columns>
                                        <asp:BoundColumn DataField="Hora" HeaderText="TIPO">
                                            <ItemStyle Width="75px" />
                                        </asp:BoundColumn>
                                        <asp:BoundColumn DataField="Vehiculo" HeaderText="Vehiculo" />
                                        <asp:BoundColumn DataField="noPlacas" HeaderText="Placas" />
                                        <asp:BoundColumn DataField="Color" HeaderText="Cono" />
                                        <asp:BoundColumn DataField="Cliente" HeaderText="Cliente" ReadOnly="True" />
                                        <asp:BoundColumn DataField="ServicioCapturado" HeaderText="Servicio" />
                                        <asp:BoundColumn DataField="asesor" HeaderText="Asesor" />
                                        <asp:BoundColumn DataField="HoraPromesa" HeaderText="Hora Promesa">
                                            <ItemStyle Width="90px" />
                                        </asp:BoundColumn>
                                        <asp:BoundColumn DataField="estatus_orden" HeaderText="Estatus" />
                                        <asp:TemplateColumn>
                                            <ItemTemplate>
                                                <img id="imgGreen" runat="server" src="img/semaforo_verde.gif" class="cssImg" align="middle" />
                                                <img id="imgYellow" runat="server" src="img/semaforo_yellow.gif" class="cssImgHdd" align="middle" />
                                                <img id="imgRed" runat="server" src="img/semaforo_rojo.gif" class="cssImgHdd" align="middle" />
                                            </ItemTemplate>
                                            <ItemStyle Width="10px" />
                                        </asp:TemplateColumn>
                                    </Columns>

                                    <HeaderStyle  Font-Bold="true" Font-Size="23px" BackColor="RoyalBlue" BorderStyle="Solid" BorderWidth="1px" BorderColor="White" />
                                    <ItemStyle Font-Bold="true" Font-Size="18px" />

                                    <PagerStyle Visible="false" />

                                </asp:DataGrid>
                            </ContentTemplate>
                            <Triggers>
                                <asp:AsyncPostBackTrigger ControlID="Timer1" EventName="Tick" />
                            </Triggers>
                        </asp:UpdatePanel>


                    </td>

                    <td valign="middle" rowspan="3" class="frmclass">

                    <%--    <iframe width="400" height="290" id="Video1"
                            src="https://www.youtube.com/embed/ijUT9G7pq58?feature=player_embedded&autoplay=1&controls=0&loop=1&playlist=ijUT9G7pq58&rel=0&showinfo=0&autohide=1&color=white&iv_load_policy=3&theme=light"></iframe>--%>

                    </td>
                </tr>


                <tr>

                    <td valign="top" class="frmclass">
                        <br />
                        &nbsp;</td>

                </tr>


                <tr>

                    <td valign="top" class="frmclass">
                        <asp:UpdatePanel ID="UPGUARDAV2" runat="server" UpdateMode="Conditional" Visible="false">
                            <ContentTemplate>
                                <asp:Timer ID="Timer12" Interval="5000" Enabled="false" runat="server">
                                </asp:Timer>

                                <asp:DataGrid ID="dgLibres" runat="server" AutoGenerateColumns="False" CssClass="cssTable000"
                                    AllowPaging="true" PageSize="1" Width="1000px" GridLines="none" ShowFooter="true">

                                    <Columns>
                                        <asp:BoundColumn DataField="id_mto" />
                                        <asp:BoundColumn DataField="descripcion_mto" />
                                        <asp:BoundColumn DataField="modelo" />

                                        <asp:TemplateColumn FooterStyle-HorizontalAlign="Right"  FooterStyle-Font-Bold  ="true" FooterStyle-Font-Size="20px"  >
                                            <FooterTemplate >
                                              <asp:Label ID="lbltotal" runat="server" Text="TOTAL"></asp:Label>
                                          
                                            </FooterTemplate>
                                            <ItemTemplate>
                                                <asp:DataGrid ID="dtDet" runat="server" AutoGenerateColumns="False" CssClass="cssTable000"
                                                    AllowPaging="false"    GridLines="none">

                                                    <Columns>
                                                        <asp:BoundColumn DataField="articulo" HeaderText="Referencia" />
                                                        <asp:BoundColumn DataField="cantidad"  HeaderText="Cantidad" />
                                                        <asp:BoundColumn DataField="precio"  HeaderText="Precio" DataFormatString="{0:c}" />
                                                        <asp:BoundColumn DataField="Total"  HeaderText="Total" DataFormatString="{0:c}"/>
                                                                                                               
                                                    </Columns>
                                                    <HeaderStyle   Font-Bold="true" Font-Size="23px"  ForeColor="RoyalBlue" BorderStyle="Solid" BorderWidth="1px"   />
                                                    <ItemStyle Font-Bold="true" Font-Size="18px" />
                                                    <PagerStyle Visible="false"  />
                                                    
                                                </asp:DataGrid>


                                            </ItemTemplate>

                                        </asp:TemplateColumn>
                                    </Columns>

                                     
                                    <ItemStyle Font-Bold="true" Font-Size="18px" />

                                    <PagerStyle Visible="false" />

                                </asp:DataGrid>
                            </ContentTemplate>
                            <Triggers>
                                <asp:AsyncPostBackTrigger ControlID="Timer1" EventName="Tick" />
                            </Triggers>
                        </asp:UpdatePanel>
                       

                    </td>
                </tr>


            </tbody>
        </table>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate/>
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="Timer1" EventName="Tick" />
            </Triggers>
        </asp:UpdatePanel>

    </form>
    <div class="md-overlay"></div>
    <!-- the overlay element -->
</body>
</html>

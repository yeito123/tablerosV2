﻿Imports ZedGraph.Web
Imports System.Drawing
Imports TablerosV2LibTypes

Partial Public Class TProgreso
    Inherits System.Web.UI.Page
    Const iTablero As Integer = 2
    Dim bref As Boolean
    Dim inumHoras As Integer = 0
    Dim inumDias As Integer = 0
    Const inumLeft As Integer = 0
    Dim iHorai As Integer = 0
    Dim ifac As Double = (59.4) * inumHoras
    Dim sMensajes As ArrayList


    Property pgvDms() As Boolean
        Get
            Return Session("_pgvdms")
        End Get
        Set(ByVal value As Boolean)
            Session("_pgvdms") = value
        End Set
    End Property
    Function Nomenclatura() As String

        Return ""


        '<table   cellpadding="1" cellspacing="1" style="width:90%; " id="tblNom">
        '                    <tr>
        '                        <td style="width: 25px; background-color:  <%= TablerosV2LibTypes.SCCParametros.ObtenParametros(Request.Url.Segments(Request.Url.Segments.Length - 1), "dg")%>;">
        '                          &nbsp;
        '                             </td>   <td style="width: 200px;">
        '                            Arribos con cita



        '                        </td>
        '                        </tr>
        '                    <tr>
        '                        <td style="width: 25px; background-color: <%= TablerosV2LibTypes.SCCParametros.ObtenParametros(Request.Url.Segments(Request.Url.Segments.Length - 1), "dn")%>;">&nbsp;</td>
        '                        <td style="width: 200px;">
        '                            No show
        '                        </td>

        '                    </tr>
        '                    <tr>

        '                        <td style="width: 25px; background-color: <%= TablerosV2LibTypes.SCCParametros.ObtenParametros(Request.Url.Segments(Request.Url.Segments.Length - 1), "db")%>;">&nbsp;</td>
        '                        <td style="width: 200px;">
        '                            Arribos sin cita
        '                        </td>
        '                        </tr>
        '                    <tr>

        '                        <td style="width: 25px; background-color: <%= TablerosV2LibTypes.SCCParametros.ObtenParametros(Request.Url.Segments(Request.Url.Segments.Length - 1), "dgi")%>;">&nbsp;</td>
        '                        <td style="width: 200px;">
        '                            Arribos con cita por internet
        '                        </td>
        '                        </tr>
        '                    <tr>

        '                            <td style="width: 25px; background-color:  <%= TablerosV2LibTypes.SCCParametros.ObtenParametros(Request.Url.Segments(Request.Url.Segments.Length - 1), "dl")%>;">&nbsp;</td>
        '                        <td style="width: 200px;">
        '                                Servicio Terminado
        '                            </td>


        '                    </tr>
        '                    <tr>
        '                        <td style="width: 25px; background-color: <%= TablerosV2LibTypes.SCCParametros.ObtenParametros(Request.Url.Segments(Request.Url.Segments.Length - 1), "dw5")%>;">&nbsp;</td>
        '                        <td style="width: 200px;">
        '                            Detenido Prueba de Ruta</td>
        '                        </tr>
        '                    <tr>

        '                            <td style="width: 25px; background-color: <%= TablerosV2LibTypes.SCCParametros.ObtenParametros(Request.Url.Segments(Request.Url.Segments.Length - 1), "dw3")%>;">&nbsp;</td>
        '                        <td style="width: 200px;">
        '                                Detenido Autorizacion</td>

        '                    </tr>
        '                    <tr>
        '                         <td style="width: 25px; background-color: <%= TablerosV2LibTypes.SCCParametros.ObtenParametros(Request.Url.Segments(Request.Url.Segments.Length - 1), "dw2")%>;">&nbsp;</td>
        '                        <td style="width: 200px;">
        '                            Detenido Refacciones</td>

        '                        </tr>
        '                    <tr>

        '                            <td style="width: 25px; background-color:  <%= TablerosV2LibTypes.SCCParametros.ObtenParametros(Request.Url.Segments(Request.Url.Segments.Length - 1), "dw4")%>;">&nbsp;
        '                                 </td>
        '                        <td style="width: 200px;">
        '                                Detenido Carry Over</td>


        '                                 </tr>

        '                                 <tr>
        '                          <td style="width: 25px; background-color:  <%= TablerosV2LibTypes.SCCParametros.ObtenParametros(Request.Url.Segments(Request.Url.Segments.Length - 1), "dw7")%>;">&nbsp;</td>
        '                                     <td style="width: 200px;">
        '                            Detenido TOT</td>




        '                                 </tr>
        '                </table>


    End Function
    Private Sub whuxgaPT_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init


        If Not Page.IsPostBack Then
            txtCalendar.Text = Date.Now.ToShortDateString
            lblCalendar.Text = txtCalendar.Text
            'refreshDMS()
            lblUsr.Text = Session("Usuario")
        End If

        inumHoras = SCCParametros.ObtenParametros(Request.Url.Segments(Request.Url.Segments.Length - 1), "inumhoras")
        inumDias = SCCParametros.ObtenParametros(Request.Url.Segments(Request.Url.Segments.Length - 1), "inumdias")
        iHorai = SCCParametros.ObtenParametros(Request.Url.Segments(Request.Url.Segments.Length - 1), "ihorai")
        ifac = (59.4) * inumHoras
        If SCCParametros.ObtenParametros(Request.Url.Segments(Request.Url.Segments.Length - 1), "Leyendas") <> "" Then
            divLeyendas.Visible = True
        Else
            divLeyendas.Visible = False
        End If


    End Sub
    Sub LimpiaForm()
        Dim objc As New ArrayList()
        For Each d In Me.form1.Controls
            If Left(d.id, 13) = "txtHorarioCSa" Then
                objc.Add(d.id)
            End If
            If Left(d.id, 15) = "txtHorarioENTSa" Then
                objc.Add(d.id)
            End If
            If Left(d.id, 15) = "txtHorarioSALSa" Then
                objc.Add(d.id)
            End If
            If Left(d.id, 11) = "txtHorarioC" Then
                objc.Add(d.id)
            End If
            If Left(d.id, 11) = "txtHorarioL" Then
                objc.Add(d.id)
            End If
            If Left(d.id, 11) = "txtHorarioS" Then
                objc.Add(d.id)
            End If
            If Left(d.id, 11) = "txtAusencia" Then
                objc.Add(d.id)
            End If
            If Left(d.id, 6) = "txtMec" Then
                objc.Add(d.id)
            End If

            If Left(d.id, 6) = "txtNiv" Then
                objc.Add(d.id)
            End If
            If Left(d.id, 6) = "txtDia" Then
                objc.Add(d.id)
            End If
            If Left(d.id, 2) = "ds" Or Left(d.id, 5) = "ctlll" Then
                objc.Add(d.id)
            End If
        Next
        For Each d In objc
            Me.form1.Controls.Remove(Me.form1.FindControl(d))
        Next

        For Each d In leftfix.Controls
            If Left(d.id, 13) = "txtHorarioCSa" Then
                objc.Add(d.id)
            End If
            If Left(d.id, 15) = "txtHorarioENTSa" Then
                objc.Add(d.id)
            End If
            If Left(d.id, 15) = "txtHorarioSALSa" Then
                objc.Add(d.id)
            End If
            If Left(d.id, 11) = "txtHorarioC" Then
                objc.Add(d.id)
            End If
            If Left(d.id, 11) = "txtHorarioL" Then
                objc.Add(d.id)
            End If
            If Left(d.id, 11) = "txtHorarioS" Then
                objc.Add(d.id)
            End If
            If Left(d.id, 11) = "txtAusencia" Then
                objc.Add(d.id)
            End If
            If Left(d.id, 6) = "txtMec" Then
                objc.Add(d.id)
            End If

            If Left(d.id, 6) = "txtNiv" Then
                objc.Add(d.id)
            End If
            If Left(d.id, 6) = "txtDia" Then
                objc.Add(d.id)
            End If
            If Left(d.id, 2) = "ds" Or Left(d.id, 5) = "ctlll" Then
                objc.Add(d.id)
            End If
        Next
        For Each d In objc
            leftfix.Controls.Remove(leftfix.FindControl(d))
        Next

        Dim II As Integer = leftfix.Controls.Count
        For i = (II - 1) To 0 Step -1
            If Left(leftfix.Controls(i).ID, 6) = "txtMec" Then
                leftfix.Controls.RemoveAt(i)
            ElseIf Left(leftfix.Controls(i).ID, 6) = "txtNiv" Then
                leftfix.Controls.RemoveAt(i)
            End If
        Next


        II = floatdiv.Controls.Count
        For i = (II - 1) To 0 Step -1
            If Left(floatdiv.Controls(i).ID, 6) = "txtDia" Then
                floatdiv.Controls.RemoveAt(i)
            ElseIf Left(floatdiv.Controls(i).ID, 6) = "txtDia" Then
                floatdiv.Controls.RemoveAt(i)
            End If
        Next


    End Sub


    'Sub LlenaListaServicios()
    '    Dim dt As New DataTable
    '    Dim sqry As String = ""


    '    sqry = "Select distinct idConcepto, isnull(describeconcepto,''),describeconcepto ,color from " & System.Web.Configuration.WebConfigurationManager.AppSettings("tbServicios") & "  "
    '    dt = BDClass.SQLtoDataTable(sqry, False)

    '    DataList1.DataSource = dt

    '    DataList1.DataBind()

    'End Sub

    Private Sub AbrirChip(ByVal iId As Int64, ByVal ssTop As String, ByVal ssLeft As String)
        Dim OBJCOL As New CHIPHYPCollection
        OBJCOL = Session("ColChipsP")

        dchp.Style.Remove("Left")
        dchp.Style.Remove("Top")
        For Each obj As ChipHYP In OBJCOL
            If obj.ID = iId Then

                Modelo.Text = "Mod: " & obj.VEHICULO
                Tolerancia.Text = "H.Tol: " & obj.HORATOLERANCIA
                Service.Text = "" & obj.SERVICIOCAPTURADO
                Orden.Text = "Orden " & obj.IDBLINSUR
                Placas.Text = "Placa: " & obj.NOPLACAS
                dchp.Style.Add("Left", ssLeft)
                dchp.Style.Add("Top", ssTop)

                dchp.Focus()
                Exit For
            End If

        Next

    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If InStr(Page.AppRelativeVirtualPath, Session("URL")) = 0 Or Session("URL") Is Nothing Then Response.Redirect("Login.aspx")
        LlenaAsesores()
        Dim sdhtml As String = CType(Me.form1.FindControl("dhtml"), HtmlInputText).Value
        If Not Page.IsPostBack Then
            bref = True
        End If
        If Session("fase") Is Nothing Then
            Session("fase") = 0
        End If

        If Not Page.IsPostBack Then
            iniciaTablero0(True, txtBuscar.Text, 0)
        ElseIf Not Session("clkMenu") Is Nothing Then
            '   menuItem(Session("clkMenuid"), True)
        Else
            ' iniciaTablero(True, txtBuscar.Text)
        End If

        ' iniciaTablero(True, txtBuscar.Text)



        If sdhtml = "dchp" Then
            dchp.Visible = False
        ElseIf Left(sdhtml, 3) = "div" Then
            dchp.Visible = False
        ElseIf Left(sdhtml, 4) = "ds00." Then
            dchp.Visible = False
        ElseIf Left(sdhtml, 4) = "add_" Then
            dchp.Visible = False
            'Revision25(Split(sdhtml, "_")(1))
        ElseIf Left(sdhtml, 6) = "txtMec" Then
            dchp.Visible = False
        ElseIf sdhtml.Split(".").Length = 0 And sdhtml.Length > 0 Then
            AbrirChip(CType(Me.FindControl(sdhtml).Controls(1), HtmlInputHidden).Value, CType(Me.FindControl(sdhtml), HtmlGenericControl).Style.Item("top"), CType(Me.FindControl(sdhtml), HtmlGenericControl).Style.Item("left"))
            dchp.Visible = True
        Else
            dchp.Visible = False
        End If

    End Sub
    Sub iniciaTablero2()
        Dim dt As New DataTable
        If SCCParametros.ObtenParametros(Request.Url.Segments(Request.Url.Segments.Length - 1), "CitasVista").ToString = "1" Then
            dt = TablerosUtilsHyP.ObtenTecnicosMasVehiculosChipsView
        Else
            dt = TablerosUtilsHyP.ObtenTecnicosMasVehiculos
        End If

        Dim dt0 As DataView = TablerosUtilsHyP.ObtenTecnicos.DefaultView

        Dim dvTecnicos As DataView

        Dim dtAusencias As DataView

        Dim dtHlpHorarios As New DataTable
        dtHlpHorarios.Columns.Add("idTecnico")
        dtHlpHorarios.Columns.Add("NombreTecnico")
        dtHlpHorarios.Columns.Add("Bahia")
        dtHlpHorarios.Columns.Add("HoraEnt")
        dtHlpHorarios.Columns.Add("HoraSal")
        dtHlpHorarios.Columns.Add("HoraComer")
        dtHlpHorarios.Columns.Add("Comida")
        dtHlpHorarios.Columns.Add("PosY")
        dtHlpHorarios.Columns.Add("PosX")
        dtHlpHorarios.Columns.Add("dia")

        Dim txtMec As Label, txtNiv As Label
        Dim txtMec20 As Label
        Dim txtHorario As Label, sPosX1 As Integer = 0, sPosX2 As Integer = 0
        '    leftfix.Controls.Clear()
        Dim dtPos As New DataTable, ktop As Integer
        dtPos.Columns.Add("IdTecnico")
        dtPos.Columns.Add("IdControl")
        dtPos.Columns.Add("posY")
        dtPos.Columns.Add("IdControlP")
        dtPos.Columns.Add("OrdenP")
        dtPos.Columns.Add("posYP")

        'dtPos.Columns.Add("posb")

        ktop = 0


        Dim ITOT As Decimal
        Dim converter = System.ComponentModel.TypeDescriptor.GetConverter(GetType(System.Drawing.Color))
        Dim color As System.Drawing.Color, sColor As String





        For i = 0 To dt0.Count - 1
            ITOT = 0
            txtMec = New Label
            txtMec.ID = "txtMec" & dt0(i)("Bahia") & i
            sColor = dt0(i)("color")
            'color = color.FromArgb(255, 255 - (CType(converter.ConvertFromString(sColor), System.Drawing.Color).R), 255 - (CType(converter.ConvertFromString(sColor), System.Drawing.Color).G), 255 - (CType(converter.ConvertFromString(sColor), System.Drawing.Color).B))

            txtMec.Style.Value = "position:absolute;left:1px;top:" & ktop + 2 & "px;width:85px;height:52px;background-color:" & dt0(i)("color") & ";color:" & System.Drawing.ColorTranslator.ToHtml(color) & ";Font-weight:bold;font-family:  Lucida Grande,Lucida Sans,Arial,sans-serif;font-size:0.688em;border:solid 1px black;"
            txtMec.Text = dt0(i)("nombre_empleado")
            If CBool(dt0(i)("express")) Then
                txtMec.Style.Value = "position:absolute;left:1px;top:" & ktop + 2 & "px;width:85px;height:26px;background-color:" & dt0(i)("color") & ";color:gold;Font-weight:bold;font-family:  Lucida Grande,Lucida Sans,Arial,sans-serif;font-size:0.688em;border:solid 1px black;"
                txtMec.Text = dt0(i)("nombre_empleado") & " (express)"
                txtMec.Attributes.Add("title", "bahia express")
            Else
                txtMec.Style.Value = "position:absolute;left:1px;top:" & ktop + 2 & "px;width:85px;height:26px;background-color:" & dt0(i)("color") & ";color:black;Font-weight:bold;font-family:  Lucida Grande,Lucida Sans,Arial,sans-serif;font-size:0.688em;border:solid 1px black;"
                txtMec.Text = dt0(i)("nombre_empleado")
            End If

            '--------------Horario Comida
            For j = 0 To inumDias - 1

                If SCCParametros.ObtenParametros(Request.Url.Segments(Request.Url.Segments.Length - 1), "i20") = "1" Then
                    txtMec20 = New Label
                    txtMec20.ID = "txtMec20_" & dt0(i)("Bahia") & i & "_" & j
                    sPosX1 = ((CDate(lblCalendar.Text).DayOfYear - (CDate(lblCalendar.Text).AddDays(-inumLeft).DayOfYear)) * ifac) + IIf(((CDate(dt0(i)("HORA_ENT_LV")).Hour * 60) + CDate(dt0(i)("HORA_ENT_LV")).Minute - (iHorai * 60)) > 0, ((CDate(dt0(i)("HORA_ENT_LV")).Hour * 60) + CDate(dt0(i)("HORA_ENT_LV")).Minute - (iHorai * 60)), 0) + 92
                    sPosX2 = ((CDate(lblCalendar.Text).DayOfYear - (CDate(lblCalendar.Text).AddDays(-inumLeft).DayOfYear)) * ifac) + IIf(((CDate(dt0(i)("HORA_SAL_LV")).Hour * 60) + CDate(dt0(i)("HORA_SAL_LV")).Minute - (iHorai * 60)) > 0, ((CDate(dt0(i)("HORA_SAL_LV")).Hour * 60) + CDate(dt0(i)("HORA_SAL_LV")).Minute - (iHorai * 60)), 0) + 92


                    txtMec20.Style.Value = "position:absolute;left:" & sPosX2 - CInt((sPosX2 - sPosX1) * 0.2) + (j * (ifac)) & "px;top:" & ktop + 94 & "px;width:" & CInt((sPosX2 - sPosX1) * 0.2) & "px;height:26px;" & SCCParametros.ObtenParametros2(Request.Url.Segments(Request.Url.Segments.Length - 1), "i20") & ""
                    txtMec20.Text = "20%"
                    form1.Controls.Add(txtMec20)
                End If

                '---------Ausencias-----------
                'idia = TablerosUtils.ObtenPosYTecnicosCC(dt.Rows(i)("Bahia"))(0).Item(0)
                dtAusencias = TablerosUtilsHyP.ObtenAusenciasA1(dt0(i)("id_empleado"), CDate(lblCalendar.Text).AddDays(j))
                If dtAusencias.Count > 0 Then
                    For iai = 0 To dtAusencias.Count - 1
                        txtHorario = New Label
                        txtHorario.ID = "txtAusencia" & dt0(i)("Bahia") & i & "_" & j & "_" & iai
                        If IsDate(dtAusencias(iai).Item(1)) Then
                            sPosX1 = ((CDate(lblCalendar.Text).DayOfYear - (CDate(lblCalendar.Text).AddDays(-inumLeft).DayOfYear)) * ifac) + IIf(((CDate(dtAusencias(iai).Item(1)).Hour * 60) - (iHorai * 60)) > 0, ((((CDate(dtAusencias(iai).Item(1)).Hour * 60) - (iHorai * 60)) + CDate(dtAusencias(iai).Item(1)).Minute) * ((ifac / inumHoras) / 60)), 0) + 92
                            sPosX2 = ((CDate(lblCalendar.Text).DayOfYear - (CDate(lblCalendar.Text).AddDays(-inumLeft).DayOfYear)) * ifac) + IIf(((CDate(dtAusencias(iai).Item(2)).Hour * 60) - (iHorai * 60)) > 0, ((((CDate(dtAusencias(iai).Item(2)).Hour * 60) - (iHorai * 60)) + CDate(dtAusencias(iai).Item(2)).Minute) * ((ifac / inumHoras) / 60)), 0) + 92
                            ' sPosX2 = TablerosUtilsHyP.ObtenPosXxHora(dtAusencias(II).Item(2))
                            ' sPosX1 = TablerosUtilsHyP.ObtenPosXxHora(dtAusencias(II).Item(1))

                            If InStr(dtAusencias(iai).Item("tausencia"), "%") > 0 Then
                                If iTablero <> 1 Then
                                    txtHorario.Style.Value = "position:absolute;left:" & sPosX1 + (j * (ifac)) & "px;top:" & ktop + 94 & "px;width:" & sPosX2 - sPosX1 & "px;height:48px;background-color:Orange;Font-weight:normal;font-family:Arial;font-size:10px;text-align: center;vertical-align: middle;color:black;"
                                Else
                                    txtHorario.Style.Value = "position:absolute;left:" & sPosX1 + (j * (ifac)) & "px;top:" & ktop + 94 & "px;width:" & sPosX2 - sPosX1 & "px;height:24px;background-color:Orange;Font-weight:normal;font-family:Arial;font-size:10px;text-align: center;vertical-align: middle;color:black;"
                                End If
                            Else
                                If iTablero <> 1 Then
                                    txtHorario.Style.Value = "position:absolute;left:" & sPosX1 + (j * (ifac)) & "px;top:" & ktop + 94 & "px;width:" & sPosX2 - sPosX1 & "px;height:48px;background-color:Gray;Font-weight:normal;font-family:Arial;font-size:10px;border:solid 1px black;text-align: center;vertical-align: middle;color:white;"
                                Else
                                    txtHorario.Style.Value = "position:absolute;left:" & sPosX1 + (j * (ifac)) & "px;top:" & ktop + 94 & "px;width:" & sPosX2 - sPosX1 & "px;height:24px;background-color:Gray;Font-weight:normal;font-family:Arial;font-size:10px;border:solid 1px black;text-align: center;vertical-align: middle;color:white;"
                                End If
                            End If

                            txtHorario.Text = dtAusencias(iai).Item("tausencia")
                            Try
                                form1.Controls.Add(txtHorario)
                            Catch ex As Exception
                                LimpiaForm()
                                form1.Controls.Add(txtHorario)
                            End Try

                        End If
                    Next
                End If

                '---------Ausencias-----------

                If CDate(lblCalendar.Text).AddDays(j).DayOfWeek <> DayOfWeek.Saturday Then


                    txtHorario = New Label
                    txtHorario.ID = "txtHorarioC" & dt0(i)("Bahia") & j
                    If IsDate(dt0(i)("hora_comer")) And dt0(i)("min_comer_lv") <> "0" Then
                        sPosX1 = ((CDate(lblCalendar.Text).DayOfYear - (CDate(lblCalendar.Text).AddDays(-inumLeft).DayOfYear)) * ifac) + IIf(((CDate(dt0(i)("hora_comer")).Hour * 60) - (iHorai * 60)) > 0, ((((CDate(dt0(i)("hora_comer")).Hour * 60) - (iHorai * 60)) + CDate(dt0(i)("hora_comer")).Minute) * ((ifac / inumHoras) / 60)), 0) + 92
                        sPosX2 = ((CDate(lblCalendar.Text).DayOfYear - (CDate(lblCalendar.Text).AddDays(-inumLeft).DayOfYear)) * ifac) + IIf(((CDate(dt0(i)("hora_comer")).AddMinutes(dt0(i)("min_comer_lv")).Hour * 60) - (iHorai * 60)) > 0, ((((CDate(dt0(i)("hora_comer")).AddMinutes(dt0(i)("min_comer_lv")).Hour * 60) - (iHorai * 60)) + CDate(dt0(i)("hora_comer")).AddMinutes(dt0(i)("min_comer_lv")).Minute) * ((ifac / inumHoras) / 60)), 0) + 92

                        'sPosX2 = TablerosUtils.ObtenPosXxHora(String.Format("{0:HH:mm}", CDate(dt0(i)("hora_comer_s")).AddMinutes(dt0(i)("min_comer_s"))))
                        'sPosX1 = TablerosUtils.ObtenPosXxHora(dt0(i)("hora_comer"))
                        If iTablero <> 1 Then
                            txtHorario.Style.Value = "position:absolute;left:" & sPosX1 + (j * (ifac)) & "px;top:" & ktop + 94 & "px;width:" & sPosX2 - sPosX1 & "px;height:54px;" & SCCParametros.ObtenParametros2(Request.Url.Segments(Request.Url.Segments.Length - 1), "dc")
                        Else
                            txtHorario.Style.Value = "position:absolute;left:" & sPosX1 + (j * (ifac)) & "px;top:" & ktop + 94 & "px;width:" & sPosX2 - sPosX1 & "px;height:27px;" & SCCParametros.ObtenParametros2(Request.Url.Segments(Request.Url.Segments.Length - 1), "dc")
                        End If
                        txtHorario.Text = SCCParametros.ObtenParametros(Request.Url.Segments(Request.Url.Segments.Length - 1), "dc")
                        Try
                            form1.Controls.Add(txtHorario)
                        Catch ex As Exception
                            LimpiaForm()
                            form1.Controls.Add(txtHorario)
                        End Try
                    End If
                    '----------------------


                    txtHorario = New Label
                    txtHorario.ID = "txtHorarioSALLV" & dt0(i)("Bahia") & j
                    If IsDate(dt0(i)("HORA_SAL_LV")) Then
                        sPosX1 = ((CDate(lblCalendar.Text).DayOfYear - (CDate(lblCalendar.Text).AddDays(-inumLeft).DayOfYear)) * ifac) + IIf(((CDate(dt0(i)("HORA_SAL_LV")).Hour * 60) - (iHorai * 60)) > 0, ((((CDate(dt0(i)("HORA_SAL_LV")).Hour * 60) - (iHorai * 60)) + CDate(dt0(i)("HORA_SAL_LV")).Minute) * ((ifac / inumHoras) / 60)), 0) + 92

                        sPosX2 = ((CDate(lblCalendar.Text).DayOfYear - (CDate(lblCalendar.Text).AddDays(-inumLeft).DayOfYear)) * ifac) + ((inumHoras) * 60 * ((ifac / inumHoras) / 60)) + 92
                        dtHlpHorarios.Rows.Add(New Object() {dt0(i)("id_empleado"), dt0(i)("nombre_empleado"), dt0(i)("Bahia"), dt0(i)("hora_ent_lv"), dt0(i)("hora_sal_lv"), dt0(i)("hora_comer"), dt0(i)("min_comer_lv"), ktop + 94 & "px", sPosX1 + (j * (ifac)) & "px", CInt(CDate(lblCalendar.Text).AddDays(j).DayOfWeek)})

                        'sPosX2 = TablerosUtils.ObtenPosXxHora(String.Format("{0:HH:mm}", CDate(dt0(i)("hora_comer_s")).AddMinutes(dt0(i)("min_comer_s"))))
                        'sPosX1 = TablerosUtils.ObtenPosXxHora(dt0(i)("hora_comer"))
                        If iTablero <> 1 Then
                            txtHorario.Style.Value = "position:absolute;left:" & sPosX1 + (j * (ifac)) & "px;top:" & ktop + 94 & "px;width:" & sPosX2 - sPosX1 & "px;height:54px;" & SCCParametros.ObtenParametros2(Request.Url.Segments(Request.Url.Segments.Length - 1), "dd")
                        Else
                            txtHorario.Style.Value = "position:absolute;left:" & sPosX1 + (j * (ifac)) & "px;top:" & ktop + 94 & "px;width:" & sPosX2 - sPosX1 & "px;height:27px;" & SCCParametros.ObtenParametros2(Request.Url.Segments(Request.Url.Segments.Length - 1), "dd")
                        End If
                        txtHorario.Text = SCCParametros.ObtenParametros(Request.Url.Segments(Request.Url.Segments.Length - 1), "dd")
                        Try
                            form1.Controls.Add(txtHorario)
                        Catch ex As Exception
                            LimpiaForm()
                            form1.Controls.Add(txtHorario)
                        End Try
                    End If
                    '----------------------
                    txtHorario = New Label
                    txtHorario.ID = "txtHorarioLV" & dt0(i)("Bahia") & j
                    If IsDate(dt0(i)("HORA_ENT_LV")) Then

                        sPosX1 = ((CDate(lblCalendar.Text).DayOfYear - (CDate(lblCalendar.Text).AddDays(-inumLeft).DayOfYear)) * ifac) + 92
                        sPosX2 = ((CDate(lblCalendar.Text).DayOfYear - (CDate(lblCalendar.Text).AddDays(-inumLeft).DayOfYear)) * ifac) + IIf(((CDate(dt0(i)("HORA_ENT_LV")).Hour * 60) + CDate(dt0(i)("HORA_ENT_LV")).Minute - (iHorai * 60)) > 0, ((CDate(dt0(i)("HORA_ENT_LV")).Hour * 60) + CDate(dt0(i)("HORA_ENT_LV")).Minute - (iHorai * 60)), 0) + 92

                        'sPosX2 = TablerosUtils.ObtenPosXxHora(String.Format("{0:HH:mm}", CDate(dt0(i)("hora_comer_s")).AddMinutes(dt0(i)("min_comer_s"))))
                        'sPosX1 = TablerosUtils.ObtenPosXxHora(dt0(i)("hora_comer"))
                        If iTablero <> 1 Then
                            txtHorario.Style.Value = "position:absolute;left:" & sPosX1 + (j * (ifac)) & "px;top:" & ktop + 94 & "px;width:" & sPosX2 - sPosX1 & "px;height:54px;" & SCCParametros.ObtenParametros2(Request.Url.Segments(Request.Url.Segments.Length - 1), "dd")
                        Else
                            txtHorario.Style.Value = "position:absolute;left:" & sPosX1 + (j * (ifac)) & "px;top:" & ktop + 94 & "px;width:" & sPosX2 - sPosX1 & "px;height:27px;" & SCCParametros.ObtenParametros2(Request.Url.Segments(Request.Url.Segments.Length - 1), "dd")
                        End If
                        txtHorario.Text = SCCParametros.ObtenParametros(Request.Url.Segments(Request.Url.Segments.Length - 1), "dd")
                        Try
                            form1.Controls.Add(txtHorario)
                        Catch ex As Exception
                            LimpiaForm()
                            form1.Controls.Add(txtHorario)
                        End Try
                    End If
                    '----------------------
                Else
                    txtHorario = New Label
                    txtHorario.ID = "txtHorarioCSa" & dt0(i)("Bahia") & j
                    If IsDate(dt0(i)("hora_comer_s")) And dt0(i)("min_comer_s") <> "0" Then
                        sPosX1 = ((CDate(lblCalendar.Text).DayOfYear - (CDate(lblCalendar.Text).AddDays(-inumLeft).DayOfYear)) * ifac) + IIf(((CDate(dt0(i)("hora_comer_s")).Hour * 60) - (iHorai * 60)) > 0, ((((CDate(dt0(i)("hora_comer_s")).Hour * 60) - (iHorai * 60)) + CDate(dt0(i)("hora_comer_s")).Minute) * ((ifac / inumHoras) / 60)), 0) + 92
                        sPosX2 = ((CDate(lblCalendar.Text).DayOfYear - (CDate(lblCalendar.Text).AddDays(-inumLeft).DayOfYear)) * ifac) + IIf(((CDate(dt0(i)("hora_comer_s")).AddMinutes(dt0(i)("min_comer_s")).Hour * 60) - (iHorai * 60)) > 0, ((((CDate(dt0(i)("hora_comer_s")).AddMinutes(dt0(i)("min_comer_s")).Hour * 60) - (iHorai * 60)) + CDate(dt0(i)("hora_comer_s")).AddMinutes(dt0(i)("min_comer_s")).Minute) * ((ifac / inumHoras) / 60)), 0) + 92

                        'sPosX2 = TablerosUtils.ObtenPosXxHora(String.Format("{0:HH:mm}", CDate(dt0(i)("hora_comer_s")).AddMinutes(dt0(i)("min_comer_s"))))
                        'sPosX1 = TablerosUtils.ObtenPosXxHora(dt0(i)("hora_comer"))
                        If iTablero <> 1 Then
                            txtHorario.Style.Value = "position:absolute;left:" & sPosX1 + (j * (ifac)) & "px;top:" & ktop + 94 & "px;width:" & sPosX2 - sPosX1 & "px;height:54px;" & SCCParametros.ObtenParametros2(Request.Url.Segments(Request.Url.Segments.Length - 1), "dc")
                        Else
                            txtHorario.Style.Value = "position:absolute;left:" & sPosX1 + (j * (ifac)) & "px;top:" & ktop + 94 & "px;width:" & sPosX2 - sPosX1 & "px;height:27px;" & SCCParametros.ObtenParametros2(Request.Url.Segments(Request.Url.Segments.Length - 1), "dc")
                        End If
                        txtHorario.Text = SCCParametros.ObtenParametros(Request.Url.Segments(Request.Url.Segments.Length - 1), "dc")
                        Try
                            form1.Controls.Add(txtHorario)
                        Catch ex As Exception
                            LimpiaForm()
                            form1.Controls.Add(txtHorario)
                        End Try
                    End If
                    '----------------------


                    txtHorario = New Label
                    txtHorario.ID = "txtHorarioSALSa" & dt0(i)("Bahia") & j
                    If IsDate(dt0(i)("HORA_SAL_S")) Then
                        sPosX1 = ((CDate(lblCalendar.Text).DayOfYear - (CDate(lblCalendar.Text).AddDays(-inumLeft).DayOfYear)) * ifac) + IIf(((CDate(dt0(i)("HORA_SAL_S")).Hour * 60) - (iHorai * 60)) > 0, ((((CDate(dt0(i)("HORA_SAL_S")).Hour * 60) - (iHorai * 60)) + CDate(dt0(i)("HORA_SAL_S")).Minute) * ((ifac / inumHoras) / 60)), 0) + 92

                        sPosX2 = ((CDate(lblCalendar.Text).DayOfYear - (CDate(lblCalendar.Text).AddDays(-inumLeft).DayOfYear)) * ifac) + ((inumHoras) * 60 * ((ifac / inumHoras) / 60)) + 92
                        dtHlpHorarios.Rows.Add(New Object() {dt0(i)("id_empleado"), dt0(i)("nombre_empleado"), dt0(i)("Bahia"), dt0(i)("hora_ent_s"), dt0(i)("hora_sal_s"), dt0(i)("hora_comer_s"), dt0(i)("min_comer_s"), ktop + 94 & "px", sPosX1 + (j * (ifac)) & "px", CInt(CDate(lblCalendar.Text).AddDays(j).DayOfWeek)})

                        'sPosX2 = TablerosUtils.ObtenPosXxHora(String.Format("{0:HH:mm}", CDate(dt0(i)("hora_comer_s")).AddMinutes(dt0(i)("min_comer_s"))))
                        'sPosX1 = TablerosUtils.ObtenPosXxHora(dt0(i)("hora_comer"))
                        If iTablero <> 1 Then
                            txtHorario.Style.Value = "position:absolute;left:" & sPosX1 + (j * (ifac)) & "px;top:" & ktop + 94 & "px;width:" & sPosX2 - sPosX1 & "px;height:54px;" & SCCParametros.ObtenParametros2(Request.Url.Segments(Request.Url.Segments.Length - 1), "dd")
                        Else
                            txtHorario.Style.Value = "position:absolute;left:" & sPosX1 + (j * (ifac)) & "px;top:" & ktop + 94 & "px;width:" & sPosX2 - sPosX1 & "px;height:27px;" & SCCParametros.ObtenParametros2(Request.Url.Segments(Request.Url.Segments.Length - 1), "dd")
                        End If
                        txtHorario.Text = SCCParametros.ObtenParametros(Request.Url.Segments(Request.Url.Segments.Length - 1), "dd")
                        Try
                            form1.Controls.Add(txtHorario)
                        Catch ex As Exception
                            LimpiaForm()
                            form1.Controls.Add(txtHorario)
                        End Try
                    End If
                    '----------------------
                    txtHorario = New Label
                    txtHorario.ID = "txtHorarioENTSa" & dt0(i)("Bahia") & j
                    If IsDate(dt0(i)("HORA_ENT_S")) Then
                        sPosX1 = ((CDate(lblCalendar.Text).DayOfYear - (CDate(lblCalendar.Text).AddDays(-inumLeft).DayOfYear)) * ifac) + 92
                        sPosX2 = ((CDate(lblCalendar.Text).DayOfYear - (CDate(lblCalendar.Text).AddDays(-inumLeft).DayOfYear)) * ifac) + IIf(((CDate(dt0(i)("HORA_ENT_S")).Hour * 60) + CDate(dt0(i)("HORA_ENT_S")).Minute - (iHorai * 60)) > 0, ((CDate(dt0(i)("HORA_ENT_S")).Hour * 60) + CDate(dt0(i)("HORA_ENT_S")).Minute - (iHorai * 60)), 0) + 92

                        'sPosX2 = TablerosUtils.ObtenPosXxHora(String.Format("{0:HH:mm}", CDate(dt0(i)("hora_comer_s")).AddMinutes(dt0(i)("min_comer_s"))))
                        'sPosX1 = TablerosUtils.ObtenPosXxHora(dt0(i)("hora_comer"))
                        If iTablero <> 1 Then
                            txtHorario.Style.Value = "position:absolute;left:" & sPosX1 + (j * (ifac)) & "px;top:" & ktop + 94 & "px;width:" & sPosX2 - sPosX1 & "px;height:54px;" & SCCParametros.ObtenParametros2(Request.Url.Segments(Request.Url.Segments.Length - 1), "dd")
                        Else
                            txtHorario.Style.Value = "position:absolute;left:" & sPosX1 + (j * (ifac)) & "px;top:" & ktop + 94 & "px;width:" & sPosX2 - sPosX1 & "px;height:27px;" & SCCParametros.ObtenParametros2(Request.Url.Segments(Request.Url.Segments.Length - 1), "dd")
                        End If
                        txtHorario.Text = SCCParametros.ObtenParametros(Request.Url.Segments(Request.Url.Segments.Length - 1), "dd")
                        Try
                            form1.Controls.Add(txtHorario)
                        Catch ex As Exception
                            LimpiaForm()
                            form1.Controls.Add(txtHorario)
                        End Try
                    End If
                End If



            Next
            ' dtPos.Rows.Add(New Object() {dt0(i)("id_empleado"), txtMec.ID, ktop + 2, txtNiv.ID, dvTecnicos(k)("noorden"), ktop + 94})
            If iTablero <> 1 Then
                txtNiv = New Label
                txtNiv.ID = "txtNiv" & dt0(i)("Bahia") & i & "A"
                txtNiv.Style.Value = "position:absolute;left:90px;top:" & ktop + 94 & "px;width:5px;height:24px;background-color:White;Font-weight:bold;font-family:Arial;font-size:10px;border:solid 1px silver;"
                txtNiv.Text = "P"

                form1.Controls.Add(txtNiv)
                txtNiv = New Label
                txtNiv.ID = "txtNiv" & dt0(i)("Bahia") & i & "B"
                txtNiv.Style.Value = "position:absolute;left:90px;top:" & ktop + 94 + 25 & "px;width:5px;height:24px;background-color:White;Font-weight:bold;font-family:Arial;font-size:10px;border:solid 1px silver;"
                txtNiv.Text = "T"
                form1.Controls.Add(txtNiv)
            End If
            dt.DefaultView.RowFilter = "Bahia='" & dt0(i)("Bahia") & "' "
            dvTecnicos = dt.DefaultView
            'dtPos.Rows.Add(New Object() {dt0(i)("id_empleado"), txtMec.ID, ktop + 2, txtNiv.ID, dvTecnicos(0)("noorden"), ktop + 94})

            For k = 0 To dvTecnicos.Count - 1

                'txtNiv = New Label
                'txtNiv.ID = "txtNiv" & dt0(i)("Bahia") & "_" & i & "_" & dvTecnicos(k)("noorden")
                'txtNiv.Style.Value = "position:absolute;left:31px;top:" & ktop + 2 & "px;width:55px;height:26px;background-color:#eeeee0;Font-weight:bold;font-family:  Lucida Grande,Lucida Sans,Arial,sans-serif;font-size:10px;border:solid 1px black;"
                'txtNiv.Text = dvTecnicos(k)("noplacas")
                'leftfix.Controls.Add(txtNiv)
                dtPos.Rows.Add(New Object() {dt0(i)("id_empleado"), txtMec.ID, ktop + 2, txtMec.ID, dvTecnicos(k)("noorden"), ktop + 94})
                ITOT = ITOT + Val(dvTecnicos(k)("servicio"))

                'ktop = ktop + 27


            Next
            Session("dthlphorarios") = dtHlpHorarios
            ITOT = System.Math.Round(ITOT / 60, 1)
            txtMec.ToolTip = "Total Servicios: " & ITOT & " horas"

            leftfix.Controls.Add(txtMec)


            ktop = ktop + 60

        Next

        Session("dtPosY") = dtPos


        Session.Remove("ObtenAusencias")
    End Sub
    Sub LlenaComboOrdenesDetenidos(s As String, stipo As String)
        Dim OBJCOLO As New CHIPHYPCollection
        OBJCOLO = OBJCOLO.ObtenChipsOrdenesDetenidos(stipo, HttpContext.Current.Session("cveAsesor"))
        cboOrdenes.Items.Clear()
        cboOrdenes.Items.Add(New ListItem(""))
        For Each objD As ChipHYP In OBJCOLO

            If cboOrdenes.Items.IndexOf(cboOrdenes.Items.FindByText(objD.NOORDEN)) < 0 Then

                cboOrdenes.Items.Add(New ListItem(objD.NOORDEN))
            End If

        Next
        Try
            cboOrdenes.SelectedIndex = cboOrdenes.Items.IndexOf(cboOrdenes.Items.FindByText(s))
        Catch ex As Exception
            cboOrdenes.SelectedIndex = 0
        End Try
    End Sub
    Sub LlenaComboOrdenes(s As String)
        Dim OBJCOLO As New CHIPHYPCollection
        OBJCOLO = OBJCOLO.ObtenChipsOrdenes(HttpContext.Current.Session("cveAsesor"))
        cboOrdenes.Items.Clear()
        cboOrdenes.Items.Add(New ListItem(""))
        For Each objD As ChipHYP In OBJCOLO
            If cboOrdenes.Items.IndexOf(cboOrdenes.Items.FindByText(objD.NOORDEN)) < 0 Then
                cboOrdenes.Items.Add(New ListItem(objD.NOORDEN))
            End If

        Next
        Try
            cboOrdenes.SelectedIndex = cboOrdenes.Items.IndexOf(cboOrdenes.Items.FindByText(s))
        Catch ex As Exception
            cboOrdenes.SelectedIndex = 0
        End Try
    End Sub

    Sub LlenaComboOrdenesRepprocesos(s As String)
        Dim OBJCOLO As New CHIPHYPCollection
        OBJCOLO = OBJCOLO.ObtenChipsOrdenesReprocesos(HttpContext.Current.Session("cveAsesor"))
        cboOrdenes.Items.Clear()
        cboOrdenes.Items.Add(New ListItem(""))
        For Each objD As ChipHYP In OBJCOLO
            If cboOrdenes.Items.IndexOf(cboOrdenes.Items.FindByText(objD.NOORDEN)) < 0 Then
                cboOrdenes.Items.Add(New ListItem(objD.NOORDEN))
            End If

        Next
        Try
            cboOrdenes.SelectedIndex = cboOrdenes.Items.IndexOf(cboOrdenes.Items.FindByText(s))
        Catch ex As Exception
            cboOrdenes.SelectedIndex = 0
        End Try
    End Sub
    'Sub iniciaTablero(ByVal bTecnicos As Boolean, Optional sorden As String = "", Optional bDetenidos As Boolean = False, Optional bWS As Boolean = False)
    '    LimpiaForm()
    '    Dim dtTemp As DataTable

    '    bref = False
    '    Dim sScript As String = ""
    '    Dim iNumbahias As Integer ' = dt.Rows.Count
    '    Dim ilargo As Integer = 0
    '    Dim iwidth As Integer = "7500"
    '    Dim dt As DataView = TablerosUtilsHyP.ObtenTecnicos.DefaultView
    '    Dim OBJCOL As New CHIPHYPCollection, objchip As ChipHYP

    '    Dim iNivel As Integer = 0
    '    Dim txtMec As HtmlGenericControl
    '    Dim imgLstInfo As New ArrayList()
    '    Session("imgLstInfo") = imgLstInfo
    '    If bDetenidos And Not Session("rbDet") Is Nothing And bWS = False Then

    '        If sorden <> "" Then
    '            OBJCOL = OBJCOL.ObtenChipsAllDet(sorden, rdlBuscar.SelectedIndex)
    '        Else
    '            OBJCOL = OBJCOL.ObtenChipsAllDet("", 0)
    '        End If
    '        If Not Page.IsPostBack Then
    '            LlenaComboOrdenesDetenidos("")
    '        ElseIf txtBuscar.Text.Trim <> "" Then
    '            LlenaComboOrdenesDetenidos(txtBuscar.Text.Trim)
    '        ElseIf cboOrdenes.SelectedIndex > -1 Then
    '            LlenaComboOrdenesDetenidos(cboOrdenes.Items(cboOrdenes.SelectedIndex).Text)
    '        Else
    '            LlenaComboOrdenesDetenidos("")
    '        End If
    '    ElseIf bDetenidos = False And bWS = False And Session("rbCaptura") = False Then
    '        If HttpContext.Current.Session("Usuario").ToString.ToLower <> "admin" And SCCParametros.ObtenParametros(Request.Url.Segments(Request.Url.Segments.Length - 1), "FiltroAsesor") = "1" Then

    '            If sorden <> "" Then
    '                OBJCOL = OBJCOL.ObtenChipsAll(sorden, rdlBuscar.SelectedIndex, HttpContext.Current.Session("cveAsesor"))
    '            Else
    '                OBJCOL = OBJCOL.ObtenChipsAll("", 0, HttpContext.Current.Session("cveAsesor"))
    '            End If

    '        Else
    '            If sorden <> "" Then
    '                OBJCOL = OBJCOL.ObtenChipsAll(sorden, rdlBuscar.SelectedIndex)
    '            Else
    '                OBJCOL = OBJCOL.ObtenChipsAll("", 0)
    '            End If
    '        End If
    '        If Not Page.IsPostBack Then
    '            LlenaComboOrdenes("")
    '        ElseIf txtBuscar.Text.Trim <> "" Then
    '            LlenaComboOrdenes(txtBuscar.Text.Trim)
    '        ElseIf cboOrdenes.SelectedIndex > -1 Then
    '            LlenaComboOrdenes(cboOrdenes.Items(cboOrdenes.SelectedIndex).Text)
    '        End If


    '    ElseIf bWS = True Then

    '        OBJCOL = OBJCOL.ObtenChipsAllWS()

    '    End If


    '    iNumbahias = dt.Count
    '    Session("ColChips") = OBJCOL


    '    'iwidth = 75.5 * (Date.DaysInMonth(Now.Year, Now.Month) + Date.DaysInMonth(Now.AddMonths(1).Year, Now.AddMonths(1).Month))
    '    ' iwidth = (475.5 * (3 - CDATES.iDomingos)) 'sundays
    '    iwidth = ifac * (inumDias)
    '    floatdiv.Style.Remove("width")
    '    floatdiv.Style.Add("width", iwidth + 190 & "px")
    '    topfix0.Style.Remove("width")
    '    topfix0.Style.Add("width", iwidth + 190 & "px")
    '    If iTablero <> 1 Then
    '        iNumbahias = iNumbahias '* 2
    '    End If
    '    ilargo = ((iNumbahias) * 60) + 92

    '    If bTecnicos Then

    '        'If form1.FindControl("txtPos") Is Nothing Then
    '        '    Dim txtPos As New HtmlGenericControl("div")
    '        '    txtPos = New HtmlGenericControl("div")
    '        '    txtPos.ID = "txtPos"
    '        '    txtPos.Style.Value = "position:absolute;left:" & CInt(((((CDate(lblCalendar.Text).DayOfYear - CDate(lblCalendar.Text).AddDays(-1).DayOfYear - 2 - CDATES.iDomingos(CDate(lblCalendar.Text))) * 24) + CDate(lblCalendar.Text).Hour) / 3) * 9.4369999999999994) & "px;top:0px;width:1px;height:1px;background-color:White;Font-weight:bold;font-family:  Lucida Grande,Lucida Sans,Arial,sans-serif;font-size:10px;border:solid 1px silver;text-align:center;"
    '        '    form1.Controls.Add(txtPos)
    '        'End If



    '        sScript += "<script type='text/javascript'>" & vbCrLf
    '        sScript += "var jg_doc = new jsGraphics();" & vbCrLf
    '        'sScript += "var days = " & CDate(lblCalendar.Text).DayOfYear + (3 - CDate(lblCalendar.Text).DayOfYear - 2) - CDATES.iDomingos(CDate(lblCalendar.Text)) & ";" & vbCrLf

    '        sScript += "var hours = " & Date.Now.Hour & ";" & vbCrLf
    '        sScript += "var minutes = " & Date.Now.Minute & ";" & vbCrLf
    '        sScript += "var ifac = 0.05*94;" & vbCrLf
    '        sScript += "if(hours<" & iHorai & "||hours>" & iHorai + inumHoras - 1 & "){"
    '        sScript += "hours=0;minutes=0; "
    '        sScript += "} else {hours=hours-" & iHorai & ";}" & vbCrLf
    '        sScript += "jg_doc.setColor('" & SCCParametros.ObtenParametros(Request.Url.Segments(Request.Url.Segments.Length - 1), "bTiempo") & "');" & vbCrLf
    '        sScript += "lx = ((hours * 60) + minutes);(lx *(59.437/2));lx=lx+ifac;" & vbCrLf
    '        sScript += "if (lx > ifac) {" & vbCrLf
    '        sScript += "lx =  ((hours * 60) + minutes) - ifac; ;" & vbCrLf
    '        sScript += "" & vbCrLf
    '        sScript += "lx = parseInt(lx);" & vbCrLf
    '        sScript += "jg_doc.fillRect(92, 94, lx, " & ilargo - 92 & ");}" & vbCrLf


    '
    '        sScript += " var ejeX=206; var ejeY=94; " & vbCrLf
    '        If iTablero <> 1 Then
    '            sScript += " for(var d_i = 1; d_i <= " & iNumbahias & "; d_i++){ " & vbCrLf
    '        Else
    '            sScript += " for(var d_i = 1; d_i <= " & iNumbahias * 6 & "; d_i++){ " & vbCrLf

    '        End If


    '        sScript += "    ejeY += 60; " & vbCrLf
    '        sScript += "    if (d_i == " & iNumbahias & " || d_i == " & iNumbahias * 2 & "  || d_i == " & iNumbahias * 3 & "  || d_i == " & iNumbahias * 4 & " || d_i == " & iNumbahias * 5 & "){" & vbCrLf
    '        sScript += "        jg_doc.setColor('Black');   jg_doc.fillRect(0, ejeY, " & iwidth + 92 & ", 2);} " & vbCrLf
    '        sScript += "    else{jg_doc.setColor('Darkslategray');jg_doc.drawLine(0, ejeY, " & iwidth + 92 & ", ejeY);} " & vbCrLf

    '        sScript += "    jg_doc.setColor('#EEEEE0');jg_doc.fillRect(0, ejeY-30, " & iwidth + 92 & ", 30); " & vbCrLf
    '        'sScript += "    jg_doc.setColor('#E0FFFF');jg_doc.fillRect(0, ejeY-60, " & iwidth + 92 & ", 30); " & vbCrLf

    '        sScript += " }" & vbCrLf


    ''


    '        sScript += "jg_doc.setColor('Lightcoral');" & vbCrLf
    '        sScript += "jg_doc.drawLine(92, 0, 92, " & ilargo & "); " & vbCrLf
    '        sScript += "jg_doc.setColor('Black');" & vbCrLf
    '        sScript += "jg_doc.fillRect(" & iwidth + 92 & ", 0, 3, " & ilargo & ");" & vbCrLf
    '        sScript += " jg_doc.setColor('Black'); " & vbCrLf


    '        sScript += "jg_doc.fillRect(0, " & ilargo & ", " & iwidth + 92 & ", 3);" & vbCrLf

    '        'Silver para pintar 5 minutos
    '        sScript += "jg_doc.setColor('Silver'); " & vbCrLf
    '        sScript += "var posX = 92,posX2=92,posX3=92;" & vbCrLf
    '        sScript += "for(var d_i = 1; d_i <= " & System.Math.Round(iwidth / ifac) & "; d_i++){" & vbCrLf
    '        sScript += "            for(var d_j = 1; d_j < " & inumHoras + 1 & "; d_j++){" & vbCrLf

    '        ' sScript += "                jg_doc.setColor('red'); jg_doc.drawLine(posX2+(59.437/2), 92, posX2+(59.437/2), " & ilargo & ");" & vbCrLf

    '        sScript += "jg_doc.setStroke(1); for(var d_d = 1; d_d < 13; d_d++){ posX3=posX3+4.95;" & vbCrLf
    '        sScript += " jg_doc.setColor('" & SCCParametros.ObtenParametros(Request.Url.Segments(Request.Url.Segments.Length - 1), "bTableroGrid") & "'); jg_doc.drawLine(posX3, 92, posX3, " & ilargo & ");" & vbCrLf
    '        sScript += "               }" & vbCrLf

    '        sScript += "                jg_doc.setColor('" & SCCParametros.ObtenParametros2(Request.Url.Segments(Request.Url.Segments.Length - 1), "bTableroGrid") & "'); jg_doc.setStroke(2); jg_doc.drawLine(posX2, 92, posX2, " & ilargo & ");" & vbCrLf
    '        sScript += "                jg_doc.setColor(' " & SCCParametros.ObtenParametros(Request.Url.Segments(Request.Url.Segments.Length - 1), "bTableroGrid2") & "'); jg_doc.drawLine(posX2+(60/2), 92, posX2+(60/2), " & ilargo & ");" & vbCrLf



    '        sScript += "                posX2=posX2+59.437;}" & vbCrLf
    '        sScript += "        jg_doc.setColor('Navy'); jg_doc.drawLine(posX, 92, posX, " & ilargo & "); " & vbCrLf

    '        'sScript += "        jg_doc.setColor('Silver'); jg_doc.drawLine(posX+37.75, 92, posX+37.75, " & ilargo & "); " & vbCrLf
    '        sScript += "     posX = posX+" & ifac & ";}" & vbCrLf




    '        sScript += " " & vbCrLf


    '        sScript += " //SET_DHTML('ds00'); " & vbCrLf
    '        sScript += " " & vbCrLf
    '        sScript += "" & vbCrLf


    '        sScript += "</script>" & vbCrLf
    '        Page.ClientScript.RegisterClientScriptBlock(Page.GetType, "TabGraph", sScript)


    '        ''  Exit Sub

    '        Dim ddate As Date = Now.Date.AddDays(-inumLeft)
    '        ddate = CDate(lblCalendar.Text).AddDays(-inumLeft)
    '        Dim txtDia2 As HtmlGenericControl
    '        Dim txtDia3 As HtmlGenericControl
    '        Dim dtPosDias As New DataTable, ktop As Integer = 0
    '        dtPosDias.Columns.Add("dia", New Date().GetType)
    '        dtPosDias.Columns.Add("posleft", New Integer().GetType)
    '        dtPosDias.Rows.Clear()


    '        For i = 1 To inumDias

    '            txtDia3 = New HtmlGenericControl("div")
    '            txtDia2 = New HtmlGenericControl("div")
    '            txtDia2.ID = "txtDia" & ddate.AddDays(i - inumLeft).DayOfYear

    '            txtDia2.Style.Value = "border:none;position:absolute;left:" & 92 + ((ifac) * (i - 1)) & "px;top:50px;width:" & ifac & "px;height:40px;background-color:White;Font-weight:bold;font-family:  Lucida Grande,Lucida Sans,Arial,sans-serif;font-size:15px;text-align:center;"

    '            txtDia2.InnerText = ddate.AddDays(i - 1).ToShortDateString

    '            dtPosDias.Rows.Add(New Object() {CDate(txtDia2.InnerText), 92 + ((ifac) * (i - 1))})
    '            txtDia3.Style.Value = "width:" & ifac & "px;height:10px;background-color:White;Font-weight:bold;font-family:Arial;font-size:12px;text-align:center;"
    '            txtDia3.InnerHtml = "<table border='0' cellspacing=0 cellpadding=0 ><tr>"
    '            For ii = 0 To inumHoras - 1
    '                txtDia3.InnerHtml = txtDia3.InnerHtml & "<td  style='border:solid 1px black; width:" & Math.Round(ifac / inumHoras, MidpointRounding.ToEven) & "px;background-color:White;' >" & String.Format("{00:d}", ii + iHorai) & ":00</td>"

    '            Next
    '            txtDia3.InnerHtml = txtDia3.InnerHtml & "</tr></table>"
    '            txtDia2.Controls.Add(txtDia3)
    '            If form1.FindControl(txtDia2.ID) Is Nothing Then
    '                floatdiv.Controls.Add(txtDia2)
    '            End If


    '        Next
    '        Session("dtPosDias") = dtPosDias
    '    End If



    '    Dim imgLst As New ArrayList()
    '    Dim xleft As Integer = -100, III As Integer = 20
    '    imgLst.Clear()


    '    Dim imgLstPosMec As New DataTable
    '    imgLstPosMec.Columns.Add("ID")
    '    imgLstPosMec.Columns.Add("noorden")
    '    imgLstPosMec.Columns.Add("idservicio")
    '    imgLstPosMec.Columns.Add("noplacas")
    '    imgLstPosMec.Columns.Add("cliente")
    '    imgLstPosMec.Columns.Add("idcontrol")
    '    imgLstPosMec.Columns.Add("toppx")
    '    imgLstPosMec.Rows.Clear()

    '    leftfix0.Controls.Clear()
    '    For i = 1 To OBJCOL.Count


    '        txtMec = New HtmlGenericControl("div")
    '        txtMec.ID = "txtMec_" & i


    '        Dim ixdivchk As New CheckBox
    '        ixdivchk.ID = "ctlllchk_" & i

    '        ixdivchk.Style.Add("top", "0")
    '        ixdivchk.Style.Add("position", "absolute")
    '        ixdivchk.Style.Add("Left", "0")
    '        ixdivchk.Attributes.Add("onclick", "chkSelF")


    '        objchip = OBJCOL.Item(i - 1)

    '        xleft = xleft + 110
    '        If (i / III) - Fix(i / III) = 0 Then
    '            xleft = 220
    '        End If


    '        If bDetenidos = True Then
    '            txtMec.Style.Value = "position:absolute;top:" & ((Fix((i - 1) / III)) * 32) + 75 & "px;left:" & xleft + 5 & "px;width:100px; background-color:" & SCCParametros.ObtenParametros(Request.Url.Segments(Request.Url.Segments.Length - 1), "dw" & objchip.IDMOTIVOPARO) & ";Font-weight:bold;font-family:  Lucida Grande,Lucida Sans,Arial,sans-serif;font-size:12px;border:solid 1px black;"
    '            txtMec.InnerText = objchip.NOPLACAS & " Orden:" & objchip.NOORDEN & vbCrLf & "Unidad: " & objchip.VEHICULO & vbCrLf & "Detenida: " & objchip.STATUSOS & vbCrLf & "Tecnico: " & TablerosUtilsHyP.ObtenNombreTecnicos(objchip.IDTECNICO) & vbCrLf & "Duracion: " & objchip.SERVICIO & vbCrLf & "Descripcion:" & objchip.SERVICIOCAPTURADO.Trim()
    '            '  txtMec.ToolTip = "Tipo: " & objchip.TIPOCLIENTE & vbCrLf & "Servicio: " & objchip.SERVICIOCAPTURADO & vbCrLf & "Comentarios: " & objchip.OBSERVACIONES & ""
    '            txtMec.Attributes.Add("class", "menu3")

    '        ElseIf objchip.TIPOCLIENTE.ToLower = "waste" Then

    '            txtMec.Style.Value = "position:absolute;top:" & ((Fix((i - 1) / III)) * 32) + 75 & "px;left:" & xleft + 5 & "px;width:100px; background-color:" & SCCParametros.ObtenParametros(Request.Url.Segments(Request.Url.Segments.Length - 1), "dgw" & objchip.IDMOTIVOPARO) & ";Font-weight:bold;font-family:  Lucida Grande,Lucida Sans,Arial,sans-serif;font-size:12px;border:solid 1px black;"
    '            txtMec.InnerText = objchip.TIPOCLIENTE & " ID:" & objchip.IDSERVICIO & vbCrLf & "Duracion: " & objchip.SERVICIO & vbCrLf & vbCrLf & "Descripcion:" & objchip.SERVICIOCAPTURADO.Trim()
    '            '  txtMec.ToolTip = "Tipo: " & objchip.TIPOCLIENTE & vbCrLf & "Servicio: " & objchip.SERVICIOCAPTURADO & vbCrLf
    '            txtMec.Attributes.Add("class", "menu2")

    '        Else
    '            txtMec.Style.Value = "position:absolute;top:" & ((Fix((i - 1) / III)) * 32) + 75 & "px;left:" & xleft + 5 & "px;width:100px; background-color:" & "#fff" & ";Font-weight:bold;font-family:  Lucida Grande,Lucida Sans,Arial,sans-serif;font-size:12px;border:solid 1px black;"
    '            txtMec.InnerText = objchip.NOPLACAS & " Orden:" & objchip.NOORDEN & vbCrLf & "Unidad: " & objchip.VEHICULO & vbCrLf & "FechaOrden: " & objchip.FECHA.ToShortDateString() & vbCrLf & "Color: " & objchip.COLOR & vbCrLf & "Duracion: " & objchip.SERVICIO & vbCrLf & "Asesor:" & TablerosUtilsHyP.ObtenNombreAsesor(objchip.IDASESOR) & vbCrLf & "Descripcion:" & objchip.SERVICIOCAPTURADO.Trim()
    '            '   txtMec.ToolTip = "Tipo: " & objchip.TIPOCLIENTE & vbCrLf & "Servicio: " & objchip.SERVICIOCAPTURADO & vbCrLf & "Comentarios: " & objchip.OBSERVACIONES & ""
    '            txtMec.Attributes.Add("class", "menu2")
    '        End If


    '        dtTemp = TablerosUtilsHyP.ObtenServiciosxNoorden(objchip.NOORDEN)
    '        If dtTemp.Rows.Count > 0 Then
    '            '  txtMec.ToolTip += vbCrLf & "Tareas:" & vbCrLf
    '            For ii As Integer = 0 To dtTemp.Rows.Count - 1
    '                '    txtMec.ToolTip += "- " & dtTemp.Rows(ii).Item(0).ToString & vbCrLf
    '            Next
    '        End If

    '        ixdivchk.Style.Value = "float: left;"


    '        'txtMec.Controls.Add(ixdivchk)

    '        leftfix0.Controls.Add(txtMec)
    '        imgLst.Add(txtMec.ID)

    '        imgLstPosMec.Rows.Add(New Object() {objchip.ID, objchip.NOORDEN, objchip.IDSERVICIO, objchip.NOPLACAS, objchip.CLIENTE, txtMec.ID, 95 + ((50) * (i - 1))})
    '        AgregaInfo(txtMec.ID, objchip.ID & "___" & objchip.NOORDEN & "___" & objchip.NOPLACAS & "___" & objchip.IDSERVICIO & "___" & objchip.COLORPRISMA & "___" & objchip.CLIENTE & "___" & objchip.ASYSRENGLON & "___" & objchip.SERVICIOCAPTURADO & "___" & objchip.HORAASESOR & "___" & objchip.VEHICULO & "___" & objchip.VIN & "___" & objchip.AÑO & "___" & objchip.COLOR & "___" & objchip.IDASESOR & "___" & objchip.TELEFONOS & "___" & objchip.SERVICIO & "___" & objchip.IDITEM & "___" & objchip.NOPRISMA & "___" & objchip.TIPOCLIENTE & "___" & objchip.FECHA & "___" & objchip.HORAASESOR & "___" & objchip.IDBLINSUR & "___" & objchip.IDHD & "___" & objchip.IDMOTIVOPARO)

    '    Next

    '    Session("imgLst") = imgLst
    '    Session("imgLstPosMec") = imgLstPosMec


    '    iniciaTablero2()
    '    PINTACHIPS()
    '    Session.Remove("ObtenAusencias")
    'End Sub

    Protected Sub lblDescFase_click(ByVal sender As Object, ByVal e As EventArgs)
        Session("fase") = CType(CType(sender.parent, DataListItem).FindControl("lblFase"), Label).Text


        bref = True
        iniciaTablero0(True, txtBuscar.Text, 0)

    End Sub
    Private Sub txtCalendar_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCalendar.TextChanged

        lblCalendar.Text = txtCalendar.Text
        iniciaTablero0(True, txtBuscar.Text, 0)
    End Sub
    Sub PINTACHIPS()



        Dim OBJCOL As New CHIPHYPCollection, objchip As ChipHYP
        Dim sColor As String, sColorServicio As String, oChip As String, iNivel As Integer = 0
        'Dim dtDetenidos As New DataTable, dtIniciados As New DataTable, i As Integer, k As Integer, sLeft As Double, swidth As Integer
        Dim sstop As String, ssleft As String
        Dim imgLst As New ArrayList(), bAlarm As Boolean = False, bAlarmF As Boolean = False
        Dim imgLst2 As New ArrayList()
        Session("imgLst2") = imgLst2

        Dim sToolTips As String = SCCParametros.ObtenParametros2(Request.Url.Segments(Request.Url.Segments.Length - 1), "campomostrar")

        imgLst = Session("imgLst")

        If SCCParametros.ObtenParametros(Request.Url.Segments(Request.Url.Segments.Length - 1), "CitasVista").ToString = "1" Then
            OBJCOL = OBJCOL.ObtenChipsAllPCitasView(Request.Url.Segments(Request.Url.Segments.Length - 1), CDate(lblCalendar.Text))

        Else
            OBJCOL = OBJCOL.ObtenChipsAllP(Request.Url.Segments(Request.Url.Segments.Length - 1), CDate(lblCalendar.Text))

        End If

        Session("ColChipsP") = OBJCOL
        For i = 1 To OBJCOL.Count
            bAlarmF = False
            objchip = OBJCOL.Item(i - 1)
            sColorServicio = "#fff" 'TablerosUtilsHyP.ObtenColorServicioFaseII(objchip.IDSERVICIO)
            sColor = TablerosUtilsHyP.ObtenColorAsesor(objchip.IDASESOR)
            oChip = Left(objchip.OCHIP, 2)


            If objchip.CARRYOVER Then oChip = "dp"
            If objchip.SERVICIO < 60 Then oChip = "dr"
            If objchip.SERVICIO >= 60 Then oChip = "dr"
            If objchip.SERVICIO >= 120 Then oChip = "dg"

            If objchip.CONCITA Then
                Select Case objchip.TIPOCLIENTE.Trim.ToLower
                    Case "servicio", "cita normal", "cita", "citas"
                        oChip = "dg"
                    Case "reclamacion", "reclamaciones"
                        oChip = "dgr"
                    Case "retrabajo"
                        oChip = "dwr"
                    Case "express"
                        oChip = "dge"
                    Case "internet"

                        oChip = "dgi"
                    Case "diagnostico"
                        oChip = "dgd"
                    Case "compuesto"
                        oChip = "dgc"
                    Case Else
                        oChip = "dg"
                End Select

            End If

            If objchip.CONCITA = False Then
                If objchip.TIPOCLIENTE.Trim.ToLower = "waste" Then
                    oChip = "dgw"
                ElseIf objchip.TIPOCLIENTE.Trim.ToLower = "retrabajo" Then
                    oChip = "dwr"
                ElseIf objchip.TIPOCLIENTE.Trim.ToLower = "compuesto" Then
                    oChip = "dgc"
                Else
                    oChip = "db"
                End If

            End If



            If objchip.STATUS.ToLower = "detenida" Then
                oChip = "dw" & objchip.IDMOTIVOPARO
            End If

            Try
                If objchip.STATUS.ToLower = "detenida" Or objchip.STATUS.ToLower = "iniciada" Or objchip.STATUS.ToLower = "reiniciada" Then
                    iNivel = 0

                    sstop = CType(Session("dtPosY"), DataTable).Select("OrdenP='" & objchip.NOORDEN & "' and IdTecnico='" & objchip.IDTECNICO & "'")(0)("posYP") + 30 & "px"
                Else
                    iNivel = 1
                    sstop = CType(Session("dtPosY"), DataTable).Select("OrdenP='" & objchip.NOORDEN & "' and IdTecnico='" & objchip.IDTECNICO & "'")(0)("posYP") & "px"
                End If

                If objchip.STATUS.ToLower = "terminado" Then
                    If objchip.STATUSOS = "Calidad" Or objchip.STATUSOS = "PruebaRuta" Or objchip.STATUSOS = "EnPruebaCalidad" Then
                        oChip = "dwc"
                        iNivel = 0
                        sstop = CType(Session("dtPosY"), DataTable).Select("OrdenP='" & objchip.NOORDEN & "' and IdTecnico='" & objchip.IDTECNICO & "'")(0)("posYP") + 30 & "px"
                    Else
                        oChip = "dl"
                        iNivel = 0
                        sstop = CType(Session("dtPosY"), DataTable).Select("OrdenP='" & objchip.NOORDEN & "' and IdTecnico='" & objchip.IDTECNICO & "'")(0)("posYP") + 30 & "px"
                    End If
                End If
            Catch ex As Exception
                BDClass.inErr(ex.ToString & vbCrLf & vbCrLf, "Err_exec_progresotop.txt")
                sstop = "0px"

            End Try


            If objchip.VHSERVERMINADO = False Then
                If objchip.VHRECEPCION = False And CDate(objchip.FECHA.ToShortDateString & " " & objchip.HORAASESOR).AddMinutes(15) < Date.Now Then
                    If objchip.CARRYOVER = False And objchip.TIPOCLIENTE.Trim.ToLower <> "express" Then
                        If CDate(objchip.FECHA.ToShortDateString & " " & objchip.HORACITA) < Date.Now Then
                            oChip = "dn"

                        End If
                    End If

                End If
            End If

            imgLst.Add("ds" & String.Format("{0:000}", i))

            If CDate(objchip.FECHA.ToShortDateString & " " & objchip.HORARAMPA) <= Date.Now And objchip.STATUS.ToLower = "pendiente" Then
                bAlarm = True
            Else
                bAlarm = False
            End If

            If objchip.STATUS.ToLower = "iniciada" Then
                Dim tiempoT As TimeSpan = Date.Now.TimeOfDay - objchip.FECHAHORAINIOPER.TimeOfDay
                Dim tiempoH = CInt(tiempoT.Hours) * 60
                Dim tiempoM = CInt(tiempoT.Minutes)

                Dim tiempoTrancu As DateTime = objchip.FECHAHORAINIOPER.AddMinutes(tiempoH + tiempoM)
                Dim tiempoIDeal As DateTime = objchip.FECHAHORAINIOPER.AddMinutes(objchip.SERVICIO)
                If tiempoTrancu >= tiempoIDeal Then
                    bAlarmF = True
                End If
            End If


            If objchip.STATUSOS <> "SSINCARGO" And objchip.STATUSOS <> "Facturado" And objchip.STATUSOS <> "Remisionado" Then
                Try
                    ssleft = ((CDate(objchip.FECHA).DayOfYear - (CDate(lblCalendar.Text).AddDays(-inumLeft).DayOfYear)) * ifac) + IIf(((CDate(objchip.HORARAMPA).Hour * 60) - (iHorai * 60)) >= 0, ((((CDate(objchip.HORARAMPA).Hour * 60) - (iHorai * 60)) + CDate(objchip.HORARAMPA).Minute) * ((ifac / inumHoras) / 60)), 0) + 92

                    chipBoard(i, oChip, objchip.IDCHIP, CInt((objchip.SERVICIO / 60) * (ifac / inumHoras)), objchip.VEHICULO, ssleft & "px", sstop, sColor, sColorServicio, objchip.ID, objchip.SERVICIOCAPTURADO, objchip.SERVICIO, objchip.OBSERVACIONES, bAlarm, objchip, sToolTips, bAlarmF)
                Catch ex As Exception

                End Try
            End If

        Next

        Session("imgLst") = imgLst

        If SCCParametros.ObtenParametros(Request.Url.Segments(Request.Url.Segments.Length - 1), "IndicadoresCitas").ToString = "1" Then
            llenaindicadores()
        End If
    End Sub
    Sub AgregaInfo(ByVal sIdControl As String, ByVal sString As String)
        Dim imgLstInfo As New ArrayList()
        imgLstInfo = CType(Session("imgLstInfo"), ArrayList)
        imgLstInfo.Add("lblInfo" & sIdControl & "--" & sString)
        Session("imgLstInfo") = imgLstInfo

        Dim LBL As HtmlGenericControl
        LBL = New HtmlGenericControl("div")
        Try
            If form1.FindControl("lblInfo" & sIdControl) Is Nothing Then
                LBL.ID = "lblInfo" & sIdControl
                LBL.Style.Value = "display:none;"
                LBL.InnerText = sString

                form1.Controls.Add(LBL)
            Else

                CType(form1.FindControl("lblInfo" & sIdControl), HtmlGenericControl).InnerText = sString

            End If
        Catch ex As Exception

        End Try


    End Sub

    Function ObtenToppx(ByVal noorden As String, ByVal sidservicio As String, ByVal snoplacas As String, ByVal scliente As String, ByVal iNivel As Integer) As String
        Dim dt As DataTable = Session("imgLstPosMec")
        dt.DefaultView.RowFilter = "noorden='" & noorden & "' and idservicio='" & sidservicio & "' and noplacas='" & snoplacas & "' and cliente='" & scliente & "'"
        If dt.DefaultView.Count > 0 Then
            If iNivel = 1 Then
                Return CInt(dt.DefaultView(0)("toppx")) + 25 & "px"
            Else
                Return dt.DefaultView(0)("toppx") & "px"
            End If

        Else
            Return "0px"
        End If

    End Function

    Sub AplicaNivel(ByVal noorden As String, ByVal sidservicio As String, ByVal snoplacas As String, ByVal scliente As String, ByVal iNivel As Integer)
        Dim dt As DataTable = Session("imgLstPosMec")
        Dim LBL As HtmlGenericControl, LBL2 As HtmlGenericControl
        dt.DefaultView.RowFilter = "noorden='" & noorden & "' and idservicio='" & sidservicio & "' and noplacas='" & snoplacas & "' and cliente='" & scliente & "'"
        If dt.DefaultView.Count > 0 Then
            LBL = New HtmlGenericControl("div")
            LBL2 = New HtmlGenericControl("div")
            If iNivel = 1 Then
                LBL.ID = dt.DefaultView(0)("idControl") & "lblStT" & dt.DefaultView(0)("idservicio")
                LBL.Style.Value = "position:absolute;left:70px;top:25px;width:15px;height:20px;background-color:transparent;Font-weight:bold;font-family:  Lucida Grande,Lucida Sans,Arial,sans-serif;font-size:10px;border:solid 1px black;"
                LBL.InnerText = "T"
                LBL2.ID = dt.DefaultView(0)("idControl") & "lblStT2" & dt.DefaultView(0)("idservicio")
                LBL2.Style.Value = "position:absolute;left:0px;top:0px;background-color:transparent;"
                LBL2.InnerText = CType(leftfix0.FindControl(dt.DefaultView(0)("idControl")), Label).Text
                ' LBL. = "Trabajando"
                CType(leftfix0.FindControl(dt.DefaultView(0)("idControl")), Label).Controls.Add(LBL2)
                CType(leftfix0.FindControl(dt.DefaultView(0)("idControl")), Label).Controls.Add(LBL)

            Else
                LBL.ID = dt.DefaultView(0)("idControl") & "lblStP" & dt.DefaultView(0)("idservicio")
                LBL.Style.Value = "position:absolute;left:70px;top:0px;width:15px;height:20px;background-color:transparent;Font-weight:bold;font-family:  Lucida Grande,Lucida Sans,Arial,sans-serif;font-size:10px;border:solid 1px black;"
                LBL.InnerText = "P"
                LBL2.ID = dt.DefaultView(0)("idControl") & "lblStP2" & dt.DefaultView(0)("idservicio")
                LBL2.Style.Value = "position:absolute;left:0px;top:0px;background-color:transparent;"
                LBL2.InnerText = CType(leftfix0.FindControl(dt.DefaultView(0)("idControl")), Label).Text
                ' LBL.ToolTip = "Planeado"
                CType(leftfix0.FindControl(dt.DefaultView(0)("idControl")), Label).Controls.Add(LBL2)
                CType(leftfix0.FindControl(dt.DefaultView(0)("idControl")), Label).Controls.Add(LBL)
            End If


        End If

    End Sub

    Function imageCHIP(ByVal sChip As String, ByVal objChip As ChipHYP) As String


        Return SCCParametros.ObtenParametros(Request.Url.Segments(Request.Url.Segments.Length - 1), sChip)



    End Function


    Sub chipBoard(ByVal numberChip As Integer, ByVal sChip As String, ByVal iItem As Integer, ByVal iTime As Integer, ByRef sTexto As String, ByVal sL As String, ByVal sT As String, ByVal sColor As String, ByVal sColorServicio As String, ByVal iId As Integer, ByVal sServicioCapturado As String, ByVal sServicio As String, ByVal sObservaciones As String, ByVal bAlarm As Boolean, ByVal objChip As ChipHYP, stooltips As String, ByVal bAlarmF As Boolean)


        Dim sDiv, sWidth, sImageChip As String


        Dim lbl1 As String = "", lbl2 As String = "", lbl3 As String = "", lbl4 As String = ""
        Dim iPos1 As Integer



        sDiv = "ds" & String.Format("{0:000}", numberChip)

        sImageChip = imageCHIP(sChip, objChip)

        ' iWidth = (iTime * 76) / 60

        sWidth = iTime & "px"


        lbl1 = sTexto

        iPos1 = InStr(lbl1, "@")
        If iPos1 > 0 Then
            lbl2 = Mid(lbl1, iPos1 + 1, Len(lbl1) - iPos1)
            lbl1 = Mid(lbl1, 1, iPos1 - 1)

            iPos1 = InStr(lbl2, "@")
            If iPos1 > 0 Then
                lbl3 = Mid(lbl2, iPos1 + 1, Len(lbl2) - iPos1)
                lbl2 = Mid(lbl2, 1, iPos1 - 1)
            End If

            iPos1 = InStr(lbl3, "@")
            If iPos1 > 0 Then
                lbl4 = Mid(lbl3, iPos1 + 1, Len(lbl3) - iPos1)
                lbl3 = Mid(lbl3, 1, iPos1 - 1)
            End If
        End If


        displayChip(iId, sDiv, sL, sT, sWidth, sImageChip, sColor, sColorServicio, iTime, lbl1, sChip, lbl3, lbl4, sServicioCapturado, sServicio, sObservaciones, bAlarm, objChip, stooltips, bAlarmF)




    End Sub
    Sub displayChip(ByVal iItem As Integer, ByVal sDiv As String, ByVal sL As String, ByVal sT As String, ByVal sWidth As String, ByVal sImageChip As String, ByVal sColor As String, ByVal scolorservicio As String, ByVal iTime As Integer, ByVal lblChp1 As String, ByVal lblChp2 As String, ByVal lblChp3 As String, ByVal lblChp4 As String, ByVal sServiciocapturado As String, ByVal sServicio As String, ByVal sObservaciones As String, ByVal bAlarm As Boolean, ByVal objChip As ChipHYP, stoolTips As String, ByVal bAlarmF As Boolean)


        Dim iDiv As Integer
        Dim lbl1 As String
        Dim imgList As New ArrayList()
        iDiv = Val(Right(sDiv, 3))
        lbl1 = "lb" & Right(sDiv, 3) & "1"



        Dim ixdivId As New HtmlInputHidden
        ixdivId.Value = iItem
        ixdivId.ID = "ctlll_" & iItem

        Dim ixdiv As New HtmlGenericControl("div")
        ixdiv.ID = sDiv

        imgList = CType(Session("imgLst2"), ArrayList)
        imgList.Add(ixdiv.ID & "__" & objChip.ID)
        Session("imgLst2") = imgList

        Dim converter = System.ComponentModel.TypeDescriptor.GetConverter(GetType(System.Drawing.Color))
        Dim color As System.Drawing.Color




        ixdiv.Style.Add("Left", sL)
        ixdiv.Style.Add("top", sT)
        ixdiv.Style.Add("width", sWidth)
        ixdiv.Style.Add("height", "27px")
        ixdiv.Style.Add("cursor", "hand")

        ixdiv.Style.Add("background-color", sImageChip)

        ixdiv.Style.Add("color", System.Drawing.ColorTranslator.ToHtml(color))
        ixdiv.Style.Add("position", "absolute")
        ixdiv.Visible = True
        ixdiv.Style.Add("border-top-style", "solid")
        ixdiv.Style.Add("border-top-color", sColor)
        ixdiv.Style.Add("border-left-color", "black")
        ixdiv.Style.Add("border-right-color", "black")
        ixdiv.Style.Add("border-bottom-color", "black")
        ixdiv.Style.Add("border-left-style", "solid")
        ixdiv.Style.Add("border-right-style", "solid")
        ixdiv.Style.Add("border-bottom-style", "solid")
        ixdiv.Style.Add("border-left-width", "1px")
        ixdiv.Style.Add("border-right-width", "1px")
        ixdiv.Style.Add("border-bottom-width", "1px")
        'If Left(lblChp2, 2) = "dw" Then ixdiv.Style.Add("Filter", "Chroma(Color=#FFFFFF)Wave(Add=0, Freq=5, LightStrength=20, Phase=220, Strenght=10)")
        ixdiv.Style.Add("clear", "none")
        ixdiv.Style.Add("z-index", "1500")
        ixdiv.Style.Add("font-size", "10px")
        ixdiv.Style.Add("font-weight", "normal")
        ixdiv.Style.Add("text-align", "center")
        ixdiv.Attributes.Add("class", "menu")

        ixdiv.Style.Add("background-position", "left top")




        If SCCParametros.ObtenParametros(Request.Url.Segments(Request.Url.Segments.Length - 1), "colorcaptura").ToString = "1" Then
            ' ixdiv.Style.Add("filter", "progid:DXImageTransform.Microsoft.gradient(startColorstr=" & sImageChip & ", endColorstr=" & TablerosUtilsHyP.ObtenColorIdSErvicio(objChip.IDSERVICIO) & ", GradientType=3)")
            '   ixdiv.Style.Add("background", "-webkit-gradient(radial,center center,0,center center,60,from(#FFFFFF),to(" & sImageChip & "))")
            ixdiv.Style.Add("background", "-moz-linear-gradient(left, " & sImageChip & ", " & TablerosUtilsHyP.ObtenColorIdSErvicio(objChip.IDSERVICIO) & ")")
            '  ixdiv.Style.Add("background", "-moz-radial-gradient(40% 40%, farthest-side, #ffffff, " & sImageChip & ")")
            'ixdiv.Style.Add("background", "-moz-radial-gradient(40% 40%, farthest-side, #ffffff, " & sImageChip & ")")
            ixdiv.Style.Add("background", "-webkit-linear-gradient(left, " & sImageChip & ", " & TablerosUtilsHyP.ObtenColorIdSErvicio(objChip.IDSERVICIO) & ")")
            ' ixdiv.Style.Add("background", "-ms-radial-gradient(80% 20%, closest-corner, " & sImageChip & ", " & TablerosUtilsHyP.ObtenColorIdSErvicio(objChip.IDSERVICIO) & ")")
        Else
            If objChip.IDCHIP = 0 Then
                ixdiv.Style.Add("filter", "progid:DXImageTransform.Microsoft.gradient(startColorstr=#ffffff, endColorstr=" & sImageChip & ", GradientType=3)")
                '   ixdiv.Style.Add("background", "-webkit-gradient(radial,center center,0,center center,60,from(#FFFFFF),to(" & sImageChip & "))")
                ixdiv.Style.Add("background", "-moz-radial-gradient(40% 40%, farthest-side, #ffffff, " & sImageChip & ")")
                '  ixdiv.Style.Add("background", "-moz-radial-gradient(40% 40%, farthest-side, #ffffff, " & sImageChip & ")")

                ixdiv.Style.Add("background", "-webkit-radial-gradient(30% 30%, farthest-corner, #FFFFFF 30%, " & sImageChip & " 100%)")
            End If
        End If


        Dim sComentarios As String = ""
        If stoolTips.Trim.Length > 0 Then
            'EN CONSTRUCCION
        End If


        For Each d As ChipHYPCom In objChip._HypComentarios
            sComentarios = sComentarios & "--- Comentarios en " & d._Status & "---" & vbCrLf
            sComentarios = sComentarios & "Fecha: " & d._fecha.ToShortDateString & " " & d._fecha.ToShortTimeString & ", "
            sComentarios = sComentarios & "Usuario: " & d._cveUsuario & vbCrLf
            sComentarios = sComentarios & "   " & d._comentario & vbCrLf
        Next
        If objChip.CONCITA = True Then
			ixdiv.Attributes.Add("title", "--CITA " & objChip.NUMCITA & "-- HoraCita " & objChip.HORAASESOR & vbCrLf & "--Cliente: " & objChip.CLIENTE & "--N° Economico:" & objChip.COLORPRISMA & vbCrLf & "Orden:" & objChip.NOORDEN & vbCrLf & "Asesor:" & TablerosUtilsHyP.ObtenNombreAsesor(objChip.IDASESOR) & vbCrLf & "Vehiculo: " & objChip.VEHICULO & " " & objChip.COLOR & vbCrLf & " Placas: " & objChip.NOPLACAS & vbCrLf & " FechaOrden: " & objChip.FECHA.ToShortDateString() & vbCrLf & "VIN: " & objChip.VIN & vbCrLf & "Servicio: " & sServiciocapturado & vbCrLf & "Duracion: " & System.Math.Round((sServicio / 60), 2) & " horas" & vbCrLf & "Observaciones: " & sObservaciones & "" & vbCrLf & "Estatus: " & objChip.STATUS.ToUpper & "" & vbCrLf & sComentarios)

		Else
			ixdiv.Attributes.Add("title", "--Cliente: " & objChip.CLIENTE & "--N° Economico:" & objChip.COLORPRISMA & vbCrLf & "Orden:" & objChip.NOORDEN & vbCrLf & "Asesor:" & TablerosUtilsHyP.ObtenNombreAsesor(objChip.IDASESOR) & vbCrLf & "Vehiculo: " & objChip.VEHICULO & " " & objChip.COLOR & vbCrLf & " Placas: " & objChip.NOPLACAS & vbCrLf & " FechaOrden: " & objChip.FECHA.ToShortDateString() & vbCrLf & "VIN: " & objChip.VIN & vbCrLf & "Servicio: " & sServiciocapturado & vbCrLf & "Duracion: " & System.Math.Round((sServicio / 60), 2) & " horas" & vbCrLf & "Observaciones: " & sObservaciones & "" & vbCrLf & "Estatus: " & objChip.STATUS.ToUpper & "" & vbCrLf & sComentarios)

		End If



        ixdiv.InnerText = objChip.CAMPOMOSTRAR.Trim()



        If Left(objChip.STATUS.ToUpper, 1) = "I" Or Left(objChip.STATUS.ToUpper, 1) = "R" Or Left(objChip.STATUS.ToUpper, 1) = "D" Or Left(objChip.STATUS.ToUpper, 1) = "T" Then
            Dim ixdivsT As New HtmlGenericControl("div")
            ixdivsT.ID = sDiv & "ST"

            ixdivsT.Style.Add("Left", "0")
            ixdivsT.Style.Add("top", "11px")
            ixdivsT.Style.Add("cursor", "hand")
            ixdivsT.Style.Add("position", "absolute")
            ixdivsT.Style.Add("width", "100%")
            ixdivsT.Style.Add("height", "12px")

            ixdivsT.Style.Add("font-size", "10px")
            ixdivsT.Style.Add("text-align", "center")
            ixdivsT.Style.Add("font-weight", "bold")
            ixdivsT.InnerText = Left(objChip.STATUS.ToUpper, 1)
            ' ixdiv.Style.Add("z-index", "1501")
            ixdiv.Controls.Add(ixdivsT)

        End If

        If bAlarm Then
            Dim ixdivAlert As New HtmlImage
            ixdivAlert.ID = sDiv & "Alert"
            ixdivAlert.Src = "~/img/blinkyellow.gif"
            ixdivAlert.Style.Add("Left", "0")
            ixdivAlert.Style.Add("top", "0")
            ixdivAlert.Style.Add("cursor", "hand")
            ixdivAlert.Style.Add("position", "absolute")
            ixdivAlert.Style.Add("width", "100%")
            ixdivAlert.Style.Add("height", "100%")
            'ixdivAlert.Style.Add("background-color", "Transparent")
            'ixdivAlert.Style.Add("filter", "alpha(opacity = 20)")

            ' ixdiv.Style.Add("z-index", "1501")
            ixdiv.Controls.Add(ixdivAlert)

        End If

        If bAlarmF Then
            Dim ixdivAlertF As New HtmlImage
            ixdivAlertF.ID = sDiv & "Alert"
            ixdivAlertF.Src = "~/img/blink.gif"
            ixdivAlertF.Style.Add("Left", "0")
            ixdivAlertF.Style.Add("top", "0")
            ixdivAlertF.Style.Add("cursor", "hand")
            ixdivAlertF.Style.Add("position", "absolute")
            ixdivAlertF.Style.Add("width", "100%")
            ixdivAlertF.Style.Add("height", "100%")

            'ixdivAlert.Style.Add("background-color", "Transparent")
            'ixdivAlert.Style.Add("filter", "alpha(opacity = 20)")

            ixdiv.Style.Add("z-index", "1501")
            ixdiv.Controls.Add(ixdivAlertF)
        End If

        If sComentarios.Length > 0 Then
            Dim ixdivcomen As New HtmlGenericControl("div")
            ixdivcomen.ID = sDiv & "_comen"
            ixdivcomen.Style.Add("bottom", "70%")
            ixdivcomen.Style.Add("left", "90%")
            ixdivcomen.Style.Add("position", "relative")
            ixdivcomen.Style.Add("width", "6px")
            ixdivcomen.Style.Add("height", "9px")
            ixdivcomen.Style.Add("color", "#fff")
            ixdivcomen.Style.Add("background-color", "darkblue")
            ixdivcomen.InnerText = "1"
            ixdivcomen.Style.Add("font-weight", "bold")
            ixdivcomen.Style.Add("text-align", "center")
            ixdivcomen.Style.Add("font-size", "7px")
            ixdiv.Controls.Add(ixdivcomen)
        End If

        ixdiv.Controls.Add(ixdivId)

        Me.form1.Controls.Add(ixdiv)

    End Sub


    Private Sub whuxgaPT_PreRenderComplete(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.PreRenderComplete
        Dim OBJARRAY As ArrayList = CType(Session("imgLst"), ArrayList)
        'Dim OBJARRAYDAYS As ArrayList = CType(Session("imgLstDays"), ArrayList)

        'OBJARRAY.Add("divInterfaz")
        'OBJARRAY.Add("leftfix0")

        Dim va_Enumerator As System.Collections.IEnumerator = OBJARRAY.GetEnumerator()
        Dim sScript As String = ""
        sScript += "" & vbCrLf
        sScript += "" & vbCrLf
        sScript += " SET_DHTML("
        While va_Enumerator.MoveNext()

            sScript += "" & Chr(34) & va_Enumerator.Current & Chr(34) & "+RESIZABLE, "


        End While
        'sScript += "" & Chr(34) & "dsag" & Chr(34) & "+NO_DRAG, "
        sScript += "" & Chr(34) & "divifra" & Chr(34) & "+NO_DRAG, "
        sScript += "" & Chr(34) & "imgLogo1" & Chr(34) & "+NO_DRAG, "
        sScript += "" & Chr(34) & "imgLogo0" & Chr(34) & "+NO_DRAG, "
        sScript += "" & Chr(34) & "divInterfaz" & Chr(34) & ", "
        sScript += "" & Chr(34) & "pnlFin" & Chr(34) & ", "
        sScript += "" & Chr(34) & "pnlComent" & Chr(34) & ", "
        sScript += "" & Chr(34) & "divdedit2" & Chr(34) & ", "
        sScript += "" & Chr(34) & "leftfix" & Chr(34) & "+NO_DRAG, "

        sScript += "" & Chr(34) & "divFind" & Chr(34) & "+NO_DRAG, "
        sScript += "" & Chr(34) & "dhtml" & Chr(34) & "+NO_DRAG, "
        sScript = Left(sScript, Len(sScript) - 2)
        sScript += ");" & vbCrLf



        sScript += "" & vbCrLf
        scrmgr1.RegisterStartupScript(Me, Page.GetType, "TabGraphDHTML", sScript, True)
        If dchp.Visible Then
            scrmgr1.RegisterStartupScript(Me, Page.GetType, "dchpFocus", "document.getElementById('dchp').focus();", True)
        End If
    End Sub



    Private Sub imgBtnMve_DMS_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imgBtnMve_DMS.Click

        Dim schip As String = "", stexto As String = ""
        Dim ileft As Integer = CInt(((24) / 3) * 9.437)
        sMensajes = New ArrayList
        If iMulti.Value.Split(",").Length < 2 Then
            schip = CType(Me.form1.FindControl("dhtml"), HtmlInputText).Value
            _moverchip(schip, 0)
        Else
            For i As Integer = 0 To Me.iMulti.Value.Split(",").Length() - 1

                schip = iMulti.Value.Split(",")(i)
                _moverchip(schip, Me.iMulti.Value.Split(",").Length())
            Next

        End If
        For Each s As String In sMensajes
            stexto += s & "</br>"
        Next
        If stexto.Length > 0 Then TablerosUtilsHyP.iMsgBox(Me, stexto, ileft)

        iMulti.Value = ""

        bref = True
        If Session("clkMenuid") Is Nothing Then
            menuItem2(0, True)
        Else
            menuItem2(Session("clkMenuid"), True)
        End If

    End Sub
    Sub _moverchip(sdhtml As String, im As Integer)

        Dim iId As Int64, iPosx As Int32, iPosY As Int32, sHora As String
        'Dim sdhtml As String = CType(Me.form1.FindControl("dhtml"), HtmlInputText).Value
        If Split(sdhtml, ".").Length < 2 Then Exit Sub
        If Left(sdhtml, 5) = "ds00." Then Exit Sub
        'For Each d In Me.FindControl(Split(sdhtml, ".")(0)).Controls
        '    If Left(d.id, 5) = "ctlll" Then
        '        iId = d.Value
        '    End If
        'Next
        iId = obtenid(Split(sdhtml, ".")(0))
        If iId = 0 Then Exit Sub

        iPosx = CInt(Split(sdhtml, ".")(1))
        iPosY = CInt(Split(sdhtml, ".")(2))
        sHora = String.Format("{0:HH:mm}", CDate(String.Format("{00:d}", iHorai) & ":00").AddMinutes((((Decimal.Round(CDec((Val(iPosx) - 92) / ifac), 2) - Fix(CDec((Val(iPosx) - 92) / ifac))) / (ifac / inumHoras)) * ifac) * 60))

        Dim OBJCOL As New CHIPHYPCollection
        OBJCOL = Session("ColChipsP")


        For Each obj As ChipHYP In OBJCOL
            If obj.ID = iId Then
                If SCCParametros.ObtenParametros(Request.Url.Segments(Request.Url.Segments.Length - 1), "CitasVistaI") = "1" And obj.IDCHIP = 0 Then

                    obj.IDCHIP = TablerosUtilsHyP.MaxChip

                    obj.CONTINUARA = True
                    obj.ENUSO = True

                    obj.VHINVENTARIO = True

                    obj.VHREPROGRAMADO = False
                    obj.VHSERVCANCELADO = False
                    obj.VHSERVERMINADO = False

                    obj.USUARIO = lblUsr.Text
                    obj.OCHIP = "dg" & obj.SERVICIO & obj.IDCHIP

                    TablerosUtilsHyP.GuardarChip(obj)
                    obj.ID = TablerosUtilsHyP.ObtenMaxIdOrden(obj.NOORDEN)
                End If

                obj.TOPPX = iPosY
                obj.LEFTPX = iPosx
                obj.HORARAMPA = sHora
                Try
                    obj.FECHA = HttpContext.Current.Session("dtPosDias").Select("posLeft<=" & obj.LEFTPX & " and posLeft + " & ifac & ">" & obj.LEFTPX & "")(0).Item("dia")
                Catch ex As Exception

                End Try
                If Validar(obj, "M", CDate(lblCalendar.Text)) Then
                    TablerosUtilsHyP.MoverChipPRG(obj, iPosY, iPosx, ifac, inumHoras, iHorai)
                End If
                Exit For
            End If
        Next
        '


    End Sub
    Protected Sub imgBtnTme_CHP_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imgBtnTme_CHP.Click
        Dim schip As String = "", stexto As String = ""
        Dim ileft As Integer = CInt(((24) / 3) * 9.437)
        sMensajes = New ArrayList
        If iMulti.Value.Split(",").Length < 2 Then
            schip = CType(Me.form1.FindControl("dhtml"), HtmlInputText).Value
            _modtiempo(schip, 0)
        Else
            For i As Integer = 0 To Me.iMulti.Value.Split(",").Length() - 1

                schip = iMulti.Value.Split(",")(i)
                _modtiempo(schip, Me.iMulti.Value.Split(",").Length())
            Next

        End If
        For Each s As String In sMensajes
            stexto += s & "</br>"
        Next
        If stexto.Length > 0 Then TablerosUtilsHyP.iMsgBox(Me, stexto, ileft)

        iMulti.Value = ""

        bref = True
        If Session("clkMenuid") Is Nothing Then
            menuItem2(0, True)
        Else
            menuItem2(Session("clkMenuid"), True)
        End If

    End Sub
    Protected Sub cmdGuardartxt2dit2_Click(sender As Object, e As EventArgs) Handles cmdGuardartxt2dit2.Click
        Dim schip As String = "", stexto As String = ""
        Dim ileft As Integer = CInt(((24) / 3) * 9.437)
        If IsNumeric(txtedit2.Text) Then



            sMensajes = New ArrayList
            If iMulti.Value.Split(",").Length < 2 Then
                schip = CType(Me.form1.FindControl("dhtml"), HtmlInputText).Value
                schip = Left(schip, InStrRev(schip, ".")) & CInt(txtedit2.Text)
                _modtiempo(schip, 0)
            Else
                For i As Integer = 0 To Me.iMulti.Value.Split(",").Length() - 1

                    schip = iMulti.Value.Split(",")(i)
                schip = Left(schip, InStrRev(schip, ".")) & CInt(txtedit2.Text)
                _modtiempo(schip, Me.iMulti.Value.Split(",").Length())
            Next

        End If
        For Each s As String In sMensajes
            stexto += s & "</br>"
        Next
        If stexto.Length > 0 Then TablerosUtilsHyP.iMsgBox(Me, stexto, ileft)

        End If
        iMulti.Value = ""

        '      For Each obj As ChipHYP In OBJCOL
        '          If obj.ID = iId Then
        '              obj.LEFTPX = iPosx
        '              obj.TOPPX = iPosY
        '              obj.SERVICIO = iTiempo
        '              obj.HORARAMPA = shora
        '              If Validar(obj, "T", CDate(lblCalendar.Text)) Then
        '                  TablerosUtilsHyP.AumentarChipPRG(obj, iTiempo)
        '              End If
        '              Exit For
        '          End If

        '      Next
        '      bref = True
        '      If Session("clkMenuid") Is Nothing Then
        '          menuItem2(0, True)
        '      Else
        '          menuItem2(Session("clkMenuid"), True)
        '      End If
    End Sub
    Sub _modtiempo(sdhtml As String, im As Integer)
        Dim iId As Int64, iTiempo As Int32, iPosx As Int32, iPosY As Int32, shora As String
        'Dim sdhtml As String = CType(Me.form1.FindControl("dhtml"), HtmlInputText).Value
        If Split(sdhtml, ".").Length < 2 Then Exit Sub
        If Left(sdhtml, 5) = "ds00." Then Exit Sub

        iTiempo = CInt(Split(sdhtml, ".")(3))
        iTiempo = System.Math.Round(Decimal.Round(CDec(iTiempo / 59), 2) * 60, MidpointRounding.AwayFromZero)

        'iTiempo = CInt((iTiempo) * (5 / 6.33))
        iPosx = CInt(Split(sdhtml, ".")(1))
        iPosY = CInt(Split(sdhtml, ".")(2))
        shora = String.Format("{0:HH:mm}", CDate(String.Format("{00:d}", iHorai) & ":00").AddMinutes((((Decimal.Round(CDec((Val(iPosx) - 92) / ifac), 2) - Fix(CDec((Val(iPosx) - 92) / ifac))) / (ifac / inumHoras)) * ifac) * 60))

        'For Each d In Me.FindControl(Split(sdhtml, ".")(0)).Controls
        '    If Left(d.id, 5) = "ctlll" Then
        '        iId = d.Value
        '    End If
        'Next

        iId = obtenid(Split(sdhtml, ".")(0))
        If iId = 0 Then Exit Sub

        Dim OBJCOL As New CHIPHYPCollection
        OBJCOL = Session("ColChipsP")

        For Each obj As ChipHYP In OBJCOL
            If obj.ID = iId Then

                If SCCParametros.ObtenParametros(Request.Url.Segments(Request.Url.Segments.Length - 1), "CitasVistaI") = "1" And obj.IDCHIP = 0 Then

                    obj.IDCHIP = TablerosUtilsHyP.MaxChip

                    obj.CONTINUARA = True
                    obj.ENUSO = True

                    obj.VHINVENTARIO = True

                    obj.VHREPROGRAMADO = False
                    obj.VHSERVCANCELADO = False
                    obj.VHSERVERMINADO = False

                    obj.USUARIO = lblUsr.Text
                    obj.OCHIP = "dg" & obj.SERVICIO & obj.IDCHIP

                    TablerosUtilsHyP.GuardarChip(obj)
                    obj.ID = TablerosUtilsHyP.ObtenMaxIdOrden(obj.NOORDEN)
                End If


                obj.LEFTPX = iPosx
                obj.TOPPX = iPosY
                obj.SERVICIO = iTiempo
                obj.HORARAMPA = shora
                If Validar(obj, "T", CDate(lblCalendar.Text)) Then
                    TablerosUtilsHyP.AumentarChipPRG(obj, iTiempo)
                End If

                Exit For
            End If

        Next



    End Sub

    Protected Sub imgBtnUpd_DMS_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imgBtnUpd_DMS.Click
        Dim schip As String = "", stexto As String = ""
        Dim ileft As Integer = CInt(((24) / 3) * 9.437)
        sMensajes = New ArrayList
        Dim sValores() As String
        Dim sValores2() As String



        If iMulti.Value.Split(",").Length < 2 Then
            schip = CType(Me.form1.FindControl("dhtml"), HtmlInputText).Value

            sValores = Split(obtenInfo("lblInfo" & Split(schip, ".")(0)), "___")
            _grabarchip(schip, 0, sValores)
        Else
            schip = CType(Me.form1.FindControl("dhtml"), HtmlInputText).Value
            sValores = Split(obtenInfo("lblInfo" & Split(schip, ".")(0)), "___")
            For i As Integer = 0 To Me.iMulti.Value.Split(",").Length() - 1
                'schip = iMulti.Value.Split(",")(i)

                If iMulti.Value.Split(",")(i) <> schip Then
                    sValores2 = Split(obtenInfo("lblInfo" & Split(schip, ".")(0)), "___")

                    If sValores(1) = sValores(1) Then
                        'sValores(3) = sValores(3) & ";" & sValores2(3)
                        sValores(15) = CInt(sValores(15)) + CInt(sValores2(15))
                        sValores(7) = sValores(7) & ";" & sValores2(7)
                        sValores(18) = "compuesto"
                    End If

                End If

            Next



            _grabarchip(schip, Me.iMulti.Value.Split(",").Length(), sValores)


        End If
        For Each s As String In sMensajes
            stexto += s & "</br>"
        Next
        If stexto.Length > 0 Then TablerosUtilsHyP.iMsgBox(Me, stexto, ileft)



        iMulti.Value = ""

        bref = True
        '   iniciaTablero(True, txtBuscar.Text)
        If Session("clkMenuid") Is Nothing Then
            menuItem2(0, True)
        Else
            menuItem2(Session("clkMenuid"), True)
        End If


    End Sub
    Sub _grabarchip(sdhtml As String, im As Integer, sValores() As String)
        Dim objChip As New ChipHYP, objChip2 As New ChipHYP

        ' Dim sdhtml As String = CType(Me.form1.FindControl("dhtml"), HtmlInputText).Value
        If Split(sdhtml, ".").Length < 2 Then
            TablerosV2LibTypes.BDClass.inErr(sdhtml & "1595", "err_dmsProgresoOp.txt")
            Exit Sub
        End If

        If Left(sdhtml, 7) <> "txtMec_" Then
            TablerosV2LibTypes.BDClass.inErr(sdhtml & "1600", "err_dmsProgresoOp.txt")
            Exit Sub
        End If




        'Dim sValores() As String = Split(CType(Me.FindControl("lblInfo" & Split(sdhtml, ".")(0)), HtmlGenericControl).InnerText, "___")
        ''Dim sValores() As String = Split(obtenInfo("lblInfo" & Split(sdhtml, ".")(0)), "___")


        objChip.OCHIPWIDTH = CInt(Split(sdhtml, ".")(3))
        objChip.LEFTPX = CInt(Split(sdhtml, ".")(1))
        objChip.TOPPX = CInt(Split(sdhtml, ".")(2))
        objChip.IDCHIP = TablerosUtilsHyP.MaxChip


        '  AgregaInfo(


        Dim dFecha As DateTime, sHora As String, sselect As String
        Dim dt As New DataTable, itfecha As Date
        dt = HttpContext.Current.Session("dtPosDias")

        sHora = String.Format("{0:HH:mm}", CDate(String.Format("{00:d}", iHorai) & ":00").AddMinutes((((Decimal.Round(CDec((Val(objChip.LEFTPX) - 92) / ifac), 2) - Fix(CDec((Val(objChip.LEFTPX) - 92) / ifac))) / (ifac / inumHoras)) * ifac) * 60))
        sselect = "posLeft<=" & objChip.LEFTPX & " and (posLeft + " & CInt(ifac) & ")>" & objChip.LEFTPX & ""
        itfecha = dt.Select(sselect)(0).Item("dia")
        dFecha = CDate(itfecha.ToShortDateString & " " & sHora)


        objChip.IDITEM = sValores(16)
        objChip.NOORDEN = sValores(1)
        objChip.ASYSRENGLON = sValores(6)
        objChip.NOPLACAS = sValores(2)
        objChip.IDSERVICIO = sValores(3)
        objChip.SERVICIO = sValores(15)
        If objChip.SERVICIO = "0" Then objChip.SERVICIO = "15"
        objChip.CLIENTE = sValores(5)
        objChip.COLORPRISMA = sValores(4)
        objChip.SERVICIOCAPTURADO = sValores(7)
        objChip.HORAASESOR = sValores(8)
        objChip.VEHICULO = sValores(9)
        objChip.VIN = sValores(10)
        objChip.AÑO = sValores(11)
        objChip.COLOR = sValores(12)
        objChip.IDASESOR = sValores(13)
        objChip.TELEFONOS = sValores(14)
        objChip.NOPRISMA = sValores(17)

        objChip.CILINDROS = 0
        objChip.TIPOCLIENTE = sValores(18)
        objChip.IDBLINSUR = sValores(21)
        objChip.IDHD = sValores(22)
        objChip.IDMOTIVOPARO = sValores(23)
        objChip.CONCITA = False
        objChip.NUMCITA = 0
        objChip.CONTINUARA = True
        objChip.ENUSO = True
        objChip.VHRECEPCION = True
        objChip.VHINVENTARIO = True
        objChip.VHREPARANDO = False
        objChip.VHREPROGRAMADO = False
        objChip.VHSERVCANCELADO = False
        objChip.VHSERVERMINADO = False
        objChip.HORATOLERANCIA = objChip.HORAASESOR
        objChip.HORACITA = sHora
        objChip.IDTECNICO = TablerosUtilsHyP.ObtenIdTecnicosPR(objChip.TOPPX)

        objChip.HORAENTREGA = String.Format("{0:00}", CDate(objChip.HORACITA).AddMinutes(objChip.SERVICIO).Hour) & ":" & String.Format("{0:00}", CDate(objChip.HORACITA).AddMinutes(objChip.SERVICIO).Minute)
        objChip.HORARECEPCION = objChip.HORATOLERANCIA
        objChip.HORARAMPA = objChip.HORACITA
        objChip.NOMBREDIA = CDate(txtCalendar.Text).DayOfWeek
        objChip.FECHAAGENDADO = CDate(lblCalendar.Text)
        objChip.FECHAORIGINAL = CDate(txtCalendar.Text)
        objChip.FECHAENTREGA = objChip.FECHA
        objChip.STATUS = "Pendiente"
        objChip.STATUSOS = "ABIERTA"
        objChip.USUARIO = lblUsr.Text
        objChip.OCHIP = "dg" & objChip.SERVICIO & objChip.IDCHIP
        objChip.FECHA = dFecha
        objChip.OBSERVACIONES = ""



        If Validar(objChip, "G", CDate(sValores(19))) Then

            TablerosUtilsHyP.GuardarChip(objChip)
        End If






    End Sub


    Function Validar(ByVal obj As ChipHYP, ByVal iOperacion As String, s As DateTime) As Boolean

        If obj.IDCHIP = 0 Then
            sMensajes.Add("Este chip aun no ha sido recibido ")
            ' TablerosUtilsHyP.iMsgBox(Me.Page, "Este chip aun no ha sido recibido ")



            Return False
        End If

        Dim ileft As Integer = CInt(((24) / 3) * 9.437)


        Dim iwidthServ As Integer = 0
		Dim widthServ As Integer = 0

		Select Case iOperacion
            Case "G"

                If SCCParametros.ObtenParametros(Request.Url.Segments(Request.Url.Segments.Length - 1), "campoenlace") <> "" Then
                    If Not TablerosUtilsHyP.ValidarRecepcionSCVIN(obj.VIN.Trim) And obj.TIPOCLIENTE.Trim.ToLower <> "waste" And obj.IDMOTIVOPARO <> "4" Then

                        sMensajes.Add("El vehiculo con vin " & obj.VIN & " no ha sido recibido en recepcion")
                        'TablerosUtilsHyP.iMsgBox(Me.Page, "El vehiculo con vin " & obj.VIN & " no ha sido recibido en recepcion", ileft)

                        Return False
                    End If
                Else
                    If Not TablerosUtilsHyP.ValidarRecepcionSC(obj.NOPLACAS.Trim) And obj.TIPOCLIENTE.Trim.ToLower <> "waste" And obj.IDMOTIVOPARO <> "4" Then
                        sMensajes.Add("El vehiculo con placas " & obj.NOPLACAS & " no ha sido recibido en recepcion")
                        'TablerosUtilsHyP.iMsgBox(Me.Page, "El vehiculo con placas " & obj.NOPLACAS & " no ha sido recibido en recepcion", ileft)

                        Return False
                    End If
                End If


                Dim y

                y = (From p In CType(Session("ColChipsP"), CHIPHYPCollection) Where p.noplacas = obj.NOPLACAS And p.idtecnico <> obj.IDTECNICO And p.fecha.ToShortDateString() = obj.FECHA.ToShortDateString())

                For Each d In y
                    iwidthServ = (d.SERVICIO * 60) / 60
					widthServ = (obj.SERVICIO * 60) / 60
					Dim idtecnico1 As Integer
					Dim idtecnico2 As Integer
					idtecnico1 = obj.IDTECNICO
					idtecnico2 = d.idtecnico
					If idtecnico1 = idtecnico2 And TablerosUtilsHyP.ObtenPosXxHora(obj.HORARAMPA) >= TablerosUtilsHyP.ObtenPosXxHora(d.HORARAMPA) And TablerosUtilsHyP.ObtenPosXxHora(obj.HORARAMPA) < (TablerosUtilsHyP.ObtenPosXxHora(d.HORARAMPA) + iwidthServ) Then
						sMensajes.Add("El chip se encimaria con  la orden  " & d.NOORDEN)
						' TablerosUtilsHyP.iMsgBox(Me.Page, "El chip se encimaria con  la orden  " & iobj.NOORDEN)
						Return False

					ElseIf idtecnico1 = idtecnico2 And (TablerosUtilsHyP.ObtenPosXxHora(obj.HORARAMPA) + widthServ) > (TablerosUtilsHyP.ObtenPosXxHora(d.HORARAMPA)) And (TablerosUtilsHyP.ObtenPosXxHora(obj.HORARAMPA) + widthServ) <= (TablerosUtilsHyP.ObtenPosXxHora(d.HORARAMPA) + iwidthServ) Then
						sMensajes.Add("El chip se encimaria con  la orden " & d.NOORDEN)
						'  TablerosUtilsHyP.iMsgBox(Me.Page, "El chip se encimaria con  la orden " & iobj.NOORDEN)
						Return False
					ElseIf idtecnico1 = idtecnico2 And (TablerosUtilsHyP.ObtenPosXxHora(obj.HORARAMPA)) <= (TablerosUtilsHyP.ObtenPosXxHora(d.HORARAMPA)) And (TablerosUtilsHyP.ObtenPosXxHora(obj.HORARAMPA) + widthServ) >= (TablerosUtilsHyP.ObtenPosXxHora(d.HORARAMPA) + iwidthServ) Then
						sMensajes.Add("El chip se encimaria con  la orden " & d.NOORDEN)
                        '   TablerosUtilsHyP.iMsgBox(Me.Page, "El chip se encimaria con  la orden " & iobj.NOORDEN)
                        Return False
                    End If

                Next

                If obj.FECHA.AddTicks(TimeSpan.Parse(obj.HORARAMPA).Ticks) < s Then
                    sMensajes.Add("No se puede asignar antes de la hora programada")
                    'TablerosUtilsHyP.iMsgBox(Me.Page, "No se puede asignar antes de la hora programada", ileft)

                    Return False
                End If
                If obj.FECHA.AddTicks(TimeSpan.Parse(obj.HORARAMPA).Ticks) < Date.Now Then
                    sMensajes.Add("No se puede asignar antes de la hora actual")
                    'TablerosUtilsHyP.iMsgBox(Me.Page, "No se puede asignar antes de la hora programada", ileft)

                    Return False
                End If


                If SCC.SolPermisosBol(SCC.EObjetos.CHIPASESOR, SCC.EOperaciones.Grabar) = False Then
                    sMensajes.Add("No tiene permisos para  grabar esta operacion")
                    'TablerosUtilsHyP.iMsgBox(Me.Page, "No tiene permisos para  grabar esta operacion", ileft)
                    Return False
                End If

                If Session("cveAsesor").ToString.Trim.ToLower <> obj.IDASESOR.Trim.ToLower And SCCParametros.ObtenParametros(Request.Url.Segments(Request.Url.Segments.Length - 1), "iCandadoxAsesor") = "1" Then

                    If SCC.SolPermisosBol(SCC.EObjetos.CHIPASESOR, SCC.EOperaciones.SUsuario) = False Then
                        sMensajes.Add(" Solo " & obj.IDASESOR.Trim.ToLower & " tiene permisos para  grabar esta operacion")
                        'TablerosUtilsHyP.iMsgBox(Me.Page, "No tiene permisos para  grabar esta operacion", ileft)
                        Return False
                    End If


                End If

            Case "M"

                Dim y

                y = (From p In CType(Session("ColChipsP"), CHIPHYPCollection) Where p.noplacas = obj.NOPLACAS And p.idtecnico <> obj.IDTECNICO And p.fecha = obj.FECHA)

                For Each d In y
                    iwidthServ = (d.SERVICIO * 60) / 60
					widthServ = (obj.SERVICIO * 60) / 60
					Dim idtecnico1 As Integer
					Dim idtecnico2 As Integer
					idtecnico1 = obj.IDTECNICO
                    idtecnico2 = d.idtecnico

                    If idtecnico1 = idtecnico2 And TablerosUtilsHyP.ObtenPosXxHora(obj.HORARAMPA) >= TablerosUtilsHyP.ObtenPosXxHora(d.HORARAMPA) And TablerosUtilsHyP.ObtenPosXxHora(obj.HORARAMPA) < (TablerosUtilsHyP.ObtenPosXxHora(d.HORARAMPA) + iwidthServ) Then
						'sMensajes.Add("El chip se encimaria con  la orden  " & d.NOORDEN)
						muestraMensaje("El chip se encimaria con  la orden " & d.NOORDEN)
						' TablerosUtilsHyP.iMsgBox(Me.Page, "El chip se encimaria con  la orden  " & iobj.NOORDEN)
						Return False

					ElseIf idtecnico1 = idtecnico2 And (TablerosUtilsHyP.ObtenPosXxHora(obj.HORARAMPA) + widthServ) > (TablerosUtilsHyP.ObtenPosXxHora(d.HORARAMPA)) And (TablerosUtilsHyP.ObtenPosXxHora(obj.HORARAMPA) + widthServ) <= (TablerosUtilsHyP.ObtenPosXxHora(d.HORARAMPA) + iwidthServ) Then
						'sMensajes.Add("El chip se encimaria con  la orden " & d.NOORDEN)
						muestraMensaje("El chip se encimaria con  la orden " & d.NOORDEN)
						'  TablerosUtilsHyP.iMsgBox(Me.Page, "El chip se encimaria con  la orden " & iobj.NOORDEN)
						Return False
					ElseIf idtecnico1 = idtecnico2 And (TablerosUtilsHyP.ObtenPosXxHora(obj.HORARAMPA)) <= (TablerosUtilsHyP.ObtenPosXxHora(d.HORARAMPA)) And (TablerosUtilsHyP.ObtenPosXxHora(obj.HORARAMPA) + widthServ) >= (TablerosUtilsHyP.ObtenPosXxHora(d.HORARAMPA) + iwidthServ) Then
						'sMensajes.Add("El chip se encimaria con  la orden " & d.NOORDEN)
						'   TablerosUtilsHyP.iMsgBox(Me.Page, "El chip se encimaria con  la orden " & iobj.NOORDEN)
						muestraMensaje("El chip se encimaria con  la orden " & d.NOORDEN)
						Return False
                    End If

                Next
				If obj.EXPRESS Then
					sMensajes.Add("No se puede mover un chip express")
					'    TablerosUtilsHyP.iMsgBox(Me.Page, "No se puede mover una operacion terminada", ileft)
					Return False
				End If
				If obj.FECHA.AddTicks(TimeSpan.Parse(obj.HORARAMPA).Ticks) < Date.Now Then
					sMensajes.Add("No se puede asignar antes de la hora actual")
					'TablerosUtilsHyP.iMsgBox(Me.Page, "No se puede asignar antes de la hora programada", ileft)

					Return False
				End If

				If obj.STATUS = "Terminado" Then
                    sMensajes.Add("No se puede mover una operacion terminada")
                    '     TablerosUtilsHyP.iMsgBox(Me.Page, "No se puede mover una operacion terminada", ileft)
                    Return False
                End If

                If obj.STATUS = "Iniciada" Or obj.STATUS = "Reiniciada" Then
                    sMensajes.Add("No se puede mover una operacion Iniciada")
                    ' TablerosUtilsHyP.iMsgBox(Me.Page, "No se puede mover una operacion Iniciada", ileft)
                    Return False
                End If
                If obj.STATUS = "Detenida" Then
                    sMensajes.Add("No se puede mover una operacion Detenida")
                    '   TablerosUtilsHyP.iMsgBox(Me.Page, "No se puede mover una operacion Detenida", ileft)
                    Return False
                End If

                'If obj.USUARIO.Trim.ToLower <> HttpContext.Current.Session("Usuario").ToString().Trim.ToLower And SCCParametros.ObtenParametros(Request.Url.Segments(Request.Url.Segments.Length - 1), "iCandadoxUsuario") = "1" Then
                '    If SCC.SolPermisosBol(SCC.EObjetos.CHIPASESOR, SCC.EOperaciones.SUsuario) = False Then
                '        sMensajes.Add("Solo el usuario " & obj.USUARIO.Trim.ToLower & " tiene permisos sobre esta tarea")
                '        ' TablerosUtilsHyP.iMsgBox(Me.Page, "Solo el usuario " & obj.USUARIO.Trim.ToLower & " tiene permisos sobre esta tarea", ileft)
                '        Return False
                '    End If

                'End If
                'If obj.FECHA < s Then

                '    TablerosUtilsHyP.iMsgBox(Me.Page, "No se puede asignar antes de la hora programada", ileft)

                '    Return False
                'End If
                If SCC.SolPermisosBol(SCC.EObjetos.CHIPASESOR, SCC.EOperaciones.Mover) = False Then
                    sMensajes.Add("No tiene permisos para  mover esta operacion")
                    ' TablerosUtilsHyP.iMsgBox(Me.Page, "No tiene permisos para  mover esta operacion", ileft)
                    Return False
                End If
                If Session("cveAsesor").ToString.Trim.ToLower <> obj.IDASESOR.Trim.ToLower And SCCParametros.ObtenParametros(Request.Url.Segments(Request.Url.Segments.Length - 1), "iCandadoxAsesor") = "1" Then
                    If SCC.SolPermisosBol(SCC.EObjetos.CHIPASESOR, SCC.EOperaciones.SUsuario) = False Then
                        sMensajes.Add(" Solo " & obj.IDASESOR.Trim.ToLower & " tiene permisos para  mover esta operacion")
                        'TablerosUtilsHyP.iMsgBox(Me.Page, "No tiene permisos para  grabar esta operacion", ileft)
                        Return False
                    End If

                End If
            Case "B"
                If obj.STATUS = "Terminado" Then
                    sMensajes.Add("No se puede borrar una operacion terminada")
                    'TablerosUtilsHyP.iMsgBox(Me.Page, "No se puede borrar una operacion terminada", ileft)
                    Return False
                End If

                If obj.STATUS = "Iniciada" Or obj.STATUS = "Reiniciada" Then
                    sMensajes.Add("No se puede borrar una operacion Iniciada")
                    ' TablerosUtilsHyP.iMsgBox(Me.Page, "No se puede borrar una operacion Iniciada", ileft)
                    Return False
                End If
                'If obj.USUARIO.Trim.ToLower <> HttpContext.Current.Session("Usuario").ToString().Trim.ToLower And SCCParametros.ObtenParametros(Request.Url.Segments(Request.Url.Segments.Length - 1), "iCandadoxUsuario") = "1" Then
                '    If SCC.SolPermisosBol(SCC.EObjetos.CHIPASESOR, SCC.EOperaciones.SUsuario) = False Then
                '        sMensajes.Add("Solo el usuario " & obj.USUARIO.Trim.ToLower & " tiene permisos sobre esta tarea")
                '        'TablerosUtilsHyP.iMsgBox(Me.Page, "Solo el usuario " & obj.USUARIO.Trim.ToLower & " tiene permisos sobre esta tarea", ileft)
                '        Return False
                '    End If

                'End If

                If SCC.SolPermisosBol(SCC.EObjetos.CHIPASESOR, SCC.EOperaciones.Borrar) = False Then
                    sMensajes.Add("No tiene permisos para  borrar esta operacion")
                    'TablerosUtilsHyP.iMsgBox(Me.Page, "No tiene permisos para  borrar esta operacion", ileft)
                    Return False
                End If

                If Session("cveAsesor").ToString.Trim.ToLower <> obj.IDASESOR.Trim.ToLower And SCCParametros.ObtenParametros(Request.Url.Segments(Request.Url.Segments.Length - 1), "iCandadoxAsesor") = "1" Then
                    If SCC.SolPermisosBol(SCC.EObjetos.CHIPASESOR, SCC.EOperaciones.SUsuario) = False Then
                        sMensajes.Add(" Solo " & obj.IDASESOR.Trim.ToLower & " tiene permisos para  borrar esta operacion")
                        'TablerosUtilsHyP.iMsgBox(Me.Page, "No tiene permisos para  grabar esta operacion", ileft)
                        Return False
                    End If

                End If

            Case "T"
				If obj.EXPRESS Then
					sMensajes.Add("No se puede modificar un chip express")
					'    TablerosUtilsHyP.iMsgBox(Me.Page, "No se puede mover una operacion terminada", ileft)
					Return False
				End If
				If If(IsNumeric(SCCParametros.ObtenParametros(Request.Url.Segments(Request.Url.Segments.Length - 1), "RestriccionTiempo")), CInt(SCCParametros.ObtenParametros(Request.Url.Segments(Request.Url.Segments.Length - 1), "RestriccionTiempo")), 0) < CInt(obj.SERVICIO) And SCCParametros.ObtenParametros2(Request.Url.Segments(Request.Url.Segments.Length - 1), "RestriccionTiempo").ToString() = Session("UsuarioPerfil").ToString() And obj.NUMCITA = 0 Then
                    sMensajes.Add("No puede establecer esta operacion con un tiempo superior a " & SCCParametros.ObtenParametros(Request.Url.Segments(Request.Url.Segments.Length - 1), "RestriccionTiempo") & " minutos")
                    '   TablerosUtilsHyP.iMsgBox(Me.Page, "No puede establecer esta operacion con un tiempo superior a " & SCCParametros.ObtenParametros(Request.Url.Segments(Request.Url.Segments.Length - 1), "RestriccionTiempo") & " minutos", ileft)
                    Return False
                End If
                If obj.STATUS = "Terminado" Then
                    sMensajes.Add("No se puede modificar una operacion terminada")
                    ' TablerosUtilsHyP.iMsgBox(Me.Page, "No se puede modificar una operacion terminada", ileft)
                    Return False
                End If

                If obj.STATUS = "Iniciada" Or obj.STATUS = "Reiniciada" Then
                    sMensajes.Add("No se puede modificar una operacion Iniciada")
                    ' TablerosUtilsHyP.iMsgBox(Me.Page, "No se puede modificar una operacion Iniciada", ileft)
                    Return False
                End If

                If obj.USUARIO.Trim.ToLower <> HttpContext.Current.Session("Usuario").ToString().Trim.ToLower And SCCParametros.ObtenParametros(Request.Url.Segments(Request.Url.Segments.Length - 1), "iCandadoxUsuario") = "1" Then
                    sMensajes.Add("Solo el usuario " & obj.USUARIO.Trim.ToLower & " tiene permisos sobre esta tarea")
                    ' TablerosUtilsHyP.iMsgBox(Me.Page, "Solo el usuario " & obj.USUARIO.Trim.ToLower & " tiene permisos sobre esta tarea", ileft)
                    Return False
                End If
                If SCC.SolPermisosBol(SCC.EObjetos.CHIPASESOR, SCC.EOperaciones.Modificar) = False Then
                    sMensajes.Add("No tiene permisos para modificar esta operacion")
                    ' TablerosUtilsHyP.iMsgBox(Me.Page, "No tiene permisos para modificar esta operacion", ileft)
                    Return False
                End If
                If Session("cveAsesor").ToString.Trim.ToLower <> obj.IDASESOR.Trim.ToLower And SCCParametros.ObtenParametros(Request.Url.Segments(Request.Url.Segments.Length - 1), "iCandadoxAsesor") = "1" Then
                    If SCC.SolPermisosBol(SCC.EObjetos.CHIPASESOR, SCC.EOperaciones.SUsuario) = False Then
                        sMensajes.Add(" Solo " & obj.IDASESOR.Trim.ToLower & " tiene permisos para  modificar esta operacion")
                        'TablerosUtilsHyP.iMsgBox(Me.Page, "No tiene permisos para  grabar esta operacion", ileft)
                        Return False
                    End If

                End If
        End Select
        ' Try
        'If Session("cveAsesor").ToString.Trim.Length > 0 And obj.FECHA > DateAdd(DateInterval.Day, CInt(SCCParametros.ObtenParametros(Request.Url.Segments(Request.Url.Segments.Length - 1), "iNumDiasProgAs")), CDate(Date.Now.ToShortDateString)) Then
        '    sMensajes.Add("No puede programar/modificar trabajos posteriores a " & CInt(SCCParametros.ObtenParametros(Request.Url.Segments(Request.Url.Segments.Length - 1), "iNumDiasProgAs")) & " dias de hoy")
        '    'TablerosUtilsHyP.iMsgBox(Me.Page, "No puede programar/modificar trabajos posteriores a " & CInt(SCCParametros.ObtenParametros(Request.Url.Segments(Request.Url.Segments.Length - 1), "iNumDiasProgAs")) & " dias de hoy", ileft)
        '    Return False
        'End If

        ' Catch ex As Exception

        ' End Try


        If iOperacion = "B" Then Return True



        Dim OBJCOL As New CHIPHYPCollection
        OBJCOL = Session("ColChipsP")



        Dim dt As New DataTable
        dt = HttpContext.Current.Session("dtPosDias")
        Dim dFecha As DateTime
        Dim sHora As String
        Dim itfecha As Date


        sHora = String.Format("{0:HH:mm}", CDate(String.Format("{00:d}", iHorai) & ":00").AddMinutes((((Decimal.Round(CDec((Val(obj.LEFTPX) - 92) / ifac), 2) - Fix(CDec((Val(obj.LEFTPX) - 92) / ifac))) / (ifac / inumHoras)) * ifac) * 60))
        itfecha = dt.Select("posLeft<=" & obj.LEFTPX & " and posLeft + " & ifac & ">" & obj.LEFTPX & "")(0).Item("dia")
        dFecha = CDate(itfecha.ToShortDateString & " " & sHora)


        For Each iobj As ChipHYP In OBJCOL
            If iobj.ID <> obj.ID And TablerosUtilsHyP.ObtenIdTecnicosPR(obj.TOPPX).ToLower = iobj.IDTECNICO.ToLower And dFecha.DayOfWeek = iobj.FECHA.DayOfWeek And iobj.STATUS = "Pendiente" Then
                iwidthServ = (iobj.SERVICIO * 60) / 60
                widthServ = (obj.SERVICIO * 60) / 60
                If TablerosUtilsHyP.ObtenPosXxHora(obj.HORARAMPA) >= TablerosUtilsHyP.ObtenPosXxHora(iobj.HORARAMPA) And TablerosUtilsHyP.ObtenPosXxHora(obj.HORARAMPA) < (TablerosUtilsHyP.ObtenPosXxHora(iobj.HORARAMPA) + iwidthServ) Then
                    sMensajes.Add("El chip se encimaria con  la orden  " & iobj.NOORDEN)
                    ' TablerosUtilsHyP.iMsgBox(Me.Page, "El chip se encimaria con  la orden  " & iobj.NOORDEN)
                    Return False

                ElseIf (TablerosUtilsHyP.ObtenPosXxHora(obj.HORARAMPA) + widthServ) > (TablerosUtilsHyP.ObtenPosXxHora(iobj.HORARAMPA)) And (TablerosUtilsHyP.ObtenPosXxHora(obj.HORARAMPA) + widthServ) <= (TablerosUtilsHyP.ObtenPosXxHora(iobj.HORARAMPA) + iwidthServ) Then
                    sMensajes.Add("El chip se encimaria con  la orden " & iobj.NOORDEN)
                    '  TablerosUtilsHyP.iMsgBox(Me.Page, "El chip se encimaria con  la orden " & iobj.NOORDEN)
                    Return False
                ElseIf (TablerosUtilsHyP.ObtenPosXxHora(obj.HORARAMPA)) <= (TablerosUtilsHyP.ObtenPosXxHora(iobj.HORARAMPA)) And (TablerosUtilsHyP.ObtenPosXxHora(obj.HORARAMPA) + widthServ) >= (TablerosUtilsHyP.ObtenPosXxHora(iobj.HORARAMPA) + iwidthServ) Then
                    sMensajes.Add("El chip se encimaria con  la orden " & iobj.NOORDEN)
                    '   TablerosUtilsHyP.iMsgBox(Me.Page, "El chip se encimaria con  la orden " & iobj.NOORDEN)
                    Return False
                End If
            End If

        Next









        Return True
    End Function

    Function Validar(ByVal obj As ChipHYP) As Boolean

        Dim ileft As Integer = CInt(((24) / 3) * 9.437)




        If Not Len(obj.NOORDEN) > 0 Then

            TablerosUtilsHyP.iMsgBox(Me.Page, "Debe capturar el no de orden", ileft)


            Return False
        End If

        If obj.NOORDEN = "0" Then

            TablerosUtilsHyP.iMsgBox(Me.Page, "El numero de orden debe ser distinto a 0", ileft)


            Return False
        End If



        Return True
    End Function


    Sub _borrarchip(sdhtml As String, im As Integer)
        Dim iId As Int64
        ' Dim sdhtml As String = CType(Me.form1.FindControl("dhtml"), HtmlInputText).Value
        If Split(sdhtml, ".").Length < 2 Then Exit Sub
        If Left(sdhtml, 5) = "ds00." Then Exit Sub
        'For Each d In Me.FindControl(Split(sdhtml, ".")(0)).Controls
        '    If Left(d.id, 5) = "ctlll" Then
        '        iId = d.Value
        '    End If
        'Next

        iId = obtenid(Split(sdhtml, ".")(0))
        If iId = 0 Then Exit Sub


        Dim OBJCOL As New CHIPHYPCollection
        OBJCOL = Session("ColChipsP")

        For Each obj As ChipHYP In OBJCOL
            If obj.ID = iId Then
                If Validar(obj, "B", CDate(lblCalendar.Text)) Then
                    TablerosUtilsHyP.BorrarChipPRG(obj)
                End If

                Exit For
            End If

        Next




    End Sub
    Protected Sub imgBtnDel_DMS_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imgBtnDel_DMS.Click
        Dim schip As String = "", stexto As String = ""
        Dim ileft As Integer = CInt(((24) / 3) * 9.437)
        sMensajes = New ArrayList
        If iMulti.Value.Split(",").Length < 2 Then
            schip = CType(Me.form1.FindControl("dhtml"), HtmlInputText).Value
            _borrarchip(schip, 0)
        Else
            For i As Integer = 0 To Me.iMulti.Value.Split(",").Length() - 1

                schip = iMulti.Value.Split(",")(i)
                _borrarchip(schip, Me.iMulti.Value.Split(",").Length())
            Next

        End If
        For Each s As String In sMensajes
            stexto += s & "</br>"
        Next
        If stexto.Length > 0 Then TablerosUtilsHyP.iMsgBox(Me, stexto, ileft)

        iMulti.Value = ""


        bref = True
        If Session("clkMenuid") Is Nothing Then
            menuItem2(0, True)
        Else
            menuItem2(Session("clkMenuid"), True)
        End If



    End Sub
    Function obtenInfo(s As String) As String
        Dim OBJARRAY As ArrayList = CType(Session("imgLstInfo"), ArrayList)

        Dim va_Enumerator As System.Collections.IEnumerator = OBJARRAY.GetEnumerator()

        While va_Enumerator.MoveNext()
            If Split(va_Enumerator.Current, "--")(0) = s Then
                Return Split(va_Enumerator.Current, "--")(1)
            End If


        End While

        Return 0
    End Function


    Protected Sub imgBtnUpd_DMS2_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imgBtnUpd_DMS2.Click

        Dim objChip As New ChipHYP, objChip2 As New ChipHYP

        Dim sdhtml As String = CType(Me.form1.FindControl("dhtml"), HtmlInputText).Value
        If Split(sdhtml, ".").Length < 2 Then Exit Sub
        If Left(sdhtml, 7) <> "txtMec_" Then Exit Sub

        Dim sValores() As String = Split(obtenInfo("lblInfo" & Split(sdhtml, ".")(0)), "___")


        'Dim sValores() As String = Split(CType(Me.FindControl("lblInfo" & Split(sdhtml, ".")(0)), HtmlGenericControl).InnerText, "___")

        Dim OBJCOL As New CHIPHYPCollection
        OBJCOL = Session("ColChips")

        objChip.OCHIPWIDTH = CInt(Split(sdhtml, ".")(3))
        objChip.LEFTPX = CInt(Split(sdhtml, ".")(1))
        objChip.TOPPX = CInt(Split(sdhtml, ".")(2))
        objChip.IDCHIP = TablerosUtilsHyP.MaxChip


        '  AgregaInfo(


        Dim dFecha As DateTime, sHora As String, sselect As String
        Dim dt As New DataTable, itfecha As Date
        dt = HttpContext.Current.Session("dtPosDias")

        sHora = String.Format("{0:HH:mm}", CDate(String.Format("{00:d}", iHorai) & ":00").AddMinutes((((Decimal.Round(CDec((Val(objChip.LEFTPX) - 92) / ifac), 2) - Fix(CDec((Val(objChip.LEFTPX) - 92) / ifac))) / (ifac / inumHoras)) * ifac) * 60))
        sselect = "posLeft<=" & objChip.LEFTPX & " and (posLeft + " & CInt(ifac) & ")>" & objChip.LEFTPX & ""
        itfecha = dt.Select(sselect)(0).Item("dia")
        dFecha = CDate(itfecha.ToShortDateString & " " & sHora)


        objChip.IDITEM = sValores(16)
        objChip.NOORDEN = sValores(1)
        objChip.ASYSRENGLON = sValores(6)
        objChip.NOPLACAS = sValores(2)
        objChip.IDSERVICIO = sValores(3)
        objChip.SERVICIO = sValores(15)

        objChip.CLIENTE = sValores(5)
        objChip.COLORPRISMA = sValores(4)
        objChip.SERVICIOCAPTURADO = sValores(7)
        objChip.HORAASESOR = sValores(8)
        objChip.VEHICULO = sValores(9)
        objChip.VIN = sValores(10)
        objChip.AÑO = sValores(11)
        objChip.COLOR = sValores(12)
        objChip.IDASESOR = sValores(13)
        objChip.TELEFONOS = sValores(14)
        objChip.NOPRISMA = sValores(17)

        objChip.TIPOCLIENTE = sValores(18)
        objChip.IDBLINSUR = sValores(21)
        objChip.IDHD = sValores(22)




        'If Validar(objChip, "G", CDate(sValores(19))) Then

        '    TablerosUtilsHyP.GuardarChip(objChip)
        'End If

        Dim sqry As String = "update tb_citas_detenidos set status_cita='" & cboStop.SelectedItem.Text & "', id_motivo_paro='" & cboStop.SelectedItem.Value & "' where "
        sqry += " id_hd=" & objChip.IDHD & " and serviciocapturado='" & objChip.SERVICIOCAPTURADO & "'"
        BDClass.ExecuteQuery(sqry, False)

        sqry = "update tb_citas set id_motivo_paro='" & cboStop.SelectedItem.Value & "', status=status where "
        sqry += "id_hd=" & objChip.IDHD & " and serviciocapturado='" & objChip.SERVICIOCAPTURADO & "'"
        BDClass.ExecuteQuery(sqry, False)


        bref = True
        '   iniciaTablero(True, txtBuscar.Text)
        If Session("clkMenuid") Is Nothing Then
            menuItem2(0, True)
        Else
            menuItem2(Session("clkMenuid"), True)
        End If


    End Sub

    Private Sub whuxgaPT_PreInit(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.PreInit
        If Not Page.IsPostBack Then
            TablerosUtilsHyP.Salir()
        End If
    End Sub

    Protected Sub imgFind_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imgFind.Click



        Exit Sub


    End Sub

    Private Sub MPGV_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles MPGV.PreRender
        Session("DATEHYP") = CDate(lblCalendar.Text).ToShortDateString
    End Sub

    Protected Sub imgBuscar_Click(sender As Object, e As ImageClickEventArgs) Handles imgBuscar.Click


        iniciaTablero0(True, txtBuscar.Text, If(Menu1.SelectedItem Is Nothing, 0, Menu1.SelectedItem.Value))
    End Sub



    Sub menuItem2(iopcion As Integer, mtecnicos As Boolean, Optional imotivoparo As Integer = 0)

        Dim sbusqueda As String = If(txtBuscar.Text <> "", txtBuscar.Text, (If(cboOrdenes.SelectedIndex >= 0, cboOrdenes.Items(cboOrdenes.SelectedIndex).Text, "")))

        Dim iTipo As Integer = iopcion
        '0=ordenes, 1=detenido, 2=captura,3=retrabajo,4=waste, 5=salir

        If iTipo = 5 Then
            TablerosUtilsHyP.Salir()
            Response.Redirect("Inicio.aspx")
        End If




        RadioButtonList1.Visible = False

        If iopcion = 0 Then

            gvDMS.Visible = False
            iniciaTablero0(mtecnicos, sbusqueda, iTipo)

        ElseIf iopcion = 2 Then

            iniciaTablero0(mtecnicos, sbusqueda, iTipo)
            refreshDMS()

        ElseIf iopcion = 1 Then
            RadioButtonList1.Visible = True
            gvDMS.Visible = False

            iniciaTablero0(mtecnicos, sbusqueda, iTipo, imotivoparo)


        ElseIf iopcion = 3 Then
            gvDMS.Visible = False

            iniciaTablero0(mtecnicos, sbusqueda, iTipo)

        ElseIf iopcion = 4 Then
            gvDMS.Visible = False

            iniciaTablero0(mtecnicos, sbusqueda, iTipo)


        End If
    End Sub

    Sub iniciaTablero0(ByVal bTecnicos As Boolean, sorden As String, iTipo As Integer, Optional imotivoparo As Integer = 0)
        LimpiaForm()
        Dim dtTemp As DataTable

        bref = False
        Dim sScript As String = ""
        Dim iNumbahias As Integer ' = dt.Rows.Count
        Dim ilargo As Integer = 0
        Dim iwidth As Integer = "7500"
        Dim dt As DataView = TablerosUtilsHyP.ObtenTecnicos.DefaultView
        Dim OBJCOL As New CHIPHYPCollection, objchip As ChipHYP

        Dim iNivel As Integer = 0
        Dim txtMec As HtmlGenericControl
        Dim imgLstInfo As New ArrayList()
        Session("imgLstInfo") = imgLstInfo
        '0=ordenes, 1=detenido, 2=captura,3=retrabajo,4=waste, 5=salir
        Select Case iTipo
            Case 0
                If HttpContext.Current.Session("Usuario").ToString.ToLower <> "admin" And SCCParametros.ObtenParametros(Request.Url.Segments(Request.Url.Segments.Length - 1), "FiltroAsesor") = "1" Then

                    If sorden <> "" Then
                        OBJCOL = OBJCOL.ObtenChipsAll(sorden, rdlBuscar.SelectedIndex, HttpContext.Current.Session("cveAsesor"))
                    Else
                        OBJCOL = OBJCOL.ObtenChipsAll("", 0, HttpContext.Current.Session("cveAsesor"))
                    End If

                Else
                    If sorden <> "" Then
                        OBJCOL = OBJCOL.ObtenChipsAll(sorden, rdlBuscar.SelectedIndex)
                    Else
                        OBJCOL = OBJCOL.ObtenChipsAll("", 0)
                    End If
                End If
                If Not Page.IsPostBack Then
                    LlenaComboOrdenes("")
                ElseIf txtBuscar.Text.Trim <> "" Then
                    LlenaComboOrdenes(txtBuscar.Text.Trim)
                ElseIf cboOrdenes.SelectedIndex > -1 Then
                    LlenaComboOrdenes(cboOrdenes.Items(cboOrdenes.SelectedIndex).Text)
                End If


            Case 1
                If sorden <> "" Then
                    OBJCOL = OBJCOL.ObtenChipsAllDet(sorden, rdlBuscar.SelectedIndex, imotivoparo)
                Else
                    OBJCOL = OBJCOL.ObtenChipsAllDet("", 0, imotivoparo)
                End If
                If Not Page.IsPostBack Then
                    LlenaComboOrdenesDetenidos("", imotivoparo)
                ElseIf txtBuscar.Text.Trim <> "" Then
                    LlenaComboOrdenesDetenidos(txtBuscar.Text.Trim, imotivoparo)
                ElseIf cboOrdenes.SelectedIndex > -1 Then
                    LlenaComboOrdenesDetenidos(cboOrdenes.Items(cboOrdenes.SelectedIndex).Text, imotivoparo)
                Else
                    LlenaComboOrdenesDetenidos("", imotivoparo)
                End If
            Case 2

            Case 3
                If sorden <> "" Then
                    OBJCOL = OBJCOL.ObtenChipsAllRetrabajos(sorden, rdlBuscar.SelectedIndex)
                Else
                    OBJCOL = OBJCOL.ObtenChipsAllRetrabajos("", 0)

                End If
                If Not Page.IsPostBack Then
                    LlenaComboOrdenesRepprocesos("")
                ElseIf txtBuscar.Text.Trim <> "" Then
                    LlenaComboOrdenesRepprocesos(txtBuscar.Text.Trim)
                ElseIf cboOrdenes.SelectedIndex > -1 Then
                    LlenaComboOrdenesRepprocesos(cboOrdenes.Items(cboOrdenes.SelectedIndex).Text)
                End If


            Case 4
                OBJCOL = OBJCOL.ObtenChipsAllWS()

        End Select




        iNumbahias = dt.Count
        Session("ColChips") = OBJCOL


        'iwidth = 75.5 * (Date.DaysInMonth(Now.Year, Now.Month) + Date.DaysInMonth(Now.AddMonths(1).Year, Now.AddMonths(1).Month))
        ' iwidth = (475.5 * (3 - CDATES.iDomingos)) 'sundays
        iwidth = ifac * (inumDias)
        floatdiv.Style.Remove("width")
        floatdiv.Style.Add("width", iwidth + 190 & "px")
        topfix0.Style.Remove("width")
        topfix0.Style.Add("width", iwidth + 190 & "px")
        If iTablero <> 1 Then
            iNumbahias = iNumbahias '* 2
        End If
        ilargo = ((iNumbahias) * 60) + 92

        If bTecnicos Then




            sScript += "<script type='text/javascript'>" & vbCrLf
            sScript += "var jg_doc = new jsGraphics();" & vbCrLf

            sScript += "var hours = " & Date.Now.Hour & ";" & vbCrLf
            sScript += "var minutes = " & Date.Now.Minute & ";" & vbCrLf
            sScript += "var ifac = 0.05*94;" & vbCrLf
            sScript += "if(hours<" & iHorai & "||hours>" & iHorai + inumHoras - 1 & "){"
            sScript += "hours=0;minutes=0; "
            sScript += "} else {hours=hours-" & iHorai & ";}" & vbCrLf
            sScript += "jg_doc.setColor('" & SCCParametros.ObtenParametros(Request.Url.Segments(Request.Url.Segments.Length - 1), "bTiempo") & "');" & vbCrLf
            sScript += "lx = ((hours * 60) + minutes);(lx *(59.437/2));lx=lx+ifac;" & vbCrLf
            sScript += "if (lx > ifac) {" & vbCrLf
            sScript += "lx =  ((hours * 60) + minutes) - ifac; ;" & vbCrLf
            sScript += "" & vbCrLf
            sScript += "lx = parseInt(lx);" & vbCrLf
            sScript += "jg_doc.fillRect(92, 94, lx, " & ilargo - 92 & ");}" & vbCrLf


            ''
            sScript += " var ejeX=206; var ejeY=94; " & vbCrLf
            If iTablero <> 1 Then
                sScript += " for(var d_i = 1; d_i <= " & iNumbahias & "; d_i++){ " & vbCrLf
            Else
                sScript += " for(var d_i = 1; d_i <= " & iNumbahias * 6 & "; d_i++){ " & vbCrLf

            End If


            sScript += "    ejeY += 60; " & vbCrLf
            sScript += "    if (d_i == " & iNumbahias & " || d_i == " & iNumbahias * 2 & "  || d_i == " & iNumbahias * 3 & "  || d_i == " & iNumbahias * 4 & " || d_i == " & iNumbahias * 5 & "){" & vbCrLf
            sScript += "        jg_doc.setColor('Black');   jg_doc.fillRect(0, ejeY, " & iwidth + 92 & ", 2);} " & vbCrLf
            sScript += "    else{jg_doc.setColor('Darkslategray');jg_doc.drawLine(0, ejeY, " & iwidth + 92 & ", ejeY);} " & vbCrLf

            sScript += "    jg_doc.setColor('#EEEEE0');jg_doc.fillRect(0, ejeY-30, " & iwidth + 92 & ", 30); " & vbCrLf
            'sScript += "    jg_doc.setColor('#E0FFFF');jg_doc.fillRect(0, ejeY-60, " & iwidth + 92 & ", 30); " & vbCrLf

            sScript += " }" & vbCrLf


            '


            sScript += "jg_doc.setColor('Lightcoral');" & vbCrLf
            sScript += "jg_doc.drawLine(92, 0, 92, " & ilargo & "); " & vbCrLf
            sScript += "jg_doc.setColor('Black');" & vbCrLf
            sScript += "jg_doc.fillRect(" & iwidth + 92 & ", 0, 3, " & ilargo & ");" & vbCrLf
            sScript += " jg_doc.setColor('Black'); " & vbCrLf


            sScript += "jg_doc.fillRect(0, " & ilargo & ", " & iwidth + 92 & ", 3);" & vbCrLf

            'Silver para pintar 5 minutos
            sScript += "jg_doc.setColor('Silver'); " & vbCrLf
            sScript += "var posX = 92,posX2=92,posX3=92;" & vbCrLf
            sScript += "for(var d_i = 1; d_i <= " & System.Math.Round(iwidth / ifac) & "; d_i++){" & vbCrLf
            sScript += "            for(var d_j = 1; d_j < " & inumHoras + 1 & "; d_j++){" & vbCrLf

            ' sScript += "                jg_doc.setColor('red'); jg_doc.drawLine(posX2+(59.437/2), 92, posX2+(59.437/2), " & ilargo & ");" & vbCrLf

            sScript += "jg_doc.setStroke(1); for(var d_d = 1; d_d < 13; d_d++){ posX3=posX3+4.95;" & vbCrLf
            sScript += " jg_doc.setColor('" & SCCParametros.ObtenParametros(Request.Url.Segments(Request.Url.Segments.Length - 1), "bTableroGrid") & "'); jg_doc.drawLine(posX3, 92, posX3, " & ilargo & ");" & vbCrLf
            sScript += "               }" & vbCrLf

            sScript += "                jg_doc.setColor('" & SCCParametros.ObtenParametros2(Request.Url.Segments(Request.Url.Segments.Length - 1), "bTableroGrid") & "'); jg_doc.setStroke(2); jg_doc.drawLine(posX2, 92, posX2, " & ilargo & ");" & vbCrLf
            sScript += "                jg_doc.setColor(' " & SCCParametros.ObtenParametros(Request.Url.Segments(Request.Url.Segments.Length - 1), "bTableroGrid2") & "'); jg_doc.drawLine(posX2+(60/2), 92, posX2+(60/2), " & ilargo & ");" & vbCrLf



            sScript += "                posX2=posX2+59.437;}" & vbCrLf
            sScript += "        jg_doc.setColor('Navy'); jg_doc.drawLine(posX, 92, posX, " & ilargo & "); " & vbCrLf

            'sScript += "        jg_doc.setColor('Silver'); jg_doc.drawLine(posX+37.75, 92, posX+37.75, " & ilargo & "); " & vbCrLf
            sScript += "     posX = posX+" & ifac & ";}" & vbCrLf




            sScript += " " & vbCrLf


            sScript += " //SET_DHTML('ds00'); " & vbCrLf
            sScript += " " & vbCrLf
            sScript += "" & vbCrLf


            sScript += "</script>" & vbCrLf
            Page.ClientScript.RegisterClientScriptBlock(Page.GetType, "TabGraph", sScript)


            ''  Exit Sub

            Dim ddate As Date = Now.Date.AddDays(-inumLeft)
            ddate = CDate(lblCalendar.Text).AddDays(-inumLeft)
            Dim txtDia2 As HtmlGenericControl
            Dim txtDia3 As HtmlGenericControl
            Dim dtPosDias As New DataTable, ktop As Integer = 0
            dtPosDias.Columns.Add("dia", New Date().GetType)
            dtPosDias.Columns.Add("posleft", New Integer().GetType)
            dtPosDias.Rows.Clear()


            For i = 1 To inumDias

                txtDia3 = New HtmlGenericControl("div")
                txtDia2 = New HtmlGenericControl("div")
                txtDia2.ID = "txtDia" & ddate.AddDays(i - inumLeft).DayOfYear

                txtDia2.Style.Value = "border:none;position:absolute;left:" & 92 + ((ifac) * (i - 1)) & "px;top:50px;width:" & ifac & "px;height:40px;background-color:White;Font-weight:bold;font-family:  Lucida Grande,Lucida Sans,Arial,sans-serif;font-size:15px;text-align:center;"

                txtDia2.InnerText = ddate.AddDays(i - 1).ToShortDateString

                dtPosDias.Rows.Add(New Object() {CDate(txtDia2.InnerText), 92 + ((ifac) * (i - 1))})
                txtDia3.Style.Value = "width:" & ifac & "px;height:10px;background-color:White;Font-weight:bold;font-family:Arial;font-size:12px;text-align:center;"
                txtDia3.InnerHtml = "<table border='0' cellspacing=0 cellpadding=0 ><tr>"
                For ii = 0 To inumHoras - 1
                    txtDia3.InnerHtml = txtDia3.InnerHtml & "<td  style='border:solid 1px black; width:" & Math.Round(ifac / inumHoras, MidpointRounding.ToEven) & "px;background-color:White;' >" & String.Format("{00:d}", ii + iHorai) & ":00</td>"

                Next
                txtDia3.InnerHtml = txtDia3.InnerHtml & "</tr></table>"
                txtDia2.Controls.Add(txtDia3)
                If form1.FindControl(txtDia2.ID) Is Nothing Then
                    floatdiv.Controls.Add(txtDia2)
                End If


            Next
            Session("dtPosDias") = dtPosDias
        End If



        Dim imgLst As New ArrayList(), sColor As String
        Dim xleft As Integer = -100, III As Integer = 20
        imgLst.Clear()


        Dim imgLstPosMec As New DataTable
        imgLstPosMec.Columns.Add("ID")
        imgLstPosMec.Columns.Add("noorden")
        imgLstPosMec.Columns.Add("idservicio")
        imgLstPosMec.Columns.Add("noplacas")
        imgLstPosMec.Columns.Add("cliente")
        imgLstPosMec.Columns.Add("idcontrol")
        imgLstPosMec.Columns.Add("toppx")
        imgLstPosMec.Rows.Clear()

        leftfix0.Controls.Clear()
        For i = 1 To OBJCOL.Count


            txtMec = New HtmlGenericControl("div")
            txtMec.ID = "txtMec_" & i




            objchip = OBJCOL.Item(i - 1)

            xleft = xleft + 110
            If (i / III) - Fix(i / III) = 0 Then
                xleft = 220
            End If


            If SCCParametros.ObtenParametros(Request.Url.Segments(Request.Url.Segments.Length - 1), "colorcaptura").ToString = "1" Then
                sColor = TablerosUtilsHyP.ObtenColorIdSErvicio(objchip.IDSERVICIO)
            Else
                sColor = "#fff"
            End If



            If iTipo = 1 Then
                txtMec.Style.Value = "position:absolute;top:" & ((Fix((i - 1) / III)) * 32) + 75 & "px;left:" & xleft + 5 & "px;width:100px; background-color:" & SCCParametros.ObtenParametros(Request.Url.Segments(Request.Url.Segments.Length - 1), "dw" & objchip.IDMOTIVOPARO) & ";Font-weight:bold;font-family:  Lucida Grande,Lucida Sans,Arial,sans-serif;font-size:12px;border:solid 1px black;"
                txtMec.InnerText = objchip.NOPLACAS & " Orden:" & objchip.NOORDEN & vbCrLf & "Unidad: " & objchip.VEHICULO & vbCrLf & "Detenida: " & objchip.STATUSOS & vbCrLf & "Tecnico: " & TablerosUtilsHyP.ObtenNombreTecnicos(objchip.IDTECNICO) & vbCrLf & "Duracion: " & objchip.SERVICIO & vbCrLf & "Descripcion:" & objchip.SERVICIOCAPTURADO.Trim()
                '  txtMec.ToolTip = "Tipo: " & objchip.TIPOCLIENTE & vbCrLf & "Servicio: " & objchip.SERVICIOCAPTURADO & vbCrLf & "Comentarios: " & objchip.OBSERVACIONES & ""
                txtMec.Attributes.Add("class", "menu3")

            ElseIf iTipo = 3 Then

                txtMec.Style.Value = "position:absolute;top:" & ((Fix((i - 1) / III)) * 32) + 75 & "px;left:" & xleft + 5 & "px;width:100px; background-color:" & SCCParametros.ObtenParametros(Request.Url.Segments(Request.Url.Segments.Length - 1), "dwr") & ";Font-weight:bold;font-family:  Lucida Grande,Lucida Sans,Arial,sans-serif;font-size:12px;border:solid 1px black;"
                txtMec.InnerText = objchip.NOPLACAS & " Orden:" & objchip.NOORDEN & vbCrLf & "Unidad: " & objchip.VEHICULO & vbCrLf & "Detenida: " & objchip.STATUSOS & vbCrLf & "Tecnico: " & TablerosUtilsHyP.ObtenNombreTecnicos(objchip.IDTECNICO) & vbCrLf & "Duracion: " & objchip.SERVICIO & vbCrLf & "Descripcion:" & objchip.SERVICIOCAPTURADO.Trim()
                '  txtMec.ToolTip = "Tipo: " & objchip.TIPOCLIENTE & vbCrLf & "Servicio: " & objchip.SERVICIOCAPTURADO & vbCrLf & "Comentarios: " & objchip.OBSERVACIONES & ""
                txtMec.Attributes.Add("class", "menu3")


            ElseIf iTipo = 4 Then

                txtMec.Style.Value = "position:absolute;top:" & ((Fix((i - 1) / III)) * 32) + 75 & "px;left:" & xleft + 5 & "px;width:100px; background-color:" & SCCParametros.ObtenParametros(Request.Url.Segments(Request.Url.Segments.Length - 1), "dgw" & objchip.IDMOTIVOPARO) & ";Font-weight:bold;font-family:  Lucida Grande,Lucida Sans,Arial,sans-serif;font-size:12px;border:solid 1px black;"
                txtMec.InnerText = objchip.TIPOCLIENTE & " ID:" & objchip.IDSERVICIO & vbCrLf & "Duracion: " & objchip.SERVICIO & vbCrLf & vbCrLf & "Descripcion:" & objchip.SERVICIOCAPTURADO.Trim()
                '  txtMec.ToolTip = "Tipo: " & objchip.TIPOCLIENTE & vbCrLf & "Servicio: " & objchip.SERVICIOCAPTURADO & vbCrLf
                txtMec.Attributes.Add("class", "menu2")

            Else
                If objchip.TIPOCLIENTE.ToLower() = "express" Then
                    txtMec.Style.Value = "position:absolute;top:" & ((Fix((i - 1) / III)) * 32) + 75 & "px;left:" & xleft + 5 & "px;width:100px; background-color:gold;Font-weight:bold;font-family:  Lucida Grande,Lucida Sans,Arial,sans-serif;font-size:12px;border:solid 1px black;"
                    txtMec.InnerText = objchip.NOPLACAS & " Orden:" & objchip.NOORDEN & vbCrLf & "Unidad: " & objchip.VEHICULO & vbCrLf & "FechaOrden: " & objchip.FECHA.ToShortDateString() & vbCrLf & "Color: " & objchip.COLOR & vbCrLf & "Duracion: " & objchip.SERVICIO & vbCrLf & "Asesor:" & TablerosUtilsHyP.ObtenNombreAsesor(objchip.IDASESOR) & vbCrLf & "Descripcion:" & objchip.SERVICIOCAPTURADO.Trim()
                    '   txtMec.ToolTip = "Tipo: " & objchip.TIPOCLIENTE & vbCrLf & "Servicio: " & objchip.SERVICIOCAPTURADO & vbCrLf & "Comentarios: " & objchip.OBSERVACIONES & ""
                    txtMec.Attributes.Add("class", "menu2")
                Else
                    txtMec.Style.Value = "position:absolute;top:" & ((Fix((i - 1) / III)) * 32) + 75 & "px;left:" & xleft + 5 & "px;width:100px; background-color:" & sColor & ";Font-weight:bold;font-family:  Lucida Grande,Lucida Sans,Arial,sans-serif;font-size:12px;border:solid 1px black;"
                    txtMec.InnerText = objchip.NOPLACAS & " Orden:" & objchip.NOORDEN & vbCrLf & "Unidad: " & objchip.VEHICULO & vbCrLf & "FechaOrden: " & objchip.FECHA.ToShortDateString() & vbCrLf & "Color: " & objchip.COLOR & vbCrLf & "Duracion: " & objchip.SERVICIO & vbCrLf & "Asesor:" & TablerosUtilsHyP.ObtenNombreAsesor(objchip.IDASESOR) & vbCrLf & "Descripcion:" & objchip.SERVICIOCAPTURADO.Trim()
                    '   txtMec.ToolTip = "Tipo: " & objchip.TIPOCLIENTE & vbCrLf & "Servicio: " & objchip.SERVICIOCAPTURADO & vbCrLf & "Comentarios: " & objchip.OBSERVACIONES & ""
                    txtMec.Attributes.Add("class", "menu2")

                End If


            End If



            'dtTemp = TablerosUtilsHyP.ObtenServiciosxNoorden(objchip.NOORDEN)
            'If dtTemp.Rows.Count > 0 Then
            '    '  txtMec.ToolTip += vbCrLf & "Tareas:" & vbCrLf
            '    For ii As Integer = 0 To dtTemp.Rows.Count - 1
            '        '    txtMec.ToolTip += "- " & dtTemp.Rows(ii).Item(0).ToString & vbCrLf
            '    Next
            'End If


            leftfix0.Controls.Add(txtMec)
            imgLst.Add(txtMec.ID)

            imgLstPosMec.Rows.Add(New Object() {objchip.ID, objchip.NOORDEN, objchip.IDSERVICIO, objchip.NOPLACAS, objchip.CLIENTE, txtMec.ID, 95 + ((50) * (i - 1))})
            AgregaInfo(txtMec.ID, objchip.ID & "___" & objchip.NOORDEN & "___" & objchip.NOPLACAS & "___" & objchip.IDSERVICIO & "___" & objchip.COLORPRISMA & "___" & objchip.CLIENTE & "___" & objchip.ASYSRENGLON & "___" & objchip.SERVICIOCAPTURADO & "___" & objchip.HORAASESOR & "___" & objchip.VEHICULO & "___" & objchip.VIN & "___" & objchip.AÑO & "___" & objchip.COLOR & "___" & objchip.IDASESOR & "___" & objchip.TELEFONOS & "___" & objchip.SERVICIO & "___" & objchip.IDITEM & "___" & objchip.NOPRISMA & "___" & objchip.TIPOCLIENTE & "___" & objchip.FECHA & "___" & objchip.HORAASESOR & "___" & objchip.IDBLINSUR & "___" & objchip.IDHD & "___" & objchip.IDMOTIVOPARO)

        Next




        Session("imgLst") = imgLst
        Session("imgLstPosMec") = imgLstPosMec


        iniciaTablero2()
        PINTACHIPS()
        Session.Remove("ObtenAusencias")
    End Sub

    Protected Sub Menu1_MenuItemClick(ByVal sender As Object, ByVal e As MenuEventArgs) Handles Menu1.MenuItemClick
        Session("clkMenuid") = Int32.Parse(e.Item.Value)
        Session("clkMenu") = Int32.Parse(e.Item.Value)
        menuItem2(Int32.Parse(e.Item.Value), True)

    End Sub
    Protected Sub RadioButtonList1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles RadioButtonList1.SelectedIndexChanged




        menuItem2(1, True, If(RadioButtonList1.SelectedItem Is Nothing, 0, RadioButtonList1.SelectedItem.Value))

    End Sub


    Private Sub cmdGuardarComen_Click(sender As Object, e As EventArgs) Handles cmdGuardarComen.Click
        Dim iId As Int64, iTiempo As Int32, iPosx As Int32, iPosY As Int32
        Dim sdhtml As String = CType(Me.form1.FindControl("dhtmlChp"), HtmlInputText).Value

        If Split(sdhtml, ".").Length < 2 Then Exit Sub
        iTiempo = CInt(Split(sdhtml, ".")(3))
        iTiempo = CInt((iTiempo) * (5 / 6.33))
        iPosx = CInt(Split(sdhtml, ".")(1))
        iPosY = CInt(Split(sdhtml, ".")(2))
        'For Each d In Me.FindControl(Split(sdhtml, ".")(0)).Controls
        '    If Left(d.id, 5) = "ctlll" Then
        '        iId = d.Value
        '    End If
        'Next
        iId = obtenid(Split(sdhtml, ".")(0))
        If iId = 0 Then Exit Sub

        'iId = CType(Me.FindControl(Split(sdhtml, ".")(0)).Controls(1), HtmlInputHidden).Value

        Dim OBJCOL As New CHIPHYPCollection
        OBJCOL = Session("ColChipsP")

        For Each obj As ChipHYP In OBJCOL
            If obj.ID = iId Then

                If txtComen.Text.Trim.Length > 0 Then
                    ChipHYPCom.GuardaComentario(obj, txtComen.Text.Trim)
                    txtComen.Text = ""
                End If
                Exit For
            End If

        Next

        bref = True
        iniciaTablero0(True, txtBuscar.Text, 0)

    End Sub
    Sub refreshDMS()

        gvDMS.Visible = True
        gvDMS.DataSource = TablerosUtilsHyP.Obten_CONTROL_DMS()
        gvDMS.DataBind()


    End Sub

    Private Sub gvDMS_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles gvDMS.PreRender
        Dim sqry As String, i As Integer
        Dim db As New BDClass
        Dim DT2 As New DataTable, dt As New DataTable


        If HttpContext.Current.Session("pretbservicios") Is Nothing Then
			sqry = "select idservicio, describeservicio, tiempoServicio, vehiculos from " & System.Web.Configuration.WebConfigurationManager.AppSettings("tbServicios") & " where idconcepto <>  'W' "

			HttpContext.Current.Session("pretbservicios") = BDClass.SQLtoDataTable(sqry, False)
        End If

        dt = HttpContext.Current.Session("pretbservicios")


        For i = 0 To gvDMS.Items.Count - 1
            dt.DefaultView.RowFilter = "vehiculos='" & gvDMS.Items(i).Cells(6).Text.Trim & "' or vehiculos='TODOS'"
            DT2 = dt.DefaultView.ToTable

            CType(gvDMS.Items(i).FindControl("txtCapOrden"), TextBox).Text = gvDMS.Items(i).Cells(1).Text
            CType(gvDMS.Items(i).FindControl("txtTorre"), TextBox).Text = gvDMS.Items(i).Cells(15).Text
            CType(gvDMS.Items(i).FindControl("cboCapServicio"), DropDownList).DataSource = DT2
            CType(gvDMS.Items(i).FindControl("cboCapServicio"), DropDownList).DataTextField = DT2.Columns(1).ColumnName
            CType(gvDMS.Items(i).FindControl("cboCapServicio"), DropDownList).DataValueField = DT2.Columns(0).ColumnName
            CType(gvDMS.Items(i).FindControl("cboCapServicio"), DropDownList).DataBind()
            CType(gvDMS.Items(i).FindControl("arr2T"), DropDownList).DataSource = DT2
            CType(gvDMS.Items(i).FindControl("arr2T"), DropDownList).DataTextField = DT2.Columns(2).ColumnName
            CType(gvDMS.Items(i).FindControl("arr2T"), DropDownList).DataValueField = DT2.Columns(0).ColumnName
            CType(gvDMS.Items(i).FindControl("arr2T"), DropDownList).DataBind()
            Try
                CType(gvDMS.Items(i).FindControl("cboCapServicio"), DropDownList).Items.FindByText(gvDMS.Items(i).Cells(8).Text).Selected = True
            Catch ex As Exception
                'CType(GridView4.Rows(i).FindControl("cboCapServicio"), dropdownlist).items.findbyvalue(request(CType(GridView4.Rows((Session("noRow"))).FindControl("cboCapServicio"), dropdownlist).uniqueid)).selected = True
            End Try

        Next
    End Sub
    Sub sel_Click1(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)

        Dim SelectedIndex As Integer = CType(sender.parent.parent, DataGridItem).ItemIndex
        gvDMS.SelectedIndex = SelectedIndex
        Dim objChip As New ChipHYP

        objChip.NOORDEN = obtenValor(CType(gvDMS.SelectedItem.FindControl("txtCapOrden"), TextBox).UniqueID) 'CType(gvDMS.SelectedItem.FindControl("txtCapOrden"), TextBox).Text
        objChip.ASYSRENGLON = gvDMS.SelectedItem.Cells(0).Text
        objChip.NOPLACAS = gvDMS.SelectedItem.Cells(5).Text
        objChip.CLIENTE = obtenValor(CType(gvDMS.SelectedItem.FindControl("txtCliente"), TextBox).UniqueID) 'CType(gvDMS.SelectedItem.FindControl("txtCliente"), TextBox).Text
        objChip.SERVICIO = obtenValor(CType(gvDMS.SelectedItem.FindControl("txtservicio"), TextBox).UniqueID) 'CType(gvDMS.SelectedItem.FindControl("txtservicio"), TextBox).Text
        objChip.SERVICIOCAPTURADO = TablerosUtilsHyP.ObtenServicios.Select("idServicio='" & obtenValor(CType(gvDMS.SelectedItem.FindControl("cboCapServicio"), DropDownList).UniqueID) & "'")(0).Item("Describeservicio")
        objChip.HORAASESOR = gvDMS.SelectedItem.Cells(3).Text
        objChip.VEHICULO = gvDMS.SelectedItem.Cells(6).Text
        objChip.IDSERVICIO = obtenValor(CType(gvDMS.SelectedItem.FindControl("cboCapServicio"), DropDownList).UniqueID)

        objChip.AÑO = Val(gvDMS.SelectedItem.Cells(11).Text)
        objChip.COLOR = gvDMS.SelectedItem.Cells(12).Text
        objChip.CILINDROS = gvDMS.SelectedItem.Cells(13).Text
        objChip.COLORPRISMA = obtenValor(CType(gvDMS.SelectedItem.FindControl("txtTorre"), TextBox).UniqueID) 'CType(gvDMS.SelectedItem.FindControl("txtTorre"), TextBox).Text
        objChip.IDASESOR = gvDMS.SelectedItem.Cells(14).Text
        objChip.IDHD = gvDMS.SelectedItem.Cells(16).Text

        objChip.TIPOCLIENTE = "Servicio"
        objChip.CONCITA = False
        objChip.NUMCITA = 0
        objChip.CONTINUARA = True
        objChip.ENUSO = True
        objChip.VHRECEPCION = True
        objChip.VHINVENTARIO = True
        objChip.VHREPARANDO = False
        objChip.VHREPROGRAMADO = False
        objChip.VHSERVCANCELADO = False
        objChip.VHSERVERMINADO = False
        objChip.HORATOLERANCIA = objChip.HORAASESOR

        objChip.HORACITA = objChip.HORAASESOR
        objChip.HORAENTREGA = String.Format("{0:00}", CDate(objChip.HORACITA).AddMinutes(objChip.SERVICIO).Hour) & ":" & String.Format("{0:00}", CDate(objChip.HORACITA).AddMinutes(objChip.SERVICIO).Minute)
        objChip.HORARECEPCION = objChip.HORATOLERANCIA
        objChip.HORARAMPA = objChip.HORACITA
        objChip.NOMBREDIA = CDate(txtCalendar.Text).DayOfWeek
        objChip.FECHAAGENDADO = CDate(lblCalendar.Text)
        objChip.FECHAORIGINAL = CDate(txtCalendar.Text)
        objChip.STATUS = "Pendiente"
        objChip.STATUSOS = "ABIERTA"
        objChip.USUARIO = lblUsr.Text
        objChip.OCHIP = "dg" & objChip.SERVICIO & objChip.IDCHIP
        objChip.FECHA = CDate(txtCalendar.Text)
        objChip.CONTACTOTELEFONO = ""
        objChip.CONTACTONOMBRE = ""
        objChip.TELEFONOS = ""
        objChip.OBSERVACIONES = ""

        If Validar(objChip) Then

            TablerosUtilsHyP.GuardarChipCaptura(objChip)
        End If
        '  iniciaTablero(True, txtBuscar.Text)
        menuItem2(2, True)
    End Sub
    Private Function obtenValor(ByVal ItemRequest As String) As String
        For Each nRequest As String In Request.Form
            If nRequest.LastIndexOf(ItemRequest.Trim) > -1 Then
                Return Request.Form(nRequest).Trim
            End If
        Next
        Return ""
    End Function
    Sub NuevaOK(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
        Select Case CType(sender.parent.parent.parent.parent, DataGrid).ID

            Case gvDMS.ID
                Me.pgvDms = True
                gvDMS.SelectedIndex = CType(sender.parent.parent, DataGridItem).ItemIndex
                gvDMS.Focus()
        End Select

    End Sub


    Function obtenid(s As String) As Int64
        Dim OBJARRAY As ArrayList = CType(Session("imgLst2"), ArrayList)

        Dim va_Enumerator As System.Collections.IEnumerator = OBJARRAY.GetEnumerator()

        While va_Enumerator.MoveNext()
            If Split(va_Enumerator.Current, "__")(0) = s Then
                Return Int64.Parse(Split(va_Enumerator.Current, "__")(1))
            End If


        End While

        Return 0
    End Function
    Private Sub imgBtnDgn_Kdw_Click(sender As Object, e As ImageClickEventArgs) Handles imgBtnDgn_Kdw.Click
        Dim iId As Int64
        Dim sdhtml As String = CType(Me.form1.FindControl("dhtml"), HtmlInputText).Value
        If Split(sdhtml, ".").Length < 2 Then Exit Sub
        If Left(sdhtml, 5) = "ds00." Then Exit Sub

        'For Each d In Me.FindControl(Split(sdhtml, ".")(0)).Controls
        '    If Left(d.id, 5) = "ctlll" Then
        '        iId = d.Value
        '    End If
        'Next

        iId = obtenid(Split(sdhtml, ".")(0))
        If iId = 0 Then Exit Sub

        Dim OBJCOL As New CHIPHYPCollection
        OBJCOL = Session("ColChipsP")

        For Each obj As ChipHYP In OBJCOL
            If obj.ID = iId Then
                Session("NF") = obj.ID

                Exit For
            End If

        Next

        Dim scriptString As String = "<script language='JavaScript'>" _
                                           & " window.open('Diagnostico.aspx', '', 'fullscreen=yes, scrollbars=auto');</script>"

        Page.ClientScript.RegisterStartupScript(GetType(Page), "ShowValue", scriptString)

        bref = True
        iniciaTablero0(True, txtBuscar.Text, 0)
    End Sub
    Private Sub imgBtnWrk_Kdw_Click(sender As Object, e As ImageClickEventArgs) Handles imgBtnWrk_Kdw.Click
        Dim iId As Int64
        Dim sdhtml As String = CType(Me.form1.FindControl("dhtml"), HtmlInputText).Value
        If Split(sdhtml, ".").Length < 2 Then Exit Sub
        If Left(sdhtml, 5) = "ds00." Then Exit Sub

        'For Each d In Me.FindControl(Split(sdhtml, ".")(0)).Controls
        '    If Left(d.id, 5) = "ctlll" Then
        '        iId = d.Value
        '    End If
        'Next

        iId = obtenid(Split(sdhtml, ".")(0))
        If iId = 0 Then Exit Sub

        Dim OBJCOL As New CHIPHYPCollection
        OBJCOL = Session("ColChipsP")

        For Each obj As ChipHYP In OBJCOL
            If obj.ID = iId Then
                Session("OS") = obj.NOORDEN

                Exit For
            End If

        Next
        Try

            Dim scriptString As String = "<script language='JavaScript'>" _
                                               & " window.open('OrdenTecnico.aspx', 'windowWrk', 'scrollbars=yes, toolbar=yes, top=0, left=0, width=1265, height=613, resize=no');</script>"

            Page.ClientScript.RegisterStartupScript(GetType(Page), "ShowWork", scriptString)

        Catch eexc As Exception
            Session("Error") = eexc.Message
        End Try

        bref = True
        iniciaTablero0(True, txtBuscar.Text, 0)
    End Sub
    Sub LlenaAsesores()
        Dim dt As New DataTable
        Dim sqry As String = ""

        If HttpContext.Current.Session("cveasesores") Is Nothing Then
            sqry = "Select nombre,color from SccUsuarios  WHERE isnull(cveasesor,'')<>'' "
            dt = BDClass.SQLtoDataTable(sqry, False)

            HttpContext.Current.Session("cveasesores") = dt
        End If

        dt = CType(Session("cveasesores"), DataTable)

        DataList2.DataSource = dt

        DataList2.DataBind()

    End Sub

    Private Sub DataList2_PreRender(sender As Object, e As EventArgs) Handles DataList2.PreRender
        For i = 0 To DataList2.Items.Count - 1
            Try
                CType(DataList2.Items(i).Controls(1), Label).Style.Value = "color:" & CType(DataList2.Items(i).Controls(1), Label).Text & ";background-color:" & CType(DataList2.Items(i).Controls(1), Label).Text & ";"

            Catch ex As Exception

            End Try
        Next
    End Sub

    Protected Sub cboOrdenes_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboOrdenes.SelectedIndexChanged
        Dim s As String
        s = cboOrdenes.Items(sender.SelectedIndex).Text


        If Menu1.SelectedValue.ToString = "1" Then
            iniciaTablero0(True, s, 1)
            LlenaComboOrdenesDetenidos(s, If(RadioButtonList1.SelectedItem Is Nothing, 0, RadioButtonList1.SelectedItem.Value))
        Else
            iniciaTablero0(True, s, 0)
            LlenaComboOrdenes(s)
        End If



    End Sub

    Private Sub imgRefrescar_Click(sender As Object, e As ImageClickEventArgs) Handles imgRefrescar.Click
        iniciaTablero0(True, txtBuscar.Text, 0)
    End Sub
    Sub ZedGraphWeb1_RenderGraph(ByVal webObject As ZedGraph.Web.ZedGraphWeb, ByVal g As System.Drawing.Graphics, ByVal pane As ZedGraph.MasterPane)


        Dim myPane As ZedGraph.GraphPane = pane(0)
        myPane.XAxis.Title.Text = "X-Axis"
        myPane.YAxis.Title.Text = "Y-Axis"
        Dim dthlhorarios As DataTable = Session("dthlphorarios")

        Dim iIndex As Integer = CType(webObject.Parent.Parent.Parent, DataGridItem).ItemIndex

        'If Not IsNumeric(CType(dgEstrategias.Items(iIndex).FindControl("lblContactados"), System.Web.UI.WebControls.Label).Text) Then Exit Sub
        'If Not IsNumeric(CTypse(dgEstrategias.Items(iIndex).FindControl("lblTotal"), System.Web.UI.WebControls.Label).Text) Then Exit Sub

        Dim x6() As Double = {0}
        dthlhorarios.DefaultView.RowFilter = "idTecnico='" & dgIndicadores.Items(iIndex).Cells(0).Text & "'"
        If dthlhorarios.DefaultView.Count > 0 Then
            x6 = New Double() {DateDiff(DateInterval.Minute, CType(dthlhorarios.DefaultView(0)("horaEnt"), Date), CType(dthlhorarios.DefaultView(0)("horaSal"), Date))}
        End If


        Dim x3() As Double = {CInt(dgIndicadores.Items(iIndex).Cells(1).Text)}
        Dim x4() As Double = {CInt(dgIndicadores.Items(iIndex).Cells(2).Text)}
        Dim x5() As Double = {CInt(dgIndicadores.Items(iIndex).Cells(3).Text)}


        CType(dgIndicadores.Items(iIndex).FindControl("lblPercentage"), System.Web.UI.WebControls.Label).Text = "nadita"
        'Dim x4() As Double = {CInt(CType(dgEstrategias.Items(iIndex).FindControl("lblTotal"), System.Web.UI.WebControls.Label).Text) - CInt(CType(dgEstrategias.Items(iIndex).FindControl("lblContactados"), System.Web.UI.WebControls.Label).Text)}

        Dim labels() As String = {TablerosUtilsHyP.ObtenNombreTecnicos(dgIndicadores.Items(iIndex).Cells(0).Text)}

        Dim myCurve As ZedGraph.BarItem
        myCurve = myPane.AddBar("Con Cita", x3, Nothing, Color.CadetBlue)
        myCurve.Label.IsVisible = True
        myCurve.Label.Text = "prueba"
        myCurve.Bar.Fill.RangeMax = x6(0)

        myCurve.Bar.Fill = New ZedGraph.Fill(Color.Olive, Color.DarkGreen, Color.Olive, 0.0F)
        myCurve = myPane.AddBar("Sin Cita", x4, Nothing, Color.Maroon)
        myCurve.Bar.Fill.RangeMax = x6(0)
        myCurve.Bar.Fill = New ZedGraph.Fill(Color.DarkBlue, Color.DarkBlue, Color.SkyBlue, 0.0F)
        'myCurve = myPane.AddBar("terminado", x5, Nothing, Color.Maroon)
        'myCurve.Bar.Fill.RangeMax = x6(0)
        'myCurve.Bar.Fill = New ZedGraph.Fill(Color.GreenYellow, Color.YellowGreen, Color.GreenYellow, 0.0F)
        myCurve = myPane.AddBar("lleno", New Double() {x6(0) - x3(0) + x4(0)}, Nothing, Color.Snow)
        myCurve.Bar.Fill.RangeMax = x6(0)
        myCurve.Bar.Fill = New ZedGraph.Fill(Color.Snow, Color.Snow, Color.Snow, 0.0F)


        CType(dgIndicadores.Items(iIndex).FindControl("lblPercentage"), System.Web.UI.WebControls.Label).Text = CInt(x3(0) / x6(0) * 100) & "%"
        CType(dgIndicadores.Items(iIndex).FindControl("lblPercentage2"), System.Web.UI.WebControls.Label).Text = CInt(x4(0) / x6(0) * 100) & "%"
        CType(dgIndicadores.Items(iIndex).FindControl("lblPercentage3"), System.Web.UI.WebControls.Label).Text = CInt((x6(0) - x4(0) - x3(0)) / x6(0) * 100) & "%"


        'myPane.Legend.Fill = New ZedGraph.Fill(Color.White, Color.FromArgb(255, 255, 250), 1200.0F)
        'myPane.Legend.IsVisible = True

        myPane.BarSettings.Base = ZedGraph.BarBase.Y
        myPane.YAxis.Scale.TextLabels = labels


        myPane.YAxis.Type = ZedGraph.AxisType.Text

        myPane.XAxis.MajorTic.IsBetweenLabels = True
        Dim myText As ZedGraph.TextObj = New ZedGraph.TextObj("Interesting / nPoint", 230.0F, 70.0F)
        myText.FontSpec.FontColor = Color.Red
        myText.Location.AlignH = ZedGraph.AlignH.Center
        myText.Location.AlignV = ZedGraph.AlignV.Top
        myPane.GraphObjList.Add(myText)



        myPane.Chart.Fill = New ZedGraph.Fill(Color.Gray, Color.Snow, 45.0F)

        myPane.BarSettings.Type = ZedGraph.BarType.Stack
        ' myCurve.CreateBarLabels(myPane, False, 45.0F)
        pane.AxisChange(g)

    End Sub
    Sub llenaindicadores()
        Dim objCHIPCol As New CHIPHYPCollection, dr As DataRow
        Dim dtIndicadores As New DataTable

        dtIndicadores.Columns.Add("id")
        dtIndicadores.Columns.Add("ocupadoc")
        dtIndicadores.Columns.Add("ocupados")
        dtIndicadores.Columns.Add("total")
        dtIndicadores.Columns.Add("dia")
        Dim y, x, w, z
        Dim i As Integer = 0

        objCHIPCol = Session("ColChipsP")

        If objCHIPCol Is Nothing Then Exit Sub

        Dim iFecha As Date = CDate(txtCalendar.Text)
        Dim iFechaIni As New Date(CDate(iFecha).AddDays(-CInt(iFecha.DayOfWeek) + 1).Year, CDate(iFecha).AddDays(-CInt(iFecha.DayOfWeek) + 1).Month, CDate(iFecha).AddDays(-CInt(iFecha.DayOfWeek) + 1).Day)
        Dim iFechaFin As New Date(CDate(iFecha).AddDays(inumDias - CInt(iFecha.DayOfWeek)).Year, CDate(iFecha).AddDays(inumDias - CInt(iFecha.DayOfWeek)).Month, CDate(iFecha).AddDays(inumDias - CInt(iFecha.DayOfWeek)).Day)

        Do While iFechaIni <= iFechaFin
            i = i + 1
            y = (From p As ChipHYP In objCHIPCol Where p.FECHA.ToShortDateString = iFechaIni.ToShortDateString Select p.IDTECNICO).Distinct()

            For Each c In y
                x = (From p As ChipHYP In objCHIPCol Where p.FECHA.ToShortDateString = iFechaIni.ToShortDateString And p.IDTECNICO = c.ToString() And p.NUMCITA <> 0 Group p By p.IDTECNICO Into Group Select total = Group.Sum(Function(p) (p.SERVICIO))).FirstOrDefault()
                w = (From p As ChipHYP In objCHIPCol Where p.FECHA.ToShortDateString = iFechaIni.ToShortDateString And p.IDTECNICO = c.ToString() And p.NUMCITA = 0 Group p By p.IDTECNICO Into Group Select total = Group.Sum(Function(p) (p.SERVICIO))).FirstOrDefault()
                z = (From p As ChipHYP In objCHIPCol Where p.FECHA.ToShortDateString = iFechaIni.ToShortDateString And p.IDTECNICO = c.ToString() Group p By p.IDTECNICO Into Group Select total = Group.Sum(Function(p) (p.SERVICIO))).FirstOrDefault()

                dr = dtIndicadores.NewRow
                dr.ItemArray = New Object() {c, IIf(x Is Nothing, 0, x), IIf(x Is Nothing, 0, w), z, CInt(iFechaIni.DayOfWeek)}
                dtIndicadores.Rows.Add(dr)
            Next

            iFechaIni = iFechaIni.AddDays(1)
        Loop
        dgIndicadores.DataSource = dtIndicadores
        dgIndicadores.DataBind()

    End Sub
    Private Sub dgIndicadores_PreRender(sender As Object, e As EventArgs) Handles dgIndicadores.PreRender
        Dim dthlhorarios As DataTable = Session("dthlphorarios")
        Dim i As Integer
        Dim sfilter As String = ""
        For i = 0 To dgIndicadores.Items.Count - 1
            sfilter = "idTecnico='" & dgIndicadores.Items(i).Cells(0).Text & "' and dia='" & dgIndicadores.Items(i).Cells(4).Text & "'"

            dthlhorarios.DefaultView.RowFilter = sfilter
            If dthlhorarios.DefaultView.Count > 0 Then
                CType(dgIndicadores.Items(i).FindControl("divzed"), HtmlGenericControl).Style.Value = "position:absolute;left:" & dthlhorarios.DefaultView(0)("posx") & ";top:" & dthlhorarios.DefaultView(0)("posy") & ";"

            End If
        Next

    End Sub
    Protected Sub btnOK_Click(sender As Object, e As EventArgs)
        Dim m As String
        Dim sdhtml As String = CType(Me.form1.FindControl("dhtml"), HtmlInputText).Value
        If (txtMinutos.Text.Length < 1) Then
            m = "debe escribir un tamaño para el chip."
            muestraMensaje(m)
        Else
            Dim id As Integer = obtenid(Split(sdhtml, ".")(0))
            m = "update tb_citas set servicio = '" & txtMinutos.Text.Trim & "' where id = '" & id & "'"
            BDClass.ExecuteQuery(m, False)
        End If

        txtMinutos.Text = ""
        iniciaTablero0(True, txtBuscar.Text, 0)
    End Sub
    Protected Sub muestraMensaje(m As String)
        Response.Write("<script>window.alert('" & m & "');</script>")
    End Sub
End Class
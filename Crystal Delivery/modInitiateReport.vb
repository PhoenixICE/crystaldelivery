Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared


Module modInitiateReport

    Public Function fncReportSource() As CrystalDecisions.CrystalReports.Engine.ReportDocument
        Try
            Dim strExportDirectory(0) As String
            Dim crxSubReport As New ReportDocument()
            Dim crxSubReportObject As CrystalDecisions.CrystalReports.Engine.SubreportObject
            Dim intIndex As Integer = 0
            'Dim intTableIndex As Integer
            Dim txtDataID As String
            Dim txtDataValue1 As String
            Dim txtDataValue2 As String
            Dim txtDataValue3 As String
            Dim txtDataValue4 As String
            'Dim ReportSettingsInfo As String = App_Path() & "ScheduledReports\" & glbActiveID & "CDF"
            'Dim intSubTableIndex As Integer
            'Dim intSubTableCounter As Integer
            Dim ConInfo As New CrystalDecisions.Shared.TableLogOnInfo
            Dim crxReport As New ReportDocument()
            Dim crSections As Sections
            Dim crSection As Section
            Dim crReportObjects As ReportObjects
            Dim crReportObject As ReportObject
            Dim intParIndex As Integer
            Dim currValue As CrystalDecisions.Shared.ParameterValues
            Dim paraValue As New CrystalDecisions.Shared.ParameterDiscreteValue
            Dim rangValue As New CrystalDecisions.Shared.ParameterRangeValue
            Dim oCRDb As CrystalDecisions.CrystalReports.Engine.Database '= crxReport.Database
            Dim oCRTables As CrystalDecisions.CrystalReports.Engine.Tables '= oCRDb.Tables
            Dim oCRTable As CrystalDecisions.CrystalReports.Engine.Table
            Dim oCRTableLogonInfo As CrystalDecisions.Shared.TableLogOnInfo
            Dim oCRConnectionInfo As New CrystalDecisions.Shared.ConnectionInfo()

            strSourceReportName = ""
            strExportDirectory(0) = ""
            intIndex = 0
            txtDataValue1 = ""
            txtDataValue2 = ""
            txtDataValue3 = ""
            txtDataValue4 = ""
            fncReportSource = Nothing


            If FileExists(ReportSettingsInfo) = True Then
                decryptfile(ReportSettingsInfo)

                Dim objReaderSource As New System.IO.StreamReader(ReportSettingsInfo)
                Dim objReader As New System.IO.StreamReader(ReportSettingsInfo)

                Do
                    If objReaderSource.ReadLine() = "SOURCEREPORT" Then
                        strSourceReportName = objReaderSource.ReadLine()
                    End If
                Loop Until objReaderSource.EndOfStream
                objReaderSource.Close()

                crxReport.Load(strSourceReportName)
                crSections = crxReport.ReportDefinition.Sections
                'MsgBox(crxReport.RecordSelectionFormula)
                'crxReport.datadefinition.ParameterFields.Item(0).CurrentValues.Clear()


                Do
                    txtDataID = fncFindDynamicValue(objReader.ReadLine)
                    Select Case txtDataID
                        Case "DISCRETE"
                            txtDataValue1 = fncFindDynamicValue(objReader.ReadLine)
                            txtDataValue2 = fncFindDynamicValue(objReader.ReadLine)
                            txtDataValue1 = fncFindDynamicText(txtDataValue1, False, ReportSettingsInfo)
                            txtDataValue2 = fncFindDynamicText(txtDataValue2, False, ReportSettingsInfo)

                            For intParIndex = 0 To crxReport.DataDefinition.ParameterFields.Count - 1
                                If crxReport.DataDefinition.ParameterFields.Item(intParIndex).Name = txtDataValue1 And txtDataValue2 <> "" Then
                                    'If crxReport.DataDefinition.ParameterFields.Item(intParIndex).ReportName = "" Then
                                    Select Case crxReport.DataDefinition.ParameterFields.Item(intParIndex).ParameterValueKind
                                        Case ParameterValueKind.BooleanParameter
                                            crxReport.SetParameterValue(txtDataValue1, txtDataValue2)
                                            currValue = crxReport.DataDefinition.ParameterFields.Item(txtDataValue1).CurrentValues
                                            paraValue.Value = CBool(txtDataValue2)
                                            currValue.Add(paraValue)
                                            crxReport.DataDefinition.ParameterFields.Item(txtDataValue1).ApplyCurrentValues(currValue)
                                        Case ParameterValueKind.CurrencyParameter
                                            currValue = crxReport.DataDefinition.ParameterFields.Item(txtDataValue1).CurrentValues
                                            paraValue.Value = CDec(txtDataValue2)
                                            currValue.Add(paraValue)
                                            crxReport.DataDefinition.ParameterFields.Item(txtDataValue1).ApplyCurrentValues(currValue)
                                        Case ParameterValueKind.DateParameter
                                            crxReport.DataDefinition.ParameterFields.Item(intParIndex).CurrentValues.AddValue(CDate(txtDataValue2))
                                            currValue = crxReport.DataDefinition.ParameterFields.Item(txtDataValue1).CurrentValues
                                            paraValue.Value = CDate(txtDataValue2)
                                            currValue.Add(paraValue)
                                            crxReport.DataDefinition.ParameterFields.Item(txtDataValue1).ApplyCurrentValues(currValue)
                                        Case ParameterValueKind.DateTimeParameter
                                            currValue = crxReport.DataDefinition.ParameterFields.Item(txtDataValue1).CurrentValues
                                            paraValue.Value = CDate(txtDataValue2)
                                            currValue.Add(paraValue)
                                            crxReport.DataDefinition.ParameterFields.Item(txtDataValue1).ApplyCurrentValues(currValue)
                                        Case ParameterValueKind.NumberParameter
                                            currValue = crxReport.DataDefinition.ParameterFields.Item(txtDataValue1).CurrentValues
                                            paraValue.Value = CDbl(txtDataValue2)
                                            currValue.Add(paraValue)
                                            crxReport.DataDefinition.ParameterFields.Item(txtDataValue1).ApplyCurrentValues(currValue)
                                        Case ParameterValueKind.StringParameter
                                            currValue = crxReport.DataDefinition.ParameterFields.Item(txtDataValue1).CurrentValues
                                            paraValue.Value = CStr(txtDataValue2)
                                            currValue.Add(paraValue)
                                            crxReport.DataDefinition.ParameterFields.Item(txtDataValue1).ApplyCurrentValues(currValue)
                                        Case ParameterValueKind.TimeParameter
                                            currValue = crxReport.DataDefinition.ParameterFields.Item(txtDataValue1).CurrentValues
                                            paraValue.Value = CDate(txtDataValue2)
                                            currValue.Add(paraValue)
                                            crxReport.DataDefinition.ParameterFields.Item(txtDataValue1).ApplyCurrentValues(currValue)
                                    End Select
                                    'End If
                                End If
                            Next intParIndex

                            For Each crSection In crSections
                                crReportObjects = crSection.ReportObjects
                                For Each crReportObject In crReportObjects
                                    If crReportObject.Kind = ReportObjectKind.SubreportObject Then
                                        crxSubReportObject = CType(crReportObject, SubreportObject)
                                        crxSubReport = crxSubReportObject.OpenSubreport(crxSubReportObject.SubreportName)

                                        For intParIndex = 0 To crxSubReport.DataDefinition.ParameterFields.Count - 1
                                            If crxSubReport.DataDefinition.ParameterFields.Item(intParIndex).Name = txtDataValue1 And txtDataValue2 <> "" Then
                                                'If crxSubReport.DataDefinition.ParameterFields.Item(intParIndex).ReportName <> "" Then
                                                Select Case crxSubReport.DataDefinition.ParameterFields.Item(intParIndex).ParameterValueKind
                                                    Case ParameterValueKind.BooleanParameter
                                                        crxSubReport.SetParameterValue(txtDataValue1, txtDataValue2)
                                                        currValue = crxSubReport.DataDefinition.ParameterFields.Item(txtDataValue1).CurrentValues
                                                        paraValue.Value = CBool(txtDataValue2)
                                                        currValue.Add(paraValue)
                                                        crxSubReport.DataDefinition.ParameterFields.Item(txtDataValue1).ApplyCurrentValues(currValue)
                                                    Case ParameterValueKind.CurrencyParameter
                                                        currValue = crxSubReport.DataDefinition.ParameterFields.Item(txtDataValue1).CurrentValues
                                                        paraValue.Value = CDec(txtDataValue2)
                                                        currValue.Add(paraValue)
                                                        crxSubReport.DataDefinition.ParameterFields.Item(txtDataValue1).ApplyCurrentValues(currValue)
                                                    Case ParameterValueKind.DateParameter
                                                        crxSubReport.DataDefinition.ParameterFields.Item(intParIndex).CurrentValues.AddValue(CDate(txtDataValue2))
                                                        currValue = crxSubReport.DataDefinition.ParameterFields.Item(txtDataValue1).CurrentValues
                                                        paraValue.Value = CDate(txtDataValue2)
                                                        currValue.Add(paraValue)
                                                        crxSubReport.DataDefinition.ParameterFields.Item(txtDataValue1).ApplyCurrentValues(currValue)
                                                    Case ParameterValueKind.DateTimeParameter
                                                        currValue = crxSubReport.DataDefinition.ParameterFields.Item(txtDataValue1).CurrentValues
                                                        paraValue.Value = CDate(txtDataValue2)
                                                        currValue.Add(paraValue)
                                                        crxSubReport.DataDefinition.ParameterFields.Item(txtDataValue1).ApplyCurrentValues(currValue)
                                                    Case ParameterValueKind.NumberParameter
                                                        currValue = crxSubReport.DataDefinition.ParameterFields.Item(txtDataValue1).CurrentValues
                                                        paraValue.Value = CDbl(txtDataValue2)
                                                        currValue.Add(paraValue)
                                                        crxSubReport.DataDefinition.ParameterFields.Item(txtDataValue1).ApplyCurrentValues(currValue)
                                                    Case ParameterValueKind.StringParameter
                                                        currValue = crxSubReport.DataDefinition.ParameterFields.Item(txtDataValue1).CurrentValues
                                                        paraValue.Value = CStr(txtDataValue2)
                                                        currValue.Add(paraValue)
                                                        crxSubReport.DataDefinition.ParameterFields.Item(txtDataValue1).ApplyCurrentValues(currValue)
                                                    Case ParameterValueKind.TimeParameter
                                                        currValue = crxSubReport.DataDefinition.ParameterFields.Item(txtDataValue1).CurrentValues
                                                        paraValue.Value = CDate(txtDataValue2)
                                                        currValue.Add(paraValue)
                                                        crxSubReport.DataDefinition.ParameterFields.Item(txtDataValue1).ApplyCurrentValues(currValue)
                                                End Select
                                                'End If
                                            End If
                                        Next intParIndex

                                    End If
                                Next
                            Next

                        Case "RANGE"
                            txtDataValue1 = fncFindDynamicValue(objReader.ReadLine)
                            txtDataValue2 = fncFindDynamicValue(objReader.ReadLine)
                            txtDataValue3 = fncFindDynamicValue(objReader.ReadLine)
                            txtDataValue1 = fncFindDynamicText(txtDataValue1, False, ReportSettingsInfo)
                            txtDataValue2 = fncFindDynamicText(txtDataValue2, False, ReportSettingsInfo)
                            txtDataValue3 = fncFindDynamicText(txtDataValue3, False, ReportSettingsInfo)



                            For intParIndex = 0 To crxReport.DataDefinition.ParameterFields.Count - 1
                                If crxReport.DataDefinition.ParameterFields.Item(intParIndex).Name = txtDataValue1 And txtDataValue2 <> "" And txtDataValue3 <> "" Then
                                    'If crxReport.DataDefinition.ParameterFields.Item(intParIndex).ReportName = "" Then
                                    Select Case crxReport.DataDefinition.ParameterFields.Item(intParIndex).ParameterValueKind
                                        Case ParameterValueKind.BooleanParameter
                                            crxReport.SetParameterValue(txtDataValue1, txtDataValue2)
                                            currValue = crxReport.DataDefinition.ParameterFields.Item(txtDataValue1).CurrentValues
                                            rangValue.StartValue = CBool(txtDataValue2)
                                            rangValue.EndValue = CBool(txtDataValue3)
                                            currValue.Add(rangValue)
                                            crxReport.DataDefinition.ParameterFields.Item(txtDataValue1).ApplyCurrentValues(currValue)
                                        Case ParameterValueKind.CurrencyParameter
                                            currValue = crxReport.DataDefinition.ParameterFields.Item(txtDataValue1).CurrentValues
                                            rangValue.StartValue = CDec(txtDataValue2)
                                            rangValue.EndValue = CDec(txtDataValue3)
                                            currValue.Add(rangValue)
                                            crxReport.DataDefinition.ParameterFields.Item(txtDataValue1).ApplyCurrentValues(currValue)
                                        Case ParameterValueKind.DateParameter
                                            crxReport.DataDefinition.ParameterFields.Item(intParIndex).CurrentValues.AddValue(CDate(txtDataValue2))
                                            currValue = crxReport.DataDefinition.ParameterFields.Item(txtDataValue1).CurrentValues
                                            rangValue.StartValue = CDate(txtDataValue2)
                                            rangValue.EndValue = CDate(txtDataValue3)
                                            currValue.Add(rangValue)
                                            crxReport.DataDefinition.ParameterFields.Item(txtDataValue1).ApplyCurrentValues(currValue)
                                        Case ParameterValueKind.DateTimeParameter
                                            currValue = crxReport.DataDefinition.ParameterFields.Item(txtDataValue1).CurrentValues
                                            rangValue.StartValue = CDate(txtDataValue2)
                                            rangValue.EndValue = CDate(txtDataValue3)
                                            currValue.Add(rangValue)
                                            crxReport.DataDefinition.ParameterFields.Item(txtDataValue1).ApplyCurrentValues(currValue)
                                        Case ParameterValueKind.NumberParameter
                                            currValue = crxReport.DataDefinition.ParameterFields.Item(txtDataValue1).CurrentValues
                                            rangValue.StartValue = CDbl(txtDataValue2)
                                            rangValue.EndValue = CDbl(txtDataValue3)
                                            currValue.Add(rangValue)
                                            crxReport.DataDefinition.ParameterFields.Item(txtDataValue1).ApplyCurrentValues(currValue)
                                        Case ParameterValueKind.StringParameter
                                            currValue = crxReport.DataDefinition.ParameterFields.Item(txtDataValue1).CurrentValues
                                            rangValue.StartValue = CStr(txtDataValue2)
                                            rangValue.EndValue = CStr(txtDataValue3)
                                            currValue.Add(rangValue)
                                            crxReport.DataDefinition.ParameterFields.Item(txtDataValue1).ApplyCurrentValues(currValue)
                                        Case ParameterValueKind.TimeParameter
                                            currValue = crxReport.DataDefinition.ParameterFields.Item(txtDataValue1).CurrentValues
                                            rangValue.StartValue = CDate(txtDataValue2)
                                            rangValue.EndValue = CDate(txtDataValue3)
                                            currValue.Add(rangValue)
                                            crxReport.DataDefinition.ParameterFields.Item(txtDataValue1).ApplyCurrentValues(currValue)
                                    End Select
                                    'End If
                                End If
                            Next intParIndex

                            For Each crSection In crSections
                                crReportObjects = crSection.ReportObjects
                                For Each crReportObject In crReportObjects
                                    If crReportObject.Kind = ReportObjectKind.SubreportObject Then
                                        crxSubReportObject = CType(crReportObject, SubreportObject)
                                        crxSubReport = crxSubReportObject.OpenSubreport(crxSubReportObject.SubreportName)

                                        For intParIndex = 0 To crxSubReport.DataDefinition.ParameterFields.Count - 1
                                            If crxSubReport.DataDefinition.ParameterFields.Item(intParIndex).Name = txtDataValue1 And txtDataValue2 <> "" And txtDataValue3 <> "" Then
                                                'If crxsubreport.DataDefinition.ParameterFields.Item(intParIndex).ReportName = "" Then
                                                Select Case crxSubReport.DataDefinition.ParameterFields.Item(intParIndex).ParameterValueKind
                                                    Case ParameterValueKind.BooleanParameter
                                                        crxSubReport.SetParameterValue(txtDataValue1, txtDataValue2)
                                                        currValue = crxSubReport.DataDefinition.ParameterFields.Item(txtDataValue1).CurrentValues
                                                        rangValue.StartValue = CBool(txtDataValue2)
                                                        rangValue.EndValue = CBool(txtDataValue3)
                                                        currValue.Add(rangValue)
                                                        crxSubReport.DataDefinition.ParameterFields.Item(txtDataValue1).ApplyCurrentValues(currValue)
                                                    Case ParameterValueKind.CurrencyParameter
                                                        currValue = crxSubReport.DataDefinition.ParameterFields.Item(txtDataValue1).CurrentValues
                                                        rangValue.StartValue = CDec(txtDataValue2)
                                                        rangValue.EndValue = CDec(txtDataValue3)
                                                        currValue.Add(rangValue)
                                                        crxSubReport.DataDefinition.ParameterFields.Item(txtDataValue1).ApplyCurrentValues(currValue)
                                                    Case ParameterValueKind.DateParameter
                                                        crxSubReport.DataDefinition.ParameterFields.Item(intParIndex).CurrentValues.AddValue(CDate(txtDataValue2))
                                                        currValue = crxSubReport.DataDefinition.ParameterFields.Item(txtDataValue1).CurrentValues
                                                        rangValue.StartValue = CDate(txtDataValue2)
                                                        rangValue.EndValue = CDate(txtDataValue3)
                                                        currValue.Add(rangValue)
                                                        crxSubReport.DataDefinition.ParameterFields.Item(txtDataValue1).ApplyCurrentValues(currValue)
                                                    Case ParameterValueKind.DateTimeParameter
                                                        currValue = crxSubReport.DataDefinition.ParameterFields.Item(txtDataValue1).CurrentValues
                                                        rangValue.StartValue = CDate(txtDataValue2)
                                                        rangValue.EndValue = CDate(txtDataValue3)
                                                        currValue.Add(rangValue)
                                                        crxSubReport.DataDefinition.ParameterFields.Item(txtDataValue1).ApplyCurrentValues(currValue)
                                                    Case ParameterValueKind.NumberParameter
                                                        currValue = crxSubReport.DataDefinition.ParameterFields.Item(txtDataValue1).CurrentValues
                                                        rangValue.StartValue = CDbl(txtDataValue2)
                                                        rangValue.EndValue = CDbl(txtDataValue3)
                                                        currValue.Add(rangValue)
                                                        crxSubReport.DataDefinition.ParameterFields.Item(txtDataValue1).ApplyCurrentValues(currValue)
                                                    Case ParameterValueKind.StringParameter
                                                        currValue = crxSubReport.DataDefinition.ParameterFields.Item(txtDataValue1).CurrentValues
                                                        rangValue.StartValue = CStr(txtDataValue2)
                                                        rangValue.EndValue = CStr(txtDataValue3)
                                                        currValue.Add(rangValue)
                                                        crxSubReport.DataDefinition.ParameterFields.Item(txtDataValue1).ApplyCurrentValues(currValue)
                                                    Case ParameterValueKind.TimeParameter
                                                        currValue = crxSubReport.DataDefinition.ParameterFields.Item(txtDataValue1).CurrentValues
                                                        rangValue.StartValue = CDate(txtDataValue2)
                                                        rangValue.EndValue = CDate(txtDataValue3)
                                                        currValue.Add(rangValue)
                                                        crxSubReport.DataDefinition.ParameterFields.Item(txtDataValue1).ApplyCurrentValues(currValue)
                                                End Select
                                                'End If
                                            End If
                                        Next intParIndex

                                    End If
                                Next
                            Next

                            'For intParIndex = 0 To crxReport.DataDefinition.ParameterFields.Count - 1
                            'If crxReport.DataDefinition.ParameterFields.Item(intParIndex).Name = txtDataValue1 And txtDataValue2 <> "" And txtDataValue3 <> "" Then
                            'If crxReport.DataDefinition.ParameterFields.Item(intParIndex).ReportName = "" Then

                            'Select Case crxReport.DataDefinition.ParameterFields.Item(intParIndex).ParameterValueKind
                            'Case ParameterValueKind.BooleanParameter
                            'crxReport.DataDefinition.ParameterFields.Item(intParIndex).CurrentValues.AddRange(CBool(txtDataValue2), CBool(txtDataValue3), RangeBoundType.BoundInclusive, RangeBoundType.BoundInclusive)
                            'Case ParameterValueKind.CurrencyParameter
                            'crxReport.DataDefinition.ParameterFields.Item(intParIndex).CurrentValues.AddRange(CDec(txtDataValue2), CDec(txtDataValue3), RangeBoundType.BoundInclusive, RangeBoundType.BoundInclusive)
                            'Case ParameterValueKind.DateParameter
                            'crxReport.DataDefinition.ParameterFields.Item(intParIndex).CurrentValues.AddRange(CDate(txtDataValue2), CDate(txtDataValue3), RangeBoundType.BoundInclusive, RangeBoundType.BoundInclusive)
                            'Case ParameterValueKind.DateTimeParameter
                            'crxReport.DataDefinition.ParameterFields.Item(intParIndex).CurrentValues.AddRange(CDate(txtDataValue2), CDate(txtDataValue3), RangeBoundType.BoundInclusive, RangeBoundType.BoundInclusive)
                            'Case ParameterValueKind.NumberParameter
                            'crxReport.DataDefinition.ParameterFields.Item(intParIndex).CurrentValues.AddRange(CDbl(txtDataValue2), CDbl(txtDataValue3), RangeBoundType.BoundInclusive, RangeBoundType.BoundInclusive)
                            'Case ParameterValueKind.StringParameter
                            'crxReport.DataDefinition.ParameterFields.Item(intParIndex).CurrentValues.AddRange(CStr(txtDataValue2), CStr(txtDataValue3), RangeBoundType.BoundInclusive, RangeBoundType.BoundInclusive)
                            'Case ParameterValueKind.TimeParameter
                            'crxReport.DataDefinition.ParameterFields.Item(intParIndex).CurrentValues.AddRange(CDate(txtDataValue2), CDate(txtDataValue3), RangeBoundType.BoundInclusive, RangeBoundType.BoundInclusive)
                            'End Select
                            'End If
                            'End If
                            'Next intParIndex

                        Case "CONNECTION"
                            'ConInfo.ConnectionInfo.ServerName = ""
                            'ConInfo.ConnectionInfo.DatabaseName = ""
                            'ConInfo.ConnectionInfo.UserID = ""
                            'ConInfo.ConnectionInfo.Password = ""
                            txtDataValue1 = fncFindDynamicValue(objReader.ReadLine)
                            txtDataValue2 = fncFindDynamicValue(objReader.ReadLine)
                            txtDataValue3 = fncFindDynamicValue(DecryptText(objReader.ReadLine, glbEKey))
                            txtDataValue4 = fncFindDynamicValue(DecryptText(objReader.ReadLine, glbEKey))



                            oCRDb = crxReport.Database
                            oCRTables = oCRDb.Tables
                            'Dim oCRTable As CrystalDecisions.CrystalReports.Engine.Table
                            'Dim oCRTableLogonInfo As CrystalDecisions.Shared.TableLogOnInfo
                            'Dim oCRConnectionInfo As New CrystalDecisions.Shared.ConnectionInfo()
                            oCRConnectionInfo.DatabaseName = txtDataValue1
                            oCRConnectionInfo.ServerName = txtDataValue2
                            oCRConnectionInfo.UserID = txtDataValue3
                            oCRConnectionInfo.Password = txtDataValue4

                            For Each oCRTable In oCRTables
                                oCRTableLogonInfo = oCRTable.LogOnInfo
                                oCRTableLogonInfo.ConnectionInfo = oCRConnectionInfo
                                oCRTable.ApplyLogOnInfo(oCRTableLogonInfo)
                            Next


                            crSections = crxReport.ReportDefinition.Sections
                            For Each crSection In crSections
                                crReportObjects = crSection.ReportObjects
                                For Each crReportObject In crReportObjects
                                    If crReportObject.Kind = ReportObjectKind.SubreportObject Then

                                        'If you find a subreport, typecast the reportobject to a subreport object
                                        crxSubReportObject = CType(crReportObject, SubreportObject)

                                        'Open the subreport
                                        crxSubReport = crxSubReportObject.OpenSubreport(crxSubReportObject.SubreportName)

                                        oCRDb = crxSubReport.Database
                                        oCRTables = oCRDb.Tables
                                        For Each oCRTable In oCRTables
                                            oCRTableLogonInfo = oCRTable.LogOnInfo
                                            oCRTableLogonInfo.ConnectionInfo = oCRConnectionInfo
                                            oCRTable.ApplyLogOnInfo(oCRTableLogonInfo)
                                        Next

                                        'Loop through each table and set the connection info
                                        'Pass the connection info to the logoninfo object then apply the
                                        'logoninfo to the subreport

                                        'For Each crTable In crTables
                                        'With crConnInfo
                                        '.ServerName = "server name"
                                        '.DatabaseName = "database name"
                                        '.UserID = "user id"
                                        '.Password = "password"
                                        'End With
                                        'crLogOnInfo = crTable.LogOnInfo
                                        'crLogOnInfo.ConnectionInfo = crConnInfo
                                        'crTable.ApplyLogOnInfo(crLogOnInfo)
                                        'Next
                                    End If
                                Next
                            Next

                    End Select
                Loop Until objReader.EndOfStream
                objReader.Close()
                encryptfile(ReportSettingsInfo)

            End If
            'MsgBox(crxReport.DataSourceConnections.Item(0))
            fncReportSource = crxReport


        Catch ex As Exception
            ErrorWriter(ex.Message.ToString)

        End Try


    End Function
End Module

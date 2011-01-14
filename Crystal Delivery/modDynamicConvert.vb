Module modDynamicConvert
    Public Function fncFindDynamicValue(ByVal strCurrentValue As String) As String
        Try
            Dim datNewDate As Date
            Dim strSplitValues As String()

            strSplitValues = strCurrentValue.Split(":")


            Select Case strSplitValues(LBound(strSplitValues))
                Case "Today (Days)"
                    datNewDate = DateAdd(DateInterval.Day, CInt(strSplitValues(UBound(strSplitValues))), Now)
                    fncFindDynamicValue = datNewDate.ToShortDateString
                Case "Today (Months)"
                    datNewDate = DateAdd(DateInterval.Month, CInt(strSplitValues(UBound(strSplitValues))), Now)
                    fncFindDynamicValue = datNewDate.ToShortDateString
                Case "Month Start (Days)"
                    datNewDate = DateSerial(Now.Year, Now.Month, 1)
                    'datNewDate = CDate(Now.Month & " 01 " & Now.Year)
                    datNewDate = DateAdd(DateInterval.Day, CInt(strSplitValues(UBound(strSplitValues))), datNewDate)
                    fncFindDynamicValue = datNewDate.ToShortDateString
                Case "Month End (Days)"
                    datNewDate = DateSerial(Now.Year, Now.Month, 1)
                    'datNewDate = CDate(Now.Month & " 01 " & Now.Year)
                    datNewDate = DateAdd(DateInterval.Month, 1, datNewDate)
                    datNewDate = DateAdd(DateInterval.Day, -1, datNewDate)
                    datNewDate = DateAdd(DateInterval.Day, CInt(strSplitValues(UBound(strSplitValues))), datNewDate)
                    fncFindDynamicValue = datNewDate.ToShortDateString
                Case "Month Start (Months)"
                    datNewDate = DateSerial(Now.Year, Now.Month, 1)
                    'datNewDate = CDate(Now.Month & " 01 " & Now.Year)
                    datNewDate = DateAdd(DateInterval.Month, CInt(strSplitValues(UBound(strSplitValues))), datNewDate)
                    fncFindDynamicValue = datNewDate.ToShortDateString
                Case "Month End (Months)"
                    datNewDate = DateSerial(Now.Year, Now.Month, 1)
                    'datNewDate = CDate(Now.Month & " 01 " & Now.Year)
                    'datNewDate = DateAdd(DateInterval.Month, 1, datNewDate)
                    'datNewDate = DateAdd(DateInterval.Day, -1, datNewDate)
                    datNewDate = DateAdd(DateInterval.Month, CInt(strSplitValues(UBound(strSplitValues))), datNewDate)
                    datNewDate = DateAdd(DateInterval.Month, 1, datNewDate)
                    datNewDate = DateAdd(DateInterval.Day, -1, datNewDate)
                    fncFindDynamicValue = datNewDate.ToShortDateString
                Case "Year Start (Days)"
                    datNewDate = DateSerial(Now.Year, 1, 1)
                    datNewDate = DateAdd(DateInterval.Day, CInt(strSplitValues(UBound(strSplitValues))), datNewDate)
                    fncFindDynamicValue = datNewDate.ToShortDateString
                Case "Year End (Days)"
                    datNewDate = DateSerial(Now.Year, 12, 31)
                    datNewDate = DateAdd(DateInterval.Day, CInt(strSplitValues(UBound(strSplitValues))), datNewDate)
                    fncFindDynamicValue = datNewDate.ToShortDateString
                Case "Year Start (Months)"
                    datNewDate = DateSerial(Now.Year, 1, 1)
                    datNewDate = DateAdd(DateInterval.Month, CInt(strSplitValues(UBound(strSplitValues))), datNewDate)
                    fncFindDynamicValue = datNewDate.ToShortDateString
                Case "Year End (Months)"
                    datNewDate = DateSerial(Now.Year, 12, 31)
                    datNewDate = DateAdd(DateInterval.Month, CInt(strSplitValues(UBound(strSplitValues))), datNewDate)
                    fncFindDynamicValue = datNewDate.ToShortDateString
                Case "Year Start (Years)"
                    datNewDate = DateSerial(Now.Year, 1, 1)
                    datNewDate = DateAdd(DateInterval.Year, CInt(strSplitValues(UBound(strSplitValues))), datNewDate)
                    fncFindDynamicValue = datNewDate.ToShortDateString
                Case "Year End (Years)"
                    datNewDate = DateSerial(Now.Year, 12, 31)
                    datNewDate = DateAdd(DateInterval.Year, CInt(strSplitValues(UBound(strSplitValues))), datNewDate)
                    fncFindDynamicValue = datNewDate.ToShortDateString
                Case "Sunday (Weeks)"
                    Select Case Weekday(Now)
                        Case 1
                            datNewDate = DateAdd(DateInterval.Day, 0 + (CInt(strSplitValues(UBound(strSplitValues))) * 7), Now())
                        Case 2
                            datNewDate = DateAdd(DateInterval.Day, -1 + (CInt(strSplitValues(UBound(strSplitValues))) * 7), Now())
                        Case 3
                            datNewDate = DateAdd(DateInterval.Day, -2 + (CInt(strSplitValues(UBound(strSplitValues))) * 7), Now())
                        Case 4
                            datNewDate = DateAdd(DateInterval.Day, -3 + (CInt(strSplitValues(UBound(strSplitValues))) * 7), Now())
                        Case 5
                            datNewDate = DateAdd(DateInterval.Day, -4 + (CInt(strSplitValues(UBound(strSplitValues))) * 7), Now())
                        Case 6
                            datNewDate = DateAdd(DateInterval.Day, -5 + (CInt(strSplitValues(UBound(strSplitValues))) * 7), Now())
                        Case 7
                            datNewDate = DateAdd(DateInterval.Day, -6 + (CInt(strSplitValues(UBound(strSplitValues))) * 7), Now())
                    End Select
                    fncFindDynamicValue = datNewDate.ToShortDateString
                Case "Monday (Weeks)"
                    Select Case Weekday(Now)
                        Case 1
                            datNewDate = DateAdd(DateInterval.Day, 1 + (CInt(strSplitValues(UBound(strSplitValues))) * 7), Now())
                        Case 2
                            datNewDate = DateAdd(DateInterval.Day, 0 + (CInt(strSplitValues(UBound(strSplitValues))) * 7), Now())
                        Case 3
                            datNewDate = DateAdd(DateInterval.Day, -1 + (CInt(strSplitValues(UBound(strSplitValues))) * 7), Now())
                        Case 4
                            datNewDate = DateAdd(DateInterval.Day, -2 + (CInt(strSplitValues(UBound(strSplitValues))) * 7), Now())
                        Case 5
                            datNewDate = DateAdd(DateInterval.Day, -3 + (CInt(strSplitValues(UBound(strSplitValues))) * 7), Now())
                        Case 6
                            datNewDate = DateAdd(DateInterval.Day, -4 + (CInt(strSplitValues(UBound(strSplitValues))) * 7), Now())
                        Case 7
                            datNewDate = DateAdd(DateInterval.Day, -5 + (CInt(strSplitValues(UBound(strSplitValues))) * 7), Now())
                    End Select
                    fncFindDynamicValue = datNewDate.ToShortDateString
                Case "Tuesday (Weeks)"
                    Select Case Weekday(Now)
                        Case 1
                            datNewDate = DateAdd(DateInterval.Day, 2 + (CInt(strSplitValues(UBound(strSplitValues))) * 7), Now())
                        Case 2
                            datNewDate = DateAdd(DateInterval.Day, 1 + (CInt(strSplitValues(UBound(strSplitValues))) * 7), Now())
                        Case 3
                            datNewDate = DateAdd(DateInterval.Day, 0 + (CInt(strSplitValues(UBound(strSplitValues))) * 7), Now())
                        Case 4
                            datNewDate = DateAdd(DateInterval.Day, -1 + (CInt(strSplitValues(UBound(strSplitValues))) * 7), Now())
                        Case 5
                            datNewDate = DateAdd(DateInterval.Day, -2 + (CInt(strSplitValues(UBound(strSplitValues))) * 7), Now())
                        Case 6
                            datNewDate = DateAdd(DateInterval.Day, -3 + (CInt(strSplitValues(UBound(strSplitValues))) * 7), Now())
                        Case 7
                            datNewDate = DateAdd(DateInterval.Day, -4 + (CInt(strSplitValues(UBound(strSplitValues))) * 7), Now())
                    End Select
                    fncFindDynamicValue = datNewDate.ToShortDateString
                Case "Wednesday (Weeks)"
                    Select Case Weekday(Now)
                        Case 1
                            datNewDate = DateAdd(DateInterval.Day, 3 + (CInt(strSplitValues(UBound(strSplitValues))) * 7), Now())
                        Case 2
                            datNewDate = DateAdd(DateInterval.Day, 2 + (CInt(strSplitValues(UBound(strSplitValues))) * 7), Now())
                        Case 3
                            datNewDate = DateAdd(DateInterval.Day, 1 + (CInt(strSplitValues(UBound(strSplitValues))) * 7), Now())
                        Case 4
                            datNewDate = DateAdd(DateInterval.Day, 0 + (CInt(strSplitValues(UBound(strSplitValues))) * 7), Now())
                        Case 5
                            datNewDate = DateAdd(DateInterval.Day, -1 + (CInt(strSplitValues(UBound(strSplitValues))) * 7), Now())
                        Case 6
                            datNewDate = DateAdd(DateInterval.Day, -2 + (CInt(strSplitValues(UBound(strSplitValues))) * 7), Now())
                        Case 7
                            datNewDate = DateAdd(DateInterval.Day, -3 + (CInt(strSplitValues(UBound(strSplitValues))) * 7), Now())
                    End Select
                    fncFindDynamicValue = datNewDate.ToShortDateString
                Case "Thursday (Weeks)"
                    Select Case Weekday(Now)
                        Case 1
                            datNewDate = DateAdd(DateInterval.Day, 4 + (CInt(strSplitValues(UBound(strSplitValues))) * 7), Now())
                        Case 2
                            datNewDate = DateAdd(DateInterval.Day, 3 + (CInt(strSplitValues(UBound(strSplitValues))) * 7), Now())
                        Case 3
                            datNewDate = DateAdd(DateInterval.Day, 2 + (CInt(strSplitValues(UBound(strSplitValues))) * 7), Now())
                        Case 4
                            datNewDate = DateAdd(DateInterval.Day, 1 + (CInt(strSplitValues(UBound(strSplitValues))) * 7), Now())
                        Case 5
                            datNewDate = DateAdd(DateInterval.Day, 0 + (CInt(strSplitValues(UBound(strSplitValues))) * 7), Now())
                        Case 6
                            datNewDate = DateAdd(DateInterval.Day, -1 + (CInt(strSplitValues(UBound(strSplitValues))) * 7), Now())
                        Case 7
                            datNewDate = DateAdd(DateInterval.Day, -2 + (CInt(strSplitValues(UBound(strSplitValues))) * 7), Now())
                    End Select
                    fncFindDynamicValue = datNewDate.ToShortDateString
                Case "Friday (Weeks)"
                    Select Case Weekday(Now)
                        Case 1
                            datNewDate = DateAdd(DateInterval.Day, 5 + (CInt(strSplitValues(UBound(strSplitValues))) * 7), Now())
                        Case 2
                            datNewDate = DateAdd(DateInterval.Day, 4 + (CInt(strSplitValues(UBound(strSplitValues))) * 7), Now())
                        Case 3
                            datNewDate = DateAdd(DateInterval.Day, 3 + (CInt(strSplitValues(UBound(strSplitValues))) * 7), Now())
                        Case 4
                            datNewDate = DateAdd(DateInterval.Day, 2 + (CInt(strSplitValues(UBound(strSplitValues))) * 7), Now())
                        Case 5
                            datNewDate = DateAdd(DateInterval.Day, 1 + (CInt(strSplitValues(UBound(strSplitValues))) * 7), Now())
                        Case 6
                            datNewDate = DateAdd(DateInterval.Day, 0 + (CInt(strSplitValues(UBound(strSplitValues))) * 7), Now())
                        Case 7
                            datNewDate = DateAdd(DateInterval.Day, -1 + (CInt(strSplitValues(UBound(strSplitValues))) * 7), Now())
                    End Select
                    fncFindDynamicValue = datNewDate.ToShortDateString
                Case "Saturday (Weeks)"
                    Select Case Weekday(Now)
                        Case 1
                            datNewDate = DateAdd(DateInterval.Day, 6 + (CInt(strSplitValues(UBound(strSplitValues))) * 7), Now())
                        Case 2
                            datNewDate = DateAdd(DateInterval.Day, 5 + (CInt(strSplitValues(UBound(strSplitValues))) * 7), Now())
                        Case 3
                            datNewDate = DateAdd(DateInterval.Day, 4 + (CInt(strSplitValues(UBound(strSplitValues))) * 7), Now())
                        Case 4
                            datNewDate = DateAdd(DateInterval.Day, 3 + (CInt(strSplitValues(UBound(strSplitValues))) * 7), Now())
                        Case 5
                            datNewDate = DateAdd(DateInterval.Day, 2 + (CInt(strSplitValues(UBound(strSplitValues))) * 7), Now())
                        Case 6
                            datNewDate = DateAdd(DateInterval.Day, 1 + (CInt(strSplitValues(UBound(strSplitValues))) * 7), Now())
                        Case 7
                            datNewDate = DateAdd(DateInterval.Day, 0 + (CInt(strSplitValues(UBound(strSplitValues))) * 7), Now())
                    End Select
                    fncFindDynamicValue = datNewDate.ToShortDateString
                Case Else
                    fncFindDynamicValue = strCurrentValue
            End Select
        Catch ex As Exception
            ErrorWriter(ex.Message.ToString)
            fncFindDynamicValue = ""
            'return false
        End Try
    End Function


    Public Function fncFindDynamicText(ByVal strCurrentValue As String, ByVal booNumPos As Boolean, ByVal ReportSettingsInfo As String) As String
        Try
            Dim strSplitPV1() As String
            Dim intIndex As Integer = 0
            Dim strSplitPV2() As String
            Dim strSplitPV3(1) As String
            Dim intNumber As Integer




            'Dim ReportSettingsInfo As String = App_Path() & "ScheduledReports\" & glbActiveID & "CDF"
            Dim txtDataID As String
            Dim intPVCounter As Integer
            strCurrentValue = Replace(strCurrentValue, "[t]", CStr(Format(Now, "t")))
            strCurrentValue = Replace(strCurrentValue, "[G]", CStr(Format(Now, "G")))
            strCurrentValue = Replace(strCurrentValue, "[D]", CStr(Format(Now, "D")))
            strCurrentValue = Replace(strCurrentValue, "[T]", CStr(Format(Now, "T")))
            strCurrentValue = Replace(strCurrentValue, "[t]", CStr(Format(Now, "t")))
            strCurrentValue = Replace(strCurrentValue, "[f]", CStr(Format(Now, "f")))
            strCurrentValue = Replace(strCurrentValue, "[F]", CStr(Format(Now, "F")))
            strCurrentValue = Replace(strCurrentValue, "[g]", CStr(Format(Now, "g")))
            strCurrentValue = Replace(strCurrentValue, "[r]", CStr(Format(Now, "r")))
            strCurrentValue = Replace(strCurrentValue, "[s]", CStr(Format(Now, "s")))
            strCurrentValue = Replace(strCurrentValue, "[u]", CStr(Format(Now, "u")))
            strCurrentValue = Replace(strCurrentValue, "[U]", CStr(Format(Now, "U")))
            strCurrentValue = Replace(strCurrentValue, "[m]", CStr(Format(Now(), "MM")))
            strCurrentValue = Replace(strCurrentValue, "[y]", CStr(Format(Now(), "yyyy")))
            strCurrentValue = Replace(strCurrentValue, "[d]", CStr(Format(Now(), "dd")))
            strCurrentValue = Replace(strCurrentValue, "[w]", CStr(DatePart("w", Now())))
            strCurrentValue = Replace(strCurrentValue, "[ww]", CStr(DatePart("ww", Now())))
            strCurrentValue = Replace(strCurrentValue, "[dy]", CStr(DatePart("y", Now())))
            strCurrentValue = Replace(strCurrentValue, "[iw]", CStr(getISOWeek(Now())))
            strCurrentValue = Replace(strCurrentValue, "[iy]", CStr(getISOYear(Now())))
            strCurrentValue = Replace(strCurrentValue, "[id]", CStr(getISODay(Now())))
            strCurrentValue = Replace(strCurrentValue, "[ws]", "[ws:0]")
            strCurrentValue = Replace(strCurrentValue, "[wl]", "[wl:0]")
            strCurrentValue = Replace(strCurrentValue, "[ml]", "[ml:0]")
            strCurrentValue = Replace(strCurrentValue, "[ms]", "[ms:0]")
            strCurrentValue = Replace(strCurrentValue, "[mdy]", Format(Now.Date, "MM-dd-yyyy"))
            strCurrentValue = Replace(strCurrentValue, "[ymd]", Format(Now.Date, "yyyy-MM-dd"))
            strCurrentValue = Replace(strCurrentValue, "[dpm]", Format(Now.Date, "MM"))
            strCurrentValue = Replace(strCurrentValue, "[dpms]", Format(Now.Date, "MMM"))
            strCurrentValue = Replace(strCurrentValue, "[dpml]", Format(Now.Date, "MMMM"))
            strCurrentValue = Replace(strCurrentValue, "[dpys]", Format(Now.Date, "yy"))
            strCurrentValue = Replace(strCurrentValue, "[dpyl]", Format(Now.Date, "yyyy"))

            If InStr(strCurrentValue, "[", CompareMethod.Text) Then
                Do
                    strSplitPV1 = Split(strCurrentValue, "[", 2, CompareMethod.Text)
                    strSplitPV2 = Split(strSplitPV1(1), "]", 2, CompareMethod.Text)
                    strSplitPV3 = strSplitPV2(0).Split(":")
                    'If InStr(strSplitPV2(0), ":") Then
                    '    strSplitPV3 = strSplitPV2(0).Split(":")
                    '    'Else
                    '    '    strSplitPV3(0) = strSplitPV2(0)
                    '    '    strSplitPV3(1) = 0
                    '    'End If



                    Select Case UCase(strSplitPV3(0))
                        Case "DPM"
                            Dim datTempDate As Date
                            datTempDate = DateAdd(DateInterval.Day, CInt(strSplitPV3(1)), Now)
                            strCurrentValue = strSplitPV1(0) & CStr(Format(datTempDate, "MM")) & strSplitPV2(1)
                        Case "DPMS"
                            Dim datTempDate As Date
                            datTempDate = DateAdd(DateInterval.Day, CInt(strSplitPV3(1)), Now)
                            strCurrentValue = strSplitPV1(0) & CStr(Format(datTempDate, "MMM")) & strSplitPV2(1)
                        Case "DPML"
                            Dim datTempDate As Date
                            datTempDate = DateAdd(DateInterval.Day, CInt(strSplitPV3(1)), Now)
                            strCurrentValue = strSplitPV1(0) & CStr(Format(datTempDate, "MMMM")) & strSplitPV2(1)
                        Case "DPYS"
                            Dim datTempDate As Date
                            datTempDate = DateAdd(DateInterval.Day, CInt(strSplitPV3(1)), Now)
                            strCurrentValue = strSplitPV1(0) & CStr(Format(datTempDate, "yy")) & strSplitPV2(1)
                        Case "DPYL"
                            Dim datTempDate As Date
                            datTempDate = DateAdd(DateInterval.Day, CInt(strSplitPV3(1)), Now)
                            strCurrentValue = strSplitPV1(0) & CStr(Format(datTempDate, "yyyy")) & strSplitPV2(1)
                        Case "MDY"
                            Dim datTempDate As Date
                            datTempDate = DateAdd(DateInterval.Day, CInt(strSplitPV3(1)), Now)
                            strCurrentValue = strSplitPV1(0) & CStr(Format(datTempDate, "MM-dd-yyyy")) & strSplitPV2(1)
                        Case "YMD"
                            Dim datTempDate As Date
                            datTempDate = DateAdd(DateInterval.Day, CInt(strSplitPV3(1)), Now)
                            strCurrentValue = strSplitPV1(0) & CStr(Format(datTempDate, "yyyy-MM-dd")) & strSplitPV2(1)
                        Case "WL"
                            Dim datTempDate As Date
                            Dim txtDay As String = ""
                            datTempDate = DateAdd(DateInterval.Day, CInt(strSplitPV3(1)), Now)
                            Select Case DatePart("w", datTempDate) 'CInt(strCurrentValue)
                                Case 1
                                    txtDay = "Sunday"
                                Case 2
                                    txtDay = "Monday"
                                Case 3
                                    txtDay = "Tuesday"
                                Case 4
                                    txtDay = "Wednesday"
                                Case 5
                                    txtDay = "Thursday"
                                Case 6
                                    txtDay = "Friday"
                                Case 7
                                    txtDay = "Saturday"
                            End Select
                            strCurrentValue = strSplitPV1(0) & txtDay & strSplitPV2(1)


                        Case "WS"
                            Dim datTempDate As Date
                            Dim txtDay As String = ""
                            datTempDate = DateAdd(DateInterval.Day, CInt(strSplitPV3(1)), Now)
                            Select Case DatePart("w", datTempDate) 'CInt(strCurrentValue)
                                Case 1
                                    txtDay = "Sun"
                                Case 2
                                    txtDay = "Mon"
                                Case 3
                                    txtDay = "Tue"
                                Case 4
                                    txtDay = "Wed"
                                Case 5
                                    txtDay = "Thu"
                                Case 6
                                    txtDay = "Fri"
                                Case 7
                                    txtDay = "Sat"
                            End Select
                            strCurrentValue = strSplitPV1(0) & txtDay & strSplitPV2(1)

                        Case "ML"
                            Dim datTempDate As Date
                            Dim txtMonth As String = ""
                            datTempDate = DateAdd(DateInterval.Month, CInt(strSplitPV3(1)), Now)
                            'strCurrentValue = strSplitPV1(0) & Format(DateAdd(DateInterval.Month, CInt(strSplitPV3(1)), Now), "MM") & strSplitPV2(1)
                            Select Case DatePart("m", datTempDate)
                                Case 1
                                    txtMonth = "January"
                                Case 2
                                    txtMonth = "February"
                                Case 3
                                    txtMonth = "March"
                                Case 4
                                    txtMonth = "April"
                                Case 5
                                    txtMonth = "May"
                                Case 6
                                    txtMonth = "June"
                                Case 7
                                    txtMonth = "July"
                                Case 8
                                    txtMonth = "August"
                                Case 9
                                    txtMonth = "September"
                                Case 10
                                    txtMonth = "October"
                                Case 11
                                    txtMonth = "November"
                                Case 12
                                    txtMonth = "December"
                            End Select
                            strCurrentValue = strSplitPV1(0) & txtMonth & strSplitPV2(1)

                        Case "MS"
                            Dim datTempDate As Date
                            Dim txtMonth As String = ""
                            datTempDate = DateAdd(DateInterval.Month, CInt(strSplitPV3(1)), Now)
                            'strCurrentValue = strSplitPV1(0) & Format(DateAdd(DateInterval.Month, CInt(strSplitPV3(1)), Now), "MM") & strSplitPV2(1)
                            Select Case DatePart("m", datTempDate)
                                Case 1
                                    txtMonth = "Jan"
                                Case 2
                                    txtMonth = "Feb"
                                Case 3
                                    txtMonth = "Mar"
                                Case 4
                                    txtMonth = "Apr"
                                Case 5
                                    txtMonth = "May"
                                Case 6
                                    txtMonth = "Jun"
                                Case 7
                                    txtMonth = "Jul"
                                Case 8
                                    txtMonth = "Aug"
                                Case 9
                                    txtMonth = "Sep"
                                Case 10
                                    txtMonth = "Oct"
                                Case 11
                                    txtMonth = "Nov"
                                Case 12
                                    txtMonth = "Dec"
                            End Select
                            strCurrentValue = strSplitPV1(0) & txtMonth & strSplitPV2(1)
                        Case "Y"
                            strCurrentValue = strSplitPV1(0) & Format(DateAdd(DateInterval.Year, CInt(strSplitPV3(1)), Now), "yyy") & strSplitPV2(1)
                        Case "D"
                            strCurrentValue = strSplitPV1(0) & Format(DateAdd(DateInterval.Day, CInt(strSplitPV3(1)), Now), "dd") & strSplitPV2(1)
                        Case "M"
                            strCurrentValue = strSplitPV1(0) & Format(DateAdd(DateInterval.Month, CInt(strSplitPV3(1)), Now), "MM") & strSplitPV2(1)
                        Case "W"
                            Dim datTempDate As Date
                            datTempDate = DateAdd(DateInterval.Day, CInt(strSplitPV3(1)), Now)
                            strCurrentValue = strSplitPV1(0) & CStr(CInt(DatePart("w", datTempDate))) & strSplitPV2(1)
                        Case "WW"
                            Dim datTempDate As Date
                            datTempDate = DateAdd(DateInterval.Day, CInt(strSplitPV3(1)) * 7, Now)
                            strCurrentValue = strSplitPV1(0) & CStr(CInt(DatePart("ww", datTempDate))) & strSplitPV2(1)
                        Case "IW"
                            Dim datTempDate As Date
                            datTempDate = DateAdd(DateInterval.Day, CInt(strSplitPV3(1)) * 7, Now)
                            strCurrentValue = strSplitPV1(0) & CStr(CInt(getISOWeek(datTempDate))) & strSplitPV2(1)
                        Case "ID"
                            Dim datTempDate As Date
                            datTempDate = DateAdd(DateInterval.Day, CInt(strSplitPV3(1)), Now)
                            strCurrentValue = strSplitPV1(0) & CStr(CInt(getISODay(datTempDate))) & strSplitPV2(1)
                        Case "IY"
                            Dim datTempDate As Date
                            datTempDate = DateAdd(DateInterval.Year, CInt(strSplitPV3(1)), Now)
                            strCurrentValue = strSplitPV1(0) & CStr(CInt(getISOYear(datTempDate))) & strSplitPV2(1)
                        Case "DY"
                            Dim datTempDate As Date
                            datTempDate = DateAdd(DateInterval.Day, CInt(strSplitPV3(1)), Now)
                            strCurrentValue = strSplitPV1(0) & CStr(CInt(DatePart("y", datTempDate))) & strSplitPV2(1)
                        Case "PV"
                            decryptfile(ReportSettingsInfo)
                            Dim objReader As New System.IO.StreamReader(ReportSettingsInfo)
                            intPVCounter = -1
                            Do
                                txtDataID = objReader.ReadLine()
                                If txtDataID = "RANGE" Or txtDataID = "DISCRETE" Then
                                    intPVCounter = intPVCounter + 1
                                    If intPVCounter = strSplitPV3(1) - 1 Then
                                        If txtDataID = "RANGE" Then
                                            objReader.ReadLine()
                                            strCurrentValue = strSplitPV1(0) & fncFindDynamicValue(objReader.ReadLine()) & " to " & fncFindDynamicValue(objReader.ReadLine()) & strSplitPV2(1)
                                        ElseIf txtDataID = "DISCRETE" Then
                                            objReader.ReadLine()
                                            strCurrentValue = strSplitPV1(0) & fncFindDynamicValue(objReader.ReadLine()) & strSplitPV2(1)
                                        End If
                                        Exit Do
                                    End If
                                End If
                            Loop Until objReader.EndOfStream
                            objReader.Close()
                            encryptfile(ReportSettingsInfo)

                        Case "PN"
                            decryptfile(ReportSettingsInfo)
                            Dim objReader As New System.IO.StreamReader(ReportSettingsInfo)
                            intPVCounter = -1
                            Do
                                txtDataID = objReader.ReadLine()
                                If txtDataID = "RANGE" Or txtDataID = "DISCRETE" Then
                                    intPVCounter = intPVCounter + 1
                                    If intPVCounter = strSplitPV3(1) - 1 Then
                                        If txtDataID = "RANGE" Then
                                            strCurrentValue = strSplitPV1(0) & fncFindDynamicText(fncFindDynamicValue(objReader.ReadLine()), False, ReportSettingsInfo) & " to " & fncFindDynamicText(fncFindDynamicValue(objReader.ReadLine()), False, ReportSettingsInfo) & strSplitPV2(1)
                                        ElseIf txtDataID = "DISCRETE" Then
                                            strCurrentValue = strSplitPV1(0) & fncFindDynamicText(fncFindDynamicValue(objReader.ReadLine()), False, ReportSettingsInfo) & strSplitPV2(1)
                                        End If
                                        Exit Do
                                    End If
                                End If
                            Loop Until objReader.EndOfStream
                            objReader.Close()
                            encryptfile(ReportSettingsInfo)
                        Case "#"
                            strCurrentValue = Replace(strCurrentValue, "[#]", "<~!#!~>")

                        Case Else
                            strCurrentValue = strSplitPV1(0) & "<<~!" & strSplitPV2(0) & "!~>>" & strSplitPV2(1)
                    End Select

                Loop Until InStr(strCurrentValue, "[", CompareMethod.Text) = False
            End If

            If InStr(strCurrentValue, "<~!#!~>", CompareMethod.Text) Then
                intNumber = 0
                strSplitPV1 = Split(strCurrentValue, "~", 2, CompareMethod.Text)
                strSplitPV2 = Split(strSplitPV1(1), "~", 2, CompareMethod.Text)
                Do
                    intNumber = intNumber + 1
                    strCurrentValue = strSplitPV1(0) & intNumber.ToString & strSplitPV2(1)
                Loop Until FileExists(strCurrentValue) = False
                'intNumber = intNumber - 1
                'strCurrentValue = strSplitPV1(0) & intNumber.ToString & strSplitPV2(1)
            End If
            strCurrentValue = Replace(strCurrentValue, "<<~!", "[")
            strCurrentValue = Replace(strCurrentValue, "!~>>", "]")
            fncFindDynamicText = strCurrentValue
        Catch ex As Exception
            ErrorWriter(ex.Message.ToString)
            fncFindDynamicText = ""
            'return false
        End Try
    End Function

    Public Function fncFixExportName(ByVal strCurrentValue As String) As String
        'Dim quote As String = """"
        Try
            Dim posn As Integer, i As Integer
            Dim fName As String
            Dim fPath As String

            posn = 0
            For i = 1 To Len(strCurrentValue)
                If (Mid(strCurrentValue, i, 1) = "\") Then
                    posn = i
                End If
            Next i

            fName = Right(strCurrentValue, Len(strCurrentValue) - posn)
            fPath = Left(strCurrentValue, posn)

            fName = Replace(fName, "/", "-")
            fName = Replace(fName, "\", "-")
            fName = Replace(fName, ":", "-")
            fName = Replace(fName, "*", "-")
            fName = Replace(fName, "?", "-")
            fName = Replace(fName, "<", "-")
            fName = Replace(fName, ">", "-")
            fName = Replace(fName, "|", "-")
            fName = Replace(fName, quote, "-")
            fncFixExportName = fPath & fName
        Catch ex As Exception
            ErrorWriter(ex.Message.ToString)
            fncFixExportName = ""
        End Try

    End Function

End Module

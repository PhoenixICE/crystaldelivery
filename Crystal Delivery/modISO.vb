Module modISO
    Public Function getISOYear(ByVal myDate As Date) As Integer
        Try
            Dim thisYear, lastYear, nextYear As Integer
            Dim thisYearWeek1Monday, nextYearWeek1Monday
            Dim ISOYear As Integer

            'Set years
            thisYear = DatePart(DateInterval.Year, myDate)
            lastYear = thisYear - 1
            nextYear = thisYear + 1

            'Set firstMondays for years
            thisYearWeek1Monday = getWeek1Monday(thisYear)
            nextYearWeek1Monday = getWeek1Monday(nextYear)

            If myDate >= nextYearWeek1Monday Then
                ISOYear = nextYear
            ElseIf myDate >= thisYearWeek1Monday Then
                ISOYear = thisYear
            Else
                ISOYear = lastYear
            End If

            Return ISOYear
        Catch ex As Exception
            ErrorWriter(ex.Message.ToString)
            Return ""
        End Try
    End Function

    Public Function getWeek1Monday(ByVal year As Integer) As Date
        Try
            Dim Jan1st As Date = New Date(year.ToString, 1, 1)

            If Jan1st.DayOfWeek <= DayOfWeek.Thursday Then
                Return DateAndTime.DateAdd(DateInterval.Day, 1 - Jan1st.DayOfWeek, Jan1st)
            Else
                Return DateAndTime.DateAdd(DateInterval.Day, 8 - Jan1st.DayOfWeek, Jan1st)
            End If
        Catch ex As Exception
            ErrorWriter(ex.Message.ToString)
            Return ""
        End Try
    End Function

    Function getNumWeeksInYear(ByVal year As Integer) As Integer
        Try
            'This is the First monday''s in the week scheme which may fall in the previous year
            Dim startYear As Date = getWeek1Monday(year)
            Dim startYearPlus1 As Date = getWeek1Monday(year + 1)

            'If there were 53 weeks in this year then 371 days from start would be smaller
            'than the first monday of year following startdate, so :-
            If DateAndTime.DateAdd(DateInterval.Day, 370, startYear) < startYearPlus1 Then
                Return 53
            Else
                Return 52
            End If
        Catch ex As Exception
            ErrorWriter(ex.Message.ToString)
            Return ""
        End Try
    End Function

    Function getStartOfWeek(ByVal week As Integer, ByVal year As Integer) As Date
        Try
            If (week > 52 And getNumWeeksInYear(year) < 53) Or week < 1 Then
                Dim e As New Exception("getStartOfWeek():Violation Of Week Numbering Scheme")
                Throw e
                Exit Function
            End If

            Dim firstMonday As Date = getWeek1Monday(year)
            Dim requestedMonday = DateAndTime.DateAdd(DateInterval.Day, 7 * (week - 1), firstMonday)

            Return requestedMonday
        Catch ex As Exception
            ErrorWriter(ex.Message.ToString)
            Return ""
        End Try
    End Function

    Function getEndOfWeek(ByVal week As Integer, ByVal year As Integer) As Date
        Try
            If (week > 52 And getNumWeeksInYear(year) < 53) Or week < 1 Then
                Dim e As New Exception("getEndOfWeek():Violation Of Week Numbering Scheme")
                Throw e
                Exit Function
            End If

            Dim firstMonday As Date = getWeek1Monday(year)
            Dim requestedSunday = DateAndTime.DateAdd(DateInterval.Day, (7 * (week - 1)) + 6, firstMonday)

            Return requestedSunday
        Catch ex As Exception
            ErrorWriter(ex.Message.ToString)
            Return ""
        End Try
    End Function

    Function getISOWeek(ByVal inDate As Date) As Integer
        Try
            Const JAN As Integer = 1
            Const DEC As Integer = 12
            Const LASTDAYOFDEC As Integer = 31
            Const FIRSTDAYOFJAN As Integer = 1
            Const THURSDAY As Integer = 4

            Dim ThursdayFlag As Boolean = False

            ''Get the day number since the beginning of the year
            Dim DayOfYear As Integer = inDate.DayOfYear

            ''Get the numeric weekday of the first day of the
            ''year (using sunday as FirstDay)
            Dim StartWeekDayOfYear As Integer = CType(New DateTime(inDate.Year, JAN, FIRSTDAYOFJAN).DayOfWeek, Integer)

            Dim EndWeekDayOfYear As Integer = CType(New DateTime(inDate.Year, DEC, LASTDAYOFDEC).DayOfWeek, Integer)

            ''Compensate for the fact that we are using monday
            ''as the first day of the week
            If StartWeekDayOfYear = 0 Then
                StartWeekDayOfYear = 7
            End If

            If EndWeekDayOfYear = 0 Then
                EndWeekDayOfYear = 7
            End If

            ''Calculate the number of days in the first and last week
            Dim DaysInFirstWeek As Integer = 8 - StartWeekDayOfYear
            Dim DaysInLastWeek As Integer = 8 - EndWeekDayOfYear

            ''If the year either starts or ends on a thursday it will have a 53rd week

            If StartWeekDayOfYear = THURSDAY OrElse EndWeekDayOfYear = THURSDAY Then
                ThursdayFlag = True
            End If

            ''We begin by calculating the number of FULL weeks between the start of the year and
            ''our date. The number is rounded up, so the smallest possible value is 0.
            Dim FullWeeks As Integer = _
                CType(Math.Ceiling((DayOfYear - DaysInFirstWeek) / 7), Integer)
            Dim WeekNumber As Integer = FullWeeks

            ''If the first week of the year has at least four days, then the actual week number for our date
            ''can be incremented by one.

            If DaysInFirstWeek >= THURSDAY Then
                WeekNumber = WeekNumber + 1
            End If


            ''If week number is larger than week 52 (and the year doesn''t either start or end on a thursday)
            ''then the correct week number is 1.

            If WeekNumber > 52 AndAlso Not ThursdayFlag Then
                WeekNumber = 1
            End If

            ''If week number is still 0, it means that we are trying to evaluate the week number for a
            ''week that belongs in the previous year (since that week has 3 days or less in our date''s year).
            ''We therefore make a recursive call using the last day of the previous year.

            If WeekNumber = 0 Then
                WeekNumber = getISOWeek(New DateTime(inDate.Year - 1, DEC, LASTDAYOFDEC))
            End If

            Return WeekNumber
        Catch ex As Exception
            ErrorWriter(ex.Message.ToString)
            Return ""
        End Try
    End Function

    Function getISODay(ByVal inDate As Date) As Integer
        Try
            Const JAN As Integer = 1
            Const DEC As Integer = 12
            Const LASTDAYOFDEC As Integer = 31
            Const FIRSTDAYOFJAN As Integer = 1
            Const THURSDAY As Integer = 4

            Dim ThursdayFlag As Boolean = False

            ''Get the day number since the beginning of the year
            Dim DayOfYear As Integer = inDate.DayOfYear

            ''Get the numeric weekday of the first day of the
            ''year (using sunday as FirstDay)
            Dim StartWeekDayOfYear As Integer = CType(New DateTime(inDate.Year, JAN, FIRSTDAYOFJAN).DayOfWeek, Integer)

            Dim EndWeekDayOfYear As Integer = CType(New DateTime(inDate.Year, DEC, LASTDAYOFDEC).DayOfWeek, Integer)

            ''Compensate for the fact that we are using monday
            ''as the first day of the week
            If StartWeekDayOfYear = 0 Then
                StartWeekDayOfYear = 7
            End If

            If EndWeekDayOfYear = 0 Then
                EndWeekDayOfYear = 7
            End If

            ''Calculate the number of days in the first and last week
            Dim DaysInFirstWeek As Integer = 8 - StartWeekDayOfYear
            Dim DaysInLastWeek As Integer = 8 - EndWeekDayOfYear

            ''If the year either starts or ends on a thursday it will have a 53rd week

            If StartWeekDayOfYear = THURSDAY OrElse EndWeekDayOfYear = THURSDAY Then
                ThursdayFlag = True
            End If

            ''We begin by calculating the number of FULL weeks between the start of the year and
            ''our date. The number is rounded up, so the smallest possible value is 0.
            Dim FullWeeks As Integer = CType(Math.Ceiling((DayOfYear - DaysInFirstWeek) / 7), Integer)
            Dim WeekNumber As Integer = FullWeeks

            ''If the first week of the year has at least four days, then the actual week number for our date
            ''can be incremented by one.

            If DaysInFirstWeek >= THURSDAY Then
                WeekNumber = WeekNumber + 1
            End If


            ''If week number is larger than week 52 (and the year doesn''t either start or end on a thursday)
            ''then the correct week number is 1.

            If WeekNumber > 52 AndAlso Not ThursdayFlag Then
                WeekNumber = 1
            End If

            ''If week number is still 0, it means that we are trying to evaluate the week number for a
            ''week that belongs in the previous year (since that week has 3 days or less in our date''s year).
            ''We therefore make a recursive call using the last day of the previous year.

            If WeekNumber = 0 Then
                WeekNumber = getISODay(New DateTime(inDate.Year - 1, DEC, LASTDAYOFDEC))
            End If
            Dim DayNumber As Integer
            DayNumber = FullWeeks * 7 + DaysInFirstWeek + DaysInLastWeek
            Return DayNumber
            'Return WeekNumber
        Catch ex As Exception
            ErrorWriter(ex.Message.ToString)
            Return ""
        End Try
    End Function
End Module

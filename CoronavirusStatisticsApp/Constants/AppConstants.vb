' FILENAME: AppConstants.vb
' AUTOR: El Plan - Nikita Budovei
' CREATED: 28.04.2022
' CHANGED: 01.05.2022
'
' DESCRIPTION: See below
'
' PRECONDITIONS: ...
' SUBSEQUENT CONDITIONS: ...
' RELATED COMPONENTS: ...
''' <summary>
''' Stores global app constants
''' </summary>
Public Module AppConstants
    Public Const ESTONIA_POPULATION As Integer = 1331000            'Number of people who live in Estonia
    Public Const HARJU_POPULATION As Integer = 609515                   'Number of people who live in Harju county 
    Public Const IDA_VURU_POPULATION As Integer = 131913                'Number of people who live in Ida-Viru county
    Public Const LAANE_VURU_POPULATION As Integer = 58402               'Number of people who live in Lääne-Viru county
    Public Const JARVA_POPULATION As Integer = 29817                    'Number of people who live in Järva county
    Public Const JOGEVA_POPULATION As Integer = 28082                   'Number of people who live in Jõgeva county
    Public Const VORU_POPULATION As Integer = 34898                     'Number of people who live in Võru county
    Public Const POLVA_POPULATION As Integer = 24473                    'Number of people who live in Põlva county
    Public Const VALGA_POPULATION As Integer = 27962                    'Number of people who live in Valga county
    Public Const TARTU_POPULATION As Integer = 153912                   'Number of people who live in Tartu county
    Public Const PARNU_POPULATION As Integer = 85760                    'Number of people who live in Pärnu county
    Public Const RAPLA_POPULATION As Integer = 33116                    'Number of people who live in Rapla county
    Public Const LAANE_POPULATION As Integer = 20285                    'Number of people who live in Lääne county
    Public Const SAARE_POPULATION As Integer = 33032                    'Number of people who live in Saare county
    Public Const HIIU_POPULATION As Integer = 9381                      'Number of people who live in Hiiu county
    Public Const VILJANDI_POPULATION As Integer = 45877                 'Number of people who live in Viljandi county
    Public Function GetPopulationByCountyName(name As String)
        Dim names() As String = {"Hiiu maakond", "Saare maakond", "Lääne maakond", "Harju maakond", "Rapla maakond", "Pärnu maakond",
            "Viljandi maakond", "Tartu maakond", "Valga maakond", "Põlva maakond", "Võru maakond", "Jõgeva maakond", "Järva maakond",
            "Lääne-Viru maakond", "Ida-Viru maakond"}
        Dim values() As Integer = {HIIU_POPULATION, SAARE_POPULATION, LAANE_POPULATION, HARJU_POPULATION, RAPLA_POPULATION,
            PARNU_POPULATION, VILJANDI_POPULATION, TARTU_POPULATION, VALGA_POPULATION, POLVA_POPULATION, VORU_POPULATION, JOGEVA_POPULATION,
            JARVA_POPULATION, LAANE_VURU_POPULATION, IDA_VURU_POPULATION}
        For i As Integer = 0 To names.Length - 1
            If (names(i) = name) Then
                Return values(i)
            End If
        Next
        Throw New Exception("Incorrect name input in GetPopulationByCountyName")
    End Function
End Module

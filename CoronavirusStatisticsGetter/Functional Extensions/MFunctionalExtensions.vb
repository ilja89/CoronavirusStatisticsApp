' FILENAME: CFunctionalExtensions.vb
' AUTHOR: El Plan : Ilja Kuznetsov.
' CREATED: 02.03.2022
' CHANGED: 02.03.2022
'
' DESCRIPTION: See below↓↓↓

' Related components: No related components, general use

Imports System.Runtime.CompilerServices

''' <summary>
''' Used to extend some classes functionality
''' </summary>
Public Module MFunctionalExtensions
    ''' <summary>
    ''' Used to safely handle &lt;<see cref="Newtonsoft.Json.Linq.JObject"/>&gt; with
    ''' &lt;<see cref="Newtonsoft.Json.Linq.JObject.SelectToken(String)"/>&gt; function even in case it is empty
    ''' </summary>
    ''' <param name="jsonObject"></param>
    ''' <param name="token"></param>
    ''' <param name="itemIndex"></param>
    ''' <returns>
    ''' &lt;<see cref="Newtonsoft.Json.Linq.JToken"/>&gt; <paramref name="token"/> of &lt;<see cref="Newtonsoft.Json.Linq.JObject"/>&gt; if it exists<br/>
    ''' If <paramref name="itemIndex"/> is entered, will try to return element of &lt;<see cref="Newtonsoft.Json.Linq.JToken"/>&gt;
    ''' with index <paramref name="itemIndex"/> <br/>
    ''' If requested <see cref="Newtonsoft.Json.Linq.JToken"/>&gt; of &lt;<see cref="Newtonsoft.Json.Linq.JObject"/>&gt;
    ''' or its element with index <paramref name="itemIndex"/> doesn't exist, returns <c>Nothing</c>
    ''' </returns>
    <Extension()>
    Public Function Exists(
                          jsonObject As Newtonsoft.Json.Linq.JObject,
                          token As String,
                          Optional itemIndex As Integer = -1
                          ) As Newtonsoft.Json.Linq.JToken
        If (jsonObject Is Nothing) Then
            Return Nothing
        Else
            If (itemIndex <> -1) Then
                If (jsonObject.SelectToken(token).Count > itemIndex) Then
                    Return jsonObject.SelectToken(token)(itemIndex)
                Else
                    Return Nothing
                End If
            Else
                If (jsonObject.SelectToken(token) IsNot Nothing) Then
                    Return jsonObject.SelectToken(token)
                Else
                    Return Nothing
                End If
            End If
        End If
    End Function
    ''' <summary>
    ''' Used to safely handle &lt;<see cref="Newtonsoft.Json.Linq.JToken"/>&gt; with
    ''' &lt;<see cref="Newtonsoft.Json.Linq.JToken.SelectToken(String)"/>&gt; function even in case it is empty
    ''' </summary>
    ''' <param name="jsonToken"></param>
    ''' <param name="token"></param>
    ''' <param name="itemIndex"></param>
    ''' <returns>
    ''' &lt;<see cref="Newtonsoft.Json.Linq.JToken"/>&gt; <paramref name="token"/> of &lt;<see cref="Newtonsoft.Json.Linq.JToken"/>&gt; if it exists<br/>
    ''' If <paramref name="itemIndex"/> is entered, will try to return element of &lt;<see cref="Newtonsoft.Json.Linq.JToken"/>&gt;
    ''' with index <paramref name="itemIndex"/> <br/>
    ''' If requested <see cref="Newtonsoft.Json.Linq.JToken"/>&gt; of &lt;<see cref="Newtonsoft.Json.Linq.JToken"/>&gt;
    ''' or its element with index <paramref name="itemIndex"/> doesn't exist, returns <c>Nothing</c>
    ''' </returns>
    <Extension()>
    Public Function Exists(
                          jsonToken As Newtonsoft.Json.Linq.JToken,
                          token As String,
                          Optional itemIndex As Integer = -1
                          ) As Newtonsoft.Json.Linq.JToken
        If (jsonToken Is Nothing) Then
            Return Nothing
        Else
            If (itemIndex <> -1) Then
                If (jsonToken.SelectToken(token).Count > itemIndex) Then
                    Return jsonToken.SelectToken(token)(itemIndex)
                Else
                    Return Nothing
                End If
            Else
                If (jsonToken.SelectToken(token) IsNot Nothing) Then
                    Return jsonToken.SelectToken(token)
                Else
                    Return Nothing
                End If
            End If
        End If
    End Function
End Module
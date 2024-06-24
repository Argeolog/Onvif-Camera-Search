Imports System.Collections.ObjectModel
Imports System.Data.SqlTypes
Imports System.IO
Imports System.Net
Imports System.Xml

Public Class Saat_Ayarlari
	Dim ZamanBolgeleri As ReadOnlyCollection(Of TimeZoneInfo) = TimeZoneInfo.GetSystemTimeZones()

	Private Sub Saat_Ayarlari_Load(sender As Object, e As EventArgs) Handles MyBase.Load
		Zaman_Gmt.Items.AddRange(ZamanBolgeleri.ToArray)
		Kaynak_Combobox.SelectedIndex = 2
		Zaman_Gmt.SelectedIndex = 76
	End Sub



	Private Sub Saat_Ayarla_Buton_Click(sender As Object, e As EventArgs) Handles Saat_Ayarla_Buton.Click

		Try


			Dim url As String = "http://" & ip_Adres_Text.Text & ":" & Port_Text.Text & "/onvif/device_service"
			Dim request As HttpWebRequest = CType(WebRequest.Create(url), HttpWebRequest)
			request.ContentType = "application/soap+xml; charset=utf-8"
			request.Method = "POST"
			Dim Credentials As New NetworkCredential(Kullanici_Adi_Text.Text, Sifre_Text.Text)
			Dim CCache As New CredentialCache From {
			{New Uri(url), "Digest", Credentials}
}
			request.Credentials = CCache

			Dim Tarih As DateTime = DateTime.Now.ToUniversalTime
			Dim NTPorManual As String = "Manual"
			If Kaynak_Combobox.SelectedIndex = 0 Then
				NTPorManual = "NTP"
			ElseIf Kaynak_Combobox.SelectedIndex = 1 Then
				Tarih = Tarih_TimePicker.Value.ToUniversalTime
			End If
			Dim TimeZone As TimeZoneInfo = (From tz In ZamanBolgeleri
											Where tz.DisplayName = Zaman_Gmt.Text
											Select tz).FirstOrDefault()

			Dim ZamanBolgesi As String = ConvertToPosixTZ(TimeZone)
			Dim DataStr As String = $"<?xml version=""1.0"" encoding=""UTF-8""?>
		<SOAP-ENV:Envelope
		xmlns:SOAP-ENV=""http://schemas.xmlsoap.org/soap/envelope/""
		xmlns:SOAP-ENC=""http://schemas.xmlsoap.org/soap/encoding/""
		xmlns:tt=""http://www.onvif.org/ver10/schema""
		xmlns:tds=""http://www.onvif.org/ver10/device/wsdl""
		xmlns:tse=""http://www.onvif.org/ver10/search/wsdl"">
		<SOAP-ENV:Header>
		</SOAP-ENV:Header>
		<SOAP-ENV:Body>
		<tds:SetSystemDateAndTime>
		<tds:DateTimeType>{NTPorManual}</tds:DateTimeType>
		<tds:DaylightSavings>false</tds:DaylightSavings>
		<tds:TimeZone>
		<tt:TZ>{ZamanBolgesi}</tt:TZ>
		</tds:TimeZone>
		<tds:UTCDateTime>
		<tt:Time>
		<tt:Hour>{Tarih.Hour}</tt:Hour>
		<tt:Minute>{Tarih.Minute}</tt:Minute>
		<tt:Second>{Tarih.Second}</tt:Second>
		</tt:Time>
		<tt:Date>
		<tt:Year>{Tarih.Year}</tt:Year>
		<tt:Month>{Tarih.Month}</tt:Month>
		<tt:Day>{Tarih.Day}</tt:Day>
		</tt:Date>
		</tds:UTCDateTime>
		</tds:SetSystemDateAndTime>
		</SOAP-ENV:Body>
		</SOAP-ENV:Envelope>"

			Using streamWriter As New StreamWriter(request.GetRequestStream())
				streamWriter.Write(DataStr)
				streamWriter.Flush()
				streamWriter.Close()
			End Using


			Dim GelenData As String = ""
			Dim response As HttpWebResponse = CType(request.GetResponse(), HttpWebResponse)
			Using streamReader As New StreamReader(response.GetResponseStream())
				GelenData = streamReader.ReadToEnd()
			End Using

			If response.StatusCode = HttpStatusCode.OK Then
				If GelenData.Contains("SetSystemDateAndTimeResponse") Then
					MsgBox("Saat Gönderme Başarılı.", 64, "Bilgi")
				Else
					MsgBox("Saat Göndermede Hata. Gelen Data" & vbCrLf & GelenData, 16, "Hata")
				End If
			End If

		Catch ex As WebException
			MsgBox(ex.Message)
		End Try

	End Sub

	Private Sub Kaynak_Combobox_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Kaynak_Combobox.SelectedIndexChanged
		If Kaynak_Combobox.SelectedIndex = 1 Then
			Tarih_TimePicker.Enabled = True
		Else
			Tarih_TimePicker.Enabled = False
		End If

	End Sub

	Function ConvertToPosixTZ(timeZone As TimeZoneInfo) As String
		Dim baseOffset As TimeSpan = timeZone.BaseUtcOffset
		Dim offsetHours As Integer = Math.Abs(baseOffset.Hours)
		Dim offsetMinutes As Integer = Math.Abs(baseOffset.Minutes)
		Dim sign As String = If(baseOffset.Hours < 0, "-", "+")
		Dim posixTz As String = $"GMT{sign}{offsetHours:00}:{offsetMinutes:00}PDT,M1.1.1/00:00:00,M1.1.2/00:00:00"
		Return posixTz
	End Function

	Private Sub Saati_Oku_Buton_Click(sender As Object, e As EventArgs) Handles Saati_Oku_Buton.Click
		Try


			Dim url As String = "http://" & ip_Adres_Text.Text & ":" & Port_Text.Text & "/onvif/device_service"
			Dim request As HttpWebRequest = CType(WebRequest.Create(url), HttpWebRequest)
			request.ContentType = "application/soap+xml; charset=utf-8"
			request.Method = "POST"
			Dim Credentials As New NetworkCredential(Kullanici_Adi_Text.Text, Sifre_Text.Text)
			Dim CCache As New CredentialCache From {
			{New Uri(url), "Digest", Credentials}
		}
			request.Credentials = CCache

			Dim DataStr As String = $"<?xml version=""1.0"" encoding=""UTF-8""?>
		<SOAP-ENV:Envelope
		xmlns:SOAP-ENV=""http://schemas.xmlsoap.org/soap/envelope/""
		xmlns:SOAP-ENC=""http://schemas.xmlsoap.org/soap/encoding/""
		xmlns:tt=""http://www.onvif.org/ver10/schema""
		xmlns:tds=""http://www.onvif.org/ver10/device/wsdl""
		xmlns:tse=""http://www.onvif.org/ver10/search/wsdl"">
	    <SOAP-ENV:Header>
        </SOAP-ENV:Header>
        <SOAP-ENV:Body>
		<tds:GetSystemDateAndTime>
	    </tds:GetSystemDateAndTime>
		</SOAP-ENV:Body>
		</SOAP-ENV:Envelope>"


			Using streamWriter As New StreamWriter(request.GetRequestStream())
				streamWriter.Write(DataStr)
				streamWriter.Flush()
				streamWriter.Close()
			End Using

			Dim GelenData As String = ""
			Dim response As HttpWebResponse = CType(request.GetResponse(), HttpWebResponse)
			Using streamReader As New StreamReader(response.GetResponseStream())
				GelenData = streamReader.ReadToEnd()
			End Using


			Dim xmlDoc As New XmlDocument()
			xmlDoc.LoadXml(GelenData)
			Dim nsManager As New XmlNamespaceManager(xmlDoc.NameTable)
			nsManager.AddNamespace("s", "http://www.w3.org/2003/05/soap-envelope")
			nsManager.AddNamespace("tt", "http://www.onvif.org/ver10/schema")
			Dim Saat As Integer = CInt(xmlDoc.SelectSingleNode("//tt:LocalDateTime/tt:Time/tt:Hour", nsManager).InnerText)
			Dim Dakika As Integer = CInt(xmlDoc.SelectSingleNode("//tt:LocalDateTime/tt:Time/tt:Minute", nsManager).InnerText)
			Dim Saniye As Integer = CInt(xmlDoc.SelectSingleNode("//tt:LocalDateTime/tt:Time/tt:Second", nsManager).InnerText)
			Dim Yil As Integer = CInt(xmlDoc.SelectSingleNode("//tt:LocalDateTime/tt:Date/tt:Year", nsManager).InnerText)
			Dim Ay As Integer = CInt(xmlDoc.SelectSingleNode("//tt:LocalDateTime/tt:Date/tt:Month", nsManager).InnerText)
			Dim Gun As Integer = CInt(xmlDoc.SelectSingleNode("//tt:LocalDateTime/tt:Date/tt:Day", nsManager).InnerText)
			Dim NtpOrManual As String = xmlDoc.SelectSingleNode("//tt:DateTimeType", nsManager).InnerText
			Dim GMT As String = xmlDoc.SelectSingleNode("//tt:TZ", nsManager).InnerText
			If GMT.Length > 9 Then
				Gmt_Label_Text.Text = GMT.Substring(0, 9)
			Else
				Gmt_Label_Text.Text = "-"
			End If

			If NtpOrManual = "NTP" Then
				NTP_Aktif_Check.Checked = True
			Else
				NTP_Aktif_Check.Checked = False
			End If
			Okunan_Saat_Text.Text = Gun.ToString("00") & "." & Ay.ToString("00") & ":" & Yil.ToString("00") & " " & Saat.ToString("00") & ":" & Dakika.ToString("00") & ":" & Saniye.ToString("00")


		Catch ex As Exception
			MsgBox(ex.Message)
		End Try








	End Sub
End Class
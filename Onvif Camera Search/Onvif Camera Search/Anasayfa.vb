Imports System.Net
Imports System.Net.Http
Imports System.Net.NetworkInformation
Imports System.Net.Sockets
Imports System.Text
Imports System.Windows.Forms.VisualStyles.VisualStyleElement
Imports System.Xml
Imports System.Threading
Imports System.IO
Imports System.Data.SqlTypes
Imports System.Web


Public Class Anasayfa


	Dim DahuaUDP As UdpClient
	Dim BroadCastAdres As IPAddress = Net.IPAddress.Parse("255.255.255.255")
	Dim DahuaPort As Integer = 5050
	Dim DahuaIPEndPoint As IPEndPoint

	Dim HikvisonUDP As UdpClient
	Dim MultiCastAdres As IPAddress = Net.IPAddress.Parse("239.255.255.250")
	Dim MultiCastPort As Integer = 37020
	Dim HikvisonIPEndPoint As IPEndPoint


	Dim OnvifUDP As UdpClient
	Dim OnvifIPEndPoint As IPEndPoint
	Dim OnvifPort As Integer = 3702
	Dim TimeOutSay As Integer
	Dim KameraList As New List(Of Kameralar)


	Class Kameralar
		Property Marka As String = "No-Name"
		Property Model As String = ""
		Property IpAdres As String = "0.0.0.0"
		Property AltAgGecidi As String = "0.0.0.0"
		Property AltAgMaskesi As String = "0.0.0.0"
		Property Port As String = 80
		Property MacAdres As String = "FF:FF:FF:FF:FF:FF"
		Property SerialNo As String = "-"
		Property Versiyon As String = "-"
		Property IpCakismasi As Boolean = False

	End Class


	Private Sub Anasayfa_Load(sender As Object, e As EventArgs) Handles MyBase.Load

		Kamera_Listview.View = View.Details
		Kamera_Listview.Columns.Add("Sira", 50, HorizontalAlignment.Left)
		Kamera_Listview.Columns.Add("Marka", 100, HorizontalAlignment.Left)
		Kamera_Listview.Columns.Add("Model", 100, HorizontalAlignment.Left)
		Kamera_Listview.Columns.Add("ipAdres", 100, HorizontalAlignment.Left)
		Kamera_Listview.Columns.Add("Port", 100, HorizontalAlignment.Left)
		Kamera_Listview.Columns.Add("AltAgMaskesi", 100, HorizontalAlignment.Left)
		Kamera_Listview.Columns.Add("AltAgGecidi", 100, HorizontalAlignment.Left)
		Kamera_Listview.Columns.Add("MacAdres", 100, HorizontalAlignment.Left)
		Kamera_Listview.Columns.Add("Versiyon", 100, HorizontalAlignment.Left)
		Kamera_Listview.Columns.Add("SerialNo", 100, HorizontalAlignment.Left)

		Ara_Buton.PerformClick()

	End Sub



	Private Sub DahuaReceiveCallback(ar As IAsyncResult)
		Try

			Dim DataByteArray As Byte() = DahuaUDP.EndReceive(ar, DahuaIPEndPoint)

			TimeOutSay = 0
			Dim Data As String = ""
			Dim YeniKamera As New Kameralar With {
				.MacAdres = ""
			}

			For ix = 120 To 136
				YeniKamera.MacAdres &= ChrW(DataByteArray(ix))
			Next

			For ix = 137 To DataByteArray.Count - 1
				Data &= ChrW(DataByteArray(ix))
			Next

			Data = Data.Replace(vbLf, "")
			Dim SplitData() As String = Data.Split(vbCrLf)
			Dim KameraModel As String = SplitData(0)
			YeniKamera.IpAdres = DataByteArray(56).ToString & "." & DataByteArray(57).ToString & "." & DataByteArray(58).ToString & "." & DataByteArray(59).ToString
			YeniKamera.AltAgMaskesi = DataByteArray(60).ToString & "." & DataByteArray(61).ToString & "." & DataByteArray(62).ToString & "." & DataByteArray(63).ToString
			YeniKamera.AltAgGecidi = DataByteArray(64).ToString & "." & DataByteArray(65).ToString & "." & DataByteArray(66).ToString & "." & DataByteArray(67).ToString
			YeniKamera.Marka = "Dahua"
			YeniKamera.Model = KameraModel.Substring(0, KameraModel.IndexOf("Name"))
			YeniKamera.MacAdres = YeniKamera.MacAdres.ToUpper

			For ir = 0 To SplitData.Count - 1
				If SplitData(ir).Contains("SerialNo") Then
					YeniKamera.SerialNo = SplitData(ir).Replace("SerialNo:", "")

				ElseIf SplitData(ir).Contains("Version") Then
					YeniKamera.Versiyon = SplitData(ir).Replace("Version:", "")
				End If
			Next

			Dim KameraVar As Boolean = KameraList.Any(Function(kamera) kamera.MacAdres = YeniKamera.MacAdres)
			If KameraVar = False Then
				KameraList.Add(YeniKamera)
			End If
			DahuaUDP.BeginReceive(New AsyncCallback(AddressOf DahuaReceiveCallback), Nothing)
		Catch ex As Exception
			MsgBox(ex.Message)
		End Try
	End Sub

	Private Sub HikvisionReceiveCallback(ar As IAsyncResult)

		Try


			Dim GelenBytes As Byte() = HikvisonUDP.EndReceive(ar, HikvisonIPEndPoint)
			Dim Data As String = Encoding.ASCII.GetString(GelenBytes)


			TimeOutSay = 0

			Dim xmlDoc As New XmlDocument()
			xmlDoc.LoadXml(Data)

			Dim YeniKamera As New Kameralar With {
				.Marka = "Hikvision",
				.Model = xmlDoc.SelectSingleNode("/ProbeMatch/DeviceDescription").InnerText,
				.IpAdres = xmlDoc.SelectSingleNode("/ProbeMatch/IPv4Address").InnerText,
				.AltAgMaskesi = xmlDoc.SelectSingleNode("/ProbeMatch/IPv4SubnetMask").InnerText,
				.AltAgGecidi = xmlDoc.SelectSingleNode("/ProbeMatch/IPv4Gateway").InnerText,
				.Port = xmlDoc.SelectSingleNode("/ProbeMatch/HttpPort").InnerText,
				.MacAdres = xmlDoc.SelectSingleNode("/ProbeMatch/MAC").InnerText.ToUpper,
				.SerialNo = xmlDoc.SelectSingleNode("/ProbeMatch/DeviceSN").InnerText,
				.Versiyon = xmlDoc.SelectSingleNode("/ProbeMatch/SoftwareVersion").InnerText
			  }

			Dim KameraVar As Boolean = KameraList.Any(Function(kamera) kamera.MacAdres = YeniKamera.MacAdres)
			If KameraVar = False Then
				KameraList.Add(YeniKamera)
			End If

			HikvisonUDP.BeginReceive(New AsyncCallback(AddressOf HikvisionReceiveCallback), Nothing)
		Catch ex As Exception
			MsgBox(ex.Message)
		End Try
	End Sub

	Private Sub OnvifReceiveCallback(ar As IAsyncResult)
		Try


			Dim GelenBytes As Byte() = OnvifUDP.EndReceive(ar, OnvifIPEndPoint)
			Dim Data As String = Encoding.ASCII.GetString(GelenBytes)

			TimeOutSay = 0

			Dim YeniKamera As New Kameralar
			Dim xmlDoc As New XmlDocument()
			xmlDoc.LoadXml(Data)
			Dim namespaceManager As New XmlNamespaceManager(xmlDoc.NameTable)
			namespaceManager.AddNamespace("s", "http://www.w3.org/2003/05/soap-envelope")
			namespaceManager.AddNamespace("d", "http://schemas.xmlsoap.org/ws/2005/04/discovery")

			Dim scopesNode As XmlNode = xmlDoc.SelectSingleNode("//d:Scopes", namespaceManager)


			If scopesNode IsNot Nothing Then
				Dim scopes As String() = scopesNode.InnerText.Split(" "c)
				For Each scope As String In scopes
					If scope.StartsWith("onvif://www.onvif.org/name/") Then
						YeniKamera.Marka = scope.Replace("onvif://www.onvif.org/name/", "")
					End If
				Next
			End If

			YeniKamera.Marka = HttpUtility.UrlDecode(YeniKamera.Marka)

			If YeniKamera.Marka.Contains("Dahua") OrElse YeniKamera.Marka.Contains("Hikvision") OrElse YeniKamera.Marka.Contains("HIKVISION") Then
				Exit Sub
			End If


			Dim xAddrsNode As XmlNode = xmlDoc.SelectSingleNode("//d:XAddrs", namespaceManager)
			If xAddrsNode IsNot Nothing Then
				Dim uri As New Uri(xAddrsNode.InnerText)
				YeniKamera.IpAdres = uri.Host
				YeniKamera.Port = uri.Port
			End If
			KameraList.Add(YeniKamera)
			OnvifUDP.BeginReceive(New AsyncCallback(AddressOf OnvifReceiveCallback), Nothing)
		Catch ex As Exception
			MsgBox(ex.Message)
		End Try
	End Sub


	Private Async Sub Ara_Buton_Click(sender As Object, e As EventArgs) Handles Ara_Buton.Click

		If Me.UseWaitCursor = False Then

			KameraList.Clear()
			TimeOutSay = 0
			Kamera_Listview.Items.Clear()
			Timeout_Timer.Enabled = True


			Dim networkInterfaces() As NetworkInterface = NetworkInterface.GetAllNetworkInterfaces()
			For Each networkInterface As NetworkInterface In networkInterfaces
				If networkInterface.NetworkInterfaceType = NetworkInterfaceType.Ethernet OrElse networkInterface.NetworkInterfaceType = NetworkInterfaceType.Wireless80211 Then
					Dim ipProperties As IPInterfaceProperties = networkInterface.GetIPProperties()
					Dim unicastAddresses As UnicastIPAddressInformationCollection = ipProperties.UnicastAddresses

					If unicastAddresses.Count > 0 Then
						If networkInterface.OperationalStatus = OperationalStatus.Up Then

							For Each unicastAddress As UnicastIPAddressInformation In unicastAddresses

								If Not unicastAddress.Address.AddressFamily = Net.Sockets.AddressFamily.InterNetworkV6 Then

									Dim LokalEndPoint As New IPEndPoint(IPAddress.Parse(unicastAddress.Address.ToString()), 0)

									DahuaUDP = New UdpClient(LokalEndPoint)
									DahuaIPEndPoint = New IPEndPoint(BroadCastAdres, DahuaPort)
									Dim DahuaSeachCode() As Byte = {163, 1, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 2, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}
									DahuaUDP.Send(DahuaSeachCode, DahuaSeachCode.Length, DahuaIPEndPoint)
									DahuaUDP.Send(DahuaSeachCode, DahuaSeachCode.Length, DahuaIPEndPoint)
									DahuaUDP.BeginReceive(New AsyncCallback(AddressOf DahuaReceiveCallback), Nothing)


									HikvisonUDP = New UdpClient(LokalEndPoint)
									Dim HikvisonIPEndPoint As New IPEndPoint(MultiCastAdres, MultiCastPort)
									Dim HikvisionSearchCode() As Byte = Encoding.ASCII.GetBytes("<?xml version=""1.0"" encoding=""utf-8""?><Probe><Uuid>" & Guid.NewGuid().ToString() & "</Uuid><Types>inquiry</Types></Probe>")
									HikvisonUDP.JoinMulticastGroup(MultiCastAdres, LokalEndPoint.Address)
									HikvisonUDP.Send(HikvisionSearchCode, HikvisionSearchCode.Length, HikvisonIPEndPoint)
									HikvisonUDP.Send(HikvisionSearchCode, HikvisionSearchCode.Length, HikvisonIPEndPoint)
									HikvisonUDP.BeginReceive(New AsyncCallback(AddressOf HikvisionReceiveCallback), HikvisonUDP)

									Dim SearchStr As String = "<?xml version=""1.0"" encoding=""UTF-8""?><e:Envelope xmlns:e=""http://www.w3.org/2003/05/soap-envelope""
									xmlns:w=""http://schemas.xmlsoap.org/ws/2004/08/addressing"" xmlns:d=""http://schemas.xmlsoap.org/ws/2005/04/discovery"">
									   <e:Header>
											<w:MessageID>uuid:" & Guid.NewGuid().ToString() & "</w:MessageID>
											<w:To>urn:schemas-xmlsoap-org:ws:2005:04:discovery</w:To>
											<w:Action>http://schemas.xmlsoap.org/ws/2005/04/discovery/Probe</w:Action>
										</e:Header>
										<e:Body>
											<d:Probe>
												<d:Types>dn:NetworkVideoTransmitter</d:Types>
											</d:Probe>
										</e:Body>
									</e:Envelope>"

									OnvifUDP = New UdpClient(LokalEndPoint)
									Dim OnvifIPEndPoint As New IPEndPoint(MultiCastAdres, OnvifPort)
									Dim OnvifSearchCode() As Byte = Encoding.ASCII.GetBytes(SearchStr)
									OnvifUDP.JoinMulticastGroup(MultiCastAdres, LokalEndPoint.Address)
									OnvifUDP.Send(OnvifSearchCode, OnvifSearchCode.Length, OnvifIPEndPoint)
									OnvifUDP.BeginReceive(New AsyncCallback(AddressOf OnvifReceiveCallback), Nothing)

									Await Task.Delay(350) 'Kamara Bulunamazsa, Tüm Network Bloklarında Arayacak...

									If KameraList.Count > 0 Then
										Exit Sub
									End If
								End If
							Next
						End If
					End If
				End If
			Next
		End If
	End Sub


	Sub Satir_Ekle(Sira As Integer, Marka As String, Model As String, ipAdres As String, Port As String, AltAgMaskesi As String, AltAgGecidi As String, MacAdres As String, Versionx As String, SerialNo As String, ipCakismasi As Boolean)

		Dim item As New ListViewItem(Sira)

		If ipCakismasi Then item.BackColor = Color.Tomato

		item.SubItems.Add(Marka)
		item.SubItems.Add(Model)
		item.SubItems.Add(ipAdres)
		item.SubItems.Add(Port)
		item.SubItems.Add(AltAgMaskesi)
		item.SubItems.Add(AltAgGecidi)
		item.SubItems.Add(MacAdres)
		item.SubItems.Add(Versionx)
		item.SubItems.Add(SerialNo)
		Kamera_Listview.Items.Add(item)

	End Sub


	Private Sub Timeout_Timer_Tick(sender As Object, e As EventArgs) Handles Timeout_Timer.Tick
		TimeOutSay += 1
		Me.UseWaitCursor = True
		Me.Cursor = Cursors.WaitCursor

		If TimeOutSay > 4 Then
			Me.UseWaitCursor = False
			Me.Cursor = Cursors.Default
			TimeOutSay = 0
			Timeout_Timer.Stop()
			Dim Sira As Integer = 0


			Dim SortedKameraList = KameraList.OrderBy(Function(k) k.IpAdres).ToList()

			Dim ipGroups = SortedKameraList.GroupBy(Function(k) k.IpAdres).Where(Function(g) g.Count() > 1)

			For Each IpCheck In ipGroups
				For Each Kamera In IpCheck
					Kamera.IpCakismasi = True
				Next
			Next


			For Each Kamx As Kameralar In SortedKameraList
				Sira += 1
				Satir_Ekle(Sira, Kamx.Marka, Kamx.Model, Kamx.IpAdres, Kamx.Port, Kamx.AltAgMaskesi, Kamx.AltAgGecidi, Kamx.MacAdres, Kamx.Versiyon, Kamx.SerialNo, Kamx.IpCakismasi)
			Next
			Kamera_Listview.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent)
			Kamera_Listview.Columns(0).Width = 50
			Kamera_Listview.Columns(4).Width = 60
		End If


	End Sub


	Private Sub Saat_Ayarla_Buton_Click(sender As Object, e As EventArgs) Handles Saat_Ayarla_Buton.Click
		Saat_Ayarlari.Show()
	End Sub

	Private Sub Zoom_Focus_Buton_Click(sender As Object, e As EventArgs) Handles Zoom_Focus_Buton.Click
		Zoom_Focus_Form.Show()
	End Sub
End Class

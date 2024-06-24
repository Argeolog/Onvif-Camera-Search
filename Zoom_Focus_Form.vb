
Imports System
Imports System.IO
Imports System.Net
Imports System.Reflection
Imports System.Threading
Imports System.Windows.Forms
Imports System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock
Imports System.Xml
Imports LibVLCSharp.Shared
Imports SharpGL
Public Class Zoom_Focus_Form
	ReadOnly LicVLCSharp As LibVLCSharp.Shared.LibVLC
	ReadOnly Player As MediaPlayer
	ReadOnly MyLock As New Object()
	Dim Buffer As IntPtr = IntPtr.Zero
	Dim VideoGenislik As UInteger = 1280
	Dim VideoYukseklik As UInteger = 720
	ReadOnly FolderPath As String = Path.Combine(Path.GetDirectoryName(Assembly.GetEntryAssembly().Location), "thumbnails")
	Dim PtzToken As String


	ReadOnly VlcParameters As String() = {
			":network-caching=200",
			":live-caching=200",
			":network-timeout=2000" ' 2000 milisaniye (2 saniye) zaman aşımı
		}

	Public Sub New()
		InitializeComponent()

		Dim CAssembly = Assembly.GetEntryAssembly()
		Dim CDirectory = New FileInfo(CAssembly.Location).DirectoryName
		Dim LDirectory = New DirectoryInfo(System.IO.Path.Combine(CDirectory, "libvlc", If(IntPtr.Size = 4, "win-x86", "win-x64")))

		Core.Initialize(LDirectory.FullName)

		Me.LicVLCSharp = New LibVLC({
				"--intf", "dummy",
				"--vout", "dummy",
				"--no-snapshot-preview",
				"--no-osd",
				"--avcodec-hw=d3d11va",
				"--no-video-title",
				"--no-stats",
				"--skip-frames",
				"--no-audio",
				"--no-sub-autodetect-file"
			})
		Me.Player = New MediaPlayer(Me.LicVLCSharp)
	End Sub


	Private Sub Zoom_in_Buton_Click(sender As Object, e As EventArgs) Handles Zoom_in_Buton.Click
		Zoom_Yap(0.1)
	End Sub


	Private Sub Zoom_out_Buton_Click(sender As Object, e As EventArgs) Handles Zoom_out_Buton.Click
		Zoom_Yap(-0.1)
	End Sub

	Private Sub Focus_Buton_Click(sender As Object, e As EventArgs) Handles Focus_Buton.Click
		Zoom_Yap(0)
	End Sub


	Sub Zoom_Yap(ZoomDeger As Double)



		Try


			Dim url As String = "http://" & ip_Adres_Text.Text & ":" & Port_Text.Text & "/onvif/device_service"
			Dim request As HttpWebRequest = CType(WebRequest.Create(url), HttpWebRequest)
			request.ContentType = "application/soap+xml; charset=utf-8"
			request.Method = "POST"
			request.Timeout = 2000
			Dim Credentials As New NetworkCredential(Kullanici_Adi_Text.Text, Sifre_Text.Text)
			Dim CCache As New CredentialCache From {
			{New Uri(url), "Digest", Credentials}
		}
			request.Credentials = CCache

			Dim DataStr As String = $"<?xml version=""1.0"" encoding=""UTF-8""?>
             <SOAP-ENV:Envelope
              xmlns:SOAP-ENV=""http://schemas.xmlsoap.org/soap/envelope/""
			  xmlns:SOAP-ENC=""http://schemas.xmlsoap.org/soap/encoding/""
			  xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance""
			  xmlns:xsd=""http://www.w3.org/2001/XMLSchema""
			  xmlns:wsa=""http://schemas.xmlsoap.org/ws/2004/08/addressing""
			  xmlns:wsdd=""http://schemas.xmlsoap.org/ws/2005/04/discovery""
			  xmlns:wsa5=""http://www.w3.org/2005/08/addressing""
			  xmlns:xmime=""http://tempuri.org/xmime.xsd""
			  xmlns:tt=""http://www.onvif.org/ver10/schema""
			  xmlns:ns3=""http://www.onvif.org/ver10/pacs""
			  xmlns:tptz=""http://www.onvif.org/ver20/ptz/wsdl""
			  xmlns:trt=""http://www.onvif.org/ver10/media/wsdl""
			  xmlns:trv=""http://www.onvif.org/ver10/receiver/wsdl""
			  xmlns:tse=""http://www.onvif.org/ver10/search/wsdl"">
			<SOAP-ENV:Header>
			 </SOAP-ENV:Header>
			 <SOAP-ENV:Body>
			   <tptz:RelativeMove>
				<tptz:ProfileToken>{PtzToken}</tptz:ProfileToken>
				<tptz:Translation>
				 <tt:PanTilt x=""0.0"" y=""0.0"" space="""">
				 </tt:PanTilt>
				 <tt:Zoom x=""{ZoomDeger}"" space="""">
				 </tt:Zoom>
				</tptz:Translation>
				<tptz:Speed>
				 <tt:PanTilt x=""0.0"" y=""0.0"" space="""">
				 </tt:PanTilt>
				 <tt:Zoom x=""{ZoomDeger}"" space="""">
				 </tt:Zoom>
				</tptz:Speed>
			   </tptz:RelativeMove>
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
				' MsgBox(GelenData)
			End If
		Catch ex As Exception
			MsgBox(ex.Message)
		End Try

	End Sub




	Private Sub Zoom_Focus_Form_Load(sender As Object, e As EventArgs) Handles MyBase.Load
		AddHandler Me.Player.LengthChanged, AddressOf Me.MediaPlayer_LengthChanged
	End Sub
	Private Sub MediaPlayer_LengthChanged(sender As Object, e As MediaPlayerLengthChangedEventArgs)



		Me.Player.SetVideoCallbacks(
				New MediaPlayer.LibVLCVideoLockCb(Function(opaque As IntPtr, planes As IntPtr)
													  Monitor.Enter(MyLock)
													  System.Runtime.InteropServices.Marshal.FreeHGlobal(Me.Buffer)
													  Me.Buffer = System.Runtime.InteropServices.Marshal.AllocHGlobal(CInt(Me.VideoGenislik * Me.VideoYukseklik * 3))
													  System.Runtime.InteropServices.Marshal.WriteIntPtr(planes, Me.Buffer)

													  Return IntPtr.Zero
												  End Function),
				New MediaPlayer.LibVLCVideoUnlockCb(Sub(opaque As IntPtr, picture As IntPtr, planes As IntPtr)
														Monitor.Exit(MyLock)
													End Sub),
				New MediaPlayer.LibVLCVideoDisplayCb(Sub(opaque As IntPtr, picture As IntPtr)
														 Try
															 Me.Invoke(New Action(AddressOf Me.OpenGL_Control.DoRender))
														 Catch
														 End Try
													 End Sub))
		Me.Player.SetVideoFormat("RV24", Me.VideoGenislik, Me.VideoYukseklik, Me.VideoGenislik * 3)
	End Sub
	Private Sub Baglan_Buton_Click(sender As Object, e As EventArgs) Handles Baglan_Buton.Click
		Try
			PtzToken = ""

			Me.Cursor = Cursors.WaitCursor
			Me.Player.Stop()
			Dim RtspAdres As String = $"rtsp://{Kullanici_Adi_Text.Text}:{Sifre_Text.Text}@{ip_Adres_Text.Text}:{Rtsp_Port.Text}"
			Me.Player.Media = New Media(Me.LicVLCSharp, New Uri(RtspAdres), VlcParameters)
			PTZ_Token_Al()
			Me.Player.Play()
			If PtzToken = "" Then
				MsgBox("PTZ Token Alınamadı !")
			End If
		Catch ex As Exception
			MsgBox(ex.Message)
		End Try
		Me.Cursor = Cursors.Default
	End Sub

	Sub PTZ_Token_Al()
		Try


			Dim url As String = "http://" & ip_Adres_Text.Text & ":" & Port_Text.Text & "/onvif/device_service"
			Dim request As HttpWebRequest = CType(WebRequest.Create(url), HttpWebRequest)
			request.ContentType = "application/soap+xml; charset=utf-8"
			request.Method = "POST"
			request.Timeout = 2000
			Dim Credentials As New NetworkCredential(Kullanici_Adi_Text.Text, Sifre_Text.Text)
			Dim CCache As New CredentialCache From {
			{New Uri(url), "Digest", Credentials}
		}
			request.Credentials = CCache

			Dim DataStr As String = $"<?xml version=""1.0"" encoding=""utf-8""?>
<s:Envelope xmlns:s=""http://www.w3.org/2003/05/soap-envelope"" xmlns:trt=""http://www.onvif.org/ver10/media/wsdl"">
    <s:Body>
        <trt:GetProfiles/>
    </s:Body>
</s:Envelope>"


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
				Dim trt As XNamespace = "http://www.onvif.org/ver10/media/wsdl"
				If PtzToken = "" Then
					Video_Cozunurlugunu_Bul(GelenData)
				End If
				PtzToken = XDocument.Parse(GelenData).Descendants(trt + "Profiles").FirstOrDefault()?.Attribute("token")?.Value
			End If
		Catch ex As Exception
			MsgBox(ex.Message)
		End Try
	End Sub

	Sub Video_Cozunurlugunu_Bul(GelenData As String)
		Try


			Dim xmlDoc As New XmlDocument()
			xmlDoc.LoadXml(GelenData)
			Dim nsMgr As New XmlNamespaceManager(xmlDoc.NameTable)
			nsMgr.AddNamespace("s", "http://www.w3.org/2003/05/soap-envelope")
			nsMgr.AddNamespace("tt", "http://www.onvif.org/ver10/schema")
			nsMgr.AddNamespace("trt", "http://www.onvif.org/ver10/media/wsdl")
			Dim widthNode As XmlNode = xmlDoc.SelectSingleNode("//tt:VideoEncoderConfiguration/tt:Resolution/tt:Width", nsMgr)
			Dim heightNode As XmlNode = xmlDoc.SelectSingleNode("//tt:VideoEncoderConfiguration/tt:Resolution/tt:Height", nsMgr)
			VideoGenislik = Convert.ToInt32(widthNode.InnerText)
			VideoYukseklik = Convert.ToInt32(heightNode.InnerText)
		Catch ex As Exception
			MsgBox(ex.Message)
		End Try

	End Sub




	Private Sub OpenGLControl1_OpenGLDraw(sender As Object, args As RenderEventArgs) Handles OpenGL_Control.OpenGLDraw


		Dim GL As SharpGL.OpenGL = Me.OpenGL_Control.OpenGL
		GL.Clear(OpenGL.GL_COLOR_BUFFER_BIT Or OpenGL.GL_DEPTH_BUFFER_BIT)
		GL.MatrixMode(OpenGL.GL_PROJECTION)
		GL.LoadIdentity()
		Monitor.Enter(Me.MyLock)
		Try
			If Me.Buffer <> IntPtr.Zero Then
				Dim xz As Single = CSng(Me.OpenGL_Control.Width) / CSng(Me.VideoGenislik)
				Dim yz As Single = CSng(Me.OpenGL_Control.Height) / CSng(Me.VideoYukseklik)

				gl.RasterPos(-1.0F, 1.0F)
				gl.PixelZoom(xz, -yz)

				gl.DrawPixels(CInt(Me.VideoGenislik), CInt(Me.VideoYukseklik), OpenGL.GL_RGB, OpenGL.GL_UNSIGNED_BYTE, Me.Buffer)
			End If
		Catch ex As Exception
			MsgBox(ex.Message)
		Finally
			Monitor.Exit(MyLock)
		End Try

		gl.Flush()
	End Sub

	Private Sub OpenGLControl1_OpenGLInitialized(sender As Object, e As EventArgs) Handles OpenGL_Control.OpenGLInitialized
		Dim gl As OpenGL = Me.OpenGL_Control.OpenGL
		gl.Enable(OpenGL.GL_BLEND)
		gl.BlendFunc(OpenGL.GL_SRC_ALPHA, OpenGL.GL_ONE_MINUS_SRC_ALPHA)
		gl.ClearColor(0, 0, 0, 0)
	End Sub

End Class
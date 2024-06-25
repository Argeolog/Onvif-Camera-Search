<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Zoom_Focus_Form
	Inherits System.Windows.Forms.Form

	'Form overrides dispose to clean up the component list.
	<System.Diagnostics.DebuggerNonUserCode()>
	Protected Overrides Sub Dispose(ByVal disposing As Boolean)
		Try
			If disposing AndAlso components IsNot Nothing Then
				components.Dispose()
			End If
		Finally
			MyBase.Dispose(disposing)
		End Try
	End Sub

	'Required by the Windows Form Designer
	Private components As System.ComponentModel.IContainer

	'NOTE: The following procedure is required by the Windows Form Designer
	'It can be modified using the Windows Form Designer.  
	'Do not modify it using the code editor.
	<System.Diagnostics.DebuggerStepThrough()>
	Private Sub InitializeComponent()
		Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Zoom_Focus_Form))
		Me.GroupBox1 = New System.Windows.Forms.GroupBox()
		Me.Surekli_Zoom_Checkbox = New System.Windows.Forms.CheckBox()
		Me.Label8 = New System.Windows.Forms.Label()
		Me.Label7 = New System.Windows.Forms.Label()
		Me.Label6 = New System.Windows.Forms.Label()
		Me.Label5 = New System.Windows.Forms.Label()
		Me.Label4 = New System.Windows.Forms.Label()
		Me.Rtsp_Port = New System.Windows.Forms.TextBox()
		Me.Focus_Buton = New System.Windows.Forms.Button()
		Me.Zoom_in_Buton = New System.Windows.Forms.Button()
		Me.Baglan_Buton = New System.Windows.Forms.Button()
		Me.Zoom_out_Buton = New System.Windows.Forms.Button()
		Me.Port_Text = New System.Windows.Forms.TextBox()
		Me.Sifre_Text = New System.Windows.Forms.TextBox()
		Me.ip_Adres_Text = New System.Windows.Forms.TextBox()
		Me.Label1 = New System.Windows.Forms.Label()
		Me.Kullanici_Adi_Text = New System.Windows.Forms.TextBox()
		Me.Label3 = New System.Windows.Forms.Label()
		Me.Label2 = New System.Windows.Forms.Label()
		Me.Vlc_Panel = New System.Windows.Forms.Panel()
		Me.OpenGL_Control = New SharpGL.OpenGLControl()
		Me.GroupBox1.SuspendLayout()
		Me.Vlc_Panel.SuspendLayout()
		CType(Me.OpenGL_Control, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.SuspendLayout()
		'
		'GroupBox1
		'
		Me.GroupBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
			Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
		Me.GroupBox1.Controls.Add(Me.Surekli_Zoom_Checkbox)
		Me.GroupBox1.Controls.Add(Me.Label8)
		Me.GroupBox1.Controls.Add(Me.Label7)
		Me.GroupBox1.Controls.Add(Me.Label6)
		Me.GroupBox1.Controls.Add(Me.Label5)
		Me.GroupBox1.Controls.Add(Me.Label4)
		Me.GroupBox1.Controls.Add(Me.Rtsp_Port)
		Me.GroupBox1.Controls.Add(Me.Focus_Buton)
		Me.GroupBox1.Controls.Add(Me.Zoom_in_Buton)
		Me.GroupBox1.Controls.Add(Me.Baglan_Buton)
		Me.GroupBox1.Controls.Add(Me.Zoom_out_Buton)
		Me.GroupBox1.Controls.Add(Me.Port_Text)
		Me.GroupBox1.Controls.Add(Me.Sifre_Text)
		Me.GroupBox1.Controls.Add(Me.ip_Adres_Text)
		Me.GroupBox1.Controls.Add(Me.Label1)
		Me.GroupBox1.Controls.Add(Me.Kullanici_Adi_Text)
		Me.GroupBox1.Controls.Add(Me.Label3)
		Me.GroupBox1.Controls.Add(Me.Label2)
		Me.GroupBox1.Location = New System.Drawing.Point(12, 470)
		Me.GroupBox1.Name = "GroupBox1"
		Me.GroupBox1.Size = New System.Drawing.Size(796, 133)
		Me.GroupBox1.TabIndex = 10
		Me.GroupBox1.TabStop = False
		Me.GroupBox1.Text = "Kamera Ayarları"
		'
		'Surekli_Zoom_Checkbox
		'
		Me.Surekli_Zoom_Checkbox.AutoSize = True
		Me.Surekli_Zoom_Checkbox.Checked = True
		Me.Surekli_Zoom_Checkbox.CheckState = System.Windows.Forms.CheckState.Checked
		Me.Surekli_Zoom_Checkbox.Location = New System.Drawing.Point(319, 12)
		Me.Surekli_Zoom_Checkbox.Name = "Surekli_Zoom_Checkbox"
		Me.Surekli_Zoom_Checkbox.Size = New System.Drawing.Size(188, 17)
		Me.Surekli_Zoom_Checkbox.TabIndex = 21
		Me.Surekli_Zoom_Checkbox.Text = "Butonu Bırakana Kadar Zoom Yap"
		Me.Surekli_Zoom_Checkbox.UseVisualStyleBackColor = True
		'
		'Label8
		'
		Me.Label8.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
		Me.Label8.AutoSize = True
		Me.Label8.Location = New System.Drawing.Point(705, 30)
		Me.Label8.Name = "Label8"
		Me.Label8.Size = New System.Drawing.Size(61, 13)
		Me.Label8.TabIndex = 20
		Me.Label8.Text = "Auto Focus"
		'
		'Label7
		'
		Me.Label7.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
		Me.Label7.AutoSize = True
		Me.Label7.Location = New System.Drawing.Point(614, 30)
		Me.Label7.Name = "Label7"
		Me.Label7.Size = New System.Drawing.Size(54, 13)
		Me.Label7.TabIndex = 19
		Me.Label7.Text = "Zoom Out"
		'
		'Label6
		'
		Me.Label6.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
		Me.Label6.AutoSize = True
		Me.Label6.Location = New System.Drawing.Point(522, 30)
		Me.Label6.Name = "Label6"
		Me.Label6.Size = New System.Drawing.Size(48, 13)
		Me.Label6.TabIndex = 18
		Me.Label6.Text = "Zoom IN"
		'
		'Label5
		'
		Me.Label5.AutoSize = True
		Me.Label5.Location = New System.Drawing.Point(148, 47)
		Me.Label5.Name = "Label5"
		Me.Label5.Size = New System.Drawing.Size(58, 13)
		Me.Label5.TabIndex = 17
		Me.Label5.Text = "RTSP Port"
		'
		'Label4
		'
		Me.Label4.AutoSize = True
		Me.Label4.Location = New System.Drawing.Point(15, 48)
		Me.Label4.Name = "Label4"
		Me.Label4.Size = New System.Drawing.Size(52, 13)
		Me.Label4.TabIndex = 16
		Me.Label4.Text = "Web Port"
		'
		'Rtsp_Port
		'
		Me.Rtsp_Port.Location = New System.Drawing.Point(212, 45)
		Me.Rtsp_Port.Name = "Rtsp_Port"
		Me.Rtsp_Port.Size = New System.Drawing.Size(101, 20)
		Me.Rtsp_Port.TabIndex = 15
		Me.Rtsp_Port.Text = "554"
		'
		'Focus_Buton
		'
		Me.Focus_Buton.Anchor = System.Windows.Forms.AnchorStyles.Right
		Me.Focus_Buton.Image = CType(resources.GetObject("Focus_Buton.Image"), System.Drawing.Image)
		Me.Focus_Buton.Location = New System.Drawing.Point(692, 52)
		Me.Focus_Buton.Name = "Focus_Buton"
		Me.Focus_Buton.Size = New System.Drawing.Size(87, 64)
		Me.Focus_Buton.TabIndex = 13
		Me.Focus_Buton.UseVisualStyleBackColor = True
		'
		'Zoom_in_Buton
		'
		Me.Zoom_in_Buton.Anchor = System.Windows.Forms.AnchorStyles.Right
		Me.Zoom_in_Buton.Image = CType(resources.GetObject("Zoom_in_Buton.Image"), System.Drawing.Image)
		Me.Zoom_in_Buton.Location = New System.Drawing.Point(506, 52)
		Me.Zoom_in_Buton.Name = "Zoom_in_Buton"
		Me.Zoom_in_Buton.Size = New System.Drawing.Size(87, 64)
		Me.Zoom_in_Buton.TabIndex = 11
		Me.Zoom_in_Buton.UseVisualStyleBackColor = True
		'
		'Baglan_Buton
		'
		Me.Baglan_Buton.Location = New System.Drawing.Point(319, 35)
		Me.Baglan_Buton.Name = "Baglan_Buton"
		Me.Baglan_Buton.Size = New System.Drawing.Size(129, 72)
		Me.Baglan_Buton.TabIndex = 7
		Me.Baglan_Buton.Text = "Bağlan"
		Me.Baglan_Buton.UseVisualStyleBackColor = True
		'
		'Zoom_out_Buton
		'
		Me.Zoom_out_Buton.Anchor = System.Windows.Forms.AnchorStyles.Right
		Me.Zoom_out_Buton.Image = CType(resources.GetObject("Zoom_out_Buton.Image"), System.Drawing.Image)
		Me.Zoom_out_Buton.Location = New System.Drawing.Point(599, 52)
		Me.Zoom_out_Buton.Name = "Zoom_out_Buton"
		Me.Zoom_out_Buton.Size = New System.Drawing.Size(87, 64)
		Me.Zoom_out_Buton.TabIndex = 14
		Me.Zoom_out_Buton.UseVisualStyleBackColor = True
		'
		'Port_Text
		'
		Me.Port_Text.Location = New System.Drawing.Point(79, 44)
		Me.Port_Text.Name = "Port_Text"
		Me.Port_Text.Size = New System.Drawing.Size(63, 20)
		Me.Port_Text.TabIndex = 6
		Me.Port_Text.Text = "80"
		'
		'Sifre_Text
		'
		Me.Sifre_Text.Location = New System.Drawing.Point(79, 96)
		Me.Sifre_Text.Name = "Sifre_Text"
		Me.Sifre_Text.Size = New System.Drawing.Size(234, 20)
		Me.Sifre_Text.TabIndex = 4
		Me.Sifre_Text.Text = "admin123"
		'
		'ip_Adres_Text
		'
		Me.ip_Adres_Text.Location = New System.Drawing.Point(79, 18)
		Me.ip_Adres_Text.Name = "ip_Adres_Text"
		Me.ip_Adres_Text.Size = New System.Drawing.Size(234, 20)
		Me.ip_Adres_Text.TabIndex = 0
		Me.ip_Adres_Text.Text = "192.168.1.110"
		'
		'Label1
		'
		Me.Label1.AutoSize = True
		Me.Label1.Location = New System.Drawing.Point(15, 21)
		Me.Label1.Name = "Label1"
		Me.Label1.Size = New System.Drawing.Size(39, 13)
		Me.Label1.TabIndex = 1
		Me.Label1.Text = "IP-Port"
		'
		'Kullanici_Adi_Text
		'
		Me.Kullanici_Adi_Text.Location = New System.Drawing.Point(79, 70)
		Me.Kullanici_Adi_Text.Name = "Kullanici_Adi_Text"
		Me.Kullanici_Adi_Text.Size = New System.Drawing.Size(234, 20)
		Me.Kullanici_Adi_Text.TabIndex = 2
		Me.Kullanici_Adi_Text.Text = "admin"
		'
		'Label3
		'
		Me.Label3.AutoSize = True
		Me.Label3.Location = New System.Drawing.Point(15, 94)
		Me.Label3.Name = "Label3"
		Me.Label3.Size = New System.Drawing.Size(53, 13)
		Me.Label3.TabIndex = 5
		Me.Label3.Text = "Password"
		'
		'Label2
		'
		Me.Label2.AutoSize = True
		Me.Label2.Location = New System.Drawing.Point(15, 68)
		Me.Label2.Name = "Label2"
		Me.Label2.Size = New System.Drawing.Size(29, 13)
		Me.Label2.TabIndex = 3
		Me.Label2.Text = "User"
		'
		'Vlc_Panel
		'
		Me.Vlc_Panel.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
			Or System.Windows.Forms.AnchorStyles.Left) _
			Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
		Me.Vlc_Panel.Controls.Add(Me.OpenGL_Control)
		Me.Vlc_Panel.Location = New System.Drawing.Point(12, 12)
		Me.Vlc_Panel.Name = "Vlc_Panel"
		Me.Vlc_Panel.Size = New System.Drawing.Size(796, 452)
		Me.Vlc_Panel.TabIndex = 15
		'
		'OpenGL_Control
		'
		Me.OpenGL_Control.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
			Or System.Windows.Forms.AnchorStyles.Left) _
			Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
		Me.OpenGL_Control.DrawFPS = False
		Me.OpenGL_Control.Location = New System.Drawing.Point(0, 0)
		Me.OpenGL_Control.Name = "OpenGL_Control"
		Me.OpenGL_Control.OpenGLVersion = SharpGL.Version.OpenGLVersion.OpenGL2_1
		Me.OpenGL_Control.RenderContextType = SharpGL.RenderContextType.DIBSection
		Me.OpenGL_Control.RenderTrigger = SharpGL.RenderTrigger.Manual
		Me.OpenGL_Control.Size = New System.Drawing.Size(793, 449)
		Me.OpenGL_Control.TabIndex = 15
		'
		'Zoom_Focus_Form
		'
		Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.ClientSize = New System.Drawing.Size(820, 615)
		Me.Controls.Add(Me.GroupBox1)
		Me.Controls.Add(Me.Vlc_Panel)
		Me.Name = "Zoom_Focus_Form"
		Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
		Me.Text = "Zoom-Focus"
		Me.GroupBox1.ResumeLayout(False)
		Me.GroupBox1.PerformLayout()
		Me.Vlc_Panel.ResumeLayout(False)
		CType(Me.OpenGL_Control, System.ComponentModel.ISupportInitialize).EndInit()
		Me.ResumeLayout(False)

	End Sub

	Friend WithEvents GroupBox1 As GroupBox
	Friend WithEvents Port_Text As TextBox
	Friend WithEvents Sifre_Text As TextBox
	Friend WithEvents ip_Adres_Text As TextBox
	Friend WithEvents Label1 As Label
	Friend WithEvents Kullanici_Adi_Text As TextBox
	Friend WithEvents Label3 As Label
	Friend WithEvents Label2 As Label
	Friend WithEvents Zoom_in_Buton As Button
	Friend WithEvents Focus_Buton As Button
	Friend WithEvents Zoom_out_Buton As Button
	Friend WithEvents Baglan_Buton As Button
	Friend WithEvents Vlc_Panel As Panel
	Private WithEvents OpenGL_Control As SharpGL.OpenGLControl
	Friend WithEvents Rtsp_Port As TextBox
	Friend WithEvents Label5 As Label
	Friend WithEvents Label4 As Label
	Friend WithEvents Label8 As Label
	Friend WithEvents Label7 As Label
	Friend WithEvents Label6 As Label
	Friend WithEvents Surekli_Zoom_Checkbox As CheckBox
End Class

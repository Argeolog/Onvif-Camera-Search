<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Saat_Ayarlari
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
		Me.ip_Adres_Text = New System.Windows.Forms.TextBox()
		Me.Label1 = New System.Windows.Forms.Label()
		Me.Label2 = New System.Windows.Forms.Label()
		Me.Kullanici_Adi_Text = New System.Windows.Forms.TextBox()
		Me.Label3 = New System.Windows.Forms.Label()
		Me.Sifre_Text = New System.Windows.Forms.TextBox()
		Me.Saat_Ayarla_Buton = New System.Windows.Forms.Button()
		Me.Tarih_TimePicker = New System.Windows.Forms.DateTimePicker()
		Me.Kaynak_Combobox = New System.Windows.Forms.ComboBox()
		Me.GroupBox1 = New System.Windows.Forms.GroupBox()
		Me.Port_Text = New System.Windows.Forms.TextBox()
		Me.GroupBox2 = New System.Windows.Forms.GroupBox()
		Me.Label6 = New System.Windows.Forms.Label()
		Me.Zaman_Gmt = New System.Windows.Forms.ComboBox()
		Me.Label5 = New System.Windows.Forms.Label()
		Me.Label4 = New System.Windows.Forms.Label()
		Me.Saati_Oku_Buton = New System.Windows.Forms.Button()
		Me.Label8 = New System.Windows.Forms.Label()
		Me.Label7 = New System.Windows.Forms.Label()
		Me.NTP_Aktif_Check = New System.Windows.Forms.CheckBox()
		Me.Label9 = New System.Windows.Forms.Label()
		Me.Gmt_Label_Text = New System.Windows.Forms.Label()
		Me.Okunan_Saat_Text = New System.Windows.Forms.Label()
		Me.GroupBox3 = New System.Windows.Forms.GroupBox()
		Me.GroupBox1.SuspendLayout()
		Me.GroupBox2.SuspendLayout()
		Me.GroupBox3.SuspendLayout()
		Me.SuspendLayout()
		'
		'ip_Adres_Text
		'
		Me.ip_Adres_Text.Location = New System.Drawing.Point(72, 18)
		Me.ip_Adres_Text.Name = "ip_Adres_Text"
		Me.ip_Adres_Text.Size = New System.Drawing.Size(197, 20)
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
		'Label2
		'
		Me.Label2.AutoSize = True
		Me.Label2.Location = New System.Drawing.Point(15, 47)
		Me.Label2.Name = "Label2"
		Me.Label2.Size = New System.Drawing.Size(29, 13)
		Me.Label2.TabIndex = 3
		Me.Label2.Text = "User"
		'
		'Kullanici_Adi_Text
		'
		Me.Kullanici_Adi_Text.Location = New System.Drawing.Point(72, 44)
		Me.Kullanici_Adi_Text.Name = "Kullanici_Adi_Text"
		Me.Kullanici_Adi_Text.Size = New System.Drawing.Size(234, 20)
		Me.Kullanici_Adi_Text.TabIndex = 2
		Me.Kullanici_Adi_Text.Text = "admin"
		'
		'Label3
		'
		Me.Label3.AutoSize = True
		Me.Label3.Location = New System.Drawing.Point(15, 73)
		Me.Label3.Name = "Label3"
		Me.Label3.Size = New System.Drawing.Size(53, 13)
		Me.Label3.TabIndex = 5
		Me.Label3.Text = "Password"
		'
		'Sifre_Text
		'
		Me.Sifre_Text.Location = New System.Drawing.Point(72, 70)
		Me.Sifre_Text.Name = "Sifre_Text"
		Me.Sifre_Text.Size = New System.Drawing.Size(234, 20)
		Me.Sifre_Text.TabIndex = 4
		Me.Sifre_Text.Text = "admin123"
		'
		'Saat_Ayarla_Buton
		'
		Me.Saat_Ayarla_Buton.Location = New System.Drawing.Point(7, 103)
		Me.Saat_Ayarla_Buton.Name = "Saat_Ayarla_Buton"
		Me.Saat_Ayarla_Buton.Size = New System.Drawing.Size(299, 45)
		Me.Saat_Ayarla_Buton.TabIndex = 6
		Me.Saat_Ayarla_Buton.Text = "Saat Ayarla"
		Me.Saat_Ayarla_Buton.UseVisualStyleBackColor = True
		'
		'Tarih_TimePicker
		'
		Me.Tarih_TimePicker.CustomFormat = "dd.MM.yyyy HH:mm:ss"
		Me.Tarih_TimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom
		Me.Tarih_TimePicker.Location = New System.Drawing.Point(72, 77)
		Me.Tarih_TimePicker.Name = "Tarih_TimePicker"
		Me.Tarih_TimePicker.Size = New System.Drawing.Size(234, 20)
		Me.Tarih_TimePicker.TabIndex = 7
		'
		'Kaynak_Combobox
		'
		Me.Kaynak_Combobox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
		Me.Kaynak_Combobox.FormattingEnabled = True
		Me.Kaynak_Combobox.Items.AddRange(New Object() {"Otomatik (NTP)", "Manuel", "PC Saati"})
		Me.Kaynak_Combobox.Location = New System.Drawing.Point(72, 26)
		Me.Kaynak_Combobox.Name = "Kaynak_Combobox"
		Me.Kaynak_Combobox.Size = New System.Drawing.Size(234, 21)
		Me.Kaynak_Combobox.TabIndex = 8
		'
		'GroupBox1
		'
		Me.GroupBox1.Controls.Add(Me.Port_Text)
		Me.GroupBox1.Controls.Add(Me.Sifre_Text)
		Me.GroupBox1.Controls.Add(Me.ip_Adres_Text)
		Me.GroupBox1.Controls.Add(Me.Label1)
		Me.GroupBox1.Controls.Add(Me.Kullanici_Adi_Text)
		Me.GroupBox1.Controls.Add(Me.Label3)
		Me.GroupBox1.Controls.Add(Me.Label2)
		Me.GroupBox1.Location = New System.Drawing.Point(12, 12)
		Me.GroupBox1.Name = "GroupBox1"
		Me.GroupBox1.Size = New System.Drawing.Size(328, 100)
		Me.GroupBox1.TabIndex = 9
		Me.GroupBox1.TabStop = False
		Me.GroupBox1.Text = "Kamera Ayarları"
		'
		'Port_Text
		'
		Me.Port_Text.Location = New System.Drawing.Point(275, 19)
		Me.Port_Text.Name = "Port_Text"
		Me.Port_Text.Size = New System.Drawing.Size(31, 20)
		Me.Port_Text.TabIndex = 6
		Me.Port_Text.Text = "80"
		'
		'GroupBox2
		'
		Me.GroupBox2.Controls.Add(Me.Label6)
		Me.GroupBox2.Controls.Add(Me.Zaman_Gmt)
		Me.GroupBox2.Controls.Add(Me.Label5)
		Me.GroupBox2.Controls.Add(Me.Label4)
		Me.GroupBox2.Controls.Add(Me.Saat_Ayarla_Buton)
		Me.GroupBox2.Controls.Add(Me.Kaynak_Combobox)
		Me.GroupBox2.Controls.Add(Me.Tarih_TimePicker)
		Me.GroupBox2.Location = New System.Drawing.Point(12, 121)
		Me.GroupBox2.Name = "GroupBox2"
		Me.GroupBox2.Size = New System.Drawing.Size(328, 160)
		Me.GroupBox2.TabIndex = 10
		Me.GroupBox2.TabStop = False
		Me.GroupBox2.Text = "Saat Ayarla"
		'
		'Label6
		'
		Me.Label6.AutoSize = True
		Me.Label6.Location = New System.Drawing.Point(4, 56)
		Me.Label6.Name = "Label6"
		Me.Label6.Size = New System.Drawing.Size(31, 13)
		Me.Label6.TabIndex = 10
		Me.Label6.Text = "GMT"
		'
		'Zaman_Gmt
		'
		Me.Zaman_Gmt.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
		Me.Zaman_Gmt.FormattingEnabled = True
		Me.Zaman_Gmt.Location = New System.Drawing.Point(72, 52)
		Me.Zaman_Gmt.Name = "Zaman_Gmt"
		Me.Zaman_Gmt.Size = New System.Drawing.Size(234, 21)
		Me.Zaman_Gmt.TabIndex = 11
		'
		'Label5
		'
		Me.Label5.AutoSize = True
		Me.Label5.Location = New System.Drawing.Point(4, 81)
		Me.Label5.Name = "Label5"
		Me.Label5.Size = New System.Drawing.Size(56, 13)
		Me.Label5.TabIndex = 9
		Me.Label5.Text = "Tarih Saat"
		'
		'Label4
		'
		Me.Label4.AutoSize = True
		Me.Label4.Location = New System.Drawing.Point(4, 29)
		Me.Label4.Name = "Label4"
		Me.Label4.Size = New System.Drawing.Size(68, 13)
		Me.Label4.TabIndex = 6
		Me.Label4.Text = "Saat Kaynak"
		'
		'Saati_Oku_Buton
		'
		Me.Saati_Oku_Buton.Location = New System.Drawing.Point(7, 103)
		Me.Saati_Oku_Buton.Name = "Saati_Oku_Buton"
		Me.Saati_Oku_Buton.Size = New System.Drawing.Size(299, 45)
		Me.Saati_Oku_Buton.TabIndex = 6
		Me.Saati_Oku_Buton.Text = "Saati Oku"
		Me.Saati_Oku_Buton.UseVisualStyleBackColor = True
		'
		'Label8
		'
		Me.Label8.AutoSize = True
		Me.Label8.Location = New System.Drawing.Point(4, 81)
		Me.Label8.Name = "Label8"
		Me.Label8.Size = New System.Drawing.Size(56, 13)
		Me.Label8.TabIndex = 9
		Me.Label8.Text = "Tarih Saat"
		'
		'Label7
		'
		Me.Label7.AutoSize = True
		Me.Label7.Location = New System.Drawing.Point(4, 56)
		Me.Label7.Name = "Label7"
		Me.Label7.Size = New System.Drawing.Size(31, 13)
		Me.Label7.TabIndex = 10
		Me.Label7.Text = "GMT"
		'
		'NTP_Aktif_Check
		'
		Me.NTP_Aktif_Check.AutoCheck = False
		Me.NTP_Aktif_Check.AutoSize = True
		Me.NTP_Aktif_Check.Location = New System.Drawing.Point(72, 29)
		Me.NTP_Aktif_Check.Name = "NTP_Aktif_Check"
		Me.NTP_Aktif_Check.Size = New System.Drawing.Size(72, 17)
		Me.NTP_Aktif_Check.TabIndex = 12
		Me.NTP_Aktif_Check.Text = "NTP Aktif"
		Me.NTP_Aktif_Check.UseVisualStyleBackColor = True
		'
		'Label9
		'
		Me.Label9.AutoSize = True
		Me.Label9.Location = New System.Drawing.Point(6, 30)
		Me.Label9.Name = "Label9"
		Me.Label9.Size = New System.Drawing.Size(29, 13)
		Me.Label9.TabIndex = 13
		Me.Label9.Text = "NTP"
		'
		'Gmt_Label_Text
		'
		Me.Gmt_Label_Text.AutoSize = True
		Me.Gmt_Label_Text.Location = New System.Drawing.Point(69, 56)
		Me.Gmt_Label_Text.Name = "Gmt_Label_Text"
		Me.Gmt_Label_Text.Size = New System.Drawing.Size(10, 13)
		Me.Gmt_Label_Text.TabIndex = 14
		Me.Gmt_Label_Text.Text = "-"
		'
		'Okunan_Saat_Text
		'
		Me.Okunan_Saat_Text.AutoSize = True
		Me.Okunan_Saat_Text.Location = New System.Drawing.Point(69, 81)
		Me.Okunan_Saat_Text.Name = "Okunan_Saat_Text"
		Me.Okunan_Saat_Text.Size = New System.Drawing.Size(10, 13)
		Me.Okunan_Saat_Text.TabIndex = 15
		Me.Okunan_Saat_Text.Text = "-"
		'
		'GroupBox3
		'
		Me.GroupBox3.Controls.Add(Me.Okunan_Saat_Text)
		Me.GroupBox3.Controls.Add(Me.Gmt_Label_Text)
		Me.GroupBox3.Controls.Add(Me.Label9)
		Me.GroupBox3.Controls.Add(Me.NTP_Aktif_Check)
		Me.GroupBox3.Controls.Add(Me.Label7)
		Me.GroupBox3.Controls.Add(Me.Label8)
		Me.GroupBox3.Controls.Add(Me.Saati_Oku_Buton)
		Me.GroupBox3.Location = New System.Drawing.Point(12, 290)
		Me.GroupBox3.Name = "GroupBox3"
		Me.GroupBox3.Size = New System.Drawing.Size(328, 160)
		Me.GroupBox3.TabIndex = 12
		Me.GroupBox3.TabStop = False
		Me.GroupBox3.Text = "Saat Oku"
		'
		'Saat_Ayarlari
		'
		Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.ClientSize = New System.Drawing.Size(349, 459)
		Me.Controls.Add(Me.GroupBox3)
		Me.Controls.Add(Me.GroupBox1)
		Me.Controls.Add(Me.GroupBox2)
		Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
		Me.MaximizeBox = False
		Me.Name = "Saat_Ayarlari"
		Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
		Me.Text = "Onvif Saat Ayarları"
		Me.GroupBox1.ResumeLayout(False)
		Me.GroupBox1.PerformLayout()
		Me.GroupBox2.ResumeLayout(False)
		Me.GroupBox2.PerformLayout()
		Me.GroupBox3.ResumeLayout(False)
		Me.GroupBox3.PerformLayout()
		Me.ResumeLayout(False)

	End Sub

	Friend WithEvents ip_Adres_Text As TextBox
	Friend WithEvents Label1 As Label
	Friend WithEvents Label2 As Label
	Friend WithEvents Kullanici_Adi_Text As TextBox
	Friend WithEvents Label3 As Label
	Friend WithEvents Sifre_Text As TextBox
	Friend WithEvents Saat_Ayarla_Buton As Button
	Friend WithEvents Tarih_TimePicker As DateTimePicker
	Friend WithEvents Kaynak_Combobox As ComboBox
	Friend WithEvents GroupBox1 As GroupBox
	Friend WithEvents GroupBox2 As GroupBox
	Friend WithEvents Label5 As Label
	Friend WithEvents Label4 As Label
	Friend WithEvents Port_Text As TextBox
	Friend WithEvents Label6 As Label
	Friend WithEvents Zaman_Gmt As ComboBox
	Friend WithEvents Saati_Oku_Buton As Button
	Friend WithEvents Label8 As Label
	Friend WithEvents Label7 As Label
	Friend WithEvents NTP_Aktif_Check As CheckBox
	Friend WithEvents Label9 As Label
	Friend WithEvents Gmt_Label_Text As Label
	Friend WithEvents Okunan_Saat_Text As Label
	Friend WithEvents GroupBox3 As GroupBox
End Class

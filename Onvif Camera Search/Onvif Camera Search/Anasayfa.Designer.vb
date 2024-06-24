<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Anasayfa
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
		Me.components = New System.ComponentModel.Container()
		Me.Ara_Buton = New System.Windows.Forms.Button()
		Me.Kamera_Listview = New System.Windows.Forms.ListView()
		Me.Timeout_Timer = New System.Windows.Forms.Timer(Me.components)
		Me.Saat_Ayarla_Buton = New System.Windows.Forms.Button()
		Me.Zoom_Focus_Buton = New System.Windows.Forms.Button()
		Me.SuspendLayout()
		'
		'Ara_Buton
		'
		Me.Ara_Buton.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
		Me.Ara_Buton.Location = New System.Drawing.Point(12, 504)
		Me.Ara_Buton.Name = "Ara_Buton"
		Me.Ara_Buton.Size = New System.Drawing.Size(136, 43)
		Me.Ara_Buton.TabIndex = 0
		Me.Ara_Buton.Text = "Ara"
		Me.Ara_Buton.UseVisualStyleBackColor = True
		'
		'Kamera_Listview
		'
		Me.Kamera_Listview.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
			Or System.Windows.Forms.AnchorStyles.Left) _
			Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
		Me.Kamera_Listview.FullRowSelect = True
		Me.Kamera_Listview.HideSelection = False
		Me.Kamera_Listview.Location = New System.Drawing.Point(12, 12)
		Me.Kamera_Listview.Name = "Kamera_Listview"
		Me.Kamera_Listview.Size = New System.Drawing.Size(776, 486)
		Me.Kamera_Listview.TabIndex = 1
		Me.Kamera_Listview.UseCompatibleStateImageBehavior = False
		Me.Kamera_Listview.View = System.Windows.Forms.View.List
		'
		'Timeout_Timer
		'
		Me.Timeout_Timer.Interval = 250
		'
		'Saat_Ayarla_Buton
		'
		Me.Saat_Ayarla_Buton.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
		Me.Saat_Ayarla_Buton.Location = New System.Drawing.Point(154, 504)
		Me.Saat_Ayarla_Buton.Name = "Saat_Ayarla_Buton"
		Me.Saat_Ayarla_Buton.Size = New System.Drawing.Size(136, 43)
		Me.Saat_Ayarla_Buton.TabIndex = 3
		Me.Saat_Ayarla_Buton.Text = "Saat Ayarları"
		Me.Saat_Ayarla_Buton.UseVisualStyleBackColor = True
		'
		'Zoom_Focus_Buton
		'
		Me.Zoom_Focus_Buton.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
		Me.Zoom_Focus_Buton.Location = New System.Drawing.Point(296, 504)
		Me.Zoom_Focus_Buton.Name = "Zoom_Focus_Buton"
		Me.Zoom_Focus_Buton.Size = New System.Drawing.Size(136, 43)
		Me.Zoom_Focus_Buton.TabIndex = 4
		Me.Zoom_Focus_Buton.Text = "Zoom-Focus"
		Me.Zoom_Focus_Buton.UseVisualStyleBackColor = True
		'
		'Anasayfa
		'
		Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.ClientSize = New System.Drawing.Size(800, 559)
		Me.Controls.Add(Me.Zoom_Focus_Buton)
		Me.Controls.Add(Me.Saat_Ayarla_Buton)
		Me.Controls.Add(Me.Kamera_Listview)
		Me.Controls.Add(Me.Ara_Buton)
		Me.Name = "Anasayfa"
		Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
		Me.Text = "Dahua/Hikvision/No-Name (Onvif) Kamera Arama"
		Me.ResumeLayout(False)

	End Sub

	Friend WithEvents Ara_Buton As Button
	Friend WithEvents Kamera_Listview As ListView
	Friend WithEvents Timeout_Timer As Timer
	Friend WithEvents Saat_Ayarla_Buton As Button
	Friend WithEvents Zoom_Focus_Buton As Button
End Class

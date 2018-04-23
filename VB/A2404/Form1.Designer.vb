Imports Microsoft.VisualBasic
Imports System
Namespace A2404
	Partial Public Class Form1
		''' <summary>
		''' Required designer variable.
		''' </summary>
		Private components As System.ComponentModel.IContainer = Nothing

		''' <summary>
		''' Clean up any resources being used.
		''' </summary>
		''' <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		Protected Overrides Sub Dispose(ByVal disposing As Boolean)
			If disposing AndAlso (components IsNot Nothing) Then
				components.Dispose()
			End If
			MyBase.Dispose(disposing)
		End Sub

		#Region "Windows Form Designer generated code"

		''' <summary>
		''' Required method for Designer support - do not modify
		''' the contents of this method with the code editor.
		''' </summary>
		Private Sub InitializeComponent()
			Me.dataGridView1 = New System.Windows.Forms.DataGridView()
			Me.button1 = New System.Windows.Forms.Button()
			Me.button2 = New System.Windows.Forms.Button()
			Me.button3 = New System.Windows.Forms.Button()
			Me.button4 = New System.Windows.Forms.Button()
			CType(Me.dataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
			Me.SuspendLayout()
			' 
			' dataGridView1
			' 
			Me.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
			Me.dataGridView1.Dock = System.Windows.Forms.DockStyle.Top
			Me.dataGridView1.Location = New System.Drawing.Point(0, 0)
			Me.dataGridView1.Name = "dataGridView1"
			Me.dataGridView1.Size = New System.Drawing.Size(793, 464)
			Me.dataGridView1.TabIndex = 0
			' 
			' button1
			' 
			Me.button1.Location = New System.Drawing.Point(22, 474)
			Me.button1.Name = "button1"
			Me.button1.Size = New System.Drawing.Size(111, 23)
			Me.button1.TabIndex = 1
			Me.button1.Text = "Show All Users"
			Me.button1.UseVisualStyleBackColor = True
'			Me.button1.Click += New System.EventHandler(Me.button1_Click);
			' 
			' button2
			' 
			Me.button2.Location = New System.Drawing.Point(139, 474)
			Me.button2.Name = "button2"
			Me.button2.Size = New System.Drawing.Size(123, 23)
			Me.button2.TabIndex = 2
			Me.button2.Text = "Show Only Managers"
			Me.button2.UseVisualStyleBackColor = True
'			Me.button2.Click += New System.EventHandler(Me.button2_Click);
			' 
			' button3
			' 
			Me.button3.Location = New System.Drawing.Point(268, 474)
			Me.button3.Name = "button3"
			Me.button3.Size = New System.Drawing.Size(136, 23)
			Me.button3.TabIndex = 3
			Me.button3.Text = "Show Only Programmers"
			Me.button3.UseVisualStyleBackColor = True
'			Me.button3.Click += New System.EventHandler(Me.button3_Click);
			' 
			' button4
			' 
			Me.button4.Location = New System.Drawing.Point(410, 474)
			Me.button4.Name = "button4"
			Me.button4.Size = New System.Drawing.Size(119, 23)
			Me.button4.TabIndex = 4
			Me.button4.Text = "Complex Query"
			Me.button4.UseVisualStyleBackColor = True
'			Me.button4.Click += New System.EventHandler(Me.button4_Click);
			' 
			' Form1
			' 
			Me.AutoScaleDimensions = New System.Drawing.SizeF(6F, 13F)
			Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
			Me.ClientSize = New System.Drawing.Size(793, 509)
			Me.Controls.Add(Me.button4)
			Me.Controls.Add(Me.button3)
			Me.Controls.Add(Me.button2)
			Me.Controls.Add(Me.button1)
			Me.Controls.Add(Me.dataGridView1)
			Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
			Me.Name = "Form1"
			Me.Text = "Form1"
			CType(Me.dataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
			Me.ResumeLayout(False)

		End Sub

		#End Region

		Private dataGridView1 As System.Windows.Forms.DataGridView
		Private WithEvents button1 As System.Windows.Forms.Button
		Private WithEvents button2 As System.Windows.Forms.Button
		Private WithEvents button3 As System.Windows.Forms.Button
		Private WithEvents button4 As System.Windows.Forms.Button
	End Class
End Namespace
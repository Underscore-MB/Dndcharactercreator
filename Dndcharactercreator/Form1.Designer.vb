<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmHome
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(disposing As Boolean)
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmHome))
        lblTitel = New Label()
        btnNew = New Button()
        btnLoad = New Button()
        btnClose = New Button()
        Label1 = New Label()
        btnHomeQ = New Button()
        btnOpenSave = New Button()
        SuspendLayout()
        ' 
        ' lblTitel
        ' 
        lblTitel.AutoSize = True
        lblTitel.Font = New Font("Book Antiqua", 18F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblTitel.Location = New Point(41, 39)
        lblTitel.Name = "lblTitel"
        lblTitel.Size = New Size(273, 56)
        lblTitel.TabIndex = 0
        lblTitel.Text = "Dungeons and Dragons" & vbCrLf & " Character creator"
        lblTitel.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' btnNew
        ' 
        btnNew.BackColor = Color.White
        btnNew.Font = New Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        btnNew.Location = New Point(91, 125)
        btnNew.Name = "btnNew"
        btnNew.Size = New Size(170, 43)
        btnNew.TabIndex = 1
        btnNew.Text = "Create New Character"
        btnNew.UseVisualStyleBackColor = False
        ' 
        ' btnLoad
        ' 
        btnLoad.BackColor = Color.White
        btnLoad.Font = New Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        btnLoad.Location = New Point(91, 183)
        btnLoad.Name = "btnLoad"
        btnLoad.Size = New Size(170, 43)
        btnLoad.TabIndex = 2
        btnLoad.Text = "Load Character"
        btnLoad.UseVisualStyleBackColor = False
        ' 
        ' btnClose
        ' 
        btnClose.BackColor = Color.White
        btnClose.Font = New Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        btnClose.Location = New Point(91, 241)
        btnClose.Name = "btnClose"
        btnClose.Size = New Size(170, 43)
        btnClose.TabIndex = 3
        btnClose.Text = "Close"
        btnClose.UseVisualStyleBackColor = False
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Location = New Point(12, 296)
        Label1.Name = "Label1"
        Label1.Size = New Size(184, 15)
        Label1.TabIndex = 4
        Label1.Text = "Only ONE charcter slot available!"
        ' 
        ' btnHomeQ
        ' 
        btnHomeQ.Location = New Point(327, 296)
        btnHomeQ.Name = "btnHomeQ"
        btnHomeQ.Size = New Size(27, 23)
        btnHomeQ.TabIndex = 5
        btnHomeQ.Text = "?"
        btnHomeQ.UseVisualStyleBackColor = True
        ' 
        ' btnOpenSave
        ' 
        btnOpenSave.BackgroundImage = My.Resources.Resources.file_icon_vector_illustration_tfmch1k1oywxve7z_tfmch1k1oywxve7z
        btnOpenSave.BackgroundImageLayout = ImageLayout.Stretch
        btnOpenSave.Location = New Point(54, 192)
        btnOpenSave.Name = "btnOpenSave"
        btnOpenSave.Size = New Size(31, 27)
        btnOpenSave.TabIndex = 6
        btnOpenSave.UseVisualStyleBackColor = True
        ' 
        ' frmHome
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(353, 320)
        Controls.Add(btnOpenSave)
        Controls.Add(btnHomeQ)
        Controls.Add(Label1)
        Controls.Add(btnClose)
        Controls.Add(btnLoad)
        Controls.Add(btnNew)
        Controls.Add(lblTitel)
        Font = New Font("Microsoft Sans Serif", 9F)
        Icon = CType(resources.GetObject("$this.Icon"), Icon)
        Name = "frmHome"
        Text = "Home"
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents lblTitel As Label
    Friend WithEvents btnNew As Button
    Friend WithEvents btnLoad As Button
    Friend WithEvents btnClose As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents btnHomeQ As Button
    Friend WithEvents btnOpenSave As Button

End Class

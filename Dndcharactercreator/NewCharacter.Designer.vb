<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class NewCharacter
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        lblTitel = New Label()
        btnSave = New Button()
        btnNext = New Button()
        btnPrevious = New Button()
        SuspendLayout()
        ' 
        ' lblTitel
        ' 
        lblTitel.Anchor = AnchorStyles.Bottom Or AnchorStyles.Right
        lblTitel.AutoSize = True
        lblTitel.Font = New Font("Book Antiqua", 18F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblTitel.Location = New Point(290, 9)
        lblTitel.Name = "lblTitel"
        lblTitel.Size = New Size(201, 28)
        lblTitel.TabIndex = 1
        lblTitel.Text = "Base Information"
        lblTitel.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' btnSave
        ' 
        btnSave.Anchor = AnchorStyles.Bottom Or AnchorStyles.Right
        btnSave.BackColor = Color.FromArgb(CByte(0), CByte(64), CByte(0))
        btnSave.FlatAppearance.BorderSize = 0
        btnSave.ForeColor = SystemColors.ButtonHighlight
        btnSave.Location = New Point(416, 386)
        btnSave.Name = "btnSave"
        btnSave.Size = New Size(75, 23)
        btnSave.TabIndex = 2
        btnSave.Text = "Save"
        btnSave.UseVisualStyleBackColor = False
        ' 
        ' btnNext
        ' 
        btnNext.Anchor = AnchorStyles.Bottom Or AnchorStyles.Right
        btnNext.Location = New Point(416, 415)
        btnNext.Name = "btnNext"
        btnNext.Size = New Size(75, 23)
        btnNext.TabIndex = 3
        btnNext.Text = "Next"
        btnNext.UseVisualStyleBackColor = True
        ' 
        ' btnPrevious
        ' 
        btnPrevious.Anchor = AnchorStyles.Bottom Or AnchorStyles.Right
        btnPrevious.Location = New Point(335, 415)
        btnPrevious.Name = "btnPrevious"
        btnPrevious.Size = New Size(75, 23)
        btnPrevious.TabIndex = 4
        btnPrevious.Text = "Previous"
        btnPrevious.UseVisualStyleBackColor = True
        ' 
        ' NewCharacter
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(503, 450)
        Controls.Add(btnPrevious)
        Controls.Add(btnNext)
        Controls.Add(btnSave)
        Controls.Add(lblTitel)
        Name = "NewCharacter"
        Text = "NewCharacter"
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents lblTitel As Label
    Friend WithEvents btnSave As Button
    Friend WithEvents btnNext As Button
    Friend WithEvents btnPrevious As Button
End Class

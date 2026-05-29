<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Log
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
        components = New ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Log))
        BtnDelete = New Button()
        BtnClose = New Button()
        Lblnfo = New Skye.UI.Label()
        LogViewer = New Skye.UI.Log.LogViewerControl()
        TipLogEX = New Skye.UI.ToolTipEX(components)
        SuspendLayout()
        ' 
        ' BtnDelete
        ' 
        BtnDelete.Anchor = AnchorStyles.Bottom Or AnchorStyles.Left
        BtnDelete.Image = My.Resources.Resources.ImageDeleteLog32
        TipLogEX.SetImage(BtnDelete, My.Resources.Resources.ImageDeleteLog32)
        BtnDelete.Location = New Point(13, 484)
        BtnDelete.Margin = New Padding(4, 3, 4, 3)
        BtnDelete.Name = "BtnDelete"
        BtnDelete.Size = New Size(48, 48)
        BtnDelete.TabIndex = 2
        BtnDelete.TabStop = False
        TipLogEX.SetText(BtnDelete, "Delete Log")
        BtnDelete.UseVisualStyleBackColor = True
        ' 
        ' BtnClose
        ' 
        BtnClose.Anchor = AnchorStyles.Bottom
        BtnClose.Image = My.Resources.Resources.ImageOK64
        TipLogEX.SetImage(BtnClose, My.Resources.Resources.ImageOK64)
        BtnClose.Location = New Point(434, 468)
        BtnClose.Margin = New Padding(4, 3, 4, 3)
        BtnClose.Name = "BtnClose"
        BtnClose.Size = New Size(64, 64)
        BtnClose.TabIndex = 3
        BtnClose.TabStop = False
        TipLogEX.SetText(BtnClose, "Close (CtrlW)")
        BtnClose.UseVisualStyleBackColor = True
        ' 
        ' Lblnfo
        ' 
        Lblnfo.Anchor = AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        Lblnfo.Font = New Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        TipLogEX.SetImage(Lblnfo, Nothing)
        Lblnfo.Location = New Point(14, 435)
        Lblnfo.Margin = New Padding(4, 0, 4, 0)
        Lblnfo.Name = "Lblnfo"
        Lblnfo.Size = New Size(905, 29)
        Lblnfo.TabIndex = 1
        Lblnfo.Text = "File Info"
        TipLogEX.SetText(Lblnfo, Nothing)
        Lblnfo.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' LogViewer
        ' 
        LogViewer.Font = New Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        TipLogEX.SetImage(LogViewer, Nothing)
        LogViewer.Location = New Point(0, 0)
        LogViewer.Margin = New Padding(4)
        LogViewer.Name = "LogViewer"
        LogViewer.Size = New Size(933, 431)
        LogViewer.TabIndex = 5
        TipLogEX.SetText(LogViewer, Nothing)
        ' 
        ' TipLogEX
        ' 
        TipLogEX.Font = New Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        TipLogEX.ShadowAlpha = 0
        TipLogEX.ShadowThickness = 0
        ' 
        ' Log
        ' 
        AutoScaleMode = AutoScaleMode.None
        ClientSize = New Size(933, 544)
        Controls.Add(LogViewer)
        Controls.Add(BtnClose)
        Controls.Add(BtnDelete)
        Controls.Add(Lblnfo)
        Font = New Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Icon = CType(resources.GetObject("$this.Icon"), Icon)
        TipLogEX.SetImage(Me, Nothing)
        KeyPreview = True
        Margin = New Padding(4, 3, 4, 3)
        MinimumSize = New Size(697, 340)
        Name = "Log"
        StartPosition = FormStartPosition.CenterScreen
        TipLogEX.SetText(Me, Nothing)
        Text = "Log"
        ResumeLayout(False)

    End Sub

    Friend WithEvents Lblnfo As Skye.UI.Label
    Friend WithEvents BtnDelete As Button
    Friend WithEvents BtnClose As Button
    Friend WithEvents LogViewer As Skye.UI.Log.LogViewerControl
    Friend WithEvents TipLogEX As Skye.UI.ToolTipEX
End Class

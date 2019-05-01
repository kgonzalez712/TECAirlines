<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
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
        Me.components = New System.ComponentModel.Container()
        Me.TECAirlinesDBDataSet = New TECAirlinesReports.TECAirlinesDBDataSet()
        Me.EMAILCONFIRMATIONBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.EMAIL_CONFIRMATIONTableAdapter = New TECAirlinesReports.TECAirlinesDBDataSetTableAdapters.EMAIL_CONFIRMATIONTableAdapter()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.RESERVATIONIDDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CLIENTIDDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FLIGHTIDDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ORIGINAIRPORTDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DESTINATIONAIRPORTDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DATEHOURDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SEATSDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PRICEDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CLIENTFNAMEDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CLIENTLNAMEDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CLIENTEMAILDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CLIENTPHONENODataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        CType(Me.TECAirlinesDBDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EMAILCONFIRMATIONBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TECAirlinesDBDataSet
        '
        Me.TECAirlinesDBDataSet.DataSetName = "TECAirlinesDBDataSet"
        Me.TECAirlinesDBDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'EMAILCONFIRMATIONBindingSource
        '
        Me.EMAILCONFIRMATIONBindingSource.DataMember = "EMAIL_CONFIRMATION"
        Me.EMAILCONFIRMATIONBindingSource.DataSource = Me.TECAirlinesDBDataSet
        '
        'EMAIL_CONFIRMATIONTableAdapter
        '
        Me.EMAIL_CONFIRMATIONTableAdapter.ClearBeforeFill = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(250, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(273, 26)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = " Reservaciones TECAirlines"
        '
        'Button1
        '
        Me.Button1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.Location = New System.Drawing.Point(297, 38)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(171, 23)
        Me.Button1.TabIndex = 2
        Me.Button1.Text = "Obtener Reservaciones"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.Button2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button2.Location = New System.Drawing.Point(684, 415)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(104, 23)
        Me.Button2.TabIndex = 3
        Me.Button2.Text = "Imprimir"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToDeleteRows = False
        Me.DataGridView1.AutoGenerateColumns = False
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.RESERVATIONIDDataGridViewTextBoxColumn, Me.CLIENTIDDataGridViewTextBoxColumn, Me.FLIGHTIDDataGridViewTextBoxColumn, Me.ORIGINAIRPORTDataGridViewTextBoxColumn, Me.DESTINATIONAIRPORTDataGridViewTextBoxColumn, Me.DATEHOURDataGridViewTextBoxColumn, Me.SEATSDataGridViewTextBoxColumn, Me.PRICEDataGridViewTextBoxColumn, Me.CLIENTFNAMEDataGridViewTextBoxColumn, Me.CLIENTLNAMEDataGridViewTextBoxColumn, Me.CLIENTEMAILDataGridViewTextBoxColumn, Me.CLIENTPHONENODataGridViewTextBoxColumn})
        Me.DataGridView1.DataSource = Me.EMAILCONFIRMATIONBindingSource
        Me.DataGridView1.Location = New System.Drawing.Point(12, 67)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.ReadOnly = True
        Me.DataGridView1.Size = New System.Drawing.Size(776, 342)
        Me.DataGridView1.TabIndex = 4
        '
        'RESERVATIONIDDataGridViewTextBoxColumn
        '
        Me.RESERVATIONIDDataGridViewTextBoxColumn.DataPropertyName = "RESERVATION_ID"
        Me.RESERVATIONIDDataGridViewTextBoxColumn.HeaderText = "RESERVATION_ID"
        Me.RESERVATIONIDDataGridViewTextBoxColumn.Name = "RESERVATIONIDDataGridViewTextBoxColumn"
        Me.RESERVATIONIDDataGridViewTextBoxColumn.ReadOnly = True
        '
        'CLIENTIDDataGridViewTextBoxColumn
        '
        Me.CLIENTIDDataGridViewTextBoxColumn.DataPropertyName = "CLIENT_ID"
        Me.CLIENTIDDataGridViewTextBoxColumn.HeaderText = "CLIENT_ID"
        Me.CLIENTIDDataGridViewTextBoxColumn.Name = "CLIENTIDDataGridViewTextBoxColumn"
        Me.CLIENTIDDataGridViewTextBoxColumn.ReadOnly = True
        '
        'FLIGHTIDDataGridViewTextBoxColumn
        '
        Me.FLIGHTIDDataGridViewTextBoxColumn.DataPropertyName = "FLIGHT_ID"
        Me.FLIGHTIDDataGridViewTextBoxColumn.HeaderText = "FLIGHT_ID"
        Me.FLIGHTIDDataGridViewTextBoxColumn.Name = "FLIGHTIDDataGridViewTextBoxColumn"
        Me.FLIGHTIDDataGridViewTextBoxColumn.ReadOnly = True
        '
        'ORIGINAIRPORTDataGridViewTextBoxColumn
        '
        Me.ORIGINAIRPORTDataGridViewTextBoxColumn.DataPropertyName = "ORIGIN_AIRPORT"
        Me.ORIGINAIRPORTDataGridViewTextBoxColumn.HeaderText = "ORIGIN_AIRPORT"
        Me.ORIGINAIRPORTDataGridViewTextBoxColumn.Name = "ORIGINAIRPORTDataGridViewTextBoxColumn"
        Me.ORIGINAIRPORTDataGridViewTextBoxColumn.ReadOnly = True
        '
        'DESTINATIONAIRPORTDataGridViewTextBoxColumn
        '
        Me.DESTINATIONAIRPORTDataGridViewTextBoxColumn.DataPropertyName = "DESTINATION_AIRPORT"
        Me.DESTINATIONAIRPORTDataGridViewTextBoxColumn.HeaderText = "DESTINATION_AIRPORT"
        Me.DESTINATIONAIRPORTDataGridViewTextBoxColumn.Name = "DESTINATIONAIRPORTDataGridViewTextBoxColumn"
        Me.DESTINATIONAIRPORTDataGridViewTextBoxColumn.ReadOnly = True
        '
        'DATEHOURDataGridViewTextBoxColumn
        '
        Me.DATEHOURDataGridViewTextBoxColumn.DataPropertyName = "DATE_HOUR"
        Me.DATEHOURDataGridViewTextBoxColumn.HeaderText = "DATE_HOUR"
        Me.DATEHOURDataGridViewTextBoxColumn.Name = "DATEHOURDataGridViewTextBoxColumn"
        Me.DATEHOURDataGridViewTextBoxColumn.ReadOnly = True
        '
        'SEATSDataGridViewTextBoxColumn
        '
        Me.SEATSDataGridViewTextBoxColumn.DataPropertyName = "SEATS"
        Me.SEATSDataGridViewTextBoxColumn.HeaderText = "SEATS"
        Me.SEATSDataGridViewTextBoxColumn.Name = "SEATSDataGridViewTextBoxColumn"
        Me.SEATSDataGridViewTextBoxColumn.ReadOnly = True
        '
        'PRICEDataGridViewTextBoxColumn
        '
        Me.PRICEDataGridViewTextBoxColumn.DataPropertyName = "PRICE"
        Me.PRICEDataGridViewTextBoxColumn.HeaderText = "PRICE"
        Me.PRICEDataGridViewTextBoxColumn.Name = "PRICEDataGridViewTextBoxColumn"
        Me.PRICEDataGridViewTextBoxColumn.ReadOnly = True
        '
        'CLIENTFNAMEDataGridViewTextBoxColumn
        '
        Me.CLIENTFNAMEDataGridViewTextBoxColumn.DataPropertyName = "CLIENT_FNAME"
        Me.CLIENTFNAMEDataGridViewTextBoxColumn.HeaderText = "CLIENT_FNAME"
        Me.CLIENTFNAMEDataGridViewTextBoxColumn.Name = "CLIENTFNAMEDataGridViewTextBoxColumn"
        Me.CLIENTFNAMEDataGridViewTextBoxColumn.ReadOnly = True
        '
        'CLIENTLNAMEDataGridViewTextBoxColumn
        '
        Me.CLIENTLNAMEDataGridViewTextBoxColumn.DataPropertyName = "CLIENT_LNAME"
        Me.CLIENTLNAMEDataGridViewTextBoxColumn.HeaderText = "CLIENT_LNAME"
        Me.CLIENTLNAMEDataGridViewTextBoxColumn.Name = "CLIENTLNAMEDataGridViewTextBoxColumn"
        Me.CLIENTLNAMEDataGridViewTextBoxColumn.ReadOnly = True
        '
        'CLIENTEMAILDataGridViewTextBoxColumn
        '
        Me.CLIENTEMAILDataGridViewTextBoxColumn.DataPropertyName = "CLIENT_EMAIL"
        Me.CLIENTEMAILDataGridViewTextBoxColumn.HeaderText = "CLIENT_EMAIL"
        Me.CLIENTEMAILDataGridViewTextBoxColumn.Name = "CLIENTEMAILDataGridViewTextBoxColumn"
        Me.CLIENTEMAILDataGridViewTextBoxColumn.ReadOnly = True
        '
        'CLIENTPHONENODataGridViewTextBoxColumn
        '
        Me.CLIENTPHONENODataGridViewTextBoxColumn.DataPropertyName = "CLIENT_PHONENO"
        Me.CLIENTPHONENODataGridViewTextBoxColumn.HeaderText = "CLIENT_PHONENO"
        Me.CLIENTPHONENODataGridViewTextBoxColumn.Name = "CLIENTPHONENODataGridViewTextBoxColumn"
        Me.CLIENTPHONENODataGridViewTextBoxColumn.ReadOnly = True
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Label1)
        Me.Name = "Form1"
        Me.Text = "Form1"
        CType(Me.TECAirlinesDBDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EMAILCONFIRMATIONBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TECAirlinesDBDataSet As TECAirlinesDBDataSet
    Friend WithEvents EMAILCONFIRMATIONBindingSource As BindingSource
    Friend WithEvents EMAIL_CONFIRMATIONTableAdapter As TECAirlinesDBDataSetTableAdapters.EMAIL_CONFIRMATIONTableAdapter
    Friend WithEvents Label1 As Label
    Friend WithEvents Button1 As Button
    Friend WithEvents Button2 As Button
    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents RESERVATIONIDDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents CLIENTIDDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents FLIGHTIDDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents ORIGINAIRPORTDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents DESTINATIONAIRPORTDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents DATEHOURDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents SEATSDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents PRICEDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents CLIENTFNAMEDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents CLIENTLNAMEDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents CLIENTEMAILDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents CLIENTPHONENODataGridViewTextBoxColumn As DataGridViewTextBoxColumn
End Class

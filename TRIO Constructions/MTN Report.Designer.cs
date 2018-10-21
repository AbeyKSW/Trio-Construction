namespace TRIO_Constructions
{
    partial class MTN_Report
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbMtnNo = new System.Windows.Forms.ComboBox();
            this.cmbSite = new System.Windows.Forms.ComboBox();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.btnAll = new System.Windows.Forms.Button();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.Company_Inventory = new TRIO_Constructions.Company_Inventory();
            this.mtn_details_tableBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.mtn_details_tableTableAdapter = new TRIO_Constructions.Company_InventoryTableAdapters.mtn_details_tableTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.Company_Inventory)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mtn_details_tableBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "MTN Number";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(22, 60);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(25, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Site";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(295, 23);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(30, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Date";
            // 
            // cmbMtnNo
            // 
            this.cmbMtnNo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMtnNo.FormattingEnabled = true;
            this.cmbMtnNo.Location = new System.Drawing.Point(112, 20);
            this.cmbMtnNo.Name = "cmbMtnNo";
            this.cmbMtnNo.Size = new System.Drawing.Size(121, 21);
            this.cmbMtnNo.TabIndex = 3;
            this.cmbMtnNo.SelectedIndexChanged += new System.EventHandler(this.cmbMtnNo_SelectedIndexChanged);
            // 
            // cmbSite
            // 
            this.cmbSite.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSite.FormattingEnabled = true;
            this.cmbSite.Location = new System.Drawing.Point(112, 57);
            this.cmbSite.Name = "cmbSite";
            this.cmbSite.Size = new System.Drawing.Size(121, 21);
            this.cmbSite.TabIndex = 4;
            this.cmbSite.SelectedIndexChanged += new System.EventHandler(this.cmbSite_SelectedIndexChanged);
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(331, 21);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(200, 20);
            this.dateTimePicker1.TabIndex = 5;
            this.dateTimePicker1.ValueChanged += new System.EventHandler(this.dateTimePicker1_ValueChanged);
            // 
            // btnAll
            // 
            this.btnAll.Location = new System.Drawing.Point(456, 55);
            this.btnAll.Name = "btnAll";
            this.btnAll.Size = new System.Drawing.Size(75, 23);
            this.btnAll.TabIndex = 6;
            this.btnAll.Text = "All MTNs";
            this.btnAll.UseVisualStyleBackColor = true;
            this.btnAll.Click += new System.EventHandler(this.btnAll_Click);
            // 
            // reportViewer1
            // 
            reportDataSource1.Name = "MTNReport";
            reportDataSource1.Value = this.mtn_details_tableBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "TRIO_Constructions.MTN Report.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(12, 95);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(769, 474);
            this.reportViewer1.TabIndex = 7;
            // 
            // Company_Inventory
            // 
            this.Company_Inventory.DataSetName = "Company_Inventory";
            this.Company_Inventory.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // mtn_details_tableBindingSource
            // 
            this.mtn_details_tableBindingSource.DataMember = "mtn_details_table";
            this.mtn_details_tableBindingSource.DataSource = this.Company_Inventory;
            // 
            // mtn_details_tableTableAdapter
            // 
            this.mtn_details_tableTableAdapter.ClearBeforeFill = true;
            // 
            // MTN_Report
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(793, 581);
            this.Controls.Add(this.reportViewer1);
            this.Controls.Add(this.btnAll);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.cmbSite);
            this.Controls.Add(this.cmbMtnNo);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.Name = "MTN_Report";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MTN_Report";
            this.Load += new System.EventHandler(this.MTN_Report_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Company_Inventory)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mtn_details_tableBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbMtnNo;
        private System.Windows.Forms.ComboBox cmbSite;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Button btnAll;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource mtn_details_tableBindingSource;
        private Company_Inventory Company_Inventory;
        private Company_InventoryTableAdapters.mtn_details_tableTableAdapter mtn_details_tableTableAdapter;
    }
}
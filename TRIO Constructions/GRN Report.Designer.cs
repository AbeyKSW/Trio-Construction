namespace TRIO_Constructions
{
    partial class GRN_Report
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
            this.cmbMtnNo = new System.Windows.Forms.ComboBox();
            this.btnAll = new System.Windows.Forms.Button();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.Company_Inventory = new TRIO_Constructions.Company_Inventory();
            this.grn_details_tableBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.grn_details_tableTableAdapter = new TRIO_Constructions.Company_InventoryTableAdapters.grn_details_tableTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.Company_Inventory)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grn_details_tableBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "MTN Number";
            // 
            // cmbMtnNo
            // 
            this.cmbMtnNo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMtnNo.FormattingEnabled = true;
            this.cmbMtnNo.Location = new System.Drawing.Point(89, 13);
            this.cmbMtnNo.Name = "cmbMtnNo";
            this.cmbMtnNo.Size = new System.Drawing.Size(121, 21);
            this.cmbMtnNo.TabIndex = 1;
            this.cmbMtnNo.SelectedIndexChanged += new System.EventHandler(this.cmbMtnNo_SelectedIndexChanged);
            // 
            // btnAll
            // 
            this.btnAll.Location = new System.Drawing.Point(256, 13);
            this.btnAll.Name = "btnAll";
            this.btnAll.Size = new System.Drawing.Size(75, 23);
            this.btnAll.TabIndex = 2;
            this.btnAll.Text = "All GRN";
            this.btnAll.UseVisualStyleBackColor = true;
            // 
            // reportViewer1
            // 
            reportDataSource1.Name = "GRNReport";
            reportDataSource1.Value = this.grn_details_tableBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "TRIO_Constructions.GRN Report.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(15, 63);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(895, 300);
            this.reportViewer1.TabIndex = 3;
            // 
            // Company_Inventory
            // 
            this.Company_Inventory.DataSetName = "Company_Inventory";
            this.Company_Inventory.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // grn_details_tableBindingSource
            // 
            this.grn_details_tableBindingSource.DataMember = "grn_details_table";
            this.grn_details_tableBindingSource.DataSource = this.Company_Inventory;
            // 
            // grn_details_tableTableAdapter
            // 
            this.grn_details_tableTableAdapter.ClearBeforeFill = true;
            // 
            // GRN_Report
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(922, 375);
            this.Controls.Add(this.reportViewer1);
            this.Controls.Add(this.btnAll);
            this.Controls.Add(this.cmbMtnNo);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.Name = "GRN_Report";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "GRN_Report";
            this.Load += new System.EventHandler(this.GRN_Report_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Company_Inventory)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grn_details_tableBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbMtnNo;
        private System.Windows.Forms.Button btnAll;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource grn_details_tableBindingSource;
        private Company_Inventory Company_Inventory;
        private Company_InventoryTableAdapters.grn_details_tableTableAdapter grn_details_tableTableAdapter;
    }
}
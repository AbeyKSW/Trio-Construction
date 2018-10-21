namespace TRIO_Constructions
{
    partial class Pending_MTN_Report
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
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.Company_Inventory = new TRIO_Constructions.Company_Inventory();
            this.mtn_status_tableBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.mtn_status_tableTableAdapter = new TRIO_Constructions.Company_InventoryTableAdapters.mtn_status_tableTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.Company_Inventory)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mtn_status_tableBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            reportDataSource1.Name = "PendingMTN";
            reportDataSource1.Value = this.mtn_status_tableBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "TRIO_Constructions.Pending MTN Report.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(13, 12);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(273, 310);
            this.reportViewer1.TabIndex = 0;
            // 
            // Company_Inventory
            // 
            this.Company_Inventory.DataSetName = "Company_Inventory";
            this.Company_Inventory.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // mtn_status_tableBindingSource
            // 
            this.mtn_status_tableBindingSource.DataMember = "mtn_status_table";
            this.mtn_status_tableBindingSource.DataSource = this.Company_Inventory;
            // 
            // mtn_status_tableTableAdapter
            // 
            this.mtn_status_tableTableAdapter.ClearBeforeFill = true;
            // 
            // Pending_MTN_Report
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(298, 334);
            this.Controls.Add(this.reportViewer1);
            this.MaximizeBox = false;
            this.Name = "Pending_MTN_Report";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Pending MTN Report";
            this.Load += new System.EventHandler(this.Pending_MTN_Report_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Company_Inventory)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mtn_status_tableBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource mtn_status_tableBindingSource;
        private Company_Inventory Company_Inventory;
        private Company_InventoryTableAdapters.mtn_status_tableTableAdapter mtn_status_tableTableAdapter;
    }
}
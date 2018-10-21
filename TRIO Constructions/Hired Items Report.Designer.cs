namespace TRIO_Constructions
{
    partial class Hired_Items_Report
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
            this.asset_details_table1BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.asset_details_table1TableAdapter = new TRIO_Constructions.Company_InventoryTableAdapters.asset_details_table1TableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.Company_Inventory)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.asset_details_table1BindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            reportDataSource1.Name = "HiredItemsReport";
            reportDataSource1.Value = this.asset_details_table1BindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "TRIO_Constructions.Hired Items Report.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(12, 12);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(819, 349);
            this.reportViewer1.TabIndex = 0;
            // 
            // Company_Inventory
            // 
            this.Company_Inventory.DataSetName = "Company_Inventory";
            this.Company_Inventory.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // asset_details_table1BindingSource
            // 
            this.asset_details_table1BindingSource.DataMember = "asset_details_table1";
            this.asset_details_table1BindingSource.DataSource = this.Company_Inventory;
            // 
            // asset_details_table1TableAdapter
            // 
            this.asset_details_table1TableAdapter.ClearBeforeFill = true;
            // 
            // Hired_Items_Report
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(843, 373);
            this.Controls.Add(this.reportViewer1);
            this.MaximizeBox = false;
            this.Name = "Hired_Items_Report";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Hired_Items_Report";
            this.Load += new System.EventHandler(this.Hired_Items_Report_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Company_Inventory)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.asset_details_table1BindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource asset_details_table1BindingSource;
        private Company_Inventory Company_Inventory;
        private Company_InventoryTableAdapters.asset_details_table1TableAdapter asset_details_table1TableAdapter;
    }
}
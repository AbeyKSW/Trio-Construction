namespace TRIO_Constructions
{
    partial class Site_Inventory_Report
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
            this.label1 = new System.Windows.Forms.Label();
            this.cmbSite = new System.Windows.Forms.ComboBox();
            this.btnFilter = new System.Windows.Forms.Button();
            this.site_inventory_tableBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.Company_Inventory = new TRIO_Constructions.Company_Inventory();
            this.site_inventory_tableTableAdapter = new TRIO_Constructions.Company_InventoryTableAdapters.site_inventory_tableTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.site_inventory_tableBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Company_Inventory)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            reportDataSource1.Name = "SiteInventoryReport";
            reportDataSource1.Value = this.site_inventory_tableBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "TRIO_Constructions.Site Inventory Report.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(12, 69);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(572, 393);
            this.reportViewer1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(25, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Site";
            // 
            // cmbSite
            // 
            this.cmbSite.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSite.FormattingEnabled = true;
            this.cmbSite.Location = new System.Drawing.Point(71, 24);
            this.cmbSite.Name = "cmbSite";
            this.cmbSite.Size = new System.Drawing.Size(121, 21);
            this.cmbSite.TabIndex = 2;
            this.cmbSite.SelectedIndexChanged += new System.EventHandler(this.cmbSite_SelectedIndexChanged);
            // 
            // btnFilter
            // 
            this.btnFilter.Location = new System.Drawing.Point(364, 24);
            this.btnFilter.Name = "btnFilter";
            this.btnFilter.Size = new System.Drawing.Size(75, 23);
            this.btnFilter.TabIndex = 3;
            this.btnFilter.Text = "Filter";
            this.btnFilter.UseVisualStyleBackColor = true;
            this.btnFilter.Click += new System.EventHandler(this.btnFilter_Click);
            // 
            // site_inventory_tableBindingSource
            // 
            this.site_inventory_tableBindingSource.DataMember = "site_inventory_table";
            this.site_inventory_tableBindingSource.DataSource = this.Company_Inventory;
            // 
            // Company_Inventory
            // 
            this.Company_Inventory.DataSetName = "Company_Inventory";
            this.Company_Inventory.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // site_inventory_tableTableAdapter
            // 
            this.site_inventory_tableTableAdapter.ClearBeforeFill = true;
            // 
            // Site_Inventory_Report
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(596, 474);
            this.Controls.Add(this.btnFilter);
            this.Controls.Add(this.cmbSite);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.reportViewer1);
            this.MaximizeBox = false;
            this.Name = "Site_Inventory_Report";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Site Inventory Report";
            this.Load += new System.EventHandler(this.Site_Inventory_Report_Load);
            ((System.ComponentModel.ISupportInitialize)(this.site_inventory_tableBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Company_Inventory)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbSite;
        private System.Windows.Forms.Button btnFilter;
        private System.Windows.Forms.BindingSource site_inventory_tableBindingSource;
        private Company_Inventory Company_Inventory;
        private Company_InventoryTableAdapters.site_inventory_tableTableAdapter site_inventory_tableTableAdapter;
    }
}
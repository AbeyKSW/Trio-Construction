namespace TRIO_Constructions
{
    partial class Warranty_Available_Items
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
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource2 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.btnAll = new System.Windows.Forms.Button();
            this.Company_Inventory = new TRIO_Constructions.Company_Inventory();
            this.asset_details_table2BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.asset_details_table2TableAdapter = new TRIO_Constructions.Company_InventoryTableAdapters.asset_details_table2TableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.Company_Inventory)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.asset_details_table2BindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            reportDataSource2.Name = "WarrantyAvailableItems";
            reportDataSource2.Value = this.asset_details_table2BindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource2);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "TRIO_Constructions.Warranty Available Items.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(12, 52);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(889, 246);
            this.reportViewer1.TabIndex = 0;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(61, 16);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(200, 20);
            this.dateTimePicker1.TabIndex = 1;
            this.dateTimePicker1.ValueChanged += new System.EventHandler(this.dateTimePicker1_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(30, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Date";
            // 
            // btnAll
            // 
            this.btnAll.Location = new System.Drawing.Point(292, 14);
            this.btnAll.Name = "btnAll";
            this.btnAll.Size = new System.Drawing.Size(75, 23);
            this.btnAll.TabIndex = 3;
            this.btnAll.Text = "All";
            this.btnAll.UseVisualStyleBackColor = true;
            this.btnAll.Click += new System.EventHandler(this.btnAll_Click);
            // 
            // Company_Inventory
            // 
            this.Company_Inventory.DataSetName = "Company_Inventory";
            this.Company_Inventory.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // asset_details_table2BindingSource
            // 
            this.asset_details_table2BindingSource.DataMember = "asset_details_table2";
            this.asset_details_table2BindingSource.DataSource = this.Company_Inventory;
            // 
            // asset_details_table2TableAdapter
            // 
            this.asset_details_table2TableAdapter.ClearBeforeFill = true;
            // 
            // Warranty_Available_Items
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(913, 310);
            this.Controls.Add(this.btnAll);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.reportViewer1);
            this.Name = "Warranty_Available_Items";
            this.Text = "Warranty Available Items";
            this.Load += new System.EventHandler(this.Warranty_Available_Items_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Company_Inventory)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.asset_details_table2BindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource asset_details_table2BindingSource;
        private Company_Inventory Company_Inventory;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnAll;
        private Company_InventoryTableAdapters.asset_details_table2TableAdapter asset_details_table2TableAdapter;
    }
}
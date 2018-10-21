namespace TRIO_Constructions
{
    partial class Company_Pool
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
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource6 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbAstName = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbQuality = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.btnFilter = new System.Windows.Forms.Button();
            this.Company_Inventory = new TRIO_Constructions.Company_Inventory();
            this.asset_details_tableBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.asset_details_tableTableAdapter = new TRIO_Constructions.Company_InventoryTableAdapters.asset_details_tableTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.Company_Inventory)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.asset_details_tableBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            reportDataSource6.Name = "CompanyPool";
            reportDataSource6.Value = this.asset_details_tableBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource6);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "TRIO_Constructions.Company Pool.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(12, 74);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(948, 485);
            this.reportViewer1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Asset Name";
            // 
            // cmbAstName
            // 
            this.cmbAstName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbAstName.FormattingEnabled = true;
            this.cmbAstName.Location = new System.Drawing.Point(82, 10);
            this.cmbAstName.Name = "cmbAstName";
            this.cmbAstName.Size = new System.Drawing.Size(121, 21);
            this.cmbAstName.TabIndex = 2;
            this.cmbAstName.SelectedIndexChanged += new System.EventHandler(this.cmbAstName_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(39, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Quality";
            // 
            // cmbQuality
            // 
            this.cmbQuality.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbQuality.FormattingEnabled = true;
            this.cmbQuality.Items.AddRange(new object[] {
            "New",
            "Used",
            "Hire"});
            this.cmbQuality.Location = new System.Drawing.Point(82, 40);
            this.cmbQuality.Name = "cmbQuality";
            this.cmbQuality.Size = new System.Drawing.Size(121, 21);
            this.cmbQuality.TabIndex = 4;
            this.cmbQuality.SelectedIndexChanged += new System.EventHandler(this.cmbQuality_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(241, 13);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Launch Date";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(330, 10);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(200, 20);
            this.dateTimePicker1.TabIndex = 6;
            this.dateTimePicker1.ValueChanged += new System.EventHandler(this.dateTimePicker1_ValueChanged);
            // 
            // btnFilter
            // 
            this.btnFilter.Location = new System.Drawing.Point(455, 40);
            this.btnFilter.Name = "btnFilter";
            this.btnFilter.Size = new System.Drawing.Size(75, 23);
            this.btnFilter.TabIndex = 7;
            this.btnFilter.Text = "All Assets";
            this.btnFilter.UseVisualStyleBackColor = true;
            this.btnFilter.Click += new System.EventHandler(this.btnFilter_Click);
            // 
            // Company_Inventory
            // 
            this.Company_Inventory.DataSetName = "Company_Inventory";
            this.Company_Inventory.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // asset_details_tableBindingSource
            // 
            this.asset_details_tableBindingSource.DataMember = "asset_details_table";
            this.asset_details_tableBindingSource.DataSource = this.Company_Inventory;
            // 
            // asset_details_tableTableAdapter
            // 
            this.asset_details_tableTableAdapter.ClearBeforeFill = true;
            // 
            // Company_Pool
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(972, 571);
            this.Controls.Add(this.btnFilter);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cmbQuality);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmbAstName);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.reportViewer1);
            this.MaximizeBox = false;
            this.Name = "Company_Pool";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Company_Pool";
            this.Load += new System.EventHandler(this.Company_Pool_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Company_Inventory)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.asset_details_tableBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbAstName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbQuality;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Button btnFilter;
        private System.Windows.Forms.BindingSource asset_details_tableBindingSource;
        private Company_Inventory Company_Inventory;
        private Company_InventoryTableAdapters.asset_details_tableTableAdapter asset_details_tableTableAdapter;
    }
}
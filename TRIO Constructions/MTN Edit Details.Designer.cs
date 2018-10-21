namespace TRIO_Constructions
{
    partial class MTN_Edit_Details
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
            this.cmbMtnNo = new System.Windows.Forms.ComboBox();
            this.Company_Inventory = new TRIO_Constructions.Company_Inventory();
            this.mtn_edit_tableBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.mtn_edit_tableTableAdapter = new TRIO_Constructions.Company_InventoryTableAdapters.mtn_edit_tableTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.Company_Inventory)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mtn_edit_tableBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            reportDataSource1.Name = "MTNEditDetails";
            reportDataSource1.Value = this.mtn_edit_tableBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "TRIO_Constructions.MTN Edit Details.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(12, 77);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(555, 246);
            this.reportViewer1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "MTN Number";
            // 
            // cmbMtnNo
            // 
            this.cmbMtnNo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMtnNo.FormattingEnabled = true;
            this.cmbMtnNo.Location = new System.Drawing.Point(103, 30);
            this.cmbMtnNo.Name = "cmbMtnNo";
            this.cmbMtnNo.Size = new System.Drawing.Size(121, 21);
            this.cmbMtnNo.TabIndex = 2;
            this.cmbMtnNo.SelectedIndexChanged += new System.EventHandler(this.cmbMtnNo_SelectedIndexChanged);
            // 
            // Company_Inventory
            // 
            this.Company_Inventory.DataSetName = "Company_Inventory";
            this.Company_Inventory.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // mtn_edit_tableBindingSource
            // 
            this.mtn_edit_tableBindingSource.DataMember = "mtn_edit_table";
            this.mtn_edit_tableBindingSource.DataSource = this.Company_Inventory;
            // 
            // mtn_edit_tableTableAdapter
            // 
            this.mtn_edit_tableTableAdapter.ClearBeforeFill = true;
            // 
            // MTN_Edit_Details
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(582, 335);
            this.Controls.Add(this.cmbMtnNo);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.reportViewer1);
            this.MaximizeBox = false;
            this.Name = "MTN_Edit_Details";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MTN Edit Details";
            this.Load += new System.EventHandler(this.MTN_Edit_Details_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Company_Inventory)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mtn_edit_tableBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbMtnNo;
        private System.Windows.Forms.BindingSource mtn_edit_tableBindingSource;
        private Company_Inventory Company_Inventory;
        private Company_InventoryTableAdapters.mtn_edit_tableTableAdapter mtn_edit_tableTableAdapter;
    }
}
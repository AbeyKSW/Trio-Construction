namespace TRIO_Constructions
{
    partial class Claim_Report
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
            this.cmbAction = new System.Windows.Forms.ComboBox();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.Company_Inventory = new TRIO_Constructions.Company_Inventory();
            this.claim_details_tableBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.claim_details_tableTableAdapter = new TRIO_Constructions.Company_InventoryTableAdapters.claim_details_tableTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.Company_Inventory)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.claim_details_tableBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(28, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Action";
            // 
            // cmbAction
            // 
            this.cmbAction.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbAction.FormattingEnabled = true;
            this.cmbAction.Items.AddRange(new object[] {
            "Warranty",
            "Auction",
            "Dispose",
            "Lost"});
            this.cmbAction.Location = new System.Drawing.Point(88, 23);
            this.cmbAction.Name = "cmbAction";
            this.cmbAction.Size = new System.Drawing.Size(121, 21);
            this.cmbAction.TabIndex = 1;
            this.cmbAction.SelectedIndexChanged += new System.EventHandler(this.cmbAction_SelectedIndexChanged);
            // 
            // reportViewer1
            // 
            reportDataSource1.Name = "ClaimReport";
            reportDataSource1.Value = this.claim_details_tableBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "TRIO_Constructions.Claim Report.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(12, 62);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(627, 267);
            this.reportViewer1.TabIndex = 2;
            // 
            // Company_Inventory
            // 
            this.Company_Inventory.DataSetName = "Company_Inventory";
            this.Company_Inventory.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // claim_details_tableBindingSource
            // 
            this.claim_details_tableBindingSource.DataMember = "claim_details_table";
            this.claim_details_tableBindingSource.DataSource = this.Company_Inventory;
            // 
            // claim_details_tableTableAdapter
            // 
            this.claim_details_tableTableAdapter.ClearBeforeFill = true;
            // 
            // Claim_Report
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(652, 341);
            this.Controls.Add(this.reportViewer1);
            this.Controls.Add(this.cmbAction);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.Name = "Claim_Report";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Claim_Report";
            this.Load += new System.EventHandler(this.Claim_Report_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Company_Inventory)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.claim_details_tableBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbAction;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource claim_details_tableBindingSource;
        private Company_Inventory Company_Inventory;
        private Company_InventoryTableAdapters.claim_details_tableTableAdapter claim_details_tableTableAdapter;
    }
}
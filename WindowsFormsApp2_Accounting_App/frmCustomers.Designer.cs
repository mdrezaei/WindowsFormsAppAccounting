
namespace WindowsFormsApp2_Accounting_App
{
    partial class frmCustomers
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
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnAddCustomers = new System.Windows.Forms.ToolStripButton();
            this.btnEditCustomers = new System.Windows.Forms.ToolStripButton();
            this.btnDeleteCustomers = new System.Windows.Forms.ToolStripButton();
            this.btnRefreshCustomer = new System.Windows.Forms.ToolStripButton();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.txtBoxSearchCustomers = new System.Windows.Forms.ToolStripTextBox();
            this.dgvCustomersList = new System.Windows.Forms.DataGridView();
            this.CustomerID_Vis = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FullName_Vis = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Number_Vis = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Email_Vis = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Address_Vis = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCustomersList)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnAddCustomers,
            this.btnEditCustomers,
            this.btnDeleteCustomers,
            this.btnRefreshCustomer,
            this.toolStripLabel1,
            this.txtBoxSearchCustomers});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(619, 62);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btnAddCustomers
            // 
            this.btnAddCustomers.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddCustomers.Image = global::WindowsFormsApp2_Accounting_App.Properties.Resources._1_contact_list;
            this.btnAddCustomers.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnAddCustomers.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAddCustomers.Name = "btnAddCustomers";
            this.btnAddCustomers.Size = new System.Drawing.Size(47, 59);
            this.btnAddCustomers.Text = "افزودن ";
            this.btnAddCustomers.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnAddCustomers.Click += new System.EventHandler(this.btnAddCustomers_Click);
            // 
            // btnEditCustomers
            // 
            this.btnEditCustomers.Image = global::WindowsFormsApp2_Accounting_App.Properties.Resources._1_document_edit;
            this.btnEditCustomers.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnEditCustomers.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnEditCustomers.Name = "btnEditCustomers";
            this.btnEditCustomers.Size = new System.Drawing.Size(47, 59);
            this.btnEditCustomers.Text = "ویرایش";
            this.btnEditCustomers.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnEditCustomers.Click += new System.EventHandler(this.btnEditCustomers_Click);
            // 
            // btnDeleteCustomers
            // 
            this.btnDeleteCustomers.Image = global::WindowsFormsApp2_Accounting_App.Properties.Resources._1_Close_Box_Red;
            this.btnDeleteCustomers.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnDeleteCustomers.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnDeleteCustomers.Name = "btnDeleteCustomers";
            this.btnDeleteCustomers.Size = new System.Drawing.Size(44, 59);
            this.btnDeleteCustomers.Text = "حذف";
            this.btnDeleteCustomers.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnDeleteCustomers.Click += new System.EventHandler(this.btnDeleteCustomers_Click);
            // 
            // btnRefreshCustomer
            // 
            this.btnRefreshCustomer.Image = global::WindowsFormsApp2_Accounting_App.Properties.Resources._1_Refresh;
            this.btnRefreshCustomer.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnRefreshCustomer.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnRefreshCustomer.Name = "btnRefreshCustomer";
            this.btnRefreshCustomer.Size = new System.Drawing.Size(60, 59);
            this.btnRefreshCustomer.Text = "بروزرسانی";
            this.btnRefreshCustomer.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnRefreshCustomer.Click += new System.EventHandler(this.btnRefreshCustomer_Click);
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(47, 59);
            this.toolStripLabel1.Text = "جستجو :";
            // 
            // txtBoxSearchCustomers
            // 
            this.txtBoxSearchCustomers.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtBoxSearchCustomers.Name = "txtBoxSearchCustomers";
            this.txtBoxSearchCustomers.Size = new System.Drawing.Size(100, 62);
            this.txtBoxSearchCustomers.TextChanged += new System.EventHandler(this.txtBoxSearchCustomers_TextChanged);
            // 
            // dgvCustomersList
            // 
            this.dgvCustomersList.AllowUserToAddRows = false;
            this.dgvCustomersList.AllowUserToDeleteRows = false;
            this.dgvCustomersList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvCustomersList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCustomersList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CustomerID_Vis,
            this.FullName_Vis,
            this.Number_Vis,
            this.Email_Vis,
            this.Address_Vis});
            this.dgvCustomersList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvCustomersList.Location = new System.Drawing.Point(0, 62);
            this.dgvCustomersList.Name = "dgvCustomersList";
            this.dgvCustomersList.ReadOnly = true;
            this.dgvCustomersList.Size = new System.Drawing.Size(619, 388);
            this.dgvCustomersList.TabIndex = 1;
            // 
            // CustomerID_Vis
            // 
            this.CustomerID_Vis.DataPropertyName = "CustomerID";
            this.CustomerID_Vis.HeaderText = "شناسه";
            this.CustomerID_Vis.Name = "CustomerID_Vis";
            this.CustomerID_Vis.ReadOnly = true;
            this.CustomerID_Vis.Visible = false;
            // 
            // FullName_Vis
            // 
            this.FullName_Vis.DataPropertyName = "FullName";
            this.FullName_Vis.HeaderText = "نام";
            this.FullName_Vis.Name = "FullName_Vis";
            this.FullName_Vis.ReadOnly = true;
            // 
            // Number_Vis
            // 
            this.Number_Vis.DataPropertyName = "Number";
            this.Number_Vis.HeaderText = "تلفن";
            this.Number_Vis.Name = "Number_Vis";
            this.Number_Vis.ReadOnly = true;
            // 
            // Email_Vis
            // 
            this.Email_Vis.DataPropertyName = "Email";
            this.Email_Vis.HeaderText = "ایمیل";
            this.Email_Vis.Name = "Email_Vis";
            this.Email_Vis.ReadOnly = true;
            // 
            // Address_Vis
            // 
            this.Address_Vis.DataPropertyName = "Address";
            this.Address_Vis.HeaderText = "ادرس";
            this.Address_Vis.Name = "Address_Vis";
            this.Address_Vis.ReadOnly = true;
            // 
            // frmCustomers
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(619, 450);
            this.Controls.Add(this.dgvCustomersList);
            this.Controls.Add(this.toolStrip1);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmCustomers";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "لیست اشخاص";
            this.Load += new System.EventHandler(this.frmCustomers_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCustomersList)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btnAddCustomers;
        private System.Windows.Forms.ToolStripButton btnEditCustomers;
        private System.Windows.Forms.ToolStripButton btnDeleteCustomers;
        private System.Windows.Forms.ToolStripButton btnRefreshCustomer;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripTextBox txtBoxSearchCustomers;
        private System.Windows.Forms.DataGridView dgvCustomersList;
        private System.Windows.Forms.DataGridViewTextBoxColumn CustomerID_Vis;
        private System.Windows.Forms.DataGridViewTextBoxColumn FullName_Vis;
        private System.Windows.Forms.DataGridViewTextBoxColumn Number_Vis;
        private System.Windows.Forms.DataGridViewTextBoxColumn Email_Vis;
        private System.Windows.Forms.DataGridViewTextBoxColumn Address_Vis;
    }
}
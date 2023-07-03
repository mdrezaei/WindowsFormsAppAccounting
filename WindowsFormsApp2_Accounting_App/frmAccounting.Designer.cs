
namespace WindowsFormsApp2_Accounting_App
{
    partial class frmAccounting
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAccounting));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dgvAccountingCustomers = new System.Windows.Forms.DataGridView();
            this.AccountingCustomersInfo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtAccountingSearch = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtAccountingName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.rbPayment = new System.Windows.Forms.RadioButton();
            this.rbIncome = new System.Windows.Forms.RadioButton();
            this.label3 = new System.Windows.Forms.Label();
            this.txtNOAmount = new System.Windows.Forms.NumericUpDown();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnSubmit = new System.Windows.Forms.Button();
            this.rangeValidator1 = new ValidationComponents.RangeValidator(this.components);
            this.requiredFieldValidator1 = new ValidationComponents.RequiredFieldValidator(this.components);
            this.dtpAccountingTransactoinTime = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAccountingCustomers)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNOAmount)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dgvAccountingCustomers);
            this.groupBox1.Controls.Add(this.txtAccountingSearch);
            this.groupBox1.Location = new System.Drawing.Point(13, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.groupBox1.Size = new System.Drawing.Size(200, 426);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "اشخاص";
            // 
            // dgvAccountingCustomers
            // 
            this.dgvAccountingCustomers.AllowUserToAddRows = false;
            this.dgvAccountingCustomers.AllowUserToDeleteRows = false;
            this.dgvAccountingCustomers.AllowUserToResizeColumns = false;
            this.dgvAccountingCustomers.AllowUserToResizeRows = false;
            this.dgvAccountingCustomers.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvAccountingCustomers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAccountingCustomers.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.AccountingCustomersInfo});
            this.dgvAccountingCustomers.Location = new System.Drawing.Point(7, 46);
            this.dgvAccountingCustomers.Name = "dgvAccountingCustomers";
            this.dgvAccountingCustomers.ReadOnly = true;
            this.dgvAccountingCustomers.Size = new System.Drawing.Size(187, 374);
            this.dgvAccountingCustomers.TabIndex = 1;
            this.dgvAccountingCustomers.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvAccountingCustomers_CellClick);
            // 
            // AccountingCustomersInfo
            // 
            this.AccountingCustomersInfo.DataPropertyName = "FullName";
            this.AccountingCustomersInfo.HeaderText = "نام شخص";
            this.AccountingCustomersInfo.Name = "AccountingCustomersInfo";
            this.AccountingCustomersInfo.ReadOnly = true;
            // 
            // txtAccountingSearch
            // 
            this.txtAccountingSearch.Location = new System.Drawing.Point(7, 20);
            this.txtAccountingSearch.Name = "txtAccountingSearch";
            this.txtAccountingSearch.Size = new System.Drawing.Size(187, 21);
            this.txtAccountingSearch.TabIndex = 0;
            this.txtAccountingSearch.TextChanged += new System.EventHandler(this.txtAccountingSearch_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(541, 35);
            this.label1.Name = "label1";
            this.label1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label1.Size = new System.Drawing.Size(27, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "نام :";
            // 
            // txtAccountingName
            // 
            this.txtAccountingName.Location = new System.Drawing.Point(219, 32);
            this.txtAccountingName.Name = "txtAccountingName";
            this.txtAccountingName.ReadOnly = true;
            this.txtAccountingName.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtAccountingName.Size = new System.Drawing.Size(265, 21);
            this.txtAccountingName.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(541, 58);
            this.label2.Name = "label2";
            this.label2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label2.Size = new System.Drawing.Size(66, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "نوع تراکنش :";
            // 
            // rbPayment
            // 
            this.rbPayment.AutoSize = true;
            this.rbPayment.Location = new System.Drawing.Point(397, 59);
            this.rbPayment.Name = "rbPayment";
            this.rbPayment.Size = new System.Drawing.Size(63, 17);
            this.rbPayment.TabIndex = 4;
            this.rbPayment.TabStop = true;
            this.rbPayment.Text = "پرداختی";
            this.rbPayment.UseVisualStyleBackColor = true;
            // 
            // rbIncome
            // 
            this.rbIncome.AutoSize = true;
            this.rbIncome.Location = new System.Drawing.Point(304, 59);
            this.rbIncome.Name = "rbIncome";
            this.rbIncome.Size = new System.Drawing.Size(60, 17);
            this.rbIncome.TabIndex = 5;
            this.rbIncome.TabStop = true;
            this.rbIncome.Text = "دریافتی";
            this.rbIncome.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(541, 84);
            this.label3.Name = "label3";
            this.label3.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label3.Size = new System.Drawing.Size(34, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "مبلغ :";
            // 
            // txtNOAmount
            // 
            this.txtNOAmount.Location = new System.Drawing.Point(219, 82);
            this.txtNOAmount.Maximum = new decimal(new int[] {
            1999999999,
            0,
            0,
            0});
            this.txtNOAmount.Name = "txtNOAmount";
            this.txtNOAmount.Size = new System.Drawing.Size(265, 21);
            this.txtNOAmount.TabIndex = 7;
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(220, 136);
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtDescription.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtDescription.Size = new System.Drawing.Size(265, 266);
            this.txtDescription.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(541, 139);
            this.label4.Name = "label4";
            this.label4.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label4.Size = new System.Drawing.Size(54, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "توضیحات :";
            // 
            // btnSubmit
            // 
            this.btnSubmit.Location = new System.Drawing.Point(220, 408);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(264, 23);
            this.btnSubmit.TabIndex = 10;
            this.btnSubmit.Text = "ثبت";
            this.btnSubmit.UseVisualStyleBackColor = true;
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
            // 
            // rangeValidator1
            // 
            this.rangeValidator1.CancelFocusChangeWhenInvalid = false;
            this.rangeValidator1.ControlToValidate = this.txtNOAmount;
            this.rangeValidator1.ErrorMessage = "لطفا ععدی صحیح مثبت وارد کنید";
            this.rangeValidator1.Icon = ((System.Drawing.Icon)(resources.GetObject("rangeValidator1.Icon")));
            this.rangeValidator1.MaximumValue = "1999999999";
            this.rangeValidator1.MinimumValue = "1";
            this.rangeValidator1.Type = ValidationComponents.ValidationDataType.Integer;
            // 
            // requiredFieldValidator1
            // 
            this.requiredFieldValidator1.CancelFocusChangeWhenInvalid = false;
            this.requiredFieldValidator1.ControlToValidate = this.txtAccountingName;
            this.requiredFieldValidator1.ErrorMessage = "شخصی را انتخاب کنید";
            this.requiredFieldValidator1.Icon = ((System.Drawing.Icon)(resources.GetObject("requiredFieldValidator1.Icon")));
            // 
            // dtpAccountingTransactoinTime
            // 
            this.dtpAccountingTransactoinTime.Location = new System.Drawing.Point(219, 109);
            this.dtpAccountingTransactoinTime.Name = "dtpAccountingTransactoinTime";
            this.dtpAccountingTransactoinTime.Size = new System.Drawing.Size(264, 21);
            this.dtpAccountingTransactoinTime.TabIndex = 11;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(541, 115);
            this.label5.Name = "label5";
            this.label5.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label5.Size = new System.Drawing.Size(72, 13);
            this.label5.TabIndex = 12;
            this.label5.Text = "تاریخ تراکنش :";
            // 
            // frmAccounting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(619, 450);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.dtpAccountingTransactoinTime);
            this.Controls.Add(this.btnSubmit);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.txtNOAmount);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.rbIncome);
            this.Controls.Add(this.rbPayment);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtAccountingName);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmAccounting";
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "تراکنش";
            this.Load += new System.EventHandler(this.frmAccounting_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAccountingCustomers)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNOAmount)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dgvAccountingCustomers;
        private System.Windows.Forms.TextBox txtAccountingSearch;
        private System.Windows.Forms.DataGridViewTextBoxColumn AccountingCustomersInfo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtAccountingName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RadioButton rbPayment;
        private System.Windows.Forms.RadioButton rbIncome;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown txtNOAmount;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnSubmit;
        private ValidationComponents.RangeValidator rangeValidator1;
        private ValidationComponents.RequiredFieldValidator requiredFieldValidator1;
        private System.Windows.Forms.DateTimePicker dtpAccountingTransactoinTime;
        private System.Windows.Forms.Label label5;
    }
}
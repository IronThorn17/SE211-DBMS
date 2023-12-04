namespace SE211GroupProject
{
    partial class MainMenu
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
            this.label1 = new System.Windows.Forms.Label();
            this.btnDepartmentTable = new System.Windows.Forms.Button();
            this.btnEmployeesTable = new System.Windows.Forms.Button();
            this.btnManagerInfoTable = new System.Windows.Forms.Button();
            this.btnPayrollTable = new System.Windows.Forms.Button();
            this.btnTimeCardTable = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(128, 59);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(107, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Choose Table";
            // 
            // btnDepartmentTable
            // 
            this.btnDepartmentTable.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDepartmentTable.Location = new System.Drawing.Point(132, 102);
            this.btnDepartmentTable.Name = "btnDepartmentTable";
            this.btnDepartmentTable.Size = new System.Drawing.Size(103, 26);
            this.btnDepartmentTable.TabIndex = 1;
            this.btnDepartmentTable.Text = "Department";
            this.btnDepartmentTable.UseVisualStyleBackColor = true;
            this.btnDepartmentTable.Click += new System.EventHandler(this.btnDepartmentTable_Click);
            // 
            // btnEmployeesTable
            // 
            this.btnEmployeesTable.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEmployeesTable.Location = new System.Drawing.Point(132, 134);
            this.btnEmployeesTable.Name = "btnEmployeesTable";
            this.btnEmployeesTable.Size = new System.Drawing.Size(103, 26);
            this.btnEmployeesTable.TabIndex = 3;
            this.btnEmployeesTable.Text = "Employee";
            this.btnEmployeesTable.UseVisualStyleBackColor = true;
            this.btnEmployeesTable.Click += new System.EventHandler(this.btnEmployeesTable_Click);
            // 
            // btnManagerInfoTable
            // 
            this.btnManagerInfoTable.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnManagerInfoTable.Location = new System.Drawing.Point(132, 166);
            this.btnManagerInfoTable.Name = "btnManagerInfoTable";
            this.btnManagerInfoTable.Size = new System.Drawing.Size(103, 26);
            this.btnManagerInfoTable.TabIndex = 4;
            this.btnManagerInfoTable.Text = "Manager";
            this.btnManagerInfoTable.UseVisualStyleBackColor = true;
            this.btnManagerInfoTable.Click += new System.EventHandler(this.btnManagerInfoTable_Click);
            // 
            // btnPayrollTable
            // 
            this.btnPayrollTable.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPayrollTable.Location = new System.Drawing.Point(132, 198);
            this.btnPayrollTable.Name = "btnPayrollTable";
            this.btnPayrollTable.Size = new System.Drawing.Size(103, 26);
            this.btnPayrollTable.TabIndex = 5;
            this.btnPayrollTable.Text = "Payroll";
            this.btnPayrollTable.UseVisualStyleBackColor = true;
            this.btnPayrollTable.Click += new System.EventHandler(this.btnPayrollTable_Click);
            // 
            // btnTimeCardTable
            // 
            this.btnTimeCardTable.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTimeCardTable.Location = new System.Drawing.Point(132, 230);
            this.btnTimeCardTable.Name = "btnTimeCardTable";
            this.btnTimeCardTable.Size = new System.Drawing.Size(103, 26);
            this.btnTimeCardTable.TabIndex = 6;
            this.btnTimeCardTable.Text = "Time Card";
            this.btnTimeCardTable.UseVisualStyleBackColor = true;
            this.btnTimeCardTable.Click += new System.EventHandler(this.btnTimeCardTable_Click);
            // 
            // MainMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 373);
            this.Controls.Add(this.btnTimeCardTable);
            this.Controls.Add(this.btnPayrollTable);
            this.Controls.Add(this.btnManagerInfoTable);
            this.Controls.Add(this.btnEmployeesTable);
            this.Controls.Add(this.btnDepartmentTable);
            this.Controls.Add(this.label1);
            this.Name = "MainMenu";
            this.Text = "MainMenu";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnDepartmentTable;
        private System.Windows.Forms.Button btnEmployeesTable;
        private System.Windows.Forms.Button btnManagerInfoTable;
        private System.Windows.Forms.Button btnPayrollTable;
        private System.Windows.Forms.Button btnTimeCardTable;
    }
}
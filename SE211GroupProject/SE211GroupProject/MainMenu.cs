using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SE211GroupProject
{
    public partial class MainMenu : Form
    {
        public MainMenu()
        {
            InitializeComponent();
        }

        private void btnDepartmentTable_Click(object sender, EventArgs e)
        {
            Department department = new Department();
            department.Show();
            this.Hide();
        }

        private void btnEmployeesTable_Click(object sender, EventArgs e)
        {
            Employee employeeTable = new Employee();
            employeeTable.Show();
            this.Hide();
        }

        private void btnManagerInfoTable_Click(object sender, EventArgs e)
        {
            Manager manager = new Manager();
            manager.Show();
            this.Hide();
        }

        private void btnTimeCardTable_Click(object sender, EventArgs e)
        {
            TimeCard timeCard = new TimeCard();
            timeCard.Show();
            this.Hide();
        }

        private void btnPayrollTable_Click(object sender, EventArgs e)
        {
            Payroll payroll = new Payroll();
            payroll.Show();
            this.Hide();
        }
    }
}

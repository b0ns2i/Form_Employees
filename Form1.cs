using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Form_Employees
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AddEmployee employee = new AddEmployee();
            employee.Show();


        }

        private void button2_Click(object sender, EventArgs e)
        {

            AddTypePhone typePhone = new AddTypePhone();
            typePhone.Show();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            AddDepartment addDepartment = new AddDepartment();
            addDepartment.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            InfoEmployees infoEmployees = new InfoEmployees();
            infoEmployees.Show();
        }
    }
}

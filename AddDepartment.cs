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

    public partial class AddDepartment : Form
    {
        TestCoreEntities testCore = new TestCoreEntities();

        public AddDepartment()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            Departments department = new Departments() { Department_Id = Guid.NewGuid(), Department_Name = textBox1.Text };
            testCore.Departments.Add(department);
            testCore.SaveChanges();
            textBox1.Clear();

        }
    }
}

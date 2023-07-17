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
    public partial class AddTypePhone : Form
    {
        TestCoreEntities testCore = new TestCoreEntities();

        public AddTypePhone()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            TypePhone typePhone = new TypePhone() { TypePhone_Id = Guid.NewGuid(), TypePhone_Name = textBox1.Text };
            var tp = testCore.TypePhone.Add(typePhone);

            testCore.SaveChanges();

        }
    }
}

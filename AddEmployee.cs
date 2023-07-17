using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Form_Employees
{
    public partial class AddEmployee : Form
    {

        TestCoreEntities testCore = new TestCoreEntities();
        


        public AddEmployee()
        {
            InitializeComponent();

            List<TypePhone> typesPhone = testCore.TypePhone.ToList();

            foreach (var t in typesPhone)
            {
                comboBox1.Items.Add(t.TypePhone_Name);
            }

            List<Departments> departments = testCore.Departments.ToList();

            foreach (var item in departments)
            {
                comboBox2.Items.Add(item.Department_Name);
            }


        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void AddEmployee_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {


           


            var departments = testCore.Departments.Where(x => x.Department_Name == comboBox2.Text).ToList();
            Employees employee = new Employees { Employees_Id = Guid.NewGuid(), Employees_FIO = textBox1.Text };

            employee.Departments = departments;
           



            Email email = new Email()
            {
                Email_Id = Guid.NewGuid(),
                Email_Name = textBox4.Text,
                Employees_Id = employee.Employees_Id,

            };

            List<TypePhone> typePhones = testCore.TypePhone.Where(tp => tp.TypePhone_Name == comboBox1.Text).ToList();

            Phone phone = new Phone()
            {
                Phone_Id = Guid.NewGuid(),
                Phone_Name = textBox2.Text,
                TypePhone_Id = typePhones.First().TypePhone_Id,
                Employees_Id = employee.Employees_Id
            };
           
            testCore.Employees.Add(employee);
            //testCore.EmployeesToDepartment.Add(employeesToDepartment);
            testCore.Email.Add(email);
            testCore.Phone.Add(phone);
            testCore.SaveChanges();
            textBox1.Clear();
            textBox2.Clear();
            textBox4.Clear();
            comboBox1.Text = "";
            comboBox2.Text = "";




        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            var departments = testCore.Departments.Where(x => x.Department_Name == comboBox2.Text).ToList();

            

        }
    }
}

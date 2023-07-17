using Form_Employees.Сlasses;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Form_Employees
{
    public partial class InfoEmployees : Form
    {

        TestCoreEntities testCore = new TestCoreEntities();
       
        public InfoEmployees()
        {
            InitializeComponent();

            AddDataGridView2();

            AddDataGridView3();

            AddDataGridView4();
        }


        public void AddDataGridView2()
        {
            dataGridView2.DataSource = testCore.Employees.ToList();
            dataGridView2.Columns[2].Visible = false;
            dataGridView2.Columns[3].Visible = false;
            dataGridView2.Columns[4].Visible = false;
        }

        public void AddDataGridView3()
        {
            dataGridView3.DataSource = testCore.Email.ToList();
            dataGridView3.Columns[2].Visible = false;
            dataGridView3.Columns[3].Visible = false;
        }

        public void AddDataGridView4()
        {
            dataGridView4.DataSource = testCore.Phone.ToList();
            dataGridView4.Columns[2].Visible = false;
            dataGridView4.Columns[3].Visible = false;
            dataGridView4.Columns[4].Visible = false;
            dataGridView4.Columns[5].Visible = false;
        }


        private void button1_Click_1(object sender, EventArgs e)
        {
            //var employees = testCore.Employees.ToList();

            //var employees = testCore.Employees.Select(em => new Employee

            //{
            //    Employee_Id = em.Employees_Id,
            //    Employee_Name = em.Employees_FIO
            //});


            //IQueryable<Employees> employee1 = testCore.Employees.Where(em => em.Employees_FIO == textBox1.Text);
            //IQueryable<EmployeesToDepartment> employeesToDepartments = testCore.EmployeesToDepartment.Where(ed => ed.Employees_Id == employee1.First().Employees_Id);


            //Guid g = employee1.First().Employees_Id;



            //var test = testCore.Employees.Where(p => p.Employees_FIO = textBox1.Text).ToList();


            //var dep = testCore.Departments.ToList();
            //var dep1 = dep.Where(d => d.Department_Id == );

            var employees = from employee in testCore.Employees
                            join email in testCore.Email on employee.Employees_Id equals email.Employees_Id
                            join phone in testCore.Phone on employee.Employees_Id equals phone.Employees_Id
                            //join department in testCore.Departments on employee.Departments equals department.i
                            //join department in testCore.Departments on employee.Employees_Id equals testCore.Departments.E
                            //First().Department_Id equals department.Department_Id
                            where employee.Employees_FIO == textBox1.Text

                            select new FullInfoEmployee
                            {
                                
                                Employees_ID = employee.Employees_Id,
                                Employees_FIO = employee.Employees_FIO,
                                Email_Name = email.Email_Name,
                                Phone_Name = phone.Phone_Name,
                                //Department_Name = department.Department_Name
                            };





            dataGridView1.DataSource = employees.ToList();






        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void InfoEmployees_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            testCore.SaveChanges();
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
          

        }

        private void button4_Click(object sender, EventArgs e)
        {


            if (dataGridView2.SelectedRows.Count > 0)
            {
                int index = dataGridView2.SelectedRows[0].Index;
                Guid id;
                bool converted = Guid.TryParse(dataGridView2[0, index].Value.ToString(), out id);
                if (converted == false)
                    return;

                Employees employees = testCore.Employees.Find(id);
                testCore.Employees.Remove(employees);
                testCore.SaveChanges();



                AddDataGridView2();

                AddDataGridView3();

                AddDataGridView4();


                MessageBox.Show("Объект удален");
            }


        }

        private void button6_Click(object sender, EventArgs e)
        {

            if (dataGridView3.SelectedRows.Count > 0)
            {
                int index = dataGridView3.SelectedRows[0].Index;
                Guid id;
                bool converted = Guid.TryParse(dataGridView3[0, index].Value.ToString(), out id);
                if (converted == false)
                    return;

                Email email = testCore.Email.Find(id);
                testCore.Email.Remove(email);
                testCore.SaveChanges();

                AddDataGridView3();

                MessageBox.Show("Объект удален");
            }

        }

        private void button7_Click(object sender, EventArgs e)
        {


            if (dataGridView4.SelectedRows.Count > 0)
            {
                int index = dataGridView4.SelectedRows[0].Index;
                Guid id;
                bool converted = Guid.TryParse(dataGridView4[0, index].Value.ToString(), out id);
                if (converted == false)
                    return;

                Phone phone = testCore.Phone.Find(id);
                testCore.Phone.Remove(phone);
                testCore.SaveChanges();

                AddDataGridView4();

                MessageBox.Show("Объект удален");
            }

        }
    }
}

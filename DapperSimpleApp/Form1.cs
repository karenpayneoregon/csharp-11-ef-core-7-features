using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Windows.Forms;
using Dapper;
using DapperSimpleApp.Models;

namespace DapperSimpleApp
{
    public partial class Form1 : Form
    {
        private string connectionString =
            "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=InsertExamples;Integrated Security=True;Encrypt=False";

        private BindingSource BindingSource = new BindingSource();

        public Form1()
        {
            InitializeComponent();
        }

        /*
         * Test connection to database
         */
        private void ConnectionButton_Click(object sender, EventArgs e)
        {
            using (var cn = new SqlConnection(connectionString))
            {
                try
                {
                    cn.Open();
                    GetAllButton.Enabled = true;
                    MessageBox.Show("Open");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Failed: " + ex.Message);
                }

            }
        }

        /*
         * Get all records from Person table
         */
        private void GetAllButton_Click(object sender, EventArgs e)
        {
            var statement = "SELECT Id,FirstName,LastName,BirthDate FROM dbo.Person;";
            using (var cn = new SqlConnection(connectionString))
            {
                var list = cn.Query<Person>(statement).AsList();
                BindingSource.DataSource = list;
                bindingNavigator1.BindingSource = BindingSource;
                dataGridView1.DataSource = BindingSource;
                CurrentButton.Enabled = true;
            }
        }

        /*
         * Get the current person from the DataGridView than query the record
         * in the database table to show how parameters are done.
         */
        private void CurrentButton_Click(object sender, EventArgs e)
        {
            var currentPerson = (Person)BindingSource.Current;
            var statement = "SELECT Id,FirstName,LastName,BirthDate FROM dbo.Person WHERE Id = @Id;";
            using (var cn = new SqlConnection(connectionString))
            {
                Person person = cn.QueryFirst<Person>(statement, new { Id = currentPerson.Id });
                MessageBox.Show($"From database {person}");
            }
        }
    }
}

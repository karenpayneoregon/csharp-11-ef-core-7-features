using System;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Windows.Forms;
using Dapper;
using DapperSimpleApp.Classes;
using DapperSimpleApp.Models;
using DapperSimpleApp.Validators;
using FluentValidation.Results;

namespace DapperSimpleApp
{
    public partial class Form1 : Form
    {
        private string connectionString =
            "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=InsertExamples;Integrated Security=True;Encrypt=False";

        private BindingSource BindingSource = new BindingSource();

        /// <summary>
        /// Provides ability to sort the DataGridView
        /// </summary>
        private SortableBindingList<Person> BindingList;

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
            using (var cn = new SqlConnection(connectionString))
            {
                var list = cn.Query<Person>(SqlStatements.GetAllPeople).AsList();
                BindingList = new SortableBindingList<Person>(list);
                BindingSource.DataSource = BindingList;
                bindingNavigator1.BindingSource = BindingSource;
                dataGridView1.DataSource = BindingSource;
                dataGridView1.ExpandColumns();
                BindingSource.ListChanged += BindingSource_ListChanged;
                CurrentButton.Enabled = true;
            }
        }

        /// <summary>
        /// Started code for updating a changed record if valid via <see cref="PersonValidator"/>
        /// </summary>
        private void BindingSource_ListChanged(object sender, ListChangedEventArgs e)
        {
            if (e.ListChangedType == ListChangedType.ItemChanged)
            {
                Person currentPerson = BindingList[e.OldIndex];
                PersonValidator validator = new PersonValidator();
                ValidationResult result = validator.Validate(currentPerson);

                if (result.IsValid)
                {
                    using (var cn = new SqlConnection(connectionString))
                    {
                        cn.Execute(SqlStatements.UpdatePerson, new
                        {
                            currentPerson.FirstName, 
                            currentPerson.LastName, 
                            currentPerson.BirthDate, 
                            currentPerson.Id
                        });
                    }
                }
                else
                {
                    /*
                     * Reset from database table and in a multi-user environment there may have
                     * been changes to this record since the app started so be aware of this.
                     */
                    using (var cn = new SqlConnection(connectionString))
                    {
                        var person = cn.QueryFirst<Person>(SqlStatements.GetPerson, new { Id = currentPerson.Id });
                        BindingList[e.OldIndex] = person;
                    }
                }

            }
        }
        
        /*
         * Get the current person from the DataGridView than query the record
         * in the database table to show how parameters are done.
         */
        private void CurrentButton_Click(object sender, EventArgs e)
        {
            var currentPerson = BindingList[BindingSource.Position];
            using (var cn = new SqlConnection(connectionString))
            {
                Person person = cn.QueryFirst<Person>(SqlStatements.GetPerson, new { Id = currentPerson.Id });
                MessageBox.Show($"From database {person}");
            }
        }

        private void ValidateButton_Click(object sender, EventArgs e)
        {

            using (var f = new SampleValidationForm())
            {
                f.ValidPerson += ValidPersonFromChildForm;
                f.ShowDialog();
            }

        }
        /// <summary>
        /// If the <see cref="Person"/> is valid in the child form, pass it back to
        /// here which perhaps add to the database table than if successful add to the
        /// BindingList which will have it shown in the DataGridView.
        /// </summary>
        /// <param name="person"></param>
        private void ValidPersonFromChildForm(Person person)
        {
            MessageBox.Show($"{person.FirstName} {person.LastName} {person.BirthDate:d}");
        }
    }
}

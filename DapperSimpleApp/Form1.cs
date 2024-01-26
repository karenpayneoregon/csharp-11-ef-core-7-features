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

        private BindingSource _bindingSource = new BindingSource();

        /// <summary>
        /// Provides ability to sort the DataGridView
        /// </summary>
        private SortableBindingList<Person> _bindingList;

        public Form1()
        {
            InitializeComponent();
            bindingNavigatorDeleteItem.Enabled = false;

            if (Environment.UserName == "PayneK")
            {
                GetAllButton.Enabled = true;
            }
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
                // read from database
                var list = cn.Query<Person>(SqlStatements.GetAllPeople).AsList();

                _bindingList = new SortableBindingList<Person>(list);
                _bindingSource.DataSource = _bindingList;
                bindingNavigator1.BindingSource = _bindingSource;
                dataGridView1.DataSource = _bindingSource;

                dataGridView1.ExpandColumns();
                _bindingSource.ListChanged += BindingSource_ListChanged;

                CurrentButton.Enabled = true;
                bindingNavigatorDeleteItem.Enabled = true;

                /*
                 * Override default action of the BindingNavigator delete button
                 * Note step 1 was to remove the default in the designer.
                 */
                bindingNavigatorDeleteItem.Click += BindingNavigatorDeleteItem_Click;

                // No records yet so disable delete button in the BindingNavigator
                bindingNavigatorDeleteItem.Enabled = _bindingList.Count > 0;
            }
        }

        /// <summary>
        /// Manually handle delete action
        /// - Ask permission to remove current record
        /// - Delete from database
        /// - If delete successful remove from the BindingList which in turn removes the person from the DataGridView
        /// </summary>
        private void BindingNavigatorDeleteItem_Click(object sender, EventArgs e)
        {
            if (_bindingSource.Current != null)
            {
                var currentPerson = _bindingList[_bindingSource.Position];
                if (Dialogs.Question($"Delete {currentPerson.FirstName} {currentPerson.LastName} ?"))
                {
                    using (var cn = new SqlConnection(connectionString))
                    {
                        var affected = cn.Execute(SqlStatements.RemovePerson, new { currentPerson.Id });
                        if (affected == 1)
                        {
                            _bindingSource.RemoveCurrent();
                            bindingNavigatorDeleteItem.Enabled = _bindingList.Count > 0;
                        }
                        else
                        {
                            MessageBox.Show("Failed to remove record");
                        }
                    }
                }
            }
            
        }

        /// <summary>
        /// Started code for updating a changed record if valid via <see cref="PersonValidator"/>
        /// </summary>
        private void BindingSource_ListChanged(object sender, ListChangedEventArgs e)
        {
            if (e.ListChangedType == ListChangedType.ItemChanged)
            {
                Person currentPerson = _bindingList[e.OldIndex];
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
                        _bindingList[e.OldIndex] = person;
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
            var currentPerson = _bindingList[_bindingSource.Position];
            using (var cn = new SqlConnection(connectionString))
            {
                Person person = cn.QueryFirst<Person>(SqlStatements.GetPerson, new { currentPerson.Id });
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
        ///
        /// This happens only if the DataGridView is currently populated.
        /// </summary>
        /// <param name="person"></param>
        private void ValidPersonFromChildForm(Person person)
        {
            if (CurrentButton.Enabled)
            {
                using (var cn = new SqlConnection(connectionString))
                {
                    person.Id = cn.QueryFirst<int>(SqlStatements.InsertPerson, person);
                    _bindingList.Add(person);
                }
            }
            else
            {
                MessageBox.Show("Read all records and try again.");
            }
        }
    }
}

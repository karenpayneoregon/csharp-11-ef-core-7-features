using System;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DapperSimpleApp.Models;
using DapperSimpleApp.Validators;
using FluentValidation.Results;

namespace DapperSimpleApp
{
    public partial class SampleValidationForm : Form
    {
        public delegate void OnValidatePerson(Person person);
        public  event OnValidatePerson ValidPerson;

        private Person Person { get; set; }
        public SampleValidationForm()
        {
            InitializeComponent();
        }

        private void ValidateButton_Click(object sender, EventArgs e)
        {
            Person = new Person()
            {
                FirstName = FirstNameTextBox.Text,
                LastName = LastNameTextBox.Text,
                BirthDate = BrthDateTimePicker.Value
            };

            /*
             * Validate Person
             */
            PersonValidator validator = new PersonValidator();
            ValidationResult result = validator.Validate(Person);

            if (!result.IsValid)
            {
                var builder = new StringBuilder();
                result.Errors.Select(x => x.ErrorMessage)
                    .ToList().ForEach(x => builder.AppendLine(x));
                MessageBox.Show(builder.ToString());
            }
            else
            {
                ValidPerson?.Invoke(Person);
                Close();
            }
        }
    }
}

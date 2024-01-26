using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DapperSimpleApp.Classes;
using DapperSimpleApp.Models;
using DapperSimpleApp.Validators;
using FluentValidation.Results;

namespace DapperSimpleApp
{
    /// <summary>
    /// Cancel button DialogResult is set to cancel which will close this form
    /// and no action is taken in the calling form.
    /// </summary>
    public partial class AddPersonForm : Form
    {
        public delegate void OnValidatePerson(Person person);
        public  event OnValidatePerson ValidPerson;
        private readonly Dictionary<string, Control> _controls = new Dictionary<string, Control>();
        private Person Person { get; set; }
        public AddPersonForm()
        {
            InitializeComponent();

            IEnumerable<Control> items = this.Descendants<Control>()
                .Where(x => x.Tag != null);

            foreach (Control item in items)
            {
                _controls.Add(item.Tag.ToString(), item);
            }
        }

        private void AddNewButton_Click(object sender, EventArgs e)
        {
            // clear error provider text on each control
            foreach (var control in _controls)
            {
                errorProvider1.SetError(control.Value, "");
            }

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
                /*
                 * Show issues
                 * 
                 */
                //var builder = new StringBuilder();
                //result.Errors.Select(x => x.ErrorMessage).ToList().ForEach(x => builder.AppendLine(x));
                //MessageBox.Show(builder.ToString());
                foreach (var item in result.Errors)
                {
                    
                    if (_controls.TryGetValue(item.PropertyName, out var control))
                    {
                        errorProvider1.SetError(control, item.ErrorMessage);
                    }
                }
            }
            else
            {
                ValidPerson?.Invoke(Person);
                Close();
            }
        }
    }
}

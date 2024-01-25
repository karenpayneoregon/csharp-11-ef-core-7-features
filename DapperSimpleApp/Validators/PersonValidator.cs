using System;
using DapperSimpleApp.Models;
using FluentValidation;

namespace DapperSimpleApp.Validators
{
    /// <summary>
    /// Basic example for a validator
    /// </summary>
    public class PersonValidator : AbstractValidator<Person>
    {
        public PersonValidator()
        {
            RuleFor(x => x.FirstName).NotEmpty();
            RuleFor(x => x.LastName).NotEmpty();
            RuleFor(x => x.BirthDate).LessThan(x => new DateTime(2006,1,1));
        }
    }
}
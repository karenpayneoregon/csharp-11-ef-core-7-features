using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using DapperSimpleApp.Models;

// ReSharper disable ConvertConstructorToMemberInitializers

namespace DapperSimpleApp.Classes
{
    /// <summary>
    /// CRUD operations void of exception handling
    /// </summary>
    internal class PersonOperations
    {
        private IDbConnection _cn;

        public PersonOperations()
            => _cn = new SqlConnection(ConfigureSettings.Get().ConnectionString);

        public List<Person> GetList() 
            => _cn.Query<Person>(SqlStatements.GetAllPeople).AsList();

        public void Update(Person currentPerson)
        {
            _cn.Execute(SqlStatements.UpdatePerson, new { currentPerson.FirstName, currentPerson.LastName, currentPerson.BirthDate, currentPerson.Id });
        }

        public Person Get(int id) 
            => _cn.QueryFirst<Person>(SqlStatements.GetPerson, new { Id = id });

        public void Add(Person person)
        {
            person.Id = _cn.QueryFirst<int>(SqlStatements.InsertPerson, person);
        }

        public bool Delete(int id) 
            => _cn.Execute(SqlStatements.RemovePerson, new { Id = id  }) == 1;
    }
}

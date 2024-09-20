using System.Collections.Generic;

namespace SwitchExpressions.Classes
{
    public class Manager : Person
    {
        public int ManagerId { get; set; }
        public int Years { get; set; }
        public List<Employee> Employees = new();
    }


}

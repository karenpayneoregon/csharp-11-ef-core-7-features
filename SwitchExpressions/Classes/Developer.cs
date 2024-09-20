using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwitchExpressions.Classes
{
    public enum Experience
    {
        Novice,
        Professional,
        Guru
    }
    public class Developer  : Person
    {
        public Experience Experience { get; set; }
    }
}

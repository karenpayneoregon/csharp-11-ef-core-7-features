using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuestionOfTheDay.Models;
public class GroupMember
{
    public string FullName { get; }
    public List<Member> Lists { get; }

    public GroupMember(string name, List<Member> items)
    {
        FullName = name;
        Lists = items;
    }
    public override string ToString() => FullName;

}
using QuestionOfTheDay.Models;

namespace QuestionOfTheDay.Classes;

internal class MemberOperations
{
    public static IEnumerable<Member> MembersList() =>
    [
        new() { Id = 1, Active = true, FirstName = "Mary", SurName = "Adams" },
        new() { Id = 2, Active = false, FirstName = "Sue", SurName = "Williams" },
        new() { Id = 3, Active = true, FirstName = "Jake", SurName = "Burns" },
        new() { Id = 4, Active = true, FirstName = "Jake", SurName = "Burns" },
        new() { Id = 5, Active = true, FirstName = "Clair", SurName = "Smith" },
        new() { Id = 6, Active = true, FirstName = "Mary", SurName = "Adams" },
        new() { Id = 7, Active = true, FirstName = "Sue", SurName = "Miller" }
    ];

    /// <summary>
    /// Get duplicate active members
    /// </summary>
    /// <param name="list">List of <see cref="Member"/></param>
    /// <returns>Duplicates</returns>
    public static List<GroupMember> GetDuplicateActiveMembers(IEnumerable<Member> list) =>
        list
            .GroupBy(member => (Name: member.FirstName, member.SurName, member.Active))
            .Where(group =>
            {
                if (!group.Key.Active) return false;
                return group.Count() > 1;
                // or
                // return group.Skip(1).Any();
            })
            .Select(item =>
                new GroupMember($"{item.Key.Name} {item.Key.SurName}", item.ToList()))
            .ToList();



}
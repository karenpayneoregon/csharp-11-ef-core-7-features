using MessagePack;


namespace BinaryFormatterAlternate.Models;

[MessagePackObject]
public class Friend
{
    [Key(0)]
    public int Id { get; set; }
    [Key(1)]
    public string FirstName { get; set; }
    [Key(2)]
    public string LastName { get; set; }
    [Key(3)]
    public DateOnly BirthDate { get; set; }
    [Key(4)]
    public string CellPhone { get; set; }   
}
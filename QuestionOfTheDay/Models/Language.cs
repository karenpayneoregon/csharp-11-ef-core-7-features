namespace QuestionOfTheDay.Models
{
    public class Language
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Code { get; set; }
        public override string? ToString() => Title;
    }
}

namespace CloneRecordApp.Models;

    public record Product(int Id, string Name, int CategoryId)
    {
        public int Id { get; set; } = Id;
        public string Name { get; set; } = Name;
        public int CategoryId { get; set; } = CategoryId;
    }





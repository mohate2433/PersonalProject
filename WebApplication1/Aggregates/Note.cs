namespace WebApplication1.Aggregates
{
    public class Note
    {
        public int Id { get; set; }
        public string? Contente { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }
        public int Views { get; set; }
        public bool Published { get; set; }
        public Person? Person { get; set; }
        public int PersonId { get; set; }
    }
}

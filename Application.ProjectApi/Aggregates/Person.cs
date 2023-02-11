using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Aggregates
{
    public class Person
    {
        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public int Age { get; set; }
        public string? Website { get; set; }
        public List<Note>? Notes { get; set; }
        [NotMapped]
        public string? FullName { get { return FirstName + " " + LastName; } }
    }
}

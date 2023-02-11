using ApplicationService.Dtos.BookDtos;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApplicationService.Dtos
{
    public class PersonDto
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public int Age { get; set; }
        public string? Website { get; set; }
        public string? FullName { get { return FirstName + " " + LastName; } }

    }
}

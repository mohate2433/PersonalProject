using ApplicationService.Dtos.BookDtos;

namespace ApplicationService.Dtos.PersonDtos
{
    public class DetailPersonDto: PersonDto
    {
        public int Id { get; set; }
        public List<SelectNoteDto>? Notes { get; set; }
    }
}

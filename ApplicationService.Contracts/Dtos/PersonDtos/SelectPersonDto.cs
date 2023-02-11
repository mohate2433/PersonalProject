using ApplicationService.Dtos.BookDtos;

namespace ApplicationService.Dtos.PersonDtos
{
    public class SelectPersonDto: PersonDto
    {
        public int Id { get; set; }
        public List<SelectNoteDto>? Notes { get; set; }
    }
}

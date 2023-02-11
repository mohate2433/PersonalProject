namespace ApplicationService.Dtos.BookDtos
{
    public class SelectNoteDto : NoteDto
    {
        public int Id { get; set; }
        public PersonDto? Person { get; set; }
    }
}

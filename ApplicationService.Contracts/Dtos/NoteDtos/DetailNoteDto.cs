namespace ApplicationService.Dtos.BookDtos
{
    public class DetailNoteDto : NoteDto
    {
        public int Id { get; set; }
        public PersonDto? Person { get; set; }
    }
}

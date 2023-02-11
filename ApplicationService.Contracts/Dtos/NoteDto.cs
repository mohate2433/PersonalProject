namespace ApplicationService.Dtos
{
    public class NoteDto
    {
        public string? Contente { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }
        public int Views { get; set; }
        public bool Published { get; set; }
        public int PersonId { get; set; }
    }
}

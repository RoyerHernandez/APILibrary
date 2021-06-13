namespace Library.Core.Entities
{
    public class Book
    {
        public int ISBN { get; set; }
        public int editorialId { get; set; }
        public string title { get; set; }
        public string sinopsis { get; set; }
        public string pages { get; set; }
    }
}

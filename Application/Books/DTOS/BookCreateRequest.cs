namespace Application.Books.DTOS
{
    public class BookCreateRequest
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public string Language { get; set; }
        public int PublisherID { get; set; }
        public string PublisherName { get; set; }
    }

}
namespace Application.Books.DTOS
{
    public class BookViewModel
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string Language { get; set; }
        public int PublisherID { get; set; }
        public string PublisherName { get; set; }
    }
}
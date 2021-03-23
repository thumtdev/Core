using System.Collections.Generic;

namespace Data.Entities
{
    public class Book
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string Language { get; set; }
        public  List<Publisher> Publisher { get; set; }
    }
}
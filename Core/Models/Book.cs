namespace models
{
    public class Book
    {
        public Book() { }
        private Book(int id, string name, string author, string genre, int pages)
        {
            Id = id;
            Name = name;
            Author = author;
            Genre = genre;
            Pages = pages;
        }

        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Author { get; set; } = string.Empty;
        public string Genre { get; set; } = string.Empty;
        public int Pages { get; set; } = 0;

        public static Book Create(int id, string name, string author, string genre, int pages)
        {
            Book book = new Book(id, name, author, genre, pages);

            return book;
        }
    }
}
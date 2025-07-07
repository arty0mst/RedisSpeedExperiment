using System.ComponentModel.DataAnnotations;

namespace Entities
{
    public class BookEntity
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Author { get; set; } = string.Empty;
        public string Genre { get; set; } = string.Empty;
        public int Pages { get; set; } = 0;
    }
}
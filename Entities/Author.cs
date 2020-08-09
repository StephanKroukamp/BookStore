using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace BookStore.Entities
{
    public class Author
    {
        public Author()
        {
            Books = new Collection<Book>();
        }

        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public ICollection<Book> Books { get; set; }
    }
}
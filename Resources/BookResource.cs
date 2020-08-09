namespace BookStore.Resources
{
    public class BookResource
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public AuthorResource Author { get; set; }
    }
}
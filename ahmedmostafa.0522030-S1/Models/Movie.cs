namespace ahmedmostafa._0522030_S1.Models
{
    public class Movie
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime ReleaseYear { get; set; }
        public List<Director> Directors { get; set; }
        public Category Category { get; set; }
    }
}

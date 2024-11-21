using ahmedmostafa._0522030_S1.Models;

namespace ahmedmostafa._0522030_S1.DTOs
{
    public class MovieDto
    {
        public string Title { get; set; }
        public DateTime ReleaseYear { get; set; }
    }
    public class MovieCategoryDto
    {
        public string Title { get; set; }
        public DateTime ReleaseYear { get; set; }
        public CategoryDto Category { get; set; }
    }

    public class MovieDirectorCategoryDto
    {
        public string Title { get; set; }
        public DateTime ReleaseYear { get; set; }
        public List<DirectorNationalityDto> Directors { get; set; }
        public CategoryDto Category { get; set; }
    }
    public class MovieDirectorDto
    {
        public string Title { get; set; }
        public DateTime ReleaseYear { get; set; }
        public List<DirectorNationalityDto> Directors { get; set; }
    }
}

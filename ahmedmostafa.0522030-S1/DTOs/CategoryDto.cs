using ahmedmostafa._0522030_S1.Models;

namespace ahmedmostafa._0522030_S1.DTOs
{
    public class CategoryDto
    {
        public string Name { get; set; }
    }
    public class CategoryMovieDto
    {
        public string Name { get; set; }
        public List<MovieDirectorDto> Movies { get; set; }
    }
}

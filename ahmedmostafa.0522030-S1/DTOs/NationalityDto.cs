using ahmedmostafa._0522030_S1.Models;

namespace ahmedmostafa._0522030_S1.DTOs
{
    public class NationalityDto
    {
        public string Name { get; set; }
    }
    public class NationalityDirectorDto
    {
        public string Name { get; set; }
        public DirectorMovieDto Director { get; set; }
    }
}

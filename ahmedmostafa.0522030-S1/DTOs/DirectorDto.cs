using ahmedmostafa._0522030_S1.Models;
using System.ComponentModel.DataAnnotations;

namespace ahmedmostafa._0522030_S1.DTOs
{
    public class DirectorDto
    {
        public string Name { get; set; }
        [Phone]
        public string Contact { get; set; }
        [EmailAddress]
        public string Email { get; set; }
    }
    public class DirectorNationalityDto
    {
        public string Name { get; set; }
        [Phone]
        public string Contact { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        public NationalityDto Nationality { get; set; }
    }
    public class DirectorMovieNationalityDto
    {
        public string Name { get; set; }
        [Phone]
        public string Contact { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        public List<MovieCategoryDto> Movies { get; set; }
        public NationalityDto Nationality { get; set; }
    }
    public class DirectorMovieDto
    {
        public string Name { get; set; }
        [Phone]
        public string Contact { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        public List<MovieCategoryDto> Movies { get; set; }

        public static implicit operator DirectorMovieDto(Director v)
        {
            throw new NotImplementedException();
        }
    }
}

using System.ComponentModel.DataAnnotations;

namespace ahmedmostafa._0522030_S1.Models
{
    public class Director
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [Phone]
        public string Contact {  get; set; }
        [EmailAddress]
        public string Email { get; set; }
        public List<Movie> Movies { get; set; }
        public Nationality Nationality { get; set;}
        public int? NationalityId {  get; set; }
    }
}

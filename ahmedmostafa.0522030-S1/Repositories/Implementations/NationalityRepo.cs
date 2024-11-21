using ahmedmostafa._0522030_S1.Data;
using ahmedmostafa._0522030_S1.DTOs;
using ahmedmostafa._0522030_S1.Models;
using ahmedmostafa._0522030_S1.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ahmedmostafa._0522030_S1.Repositories.Implementations
{
    public class NationalityRepo : INationalityRepo
    {
        private readonly AppDbContext _context;

        public NationalityRepo(AppDbContext context)
        {
            _context = context;
        }

        public void AddNationalityDirector(NationalityDirectorDto nationalityDto)
        {
            Nationality nationality = new Nationality
            {
                Name = nationalityDto.Name,
                Director = new Director
                {
                    Name = nationalityDto.Director.Name,
                    Email = nationalityDto.Director.Email,
                    Contact = nationalityDto.Director.Contact,
                    Movies = nationalityDto.Director.Movies.Select(i => new Movie
                    {
                        Title = i.Title,
                        ReleaseYear = i.ReleaseYear,
                        Category = new Category
                        {
                            Name = i.Category.Name,
                        }
                    }).ToList(),
                }
            };
            _context.Nationalities.Add(nationality);
            _context.SaveChanges();
        }

        public void DeleteNationality(int id)
        {
            var nationality = _context.Nationalities
                .Include(d => d.Director)
                .ThenInclude(m => m.Movies)
                .ThenInclude(c => c.Category)
                .FirstOrDefault(i => i.Id == id);
            if (nationality != null)
            {
                _context.Nationalities.Remove(nationality);
                _context.SaveChanges();
            }
        }

        public List<NationalityDirectorDto> GetNationalities()
        {
            var result = _context.Nationalities
                .Include(d => d.Director)
                .ThenInclude(m => m.Movies)
                .ThenInclude(c => c.Category)
                .Select(i => new NationalityDirectorDto
                {
                    Name = i.Name,
                    Director = new Director
                    {
                        Name = i.Director.Name,
                        Email = i.Director.Email,
                        Contact = i.Director.Contact,
                        Movies = i.Director.Movies.Select(i => new Movie
                        {
                            Title = i.Title,
                            ReleaseYear = i.ReleaseYear,
                            Category = new Category
                            {
                                Name = i.Category.Name
                            }
                        }).ToList()
                    }
                }).ToList();
            return result;
        }

        public NationalityDirectorDto GetNationalityById(int id)
        {
            var nationality = _context.Nationalities
                .Include(d => d.Director)
                .ThenInclude(m => m.Movies)
                .ThenInclude(c => c.Category)
                .FirstOrDefault(i => i.Id == id);
            if(nationality != null)
            {
                NationalityDirectorDto nationalityDto = new NationalityDirectorDto
                {
                    Name = nationality.Name,
                    Director = new Director
                    {
                        Name = nationality.Director.Name,
                        Email = nationality.Director.Email,
                        Contact = nationality.Director.Contact,
                        Movies = nationality.Director.Movies.Select(i => new Movie
                        {
                            Title = i.Title,
                            ReleaseYear = i.ReleaseYear,
                            Category = new Category
                            {
                                Name = i.Category.Name
                            }
                        }).ToList()
                    }
                };
                return nationalityDto;
            }
            return null;
        }

        public void UpdateNationality(int id, NationalityDirectorDto nationalityDto)
        {
            var nationality = _context.Nationalities
                .Include(d => d.Director)
                .ThenInclude(m => m.Movies)
                .ThenInclude(c => c.Category)
                .FirstOrDefault(i => i.Id == id);
            if(nationality != null)
            {
                nationality.Name = nationalityDto.Name;
                nationality.Director = new Director
                {
                    Name = nationalityDto.Director.Name,
                    Email = nationalityDto.Director.Email,
                    Contact = nationalityDto.Director.Contact,
                    Movies = nationalityDto.Director.Movies.Select(i => new Movie
                    {
                        Title = i.Title,
                        ReleaseYear = i.ReleaseYear,
                        Category = new Category
                        {
                            Name = i.Category.Name
                        }
                    }).ToList()
                };
                _context.Nationalities.Update(nationality);
                _context.SaveChanges();
            }
        }
    }
}

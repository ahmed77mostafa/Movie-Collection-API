using ahmedmostafa._0522030_S1.Data;
using ahmedmostafa._0522030_S1.DTOs;
using ahmedmostafa._0522030_S1.Models;
using ahmedmostafa._0522030_S1.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ahmedmostafa._0522030_S1.Repositories.Implementations
{
    public class DirectorRepo : IDirectorRepo
    {
        private readonly AppDbContext _context;

        public DirectorRepo(AppDbContext context)
        {
            _context = context;
        }

        public bool AddDirectorMovieNationality(DirectorMovieNationalityDto directorDto)
        {
            Director director = new Director
            {
                Name = directorDto.Name,
                Email = directorDto.Email,
                Contact = directorDto.Contact,
                Movies = directorDto.Movies.Select(i => new Movie
                {
                    Title = i.Title,
                    ReleaseYear = i.ReleaseYear,
                    Category = new Category
                    {
                        Name = i.Category.Name,
                    }
                }).ToList(),
                Nationality = new Nationality
                {
                    Name = directorDto.Nationality.Name,
                }
            };
            _context.Directors.Add(director);
            return _context.SaveChanges() > 0;
        }

        public void AddMovieDirectorJoining(int movieId, int directorId)
        {
            var director = _context.Directors.Include(i => i.Movies).FirstOrDefault(i => i.Id == directorId);
            var movie = _context.Movies.FirstOrDefault(i => i.Id == movieId);

            director.Movies.Add(movie);
            _context.SaveChanges();
        }

        public void DeleteDirectorMovieNationality(int directorId)
        {
            var director = _context.Directors.FirstOrDefault(i => i.Id == directorId);
            _context.Directors.Remove(director);
            _context.SaveChanges();
        }

        public List<DirectorMovieNationalityDto> GetDirectorAll()
        {
            var result = _context.Directors
                .Include(m => m.Movies)
                .ThenInclude(c => c.Category)
                .Include(n => n.Nationality)
                .Select(i => new DirectorMovieNationalityDto
                {
                    Name = i.Name,
                    Email = i.Email,
                    Contact = i.Contact,
                    Movies = i.Movies.Select(m => new MovieCategoryDto
                    {
                        Title = m.Title,
                        ReleaseYear = m.ReleaseYear,
                        Category = new CategoryDto
                        {
                            Name = m.Category.Name,
                        }
                    }).ToList(),
                    Nationality = new NationalityDto
                    {
                        Name = i.Nationality.Name,
                    }
                }).ToList();
            return result;
        }

        public DirectorMovieNationalityDto GetDirectorById(int directorId)
        {
            var director = _context.Directors
                .Include(m => m.Movies)
                .ThenInclude(c => c.Category)
                .Include(n => n.Nationality)
                .FirstOrDefault(i => i.Id  == directorId);
            if(director != null)
            {
                DirectorMovieNationalityDto result = new DirectorMovieNationalityDto
                {
                    Name = director.Name,
                    Email = director.Email,
                    Contact = director.Contact,
                    Movies = director.Movies.Select(i => new MovieCategoryDto
                    {
                        Title = i.Title,
                        ReleaseYear = i.ReleaseYear,
                        Category = new CategoryDto
                        {
                            Name = i.Category.Name,
                        }
                    }).ToList(),
                    Nationality = new NationalityDto
                    {
                        Name = director.Nationality.Name,
                    }
                };
                return result;
            }
            return null;
        }

        public void UpdateDirectorMovieNatioanlity(int directorId, DirectorMovieNationalityDto directorDto)
        {
            var director = _context.Directors
                .Include(m => m.Movies)
                .ThenInclude(c => c.Category)
                .Include(n => n.Nationality)
                .FirstOrDefault(i => i.Id == directorId);
            if(director != null)
            {
                director.Name = directorDto.Name;
                director.Email = directorDto.Email;
                director.Contact = directorDto.Contact;
                director.Movies = directorDto.Movies.Select(i => new Movie
                {
                    Title = i.Title,
                    ReleaseYear = i.ReleaseYear,
                    Category = new Category
                    {
                        Name = i.Category.Name,
                    }
                }).ToList();
                director.Nationality = new Nationality
                {
                    Name = directorDto.Nationality.Name,
                };
                _context.Directors.Update(director);
                _context.SaveChanges();
            }
        }
    }
}

using ahmedmostafa._0522030_S1.Data;
using ahmedmostafa._0522030_S1.DTOs;
using ahmedmostafa._0522030_S1.Models;
using ahmedmostafa._0522030_S1.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ahmedmostafa._0522030_S1.Repositories.Implementations
{
    public class MovieRepo : IMovieRepo
    {
        private readonly AppDbContext _context;

        public MovieRepo(AppDbContext context)
        {
            _context = context;
        }


        public bool AddMovieDirectorCategory(MovieDirectorCategoryDto movieDto)
        {
            var title = _context.Movies.FirstOrDefault(i => i.Title == movieDto.Title);
            var releaseDate = _context.Movies.FirstOrDefault(i => i.ReleaseYear == movieDto.ReleaseYear);
            if(title != null)
                throw new InvalidOperationException($"This title is already exist: {title.Title}");
            if (releaseDate != null)
                throw new InvalidOperationException($"This release year is already exist: {releaseDate.ReleaseYear}");
            Movie movie = new Movie
            {
                Title = movieDto.Title,
                ReleaseYear = movieDto.ReleaseYear,
                Category = new Category
                {
                    Name = movieDto.Category.Name,
                },
                Directors = movieDto.Directors.Select(d => new Director
                {
                    Name= d.Name,
                    Email = d.Email,
                    Contact = d.Contact,
                    Nationality = new Nationality
                    {
                        Name = d.Nationality.Name,
                    },
                }).ToList()
            };
            _context.Movies.Add(movie);
            return _context.SaveChanges() > 0;
        }

        public void AddMovieDirectorJoining(int movieId, int directorId)
        {
            var movie = _context.Movies.Include(d => d.Directors).FirstOrDefault(i => i.Id == movieId);
            var director = _context.Directors.FirstOrDefault(i => i.Id == directorId);

            movie.Directors.Add(director);
            _context.SaveChanges();
        }

        public void DeleteMovieDirectorCategory(int movieId)
        {
            var movie = _context.Movies.FirstOrDefault(i => i.Id == movieId);
            if(movie != null)
            {
                _context.Movies.Remove(movie);
                _context.SaveChanges();
            }
        }

        public List<MovieDirectorCategoryDto> GetMovieAll()
        {
            var Movies = _context.Movies
                                .Include(c => c.Category)
                                .Include(d => d.Directors)
                                .ThenInclude(n => n.Nationality)
                                .Select(i => new MovieDirectorCategoryDto
                                {
                                    Title = i.Title,
                                    ReleaseYear = i.ReleaseYear,
                                    Category = new CategoryDto
                                    {
                                        Name = i.Category.Name,
                                    },
                                    Directors = i.Directors.Select(i => new DirectorNationalityDto
                                    {
                                        Name = i.Name,
                                        Email = i.Email,
                                        Contact = i.Contact,
                                        Nationality = new NationalityDto
                                        {
                                            Name = i.Nationality.Name
                                        }
                                    }).ToList(),
                                }).ToList();
            if (Movies != null)
                return Movies;
            return null;
        }

        public MovieDirectorCategoryDto GetMovieById(int movieId)
        {
            var Movie = _context.Movies
                                .Include(c => c.Category)
                                .Include(d => d.Directors)
                                .ThenInclude(n => n.Nationality)
                                .FirstOrDefault(i => i.Id == movieId);

            if(Movie != null)
            {
                MovieDirectorCategoryDto movieDto = new MovieDirectorCategoryDto
                {
                    Title = Movie.Title,
                    ReleaseYear = Movie.ReleaseYear,
                    Category = new CategoryDto
                    {
                        Name = Movie.Category.Name,
                    },
                    Directors = Movie.Directors.Select(i => new DirectorNationalityDto
                    {
                        Name =i.Name,
                        Email = i.Email,
                        Contact = i.Contact,
                        Nationality = new NationalityDto
                        {
                            Name = i.Nationality.Name,
                        }
                    }).ToList(),
                };
                return movieDto;
            }
            return null;
        }

        public void UpdateMovieDirectorCategory(int movieId, MovieDirectorCategoryDto movieDto)
        {
            var Movie = _context.Movies
                        .Include(c => c.Category)
                        .Include(d => d.Directors)
                        .ThenInclude(n => n.Nationality)
                        .FirstOrDefault(i => i.Id == movieId);
            if(Movie != null)
            {
                Movie.Title = movieDto.Title;
                Movie.ReleaseYear = movieDto.ReleaseYear;
                Movie.Category = new Category
                {
                    Name = movieDto.Category.Name,
                };
                Movie.Directors = movieDto.Directors.Select(i => new Director
                {
                    Name = i.Name,
                    Email = i.Email,
                    Contact = i.Contact,
                    Nationality = new Nationality
                    {
                        Name = i.Nationality.Name,
                    },
                }).ToList();
                _context.Movies.Update(Movie);
                _context.SaveChanges();
            }
        }
    }
}

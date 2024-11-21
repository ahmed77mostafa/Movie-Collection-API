using ahmedmostafa._0522030_S1.Data;
using ahmedmostafa._0522030_S1.DTOs;
using ahmedmostafa._0522030_S1.Models;
using ahmedmostafa._0522030_S1.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ahmedmostafa._0522030_S1.Repositories.Implementations
{
    public class CategoryRepo : ICategoryRepo
    {
        private readonly AppDbContext _context;

        public CategoryRepo(AppDbContext context)
        {
            _context = context;
        }

        public void AddCategory(CategoryDto categoryDto)
        {
            Category category = new Category
            {
                Name = categoryDto.Name,
            };
            _context.Categories.Add(category);
            _context.SaveChanges();
        }

        public void AddCategoryMovie(CategoryMovieDto categoryDto)
        {
            var duplicateCategory = _context.Categories.FirstOrDefault(c => c.Name == categoryDto.Name);
            if(duplicateCategory != null)
                throw new InvalidOperationException($"This title is already exist: {duplicateCategory.Name}");
            Category category = new Category
            {
                Name = categoryDto.Name,
                Movies = categoryDto.Movies.Select(i => new Movie
                {
                    Title = i.Title,
                    ReleaseYear = i.ReleaseYear,
                    Directors = i.Directors.Select(i => new Director
                    {
                        Name = i.Name,
                        Email = i.Email,
                        Contact = i.Contact,
                        Nationality = new Nationality
                        {
                            Name = i.Nationality.Name,
                        }
                    }).ToList()
                }).ToList()
            };
            _context.Categories.Add(category);
            _context.SaveChanges();
        }

        public void DeleteCategory(int id)
        {
            var category = _context.Categories.FirstOrDefault(i => i.Id == id);
            if(category != null)
            {
                _context.Categories.Remove(category);
                _context.SaveChanges();
            }
        }

        public List<CategoryMovieDto> GetCategories()
        {
            var result = _context.Categories
                .Include(m => m.Movies)
                .ThenInclude(d => d.Directors)
                .ThenInclude(n => n.Nationality)
                .Select(i => new CategoryMovieDto
                {
                     Name= i.Name,
                     Movies = i.Movies.Select(i => new MovieDirectorDto
                     {
                         Title = i.Title,
                         ReleaseYear = i.ReleaseYear,
                         Directors = i.Directors.Select(i => new DirectorNationalityDto
                         {
                             Name = i.Name,
                             Email = i.Email,
                             Contact = i.Contact,
                             Nationality = new NationalityDto
                             {
                                 Name = i.Nationality.Name
                             } 
                         }).ToList()
                     }).ToList(),
                }).ToList();
            return result;
        }

        public CategoryMovieDto GetCategoryById(int id)
        {
            var category = _context.Categories
                .Include(m => m.Movies)
                .ThenInclude(d => d.Directors)
                .ThenInclude(n => n.Nationality)
                .FirstOrDefault(i => i.Id == id);
            if (category != null)
            {
                CategoryMovieDto categoryMovieDto = new CategoryMovieDto
                {
                    Name = category.Name,
                    Movies = category.Movies.Select(i => new MovieDirectorDto
                    {
                        Title = i.Title,
                        ReleaseYear = i.ReleaseYear,
                        Directors = i.Directors.Select(i => new DirectorNationalityDto
                        {
                            Name = i.Name,
                            Email = i.Email,
                            Contact = i.Contact,
                            Nationality = new NationalityDto
                            {
                                Name = i.Nationality.Name,
                            }
                        }).ToList()
                    }).ToList()
                };
                return categoryMovieDto;
            }
            return null;
        }

        public void UpdateCategory(int id, CategoryMovieDto categoryDto)
        {
            var category = _context.Categories
                .Include(m => m.Movies)
                .ThenInclude(d => d.Directors)
                .ThenInclude(n => n.Nationality)
                .FirstOrDefault(i => i.Id == id);
            if (category != null)
            {
                category.Name = categoryDto.Name;
                category.Movies = categoryDto.Movies.Select(i => new Movie
                {
                    Title = i.Title,
                    ReleaseYear= i.ReleaseYear,
                    Directors = i.Directors.Select(i => new Director
                    {
                        Name = i.Name,
                        Email= i.Email,
                        Contact= i.Contact,
                        Nationality = new Nationality
                        {
                            Name = i.Nationality.Name,
                        }
                    }).ToList()
                }).ToList();
                _context.Categories.Update(category);
                _context.SaveChanges();
            }
        }
    }
}

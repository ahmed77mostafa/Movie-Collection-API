using ahmedmostafa._0522030_S1.DTOs;

namespace ahmedmostafa._0522030_S1.Repositories.Interfaces
{
    public interface ICategoryRepo
    {
        public void AddCategory(CategoryDto categoryDto);
        public void AddCategoryMovie(CategoryMovieDto categoryDto);
        public List<CategoryMovieDto> GetCategories();
        public CategoryMovieDto GetCategoryById(int id);
        public void UpdateCategory(int id, CategoryMovieDto categoryDto);
        public void DeleteCategory(int id); 
    }
}

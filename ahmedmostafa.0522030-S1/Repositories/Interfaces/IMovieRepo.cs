using ahmedmostafa._0522030_S1.DTOs;

namespace ahmedmostafa._0522030_S1.Repositories.Interfaces
{
    public interface IMovieRepo
    {
        public List<MovieDirectorCategoryDto> GetMovieAll();
        public MovieDirectorCategoryDto GetMovieById(int movieId);
        public bool AddMovieDirectorCategory(MovieDirectorCategoryDto movieDto);
        public void AddMovieDirectorJoining(int  movieId, int directorId);
        public void UpdateMovieDirectorCategory(int movieId, MovieDirectorCategoryDto movieDto);
        public void DeleteMovieDirectorCategory(int movieId);
    }
}

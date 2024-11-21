using ahmedmostafa._0522030_S1.DTOs;

namespace ahmedmostafa._0522030_S1.Repositories.Interfaces
{
    public interface IDirectorRepo
    {
        public List<DirectorMovieNationalityDto> GetDirectorAll();
        public DirectorMovieNationalityDto GetDirectorById(int directorId);
        public bool AddDirectorMovieNationality(DirectorMovieNationalityDto directorDto);
        public void AddMovieDirectorJoining(int movieId, int directorId);
        public void UpdateDirectorMovieNatioanlity(int directorId, DirectorMovieNationalityDto directorDto);
        public void DeleteDirectorMovieNationality(int directorId);
    }
}

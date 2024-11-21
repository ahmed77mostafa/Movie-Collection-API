using ahmedmostafa._0522030_S1.DTOs;

namespace ahmedmostafa._0522030_S1.Repositories.Interfaces
{
    public interface INationalityRepo
    {
        public void AddNationalityDirector(NationalityDirectorDto nationalityDto);
        public List<NationalityDirectorDto> GetNationalities();
        public NationalityDirectorDto GetNationalityById(int id);
        public void UpdateNationality(int id, NationalityDirectorDto nationalityDto);
        public void DeleteNationality(int id);
    }
}

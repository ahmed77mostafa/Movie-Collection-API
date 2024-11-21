using ahmedmostafa._0522030_S1.DTOs;
using ahmedmostafa._0522030_S1.Repositories.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ahmedmostafa._0522030_S1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NationalityController : ControllerBase
    {
        private readonly INationalityRepo _nationalityRepo;

        public NationalityController(INationalityRepo nationalityRepo)
        {
            _nationalityRepo = nationalityRepo;
        }
        [HttpGet("{id}")]
        public IActionResult GetNationalityById(int id)
        {
            var nationality = _nationalityRepo.GetNationalityById(id);
            return Ok(nationality);
        }
        [HttpGet]
        public IActionResult GetNationalities()
        {
            var nationalities = _nationalityRepo.GetNationalities();
            return Ok(nationalities);
        }
        [HttpPost]
        public IActionResult AddNationality(NationalityDirectorDto nationalityDto)
        {
            _nationalityRepo.AddNationalityDirector(nationalityDto);
            return Ok();
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteNationality(int id)
        {
            _nationalityRepo.DeleteNationality(id);
            return Ok();
        }
        [HttpPut("{id}")]
        public IActionResult UpdateNationality(int id, NationalityDirectorDto nationalityDto)
        {
            _nationalityRepo.UpdateNationality(id, nationalityDto);
            return Ok();
        }
    }
}

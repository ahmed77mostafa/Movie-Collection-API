using ahmedmostafa._0522030_S1.DTOs;
using ahmedmostafa._0522030_S1.Repositories.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ahmedmostafa._0522030_S1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DirectorController : ControllerBase
    {
        private readonly IDirectorRepo _directorRepo;

        public DirectorController(IDirectorRepo directorRepo)
        {
            _directorRepo = directorRepo;
        }
        [HttpGet("{id}")]
        public IActionResult GetDirectorById(int id)
        {
            var Director = _directorRepo.GetDirectorById(id);
            if(Director != null)
            {
                return Ok(Director);
            }
            return NotFound();
        }
        [HttpGet]
        public IActionResult GetdirectorAll()
        {
            var Directors = _directorRepo.GetDirectorAll();
            if (Directors != null)
            {
                return Ok(Directors);
            }
            return BadRequest();
        }
        [HttpPost]
        public IActionResult AddDirector(DirectorMovieNationalityDto directorDto)
        {
            var result = _directorRepo.AddDirectorMovieNationality(directorDto);
            if (!result)
                return BadRequest();
            return Created();
        }
        [HttpPost("Joining")]
        public IActionResult AddMovieDirectorJoining(int movieId, int directorId)
        {
            _directorRepo.AddMovieDirectorJoining(movieId, directorId);
            return Created();
        }
        [HttpPut("{id}")]
        public IActionResult UpdateDirector(int id, DirectorMovieNationalityDto directorDto)
        {
            _directorRepo.UpdateDirectorMovieNatioanlity(id, directorDto);
            return Ok();
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteDirector(int id)
        {
            _directorRepo.DeleteDirectorMovieNationality(id);
            return Ok();
        }
    }
}

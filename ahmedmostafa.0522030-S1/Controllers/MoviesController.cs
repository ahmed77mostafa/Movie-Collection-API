using ahmedmostafa._0522030_S1.DTOs;
using ahmedmostafa._0522030_S1.Repositories.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ahmedmostafa._0522030_S1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly IMovieRepo _movieRepo;

        public MoviesController(IMovieRepo movieRepo)
        {
            _movieRepo = movieRepo;
        }
        [HttpGet("{id}")]
        public IActionResult GetMovieById(int id)
        {
            var Movie = _movieRepo.GetMovieById(id);
            if(Movie != null)
            {
                return Ok(Movie);
            }
            return NotFound();
        }
        [HttpGet]
        public IActionResult GetMovieAll()
        {
            var Movies = _movieRepo.GetMovieAll();
            if (Movies != null)
            {
                return Ok(Movies);
            }
            return BadRequest();
        }
        [HttpPost]
        public IActionResult AddMovie(MovieDirectorCategoryDto movieDto)
        {
            var result = _movieRepo.AddMovieDirectorCategory(movieDto);
            if (!result)
                return BadRequest();
            return Created();
        }
        [HttpPost("Joining")]
        public IActionResult AddMovieDirectorJoining(int movieId, int directorId)
        {
            _movieRepo.AddMovieDirectorJoining(movieId, directorId);
            return Created();
        }
        [HttpPut("{id}")]
        public IActionResult UpdateMovie(int id, MovieDirectorCategoryDto movieDto)
        {
            _movieRepo.UpdateMovieDirectorCategory(id, movieDto);
            return Ok();
        
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteMovie(int id)
        {
            _movieRepo.DeleteMovieDirectorCategory(id);
            return Ok();
        }
    }
}

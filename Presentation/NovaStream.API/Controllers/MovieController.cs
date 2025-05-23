﻿namespace NovaStream.API.Controllers;

[ApiController, Authorize(Roles = "Client")]
[Route("api/[controller]")]
public class MovieController : ControllerBase
{
    private readonly AppDbContext _dbContext;
    private readonly IUserManager _userManager;


    public MovieController(AppDbContext dbContext, IUserManager userManager)
    {
        _dbContext = dbContext;
        _userManager = userManager;
    }


    [HttpGet("[Action]"), AllowAnonymous]
    public async Task<IActionResult> Index()
    {
        try
        {
            var movies = await _dbContext.Movies.ProjectToType<MovieDto>().ToListAsync();

            movies = Random.Shared.Shuffle(movies);

            var json = JsonConvert.SerializeObject(movies, Formatting.Indented);

            return Ok(json);
        }
        catch
        {
            return StatusCode((int)HttpStatusCode.InternalServerError);
        }
    }

    [HttpGet("[Action]")]
    public async Task<IActionResult> Details([FromQuery] string name)
    {
        try
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var movie = _dbContext.Movies.Include(m => m.Director).Include(m=>m.Genres).ThenInclude(g=>g.Genre).Include(m=>m.Subtitles).Include(m => m.Actors).ThenInclude(a => a.Actor).FirstOrDefault(m => m.Name == name)?.Adapt<MovieDetailsDto>();

            if (movie is null) return NotFound();

            var user = await _userManager.ReturnUserFromContextAsync(HttpContext);

            movie.IsMarked = _dbContext.MovieMarks.Any(mm => mm.Movie.Name == name && mm.UserId == user.Id);

            var json = JsonConvert.SerializeObject(movie, Formatting.Indented);

            return Ok(json);
        }
        catch
        {
            return StatusCode((int)HttpStatusCode.InternalServerError);
        }
    }

    [HttpGet("[Action]"), AllowAnonymous]
    public async Task<IActionResult> ViewDetails([FromQuery] string name)
    {
        try
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var movie = _dbContext.Movies.FirstOrDefault(m => m.Name == name)?.Adapt<MovieViewDetailsDto>();

            if (movie is null) return NotFound();

            var user = await _userManager.ReturnUserFromContextAsync(HttpContext);

            movie.IsMarked = _dbContext.MovieMarks.Any(mm => mm.Movie.Name == name && mm.UserId == user.Id);

            var json = JsonConvert.SerializeObject(movie, Formatting.Indented);

            return Ok(json);
        }
        catch
        {
            return StatusCode((int)HttpStatusCode.InternalServerError);
        }
    }
}

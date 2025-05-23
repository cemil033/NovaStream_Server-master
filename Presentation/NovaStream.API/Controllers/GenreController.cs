﻿namespace NovaStream.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class GenreController : ControllerBase
{
    private readonly AppDbContext _dbContext;


    public GenreController(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }


    [HttpGet("[Action]")]
    public async Task<IActionResult> Index()
    {
        await Task.CompletedTask;

        try
        {

            var genres = new List<BaseGenreDto>();

            genres.AddRange(_dbContext.Genres.ProjectToType<GenreDto>());
            

            genres = Random.Shared.Shuffle(genres);

            

            var json = JsonConvert.SerializeObject(genres, Formatting.Indented);

            return Ok(json);
        }
        catch
        {
            return StatusCode((int)HttpStatusCode.InternalServerError);
        }
    }

    [HttpGet("[Action]")]
    public async Task<IActionResult> Videos([FromQuery] string name)
    {
        await Task.CompletedTask;

        try
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var videos = new List<BaseVideoDto>();

            videos.AddRange(_dbContext.MovieGenres.Include(mc => mc.Movie).Include(mc => mc.Genre).Where(mc => mc.Genre.Name == name).Select(mc => mc.Movie).ProjectToType<MovieDto>());
            videos.AddRange(_dbContext.SerialGenres.Include(sc => sc.Serial).Include(sc => sc.Genre).Where(sc => sc.Genre.Name == name).Select(sc => sc.Serial).ProjectToType<SerialDto>());

            videos = Random.Shared.Shuffle(videos);

            var json = JsonConvert.SerializeObject(videos, Formatting.Indented);

            return Ok(json);
        }
        catch
        {
            return StatusCode((int)HttpStatusCode.InternalServerError);
        }
    }
}

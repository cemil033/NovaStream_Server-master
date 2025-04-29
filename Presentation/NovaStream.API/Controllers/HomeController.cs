using NovaStream.Domain.Entities.Concrete;
using System.Collections.Generic;

namespace NovaStream.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class HomeController : ControllerBase
{
    private readonly AppDbContext _dbContext;


    public HomeController(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }


    [HttpGet("[Action]")]
    public async Task<IActionResult> Index()
    {
        await Task.CompletedTask;

        try
        {
            var homeTopvideos = new List<BaseVideoDto>();
            homeTopvideos.AddRange(_dbContext.Movies.ProjectToType<MovieHomeDto>());            
            homeTopvideos = Random.Shared.Shuffle(homeTopvideos);
            if (homeTopvideos.Count != 0)
            {
                var json1 = JsonConvert.SerializeObject(homeTopvideos.First(), Formatting.Indented);
                return Ok(json1);
            }
            var json = JsonConvert.SerializeObject(homeTopvideos, Formatting.Indented);
            return Ok(json);
        }
        catch
        {
            return StatusCode((int)HttpStatusCode.InternalServerError);
        }
    }

    [HttpGet("[Action]")]
    public async Task<IActionResult> Recommended()
    {
        await Task.CompletedTask;

        try
        {
            var videos = new List<BaseVideoDto>();

            videos.AddRange(_dbContext.Movies.Take(3).ProjectToType<MovieSearchDto>());
            videos.AddRange(_dbContext.Serials.Take(3).ProjectToType<SerialSearchDto>());


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

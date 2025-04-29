namespace NovaStream.API.Controllers;

[Route("api/[controller]")]
public class ActorController : ControllerBase
{
    private readonly AppDbContext _dbContext;


    public ActorController(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    [HttpGet("[Action]")]
    public async Task<IActionResult> Index()
    {
        await Task.CompletedTask;

        try
        {

            var actors = new List<ActorDto>();
            actors.AddRange(_dbContext.Actors.ProjectToType<ActorDto>());
            actors = Random.Shared.Shuffle(actors);
            var json = JsonConvert.SerializeObject(actors   , Formatting.Indented);

            return Ok(json);
        }
        catch
        {
            return StatusCode((int)HttpStatusCode.InternalServerError);
        }
    }
    [HttpGet("[Action]")]
    public async Task<IActionResult> About([FromQuery] int id)
    {
        await Task.CompletedTask;

        try
        {
            var actor =await _dbContext.Actors.ProjectToType<ActorDto>().FirstOrDefaultAsync(e=>e.Id==id);
            var json = JsonConvert.SerializeObject(actor, Formatting.Indented);
            return Ok(json);
        }
        catch
        {
            return StatusCode((int)HttpStatusCode.InternalServerError);
        }

    }

    [HttpGet("[Action]")]
    public async Task<IActionResult> Videos([FromQuery] int id)
    {
        await Task.CompletedTask;

        try
        {
            var videos = new List<BaseVideoDto>();

            videos.AddRange(_dbContext.MovieActors.Include(ma => ma.Actor).Where(ma => ma.ActorId == id).Select(ma => ma.Movie).ProjectToType<MovieDto>());
            videos.AddRange(_dbContext.SerialActors.Include(sa => sa.Actor).Where(sa => sa.ActorId == id).Select(sa => sa.Serial).ProjectToType<SerialDto>());

            videos.Sort((a, b) => string.Compare(a.Name, b.Name));

            var json = JsonConvert.SerializeObject(videos, Formatting.Indented);

            return Ok(json);
        }
        catch
        {
            return StatusCode((int)HttpStatusCode.InternalServerError);
        }

    }
}

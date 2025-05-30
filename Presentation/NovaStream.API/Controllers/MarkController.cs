﻿namespace NovaStream.API.Controllers;

[ApiController, Authorize(Roles = "Client")]
[Route("api/[controller]")]
public class MarkController : ControllerBase
{
    private readonly AppDbContext _dbContext;
    private readonly IUserManager _userManager;


    public MarkController(AppDbContext dbContext, IUserManager userManager)
    {
        _dbContext = dbContext;
        _userManager = userManager;
    }


    [HttpGet("[Action]")]
    public async Task<IActionResult> Index()
    {
        try
        {
            var user = await _userManager.ReturnUserFromContextAsync(HttpContext);

            if (user is null) return Unauthorized();

            var markedVideos = new List<BaseVideoDto>();

            markedVideos.AddRange(_dbContext.MovieMarks.Include(mm => mm.Movie).Where(mm => mm.UserId == user.Id).Select(mm => mm.Movie).ProjectToType<MovieDto>());
            markedVideos.AddRange(_dbContext.SerialMarks.Include(ms => ms.Serial).Where(ms => ms.UserId == user.Id).Select(ms => ms.Serial).ProjectToType<SerialDto>());

            markedVideos.Sort((a, b) => string.Compare(a.Name, b.Name));

            var json = JsonConvert.SerializeObject(markedVideos, Formatting.Indented);

            return Ok(json);
        }
        catch
        {
            return StatusCode((int)HttpStatusCode.InternalServerError);
        }
    }
    
    [HttpPut("[Action]")]
    public async Task<IActionResult> State([FromForm] UpdateMarkDto dto)
    {
        try
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var user = _userManager.ReturnUserFromContext(HttpContext);

            if (user is null) return Unauthorized();

            bool result = true;

            if (dto.IsSerial)
            {
                var serial = _dbContext.Serials.FirstOrDefault(s => s.Name == dto.Name);

                if (serial is null) return NotFound(ModelState);

                var serialMark = _dbContext.SerialMarks.FirstOrDefault(ms => ms.SerialId == serial.Id && ms.UserId == user.Id);

                if (serialMark is null)
                {
                    serialMark = new SerialMark(user.Id, serial.Id);

                    _dbContext.SerialMarks.Add(serialMark);
                    await _dbContext.SaveChangesAsync();
                }
                else
                {
                    _dbContext.SerialMarks.Remove(serialMark);
                    await _dbContext.SaveChangesAsync();

                    result = false;
                }
            }
            else
            {
                var movie = _dbContext.Movies.FirstOrDefault(s => s.Name == dto.Name);

                if (movie is null) return NotFound();

                var movieMark = _dbContext.MovieMarks.FirstOrDefault(ms => ms.MovieId == movie.Id && ms.UserId == user.Id);

                if (movieMark is null)
                {
                    movieMark = new MovieMark(user.Id, movie.Id);

                    _dbContext.MovieMarks.Add(movieMark);
                    await _dbContext.SaveChangesAsync();

                }
                else
                {
                    _dbContext.MovieMarks.Remove(movieMark);
                    await _dbContext.SaveChangesAsync();

                    result = false;
                }
            }

            return Ok(result);
        }
        catch
        {
            return StatusCode((int)HttpStatusCode.InternalServerError);
        }
    }
}

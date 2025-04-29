namespace NovaStream.Domain.Entities.Concrete.Adapters;

public class MovieMark
{
    public Movie Movie { get; set; }
    public User User { get; set; }
    public int UserId { get; set; }
    public int MovieId { get; set; }   


    public MovieMark(int userId, int movieId)
    {
        UserId = userId;
        MovieId = movieId;
    }
}

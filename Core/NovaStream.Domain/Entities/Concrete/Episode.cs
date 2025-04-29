namespace NovaStream.Domain.Entities.Concrete;

public class Episode : Video
{
    public int Number { get; set; }
    public TimeSpan VideoLength { get; set; }
    public int? SeasonId { get; set; }
    public Season? Season { get; set; }
    public ICollection<Subtitle>? Subtitles { get; } = new List<Subtitle>();

}

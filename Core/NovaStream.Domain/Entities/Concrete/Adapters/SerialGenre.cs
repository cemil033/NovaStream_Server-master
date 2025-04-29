namespace NovaStream.Domain.Entities.Concrete.Adapters;

public class SerialGenre
{
    public Serial Serial { get; set; }
    public Genre Genre { get; set; }
    public int GenreId { get; set; }
    public int SerialId { get; set; }
}

namespace NovaStream.Domain.Entities.Concrete;

public class Genre : Entity
{
    public string Name { get; set; }
    public string ImageUrl { get; set; }

    public ICollection<MovieGenre> Movies { get; set; }
    public ICollection<SerialGenre> Serials { get; set; }
    public ICollection<SoonGenre> Soons { get; set; }
}

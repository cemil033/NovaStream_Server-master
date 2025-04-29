using NovaStream.Domain.Entities.Concrete;
using System.ComponentModel.DataAnnotations;

namespace NovaStream.Domain.Entities.Abstract;

public abstract class Video
{
    [Key]
    public int Id { get; set; }
    public string? Name { get; set; }
    public int Year { get; set; }
    public int Age { get; set; }
    public string? Description { get; set; }
    public string? TrailerUrl { get; set; }
    public string? ImageUrl { get; set; }
    public string? VideoUrl { get; set; }
    public string? SearchImageUrl { get; set; }
    
}

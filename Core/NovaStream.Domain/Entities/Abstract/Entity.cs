using System.ComponentModel.DataAnnotations;

namespace NovaStream.Domain.Entities.Abstract;

public abstract class Entity
{
    [Key]
    public int Id { get; set; }
}

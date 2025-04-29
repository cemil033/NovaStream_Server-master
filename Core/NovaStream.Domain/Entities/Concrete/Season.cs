namespace NovaStream.Domain.Entities.Concrete;

public class Season : Entity
{
    public int Number { get; set; }

    public Serial? Serial { get; set; }
    public int? SerialId { get; set; }

    public ICollection<Episode> Episodes { get; set; }
}

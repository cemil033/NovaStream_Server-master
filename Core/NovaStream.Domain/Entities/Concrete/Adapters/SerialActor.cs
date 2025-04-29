namespace NovaStream.Domain.Entities.Concrete.Adapters;

public class SerialActor
{
    public Serial Serial { get; set; }
    public Actor Actor { get; set; }
    public int ActorId { get; set; }
    public int SerialId { get; set; }
}

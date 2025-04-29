namespace NovaStream.Domain.Entities.Concrete.Adapters;

public class SerialMark
{
    public Serial Serial { get; set; }
    public User User { get; set; }
    public int UserId { get; set; }
    public int SerialId { get; set; }


    public SerialMark(int userId, int serialId)
    {
        UserId = userId;
        SerialId = serialId;
    }
}

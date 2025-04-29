namespace NovaStream.Persistence.Data.Configurations;

public class SerialActorConfiguration : IEntityTypeConfiguration<SerialActor>
{
    public void Configure(EntityTypeBuilder<SerialActor> builder)
    {
        builder.HasKey(sa => new { sa.SerialId, sa.ActorId });

        builder.HasOne(sa => sa.Serial)
            .WithMany(s => s.Actors)
            .HasForeignKey(sa => sa.SerialId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(sa => sa.Actor)
            .WithMany(a => a.Serials)
            .HasForeignKey(sa => sa.ActorId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}

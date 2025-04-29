namespace NovaStream.Persistence.Data.Configurations;

public class SerialConfiguration : IEntityTypeConfiguration<Serial>
{
    public void Configure(EntityTypeBuilder<Serial> builder)
    {
        builder.HasOne(s => s.Director)
            .WithMany(p => p.Serials)
            .HasForeignKey(s => s.DirectorId)
            .OnDelete(DeleteBehavior.SetNull);
    }
}

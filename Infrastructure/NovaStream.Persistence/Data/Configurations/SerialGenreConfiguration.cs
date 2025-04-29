namespace NovaStream.Persistence.Data.Configurations;

public class SerialGenreConfiguration : IEntityTypeConfiguration<SerialGenre>
{
    public void Configure(EntityTypeBuilder<SerialGenre> builder)
    {
        builder.HasKey(sc => new { sc.SerialId, sc.GenreId });

        builder.HasOne(bc => bc.Serial)
            .WithMany(b => b.Genres)
            .HasForeignKey(bc => bc.SerialId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(bc => bc.Genre)
            .WithMany(c => c.Serials)
            .HasForeignKey(bc => bc.GenreId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}

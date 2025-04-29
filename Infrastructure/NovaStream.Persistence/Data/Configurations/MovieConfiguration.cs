namespace NovaStream.Persistence.Data.Configurations;

public class MovieConfiguration : IEntityTypeConfiguration<Movie>
{
    public void Configure(EntityTypeBuilder<Movie> builder)
    {
        builder.HasKey(ma => ma.Id );
        

        builder.HasOne(m => m.Director)
            .WithMany(p => p.Movies)
            .HasForeignKey(m => m.DirectorId)
            .OnDelete(DeleteBehavior.SetNull);

        builder.HasMany(e => e.Subtitles)
        .WithOne(e => e.Movie)
        .HasForeignKey(e => e.MovieId)
        .OnDelete(DeleteBehavior.Restrict);
    }
}

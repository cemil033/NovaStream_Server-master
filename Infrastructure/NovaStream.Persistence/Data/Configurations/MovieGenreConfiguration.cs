namespace NovaStream.Persistence.Data.Configurations;

public class MovieGenreConfiguration : IEntityTypeConfiguration<MovieGenre>
{
    public void Configure(EntityTypeBuilder<MovieGenre> builder)
    {
        builder.HasKey(sc => new { sc.MovieId, sc.GenreId });

        builder.HasOne(bc => bc.Movie)
            .WithMany(b => b.Genres)
            .HasForeignKey(bc => bc.MovieId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(bc => bc.Genre)
            .WithMany(c => c.Movies)
            .HasForeignKey(bc => bc.GenreId)
            .OnDelete(DeleteBehavior.Cascade);
        
    }
}

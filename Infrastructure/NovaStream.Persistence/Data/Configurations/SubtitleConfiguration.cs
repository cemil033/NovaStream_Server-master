namespace NovaStream.Persistence.Data.Configurations;

public class SubtitleConfiguration : IEntityTypeConfiguration<Subtitle>
{
    public void Configure(EntityTypeBuilder<Subtitle> builder)
    {
        builder.HasOne(e => e.Movie)
        .WithMany(e => e.Subtitles)
        .HasForeignKey(e => e.MovieId)
        .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(e => e.Episode)
        .WithMany(e => e.Subtitles)
        .HasForeignKey(e => e.EpisodeId)
        .OnDelete(DeleteBehavior.Restrict);
    }
}

﻿namespace NovaStream.Persistence.Data.Configurations;

public class EpisodeConfiguration : IEntityTypeConfiguration<Episode>
{
    public void Configure(EntityTypeBuilder<Episode> builder)
    {
        builder.HasOne(e => e.Season)
            .WithMany(s => s.Episodes)
            .HasForeignKey(e => e.SeasonId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasMany(e => e.Subtitles)
            .WithOne(e => e.Episode)
            .HasForeignKey(e => e.EpisodeId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}

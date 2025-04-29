namespace NovaStream.Application.MapsterProfiles;

public class SubtitleProfile
{
    public SubtitleProfile(IAWSStorageManager awsStorageManager) 
    {
        TypeAdapterConfig<Subtitle, SubtitleDto>.NewConfig()
            .Map(dest => dest.SubtitlePath, src => awsStorageManager.GetSignedUrl(src.SubtitlePath, TimeSpan.FromHours(7)));
    }
}

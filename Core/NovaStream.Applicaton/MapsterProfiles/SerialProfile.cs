﻿namespace NovaStream.Application.MapsterProfiles;

public class SerialProfile
{
	public SerialProfile(IStorageManager storageManager)
	{
        TypeAdapterConfig<Serial, SerialDto>.NewConfig()
            .Map(dest => dest.ImageUrl, src => storageManager.GetSignedUrl(src.ImageUrl));

        TypeAdapterConfig<Serial, SerialSearchDto>.NewConfig()
            .Map(dest => dest.ImageUrl, src => storageManager.GetSignedUrl(src.SearchImageUrl));

        TypeAdapterConfig<Serial, SerialViewDetailsDto>.NewConfig()
            .Map(dest => dest.ImageUrl, src => storageManager.GetSignedUrl(src.ImageUrl));

        TypeAdapterConfig<Serial, SerialDetailsDto>.NewConfig()
            .Map(dest => dest.TrailerUrl, src => storageManager.GetSignedUrl(src.TrailerUrl))
            .Map(dest => dest.Actors, src => src.Actors.Select(ma => ma.Actor).Adapt<ICollection<ActorDto>>())            
            .Map(dest => dest.Genres, src => src.Genres.Select(ma => ma.Genre).Adapt<ICollection<GenreDto>>());
    }
}

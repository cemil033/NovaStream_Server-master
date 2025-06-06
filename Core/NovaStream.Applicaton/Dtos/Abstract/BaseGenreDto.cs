﻿namespace NovaStream.Application.Dtos.Abstract;

public abstract record BaseGenreDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string ImageUrl { get; set; }
}

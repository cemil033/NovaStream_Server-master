﻿namespace NovaStream.Domain.Entities.Concrete.Adapters;

public class MovieActor
{
    public Movie Movie { get; set; }    
    public Actor Actor { get; set; }
    public int ActorId { get; set; }
    public int MovieId { get; set; }
}

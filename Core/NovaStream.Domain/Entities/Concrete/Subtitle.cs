using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NovaStream.Domain.Entities.Concrete;

public class Subtitle:Entity
{
    public string Language { get; set; }
    public string SubtitlePath { get; set; }
    public int? MovieId { get; set; }
    public int? EpisodeId { get; set; }
    public Movie? Movie { get; set; }
    public Episode? Episode { get; set; }
}

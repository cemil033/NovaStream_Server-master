using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NovaStream.Application.Dtos.Concrete;

public class HomeDto
{
    public List<BaseVideoDto> Movies { get; set; }
    public List<BaseVideoDto> Serials { get; set; }
    public List<GenreDto> Genres { get; set; }
    public BaseVideoDto HomeTopMovie { get; set; }
    public List<ActorDto> Actors { get; set; }
}

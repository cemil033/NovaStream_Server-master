using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NovaStream.Application.Dtos.Concrete;

public record MovieHomeDto : BaseVideoDto
{
    public string VideoName { get; set; }
    public string VideoDescription { get; set; }
    public string TrailerUrl { get; set; }

}

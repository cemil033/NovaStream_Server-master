using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NovaStream.Application.Dtos.Abstract;
public abstract record BaseSubtitleDto
{   
    public string Language { get; set; }    
    public string SubtitlePath { get; set; }
}
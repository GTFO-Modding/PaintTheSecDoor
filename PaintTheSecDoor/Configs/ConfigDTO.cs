using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaintTheSecDoor.Configs;
internal class ConfigDTO
{
    public StyleDTO[] Styles { get; set; } = Array.Empty<StyleDTO>();
    public string GlobalStyle { get; set; } = string.Empty;
    public LayoutDTO[] Layouts { get; set; } = Array.Empty<LayoutDTO>();
}

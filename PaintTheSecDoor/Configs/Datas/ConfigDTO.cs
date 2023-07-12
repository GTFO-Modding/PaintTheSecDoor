using System;

namespace PaintTheSecDoor.Configs.Datas;
internal class ConfigDTO
{
    public StyleDTO[] Styles { get; set; } = Array.Empty<StyleDTO>();
    public string GlobalStyle { get; set; } = string.Empty;
    public LayoutDTO[] Layouts { get; set; } = Array.Empty<LayoutDTO>();
}

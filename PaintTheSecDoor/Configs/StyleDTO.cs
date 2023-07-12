using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using UnityEngine;

namespace PaintTheSecDoor.Configs;
internal sealed class StyleDTO
{
    public string StyleName { get; set; }
    public SecurityDoorDTO Security { get; set; } = new(ColorExt.Hex("#4a6c94"), ColorExt.Hex("#ce5142"));
    public ApexDoorDTO Apex { get; set; } = new();
    public BulkheadDoorDTO Bulkhead { get; set; } = new();
    public SecurityDoorDTO InternalBulkhead { get; set; } = new(ColorExt.Hex("#919091"), Color.white);
}

internal sealed class SecurityDoorDTO
{
    public bool Enabled { get; set; } = true;
    [JsonConverter(typeof(UnityColorHexConverter))]
    public Color Main { get; set; }
    [JsonConverter(typeof(UnityColorHexConverter))]
    public Color Strip { get; set; }

    public SecurityDoorDTO(Color main, Color strip)
    {
        Main = main;
        Strip = strip;
    }
}

internal sealed class BulkheadDoorDTO
{
    public bool Enabled { get; set; } = true;
    [JsonConverter(typeof(UnityColorHexConverter))]
    public Color Main { get; set; } = ColorExt.Hex("#705736");
    [JsonConverter(typeof(UnityColorHexConverter))]
    public Color Strip1 { get; set; } = Color.white;
    [JsonConverter(typeof(UnityColorHexConverter))]
    public Color Strip2 { get; set; } = Color.black;
}

internal sealed class ApexDoorDTO
{
    public bool Enabled { get; set; } = true;
    [JsonConverter(typeof(UnityColorHexConverter))]
    public Color Main { get; set; } = ColorExt.Hex("#703d0b");
    [JsonConverter(typeof(UnityColorHexConverter))]
    public Color Strip { get; set; } = Color.black;
    [JsonConverter(typeof(UnityColorHexConverter))]
    public Color Emission { get; set; } = ColorExt.Hex("#fe310d");
    public float EmissionIntensity { get; set; } = 1.25f;
}

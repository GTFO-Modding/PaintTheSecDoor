using LevelGeneration;
using PaintTheSecDoor.API;
using PaintTheSecDoor.Utils;
using System.Text.Json.Serialization;
using UnityEngine;

namespace PaintTheSecDoor.Configs.Datas;
internal sealed class StyleDTO
{
    public string StyleName { get; set; }
    public SecurityDoorDTO Security { get; set; } = new(ColorExt.Hex("#4a6c94"), ColorExt.Hex("#ce5142"));
    public ApexDoorDTO Apex { get; set; } = new();
    public BulkheadDoorDTO Bulkhead { get; set; } = new();
    public SecurityDoorDTO InternalBulkhead { get; set; } = new(ColorExt.Hex("#919091"), Color.white);

    public void AllocateTextures()
    {
        Security?.AllocateTexture(isBulkhead: false);
        Apex?.AllocateTexture();
        Bulkhead?.AllocateTexture();
        InternalBulkhead?.AllocateTexture(isBulkhead: true);
    }

    public void DeallocateTextures()
    {
        Security?.DeallocateTexture();
        Apex?.DeallocateTexture();
        Bulkhead?.DeallocateTexture();
        InternalBulkhead?.DeallocateTexture();
    }
}

internal sealed class SecurityDoorDTO
{
    public bool Enabled { get; set; } = true;
    [JsonConverter(typeof(UnityColorHexConverter))]
    public Color Main { get; set; }
    [JsonConverter(typeof(UnityColorHexConverter))]
    public Color Strip { get; set; }

    [JsonIgnore]
    public SecurityDoorTexture Texture_4x4;
    [JsonIgnore]
    public SecurityDoorTexture Texture_8x4;

    public SecurityDoorDTO(Color main, Color strip)
    {
        Main = main;
        Strip = strip;
    }

    public void AllocateTexture(bool isBulkhead)
    {
        DeallocateTexture();

        Texture_4x4 = new SecurityDoorTexture(LG_GateType.Small, isBulkhead);
        Texture_4x4.SetColor(Main, Strip);

        Texture_8x4 = new SecurityDoorTexture(LG_GateType.Medium, isBulkhead);
        Texture_8x4.SetColor(Main, Strip);
    }

    public void DeallocateTexture()
    {
        Texture_4x4?.DestroyTexture();
        Texture_8x4?.DestroyTexture();
        Texture_4x4 = null;
        Texture_8x4 = null;
    }

    public void Apply(Transform rootTransform, LG_GateType gateType)
    {
        if (gateType == LG_GateType.Small)
            Texture_4x4.ReplaceMaterialsInChild(rootTransform);
        else if (gateType == LG_GateType.Medium)
            Texture_8x4.ReplaceMaterialsInChild(rootTransform);
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

    [JsonIgnore]
    public BulkheadDoorTexture Texture_4x4;
    [JsonIgnore]
    public BulkheadDoorTexture Texture_8x4;

    public void AllocateTexture()
    {
        DeallocateTexture();

        Texture_4x4 = new BulkheadDoorTexture(LG_GateType.Small);
        Texture_4x4.SetColor(Main, Strip1, Strip2);

        Texture_8x4 = new BulkheadDoorTexture(LG_GateType.Medium);
        Texture_8x4.SetColor(Main, Strip1, Strip2);
    }

    public void DeallocateTexture()
    {
        Texture_4x4?.DestroyTexture();
        Texture_8x4?.DestroyTexture();
        Texture_4x4 = null;
        Texture_8x4 = null;
    }

    public void Apply(Transform rootTransform, LG_GateType gateType)
    {
        if (gateType == LG_GateType.Small)
            Texture_4x4.ReplaceMaterialsInChild(rootTransform);
        else if (gateType == LG_GateType.Medium)
            Texture_8x4.ReplaceMaterialsInChild(rootTransform);
    }
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

    [JsonIgnore]
    public ApexDoorTexture Texture_4x4;
    [JsonIgnore]
    public ApexDoorTexture Texture_8x4;

    public void AllocateTexture()
    {
        DeallocateTexture();

        Texture_4x4 = new ApexDoorTexture(LG_GateType.Small);
        Texture_4x4.SetColor(Main, Strip);
        Texture_4x4.SetLightEmission(Emission, EmissionIntensity);

        Texture_8x4 = new ApexDoorTexture(LG_GateType.Medium);
        Texture_8x4.SetColor(Main, Strip);
        Texture_4x4.SetLightEmission(Emission, EmissionIntensity);
    }

    public void DeallocateTexture()
    {
        Texture_4x4?.DestroyTexture();
        Texture_8x4?.DestroyTexture();
        Texture_4x4 = null;
        Texture_8x4 = null;
    }

    public void Apply(Transform rootTransform, LG_GateType gateType)
    {
        if (gateType == LG_GateType.Small)
            Texture_4x4.ReplaceMaterialsInChild(rootTransform);
        else if (gateType == LG_GateType.Medium)
            Texture_8x4.ReplaceMaterialsInChild(rootTransform);
    }
}

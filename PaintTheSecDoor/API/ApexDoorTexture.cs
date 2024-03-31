using LevelGeneration;
using System;
using TexturePainterAPI.PaintableTextures;
using UnityEngine;

namespace PaintTheSecDoor.API;
public sealed class ApexDoorTexture : IMaterialReplacer
{
    private PaintableChannelMaskedTexture _Texture;
    private readonly string _ReplaceMaterialName;

    private Material _BakedMat, _BakedLightMat;
    private Color _EmissionColor = new(1.781479f, 0.3357761f, 0.083944f);

    public ApexDoorTexture(LG_GateType gateType)
    {
        Texture2D baseTex;
        Texture2D maskTex;
        switch (gateType)
        {
            case LG_GateType.Small:
                baseTex = Assets.BaseTex_Apex_4x4;
                maskTex = Assets.MaskTex_Apex_4x4;
                _ReplaceMaterialName = "apexDoor_4x4";
                break;

            case LG_GateType.Medium:
                baseTex = Assets.BaseTex_Apex_8x4;
                maskTex = Assets.MaskTex_Apex_8x4;
                _ReplaceMaterialName = "apexDoor_8x4";
                break;

            default:
                throw new NotImplementedException($"GateType: {gateType} is not supported!");
        }

        _Texture = new PaintableChannelMaskedTexture(baseTex);
        _Texture.SetMaskTexture(maskTex);
    }

    public void SetColor(Color main, Color strip)
    {
        _Texture?.SetTintColor(main, strip);
    }

    public void SetLightEmission(Color color, float intensity)
    {
        var c = color * intensity;
        _EmissionColor = c;
        if (_BakedLightMat != null)
        {
            _BakedLightMat.SetColor("_EmissionColor", _EmissionColor);
        }
    }

    public void ReplaceMaterialsInChild(Transform target)
    {
        MeshRenderer[] renderers = target.GetComponentsInChildren<MeshRenderer>();
        foreach (var renderer in renderers)
        {
            if (renderer.sharedMaterial == null)
                continue;

            var matName = renderer.sharedMaterial.name;
            if (string.IsNullOrEmpty(matName))
                continue;

            if (matName.Equals("ApexLights"))
            {
                if (_BakedLightMat == null)
                {
                    _BakedLightMat = new Material(renderer.sharedMaterial);
                    _BakedLightMat.SetColor("_EmissionColor", _EmissionColor);
                    _BakedLightMat.name = "ApexLights";
                }

                renderer.sharedMaterial = _BakedLightMat;
            }

            if (matName.Equals(_ReplaceMaterialName))
            {
                if (_BakedMat == null)
                {
                    _BakedMat = new Material(renderer.sharedMaterial);
                    _BakedMat.SetTexture("_MainTex", _Texture.CurrentTexture);
                    _BakedMat.SetVector("_Color", Vector4.one);
                    _BakedMat.name = _ReplaceMaterialName;
                }

                renderer.sharedMaterial = _BakedMat;
            }
        }
    }

    public void DestroyTexture()
    {
        _Texture?.Destroy();
        _Texture = null;
    }
}

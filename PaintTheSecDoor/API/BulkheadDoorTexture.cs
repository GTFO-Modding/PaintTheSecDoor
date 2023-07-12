using LevelGeneration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TexturePainterAPI.PaintableTextures;
using UnityEngine;

namespace PaintTheSecDoor.API;
public sealed class BulkheadDoorTexture : IMaterialReplacer
{
    private PaintableMaskedTexture _Texture;
    private readonly string _ReplaceMaterialName;

    private Material _BakedMat;

    public BulkheadDoorTexture(LG_GateType gateType)
    {
        Texture2D baseTex;
        Texture2D mainTex;
        Texture2D strip1Tex;
        Texture2D strip2Tex;
        switch (gateType)
        {
            case LG_GateType.Small:
                baseTex = Assets.BaseTex_Bulk_4x4;
                mainTex = Assets.PaintTex_Bulk_4x4;
                strip1Tex = Assets.Strip1Tex_Bulk_4x4;
                strip2Tex = Assets.Strip2Tex_Bulk_4x4;
                _ReplaceMaterialName = "BulkheadDoor";
                break;

            case LG_GateType.Medium:
                baseTex = Assets.BaseTex_Bulk_8x4;
                mainTex = Assets.PaintTex_Bulk_8x4;
                strip1Tex = Assets.Strip1Tex_Bulk_8x4;
                strip2Tex = Assets.Strip2Tex_Bulk_8x4;
                _ReplaceMaterialName = "BulkheadDoor_8x4";
                break;

            default:
                throw new NotImplementedException($"GateType: {gateType} is not supported!");
        }

        _Texture = new PaintableMaskedTexture(baseTex);
        _Texture.SetMaskTexture(mainTex, strip1Tex, strip2Tex);
    }

    public void SetColor(Color main, Color strip1, Color strip2)
    {
        _Texture?.SetTintColor(main, strip1, strip2);
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

            if (!matName.Equals(_ReplaceMaterialName))
                continue;

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

    public void DestroyTexture()
    {
        _Texture?.Destroy();
        _Texture = null;
    }
}

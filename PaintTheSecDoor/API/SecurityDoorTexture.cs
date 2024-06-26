﻿using LevelGeneration;
using System;
using TexturePainterAPI.PaintableTextures;
using UnityEngine;

namespace PaintTheSecDoor.API;
public sealed class SecurityDoorTexture : IMaterialReplacer
{
    private PaintableChannelMaskedTexture _Texture;
    private readonly string _ReplaceMaterialName;

    private Material _BakedMat;

    public SecurityDoorTexture(LG_GateType gateType, bool isMainBulkhead)
    {
        Texture2D baseTex;
        Texture2D maskTex;
        switch (gateType)
        {
            case LG_GateType.Small:
                baseTex = Assets.BaseTex_4x4;
                maskTex = Assets.MaskTex_4x4;
                _ReplaceMaterialName = !isMainBulkhead ? "securityDoor_4x4_tech" : "securityDoor_4x4_bulkhead"; //Why this one have different name wtf
                break;

            case LG_GateType.Medium:
                baseTex = Assets.BaseTex_8x4;
                maskTex = Assets.MaskTex_8x4;
                _ReplaceMaterialName = !isMainBulkhead ? "securityDoor_8x4_tech" : "securityDoor_8x4_tech_bulkhead";
                break;

            default:
                throw new NotImplementedException($"GateType: {gateType} is not supported!");
        }

        _Texture = new PaintableChannelMaskedTexture(baseTex);
        _Texture.SetMaskTexture(maskTex);
    }

    public void SetColor(Color mainColor, Color stripColor)
    {
        _Texture?.SetTintColor(mainColor, stripColor);
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

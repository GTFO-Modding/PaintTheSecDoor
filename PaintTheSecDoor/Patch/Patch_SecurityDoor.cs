using HarmonyLib;
using LevelGeneration;
using PaintTheSecDoor.API;
using PaintTheSecDoor.Configs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace PaintTheSecDoor.Patch;
[HarmonyPatch(typeof(LG_SecurityDoor), nameof(LG_SecurityDoor.Setup))]
internal class Patch_SecurityDoor
{
    static void Postfix(LG_SecurityDoor __instance)
    {
        if (!ConfigManager.TryGetStyle(__instance, out var style))
        {
            return;
        }

        var gateType = __instance.Gate.Type;
        var type = DoorType.Get(__instance);
        if (type == SecDoorTypes.Security_Small || type == SecDoorTypes.Security_Medium)
        {
            if (!style.Security.Enabled)
                return;

            var texture = new SecurityDoorTexture(gateType, false);
            texture.SetColor(style.Security.Main, style.Security.Strip);
            texture.ReplaceMaterialsInChild(__instance.transform);
        }
        else if (type == SecDoorTypes.InternalBulkhead_Small || type == SecDoorTypes.InternalBulkhead_Medium)
        {
            if (!style.InternalBulkhead.Enabled)
                return;

            var texture = new SecurityDoorTexture(gateType, true);
            texture.SetColor(style.InternalBulkhead.Main, style.InternalBulkhead.Strip);
            texture.ReplaceMaterialsInChild(__instance.transform);
        }
        else if (type == SecDoorTypes.Bulkhead_Small || type == SecDoorTypes.Bulkhead_Medium)
        {
            if (!style.Bulkhead.Enabled)
                return;

            var texture = new BulkheadDoorTexture(gateType);
            texture.SetColor(style.Bulkhead.Main, style.Bulkhead.Strip1, style.Bulkhead.Strip2);
            texture.ReplaceMaterialsInChild(__instance.transform);
        }
        else if (type == SecDoorTypes.Apex_Small || type == SecDoorTypes.Apex_Medium)
        {
            if (!style.Apex.Enabled)
                return;

            var texture = new ApexDoorTexture(gateType);
            texture.SetColor(style.Apex.Main, style.Apex.Strip);
            texture.SetLightEmission(style.Apex.Emission, style.Apex.EmissionIntensity);
            texture.ReplaceMaterialsInChild(__instance.transform);
        }
    }

    static Color GetLayerThemeColor(LG_SecurityDoor door)
    {
        return door.LinksToLayerType switch
        {
            LG_LayerType.MainLayer => ColorExt.Hex("#ffc4c4"),
            LG_LayerType.SecondaryLayer => ColorExt.Hex("#ffa14f"),
            LG_LayerType.ThirdLayer => ColorExt.Hex("#ff3d3d"),
            _ => throw new NotImplementedException(),
        };
    }
}

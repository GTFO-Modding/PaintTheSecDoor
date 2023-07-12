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
        ConfigManager.TryApplyToDoor(__instance);
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

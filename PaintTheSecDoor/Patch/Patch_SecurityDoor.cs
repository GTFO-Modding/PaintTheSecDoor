using HarmonyLib;
using LevelGeneration;
using PaintTheSecDoor.Configs;

namespace PaintTheSecDoor.Patch;
[HarmonyPatch(typeof(LG_SecurityDoor), nameof(LG_SecurityDoor.Setup))]
internal class Patch_SecurityDoor
{
    static void Postfix(LG_SecurityDoor __instance)
    {
        StyleManager.TryApplyToDoor(__instance);
    }
}

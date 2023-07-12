using BepInEx;
using BepInEx.Unity.IL2CPP;
using GTFO.API;
using HarmonyLib;
using PaintTheSecDoor.API;
using PaintTheSecDoor.Configs;
using System.Linq;

namespace PaintTheSecDoor;
[BepInPlugin("PaintTheSecDoor", "PaintTheSecDoor", VersionInfo.Version)]
[BepInDependency("dev.gtfomodding.gtfo-api", BepInDependency.DependencyFlags.HardDependency)]
[BepInDependency("TexturePainterAPI", BepInDependency.DependencyFlags.HardDependency)]
[BepInDependency("com.dak.MTFO", BepInDependency.DependencyFlags.SoftDependency)]
internal class EntryPoint : BasePlugin
{
    private Harmony _Harmony = null;

    public override void Load()
    {
        _Harmony = new Harmony($"{VersionInfo.RootNamespace}.Harmony");
        _Harmony.PatchAll();

        AssetAPI.OnStartupAssetsLoaded += AssetAPI_OnStartupAssetsLoaded;
    }

    private void AssetAPI_OnStartupAssetsLoaded()
    {
        Assets.LoadAll();
        ConfigManager.Init();
    }

    public override bool Unload()
    {
        _Harmony.UnpatchSelf();
        return base.Unload();
    }
}

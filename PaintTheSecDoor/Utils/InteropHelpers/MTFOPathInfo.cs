using BepInEx.Unity.IL2CPP;
using MTFO.API;

namespace PaintTheSecDoor.Utils.InteropHelpers;
internal static class MTFOPathInfo
{
    public static bool HasMTFO
    {
        get
        {
            return IL2CPPChainloader.Instance.Plugins.ContainsKey("com.dak.MTFO");
        }
    }

    public static bool HasCustomPath => MTFOPathAPI.HasCustomPath;
    public static string CustomPath => MTFOPathAPI.CustomPath;
}

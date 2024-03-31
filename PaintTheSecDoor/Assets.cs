using GTFO.API;
using UnityEngine;

namespace PaintTheSecDoor;
internal static class Assets
{
    public static Texture2D BaseTex_4x4;
    public static Texture2D MaskTex_4x4;

    public static Texture2D BaseTex_8x4;
    public static Texture2D MaskTex_8x4;

    public static Texture2D BaseTex_Apex_4x4;
    public static Texture2D MaskTex_Apex_4x4;

    public static Texture2D BaseTex_Apex_8x4;
    public static Texture2D MaskTex_Apex_8x4;

    public static Texture2D BaseTex_Bulk_4x4;
    public static Texture2D MaskTex_Bulk_4x4;

    public static Texture2D BaseTex_Bulk_8x4;
    public static Texture2D MaskTex_Bulk_8x4;

    public static void LoadAll()
    {
        BaseTex_4x4 = AssetAPI.GetLoadedAsset<Texture2D>("Assets/Modding/SecDoorPainting/4x4_base.png");
        MaskTex_4x4 = AssetAPI.GetLoadedAsset<Texture2D>("Assets/Modding/SecDoorPainting/4x4_mask.png");

        BaseTex_8x4 = AssetAPI.GetLoadedAsset<Texture2D>("Assets/Modding/SecDoorPainting/8x4_base.png");
        MaskTex_8x4 = AssetAPI.GetLoadedAsset<Texture2D>("Assets/Modding/SecDoorPainting/8x4_mask.png");

        BaseTex_Apex_4x4 = AssetAPI.GetLoadedAsset<Texture2D>("Assets/Modding/SecDoorPainting/apex_4x4_base.png");
        MaskTex_Apex_4x4 = AssetAPI.GetLoadedAsset<Texture2D>("Assets/Modding/SecDoorPainting/apex_4x4_mask.png");

        BaseTex_Apex_8x4 = AssetAPI.GetLoadedAsset<Texture2D>("Assets/Modding/SecDoorPainting/apex_8x4_base.png");
        MaskTex_Apex_8x4 = AssetAPI.GetLoadedAsset<Texture2D>("Assets/Modding/SecDoorPainting/apex_8x4_mask.png");

        BaseTex_Bulk_4x4 = AssetAPI.GetLoadedAsset<Texture2D>("Assets/Modding/SecDoorPainting/bulk_4x4_base.png");
        MaskTex_Bulk_4x4 = AssetAPI.GetLoadedAsset<Texture2D>("Assets/Modding/SecDoorPainting/bulk_4x4_mask.png");

        BaseTex_Bulk_8x4 = AssetAPI.GetLoadedAsset<Texture2D>("Assets/Modding/SecDoorPainting/bulk_8x4_base.png");
        MaskTex_Bulk_8x4 = AssetAPI.GetLoadedAsset<Texture2D>("Assets/Modding/SecDoorPainting/bulk_8x4_mask.png");
    }
}

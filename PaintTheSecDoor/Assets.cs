using GTFO.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace PaintTheSecDoor;
internal static class Assets
{
    public static Texture2D BaseTex_4x4;
    public static Texture2D MainTex_4x4;
    public static Texture2D StripTex_4x4;

    public static Texture2D BaseTex_8x4;
    public static Texture2D MainTex_8x4;
    public static Texture2D StripTex_8x4;

    public static Texture2D BaseTex_Apex_4x4;
    public static Texture2D MainTex_Apex_4x4;
    public static Texture2D StripTex_Apex_4x4;

    public static Texture2D BaseTex_Apex_8x4;
    public static Texture2D MainTex_Apex_8x4;
    public static Texture2D StripTex_Apex_8x4;

    public static Texture2D BaseTex_Bulk_4x4;
    public static Texture2D PaintTex_Bulk_4x4;
    public static Texture2D Strip1Tex_Bulk_4x4;
    public static Texture2D Strip2Tex_Bulk_4x4;

    public static Texture2D BaseTex_Bulk_8x4;
    public static Texture2D PaintTex_Bulk_8x4;
    public static Texture2D Strip1Tex_Bulk_8x4;
    public static Texture2D Strip2Tex_Bulk_8x4;

    public static void LoadAll()
    {
        BaseTex_4x4 = AssetAPI.GetLoadedAsset<Texture2D>("Assets/Modding/SecDoorPainting/4x4_base.png");
        MainTex_4x4 = AssetAPI.GetLoadedAsset<Texture2D>("Assets/Modding/SecDoorPainting/4x4_main.png");
        StripTex_4x4 = AssetAPI.GetLoadedAsset<Texture2D>("Assets/Modding/SecDoorPainting/4x4_strip.png");

        BaseTex_8x4 = AssetAPI.GetLoadedAsset<Texture2D>("Assets/Modding/SecDoorPainting/8x4_base.png");
        MainTex_8x4 = AssetAPI.GetLoadedAsset<Texture2D>("Assets/Modding/SecDoorPainting/8x4_main.png");
        StripTex_8x4 = AssetAPI.GetLoadedAsset<Texture2D>("Assets/Modding/SecDoorPainting/8x4_strip.png");

        BaseTex_Apex_4x4 = AssetAPI.GetLoadedAsset<Texture2D>("Assets/Modding/SecDoorPainting/apex_4x4_base.png");
        MainTex_Apex_4x4 = AssetAPI.GetLoadedAsset<Texture2D>("Assets/Modding/SecDoorPainting/apex_4x4_main.png");
        StripTex_Apex_4x4 = AssetAPI.GetLoadedAsset<Texture2D>("Assets/Modding/SecDoorPainting/apex_4x4_strip.png");

        BaseTex_Apex_8x4 = AssetAPI.GetLoadedAsset<Texture2D>("Assets/Modding/SecDoorPainting/apex_8x4_base.png");
        MainTex_Apex_8x4 = AssetAPI.GetLoadedAsset<Texture2D>("Assets/Modding/SecDoorPainting/apex_8x4_main.png");
        StripTex_Apex_8x4 = AssetAPI.GetLoadedAsset<Texture2D>("Assets/Modding/SecDoorPainting/apex_8x4_strip.png");

        BaseTex_Bulk_4x4 = AssetAPI.GetLoadedAsset<Texture2D>("Assets/Modding/SecDoorPainting/bulk_4x4_base.png");
        PaintTex_Bulk_4x4 = AssetAPI.GetLoadedAsset<Texture2D>("Assets/Modding/SecDoorPainting/bulk_4x4_paint.png");
        Strip1Tex_Bulk_4x4 = AssetAPI.GetLoadedAsset<Texture2D>("Assets/Modding/SecDoorPainting/bulk_4x4_strip1.png");
        Strip2Tex_Bulk_4x4 = AssetAPI.GetLoadedAsset<Texture2D>("Assets/Modding/SecDoorPainting/bulk_4x4_strip2.png");

        BaseTex_Bulk_8x4 = AssetAPI.GetLoadedAsset<Texture2D>("Assets/Modding/SecDoorPainting/bulk_8x4_base.png");
        PaintTex_Bulk_8x4 = AssetAPI.GetLoadedAsset<Texture2D>("Assets/Modding/SecDoorPainting/bulk_8x4_paint.png");
        Strip1Tex_Bulk_8x4 = AssetAPI.GetLoadedAsset<Texture2D>("Assets/Modding/SecDoorPainting/bulk_8x4_strip1.png");
        Strip2Tex_Bulk_8x4 = AssetAPI.GetLoadedAsset<Texture2D>("Assets/Modding/SecDoorPainting/bulk_8x4_strip2.png");
    }
}

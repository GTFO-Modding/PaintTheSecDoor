using GameData;
using GTFO.API.JSON;
using GTFO.API.Utilities;
using LevelGeneration;
using System.Collections.Generic;
using System.IO;

namespace PaintTheSecDoor.Configs;

using LayoutDB = LevelLayoutDataBlock;

internal static class ConfigManager
{

    private static readonly Dictionary<string, LayoutDTO> _LayoutLookup = new();
    private static readonly Dictionary<string, StyleDTO> _StyleLookup = new();
    private static StyleDTO _GlobalStyle;

    private static string _ConfigPath;

    public static void Init()
    {
        if (!MTFOPathInfo.HasMTFO)
            return;

        if (!MTFOPathInfo.HasCustomPath)
            return;

        _ConfigPath = Path.Combine(MTFOPathInfo.CustomPath, "SecDoorStyles.json");
        Logger.Info($" Json Path: {_ConfigPath}");
        
        if (File.Exists(_ConfigPath))
        {
            var listener = LiveEdit.CreateListener(MTFOPathInfo.CustomPath, "SecDoorStyles.json", false);
            listener.FileChanged += Listener_FileChanged;
            Load(File.ReadAllText(_ConfigPath));
            Logger.Info($" Loaded! ");
        }
    }

    private static void Listener_FileChanged(LiveEditEventArgs e)
    {
        LiveEdit.TryReadFileContent(_ConfigPath, (json) =>
        {
            Load(json);
            Logger.Info(" Reloaded! ");
        });
    }

    public static void Load(string json)
    {
        var config = JsonSerializer.Deserialize<ConfigDTO>(json);
        _StyleLookup.Clear();
        _LayoutLookup.Clear();

        var hasGlobalStyleSet = !string.IsNullOrEmpty(config.GlobalStyle);
        foreach (var style in config.Styles)
        {
            _StyleLookup.Add(style.StyleName, style);
            if (hasGlobalStyleSet)
            {
                if (style.StyleName.Equals(config.GlobalStyle))
                {
                    _GlobalStyle = style;
                }
            }
        }

        foreach (var layout in config.Layouts)
        {
            _LayoutLookup.Add(layout.LayoutBlockName, layout);
        }
    }

    public static bool TryGetStyle(LG_SecurityDoor secDoor, out StyleDTO style)
    {
        var expedition = RundownManager.ActiveExpedition;
        if (expedition == null)
        {
            goto FALLBACK;
        }

        var layoutName = GetLayoutName(secDoor.Gate.DimensionIndex, secDoor.LinksToLayerType);
        if (string.IsNullOrEmpty(layoutName))
        {
            goto FALLBACK;
        }

        if (!_LayoutLookup.TryGetValue(layoutName, out var layout))
        {
            goto FALLBACK;
        }

        if (!layout.TryGetDoorInfo(secDoor.Gate.m_linksTo.m_zone.LocalIndex, out var info))
        {
            goto FALLBACK;
        }

        if (!_StyleLookup.TryGetValue(info.StyleName, out style))
        {
            goto FALLBACK;
        }

        return true;

        FALLBACK:
        style = _GlobalStyle;
        return style != null;
    }

    public static string GetLayoutName(eDimensionIndex dimensionIndex, LG_LayerType linkedLayer)
    {
        var expedition = RundownManager.ActiveExpedition;
        if (expedition == null)
        {
            return string.Empty;
        }

        switch (dimensionIndex)
        {
            case eDimensionIndex.Reality:
                return linkedLayer switch
                {
                    LG_LayerType.MainLayer => LayoutDB.GetBlock(expedition.LevelLayoutData)?.name ?? string.Empty,
                    LG_LayerType.SecondaryLayer => LayoutDB.GetBlock(expedition.SecondaryLayout)?.name ?? string.Empty,
                    LG_LayerType.ThirdLayer => LayoutDB.GetBlock(expedition.ThirdLayout)?.name ?? string.Empty,
                    _ => string.Empty,
                };
            default:
                foreach (var dimData in expedition.DimensionDatas)
                {
                    if (dimData.DimensionIndex == dimensionIndex)
                    {
                        return LayoutDB.GetBlock(dimData.DimensionData)?.name ?? string.Empty; 
                    }
                }
                return string.Empty;
        }
    }
}

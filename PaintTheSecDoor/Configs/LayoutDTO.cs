using GameData;
using LevelGeneration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaintTheSecDoor.Configs;
internal sealed class LayoutDTO
{
    public string LayoutBlockName { get; set; }
    public DoorInfoDTO[] SecDoors { get; set; } = Array.Empty<DoorInfoDTO>();

    public bool TryGetDoorInfo(eLocalZoneIndex localIndex, out DoorInfoDTO info)
    {
        info = SecDoors.First(x => x.LocalIndex == localIndex);
        return info != null;
    }
}

internal sealed class DoorInfoDTO
{
    public eLocalZoneIndex LocalIndex { get; set; }
    public string StyleName { get; set; }
}

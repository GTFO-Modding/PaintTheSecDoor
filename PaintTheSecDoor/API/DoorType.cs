using LevelGeneration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaintTheSecDoor.API;
public static class DoorType
{
    public static SecDoorTypes Get(LG_SecurityDoor secDoor)
    {
        var gateType = secDoor.Gate.Type;
        if (gateType != LG_GateType.Small && gateType != LG_GateType.Medium)
            throw new NotImplementedException($"GateType: {gateType} is not supported");

        var isSmall = gateType == LG_GateType.Small;
        switch (secDoor.m_securityDoorType)
        {
            //SecDoor
            case eSecurityDoorType.Security:
                if (isSmall) return SecDoorTypes.Security_Small;
                else return SecDoorTypes.Security_Medium;

            //Apex
            case eSecurityDoorType.Apex:
                if (isSmall) return SecDoorTypes.Apex_Small;
                else return SecDoorTypes.Apex_Medium;

            //MainPath Bulkhead, Bulkhead
            case eSecurityDoorType.Bulkhead:
                var anim = secDoor.m_anim.Cast<LG_SecurityDoor_Anim>();
                if (anim.m_isBulkheadDoor)
                {
                    if (isSmall) return SecDoorTypes.Bulkhead_Small;
                    else return SecDoorTypes.Bulkhead_Medium;
                }
                else
                {
                    if (isSmall) return SecDoorTypes.InternalBulkhead_Small;
                    else return SecDoorTypes.InternalBulkhead_Medium;
                }

            default:
                throw new NotImplementedException($"SecurityDoorType: {secDoor.m_securityDoorType} is not supported");
        }
    }

    public static WeakDoorTypes Get(LG_WeakDoor weakDoor)
    {
        return weakDoor.Gate.Type switch
        {
            LG_GateType.Small => WeakDoorTypes.Weak_Small,
            LG_GateType.Medium => WeakDoorTypes.Weak_Medium,
            _ => throw new NotImplementedException($"GateType: {weakDoor.Gate.Type} is not supported"),
        };
    }
}

public enum WeakDoorTypes
{
    Weak_Small,
    Weak_Medium
}

public enum SecDoorTypes
{
    Apex_Small,
    Apex_Medium,
    Security_Small,
    Security_Medium,
    Bulkhead_Small,
    Bulkhead_Medium,
    InternalBulkhead_Small,
    InternalBulkhead_Medium
}

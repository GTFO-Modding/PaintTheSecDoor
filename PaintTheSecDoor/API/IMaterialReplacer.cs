using UnityEngine;

namespace PaintTheSecDoor.API;
public interface IMaterialReplacer
{
    public void ReplaceMaterialsInChild(Transform target);
}

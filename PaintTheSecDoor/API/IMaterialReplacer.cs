using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace PaintTheSecDoor.API;
internal interface IMaterialReplacer
{
    public void ReplaceMaterialsInChild(Transform target);
}

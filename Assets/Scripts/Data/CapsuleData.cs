using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SO_CapsuleData", menuName = "Datas/SO_CapsuleData")]
public class CapsuleData : ScriptableObject
{
    public List<Vector3> capsulePosition;
}

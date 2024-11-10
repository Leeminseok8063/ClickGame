using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CapsuleManager : Singleton<CapsuleManager>
{
    private List<Vector3> capsulePosition = new List<Vector3>();
    private List<bool> capsuleEmpty = new List<bool>();

    public void Init()
    {
        CapsuleData data = Resources.Load<CapsuleData>("Data/CapsuleData");
        capsulePosition = data.capsulePosition;
        for(int i = 0; i < capsulePosition.Count; i++)
        {
            capsuleEmpty.Add(true);
        }
    }

    public Vector3 GetRandomAcess()
    {

    }
}

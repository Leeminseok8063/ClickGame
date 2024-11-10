using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionManager : Singleton<PositionManager>
{
    private List<Vector3> capsulePosition = new List<Vector3>();
    private List<bool> capsuleEmpty = new List<bool>();

    private Vector3 mobStart;
    private Vector3 mobDest;
    private float fixXpostion;

    public List<Vector3> CapsulePosition { get { return capsulePosition; } }
    public Vector3 MobStartPos { get { return mobStart; } }
    public Vector3 MobDestPos { get { return mobDest; } }
    public float CharXpos { get { return fixXpostion; } }
    public List<bool> CapsuleEmpty { get { return capsuleEmpty; } }

    public void Init()
    {
        CapsuleData data = Resources.Load<CapsuleData>("Data/CapsuleData");
        capsulePosition = data.capsulePosition;
        for(int i = 0; i < capsulePosition.Count; i++)
        {
            capsuleEmpty.Add(true);
        }

        mobStart = new Vector3(6f, -0.6f);
        mobDest = new Vector3(1.5f, -0.6f);
        fixXpostion = -6f;
    }

    /// <summary>
    /// 빈 자리가 없으면 -1을 반환합니다.
    /// </summary>
    /// <returns></returns>
    public int GetEmptyAcess()
    {
        for(int index = 0; index < capsuleEmpty.Count; index++)
        {
            if (capsuleEmpty[index])
            {
                capsuleEmpty[index] = false;
                return index;
            }
        }

        return -1;
    }

    public void ReturnAcess(int index) { capsuleEmpty[index] = true; }
}

using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : Singleton<SpawnManager>
{
    private Dictionary<string, ObjectPool> pools;
    public void Init()
    {
        CreateTypeOfPool("Char", ObjectManager.Instance.GetChars());
        CreateTypeOfPool("Mob", ObjectManager.Instance.GetMobs());
    }

    private void CreateTypeOfPool(string typeName, List<GameObject> lists)
    {
        int index = 0;
        foreach (GameObject tempObject in lists)
        {
            index++;
            pools.Add($"{typeName}{index}", new ObjectPool($"{typeName}{index}", this.transform, tempObject));
        }
    }
}


using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : Singleton<SpawnManager>
{
    private Dictionary<string, ObjectPool> pools = new Dictionary<string, ObjectPool>();
    private int charCount;
    private int mobCount;

    public void Init()
    {
        List<GameObject> charList = ObjectManager.Instance.GetChars();
        List<GameObject> mobList = ObjectManager.Instance.GetMobs(); 
        CreateTypeOfPool("Char", charList);
        CreateTypeOfPool("Mob", mobList);
        charCount = charList.Count;
        mobCount = mobList.Count;

        SpawnMob("Char3");
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
    public void SpawnMob(string name)
    {
        GameObject temp = pools[name].Spawn();
        temp.transform.position = new Vector3(6f, -0.6f, 0);
        temp.transform.position = new Vector3(1.5f, -0.6f, 0);
    }
}


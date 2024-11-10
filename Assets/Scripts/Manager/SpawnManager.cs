using Assets.Scripts.Utils;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : Singleton<SpawnManager>
{
    private Dictionary<string, ObjectPool> pools = new Dictionary<string, ObjectPool>();
    private int charCount;
    private int mobCount;

    public int CharCount { get { return charCount; } }
    public int MobCount { get { return mobCount; } }

    public void Init()
    {
        List<GameObject> charList = ObjectManager.Instance.GetChars();
        List<GameObject> mobList = ObjectManager.Instance.GetMobs(); 
        CreateTypeOfPool("Char", charList);
        CreateTypeOfPool("Mob", mobList);
        charCount = charList.Count;
        mobCount = mobList.Count;

        SpawnCreature("Mob1");
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
    
    public void SpawnCreature(string name)
    {
        GameObject temp = pools[name].Spawn();
        temp.GetComponent<ISpawnable>().IsSpawned();
    }

    public void DespawnMob(GameObject _object)
    {
        pools[_object.name].Despawn(_object);
    }
}


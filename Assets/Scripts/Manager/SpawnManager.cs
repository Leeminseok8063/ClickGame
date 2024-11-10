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

    public GameObject SpawnMonster(int level)
    {
         GameObject Monster = Spawn
         (
            $"Mob{level}",
            PositionManager.Instance.MobStartPos,
            PositionManager.Instance.MobDestPos
         );

        return Monster;
    }

    public GameObject SpawnChar(int id)
    {
        int positionIndex = PositionManager.Instance.GetEmptyAcess();
        if (positionIndex == -1) return null;

        float XFixPos = PositionManager.Instance.CharXpos;
        Vector3 destPos = PositionManager.Instance.CapsulePosition[positionIndex];
        Vector3 startPos = new Vector3(XFixPos, destPos.y, destPos.z);

        GameObject Player = Spawn
        (
            $"Char{id}",
            startPos,
            destPos
        );

        return Player;
    }
  
    public GameObject Spawn(string name, Vector3 start, Vector3 dest)
    {
        GameObject temp = pools[name].Spawn();
        temp.GetComponent<ISpawnable>().IsSpawned(start, dest);
        return temp;
    }

    public void Despawn(GameObject _object)
    {
        pools[_object.name].Despawn(_object);
    }
}


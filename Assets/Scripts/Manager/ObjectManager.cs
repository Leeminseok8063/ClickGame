using Assets.Scripts.Utils;
using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ObjectManager : Singleton<ObjectManager>
{
    List<GameObject> charList;
    List<GameObject> mobList;

    public void Init()
    {
        ScriptableObject[] charDatas = Resources.LoadAll<ScriptableObject>("Data/CharData/");
        ScriptableObject[] mobDatas = Resources.LoadAll<ScriptableObject>("Data/MobData/");
        GameObject[] charaters = Resources.LoadAll<GameObject>("Prefabs/01.Char/");
        GameObject[] monsters = Resources.LoadAll<GameObject>("Prefabs/02.Mob/");

        Functions.SortObject(charDatas);
        Functions.SortObject(mobDatas);
        Functions.SortObject(charaters);
        Functions.SortObject(monsters);
        
        charList = SetCreature<Character>(charaters, charDatas);
        mobList = SetCreature<Monster>(monsters, mobDatas);
    }

    public GameObject GetChar(int id){ return charList[id];}    
    public GameObject GetMob(int id){ return mobList[id];}
    public List<GameObject> GetChars(){ return charList; }
    public List<GameObject> GetMobs(){ return mobList; }

    private List<GameObject> SetCreature<T>(GameObject[] objects, ScriptableObject[] datas)
    {
        int currentIndex = 0;
        List<GameObject> tempList = new List<GameObject>();
        foreach(GameObject obj in objects)
        {
            GameObject clone = Instantiate(obj);            
            clone.SetActive(false);
            clone.transform.parent = this.transform;
            
            clone.AddComponent(typeof(T));
            clone.GetComponent<ICreature>().SetData(datas[currentIndex] as CreatureData);
            
            tempList.Add(clone);
            currentIndex++;
        }

        return tempList;
    }   
}

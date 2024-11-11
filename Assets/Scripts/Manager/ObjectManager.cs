using Assets.Scripts.Utils;
using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ObjectManager : Singleton<ObjectManager>
{
    List<GameObject> charList;
    List<GameObject> mobList;
    List<GameObject> effectList;

    public void Init()
    {
        ScriptableObject[] charDatas = Resources.LoadAll<ScriptableObject>("Data/CharData/");
        ScriptableObject[] mobDatas = Resources.LoadAll<ScriptableObject>("Data/MobData/");
        GameObject[] charaters = Resources.LoadAll<GameObject>("Prefabs/01.Char/");
        GameObject[] monsters = Resources.LoadAll<GameObject>("Prefabs/02.Mob/");
        GameObject[] effects = Resources.LoadAll<GameObject>("Prefabs/04.Effect/");

        Functions.SortObject(charDatas);
        Functions.SortObject(mobDatas);
        Functions.SortObject(charaters);
        Functions.SortObject(monsters);
        Functions.SortObject(effects);
        
        charList = SetCreature<Character>(charaters, charDatas);
        mobList = SetCreature<Monster>(monsters, mobDatas);
        effectList = SetEffect(effects);
    }

    public GameObject GetChar(int id){ return charList[id];}    
    public GameObject GetMob(int id){ return mobList[id];}
    public GameObject GetParticle(int id){ return effectList[id];}
    public List<GameObject> GetChars(){ return charList; }
    public List<GameObject> GetMobs(){ return mobList; }
    public List<GameObject> GetEffects(){ return effectList; }

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
    
    private List<GameObject> SetEffect(GameObject[] objects)
    {
        List<GameObject> tempList = new List<GameObject>();
        foreach(GameObject obj in objects)
        {
            GameObject temp = Instantiate(obj);
            temp.AddComponent<Effect>();
            temp.transform.parent = this.transform;

            tempList.Add(temp);
        }

        return tempList;
    }
}

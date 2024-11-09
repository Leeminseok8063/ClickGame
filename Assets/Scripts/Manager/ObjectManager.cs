using Assets.Scripts.Utils;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
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

        charList = SetCreature(charaters, charDatas, "Character");
        mobList = SetCreature(charaters, charDatas, "Monster");
    }

    public GameObject GetChar(int id){ return charList[id];}    
    public GameObject GetMob(int id){ return mobList[id];}

    public List<GameObject> GetChars(){ return charList; }
    public List<GameObject> GetMobs(){ return charList; }

    private List<GameObject> SetCreature(GameObject[] objects, ScriptableObject[] datas, string type)
    {
        Type initType = Type.GetType(type);
        int currentIndex = 0;
        foreach(GameObject obj in objects)
        {
            obj.AddComponent(initType);
            obj.GetComponent<ICreature>().SetData(datas[currentIndex].GetComponent<CreatureData>());
        }

        return objects.ToList();
    }
}

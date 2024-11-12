using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class IOManager : Singleton<IOManager>
{
    string savePath;

    public void Init()
    {
        string path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
        savePath = path + "\\clickGame";

        if(!Directory.Exists(savePath))
        {
            Directory.CreateDirectory(savePath);
        }
    }

    public void Save()
    {
        StreamWriter sw = new StreamWriter(savePath + "\\SaveFile.sparta");
        int mapLevel = GameManager.Instance.currentLevel;
        int currentCoin = GameManager.Instance.coinCount;
        Dictionary<int, GameObject> chars = GameManager.Instance.currentPlayers;
        sw.WriteLine($"{mapLevel},{currentCoin}");
        foreach(var temp in chars)
        {
            Character tempChar = temp.Value.GetComponent<Character>();
            sw.WriteLine($"{tempChar.ID},{tempChar.maxHealth},{tempChar.damage},{tempChar.attackDelay}");
        }

        sw.Close();
        GameManager.Instance.ExitGame();
    }

    public bool Load()
    {
        if (!File.Exists(savePath + "\\SaveFile.sparta")) return false;

        StreamReader sr = new StreamReader(savePath + "\\SaveFile.sparta");
        string[] mapData = sr.ReadLine().Split(",");
        GameManager.Instance.currentMonster = SpawnManager.Instance.SpawnMonster(int.Parse(mapData[0]));
        GameManager.Instance.currentLevel = int.Parse(mapData[0]);
        GameManager.Instance.coinCount = int.Parse(mapData[1]);
        UIManager.Instance.MainUIPanel.UpdateUserTreasueUpdate();
        
        while(!sr.EndOfStream)
        {
            string[] charData = sr.ReadLine().Split(",");
            Character tempChar = GameManager.Instance.charController.GetChar(int.Parse(charData[0])).GetComponent<Character>();
            tempChar.maxHealth = float.Parse(charData[1]);
            tempChar.currentHealth = tempChar.maxHealth;
            tempChar.damage = float.Parse(charData[2]);
            tempChar.attackDelay = float.Parse(charData[3]);
        }

        sr.Close();
        return true;
    }

}


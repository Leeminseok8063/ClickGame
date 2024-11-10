using Assets.Scripts.Manager;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GameManager : Singleton<GameManager>
{
    private int currentLevel = 0;
    public InputController inputController;

    public Dictionary<int, GameObject> currentPlayers = new Dictionary<int, GameObject>();
    public GameObject currentMonster;

    public int treasureCount = 10000;
    public int priceGetChar = 10000;
    public float test = 0;
    
    public void Init()
    {
        GameObject inputModule = Instantiate(Resources.Load<GameObject>("Prefabs/03.Module/InputModule"));
        inputModule.transform.parent = this.transform;
        inputController = inputModule.GetComponent<InputController>();
    }

    public void Start()
    {
        NextPhase();
        GetChar();
    } 

    public void GetChar()
    {
        if (treasureCount < priceGetChar) return;

        GameObject spawned = SpawnManager.Instance.SpawnChar(Random.Range(1, SpawnManager.Instance.CharCount + 1));
        if (spawned == null) return;

        Character spChar = spawned.GetComponent<Character>();
        currentPlayers.Add(spChar.CapsuleIndex, spawned);
        UseTreasure(priceGetChar);
    }

    public void ExitChar(GameObject charObject)
    {
        if (currentPlayers.Count <= 1) return;
        if (!charObject.TryGetComponent<Character>(out Character tempChar)) return;

        currentPlayers.Remove(tempChar.CapsuleIndex);
        StartCoroutine(tempChar.Exit());
    }

    public void NextPhase()
    {
        if(!(currentLevel >= SpawnManager.Instance.MobCount))
        {
            currentLevel++;
            currentMonster = SpawnManager.Instance.SpawnMonster(currentLevel);
        }
    }

    public void UseTreasure(int val)
    {
        treasureCount -= val;
        UIManager.Instance.MainUIPanel.UpdateUserTreasueUpdate();
    }

    public void GetTreasure(int val)
    {
        treasureCount += val;
        UIManager.Instance.MainUIPanel.UpdateUserTreasueUpdate();
    }
}

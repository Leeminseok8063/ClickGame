using Assets.Scripts.Manager;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GameManager : Singleton<GameManager>
{
    private int currentLevel = 0;
    public InputController inputController;

    public Dictionary<string, GameObject> currentPlayers = new Dictionary<string, GameObject>();
    public GameObject currentMonster;

    public int treasureCount = 0;
    public int priceGetChar = 10000;
    public void Init()
    {
        GameObject inputModule = Instantiate(Resources.Load<GameObject>("Prefabs/03.Module/InputModule"));
        inputModule.transform.parent = this.transform;
        inputController = inputModule.GetComponent<InputController>();
    }

    public void Start()
    {
        treasureCount = 100000;
        NextPhase();
        SpawnManager.Instance.SpawnChar(1);
    }

    public void GetChar()
    {
        if (treasureCount < priceGetChar) return;

        treasureCount -= priceGetChar;
        SpawnManager.Instance.SpawnChar(Random.Range(1, SpawnManager.Instance.CharCount + 1));
    }

    public void NextPhase()
    {
        if(!(currentLevel >= SpawnManager.Instance.MobCount))
        {
            currentLevel++;
            currentMonster = SpawnManager.Instance.SpawnMonster(currentLevel);
        }
    }
}

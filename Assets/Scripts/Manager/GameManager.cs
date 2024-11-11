using Assets.Scripts.Controller;
using Assets.Scripts.Manager;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    public int currentLevel = 0;
    public InputController inputController;
    public CharController charController;

    public Dictionary<int, GameObject> currentPlayers = new Dictionary<int, GameObject>();
    public GameObject currentMonster;

    public int coinCount = 10000;
    public int priceGetChar = 10000;
    
    public void Init()
    {
        Application.targetFrameRate = 60;
        GameObject inputModule = Instantiate(Resources.Load<GameObject>("Prefabs/03.Module/InputModule"));
        inputModule.transform.parent = this.transform;
        
        inputController = inputModule.GetComponent<InputController>();
        charController = this.gameObject.AddComponent<CharController>();
    }

    public void Start()
    {
        if(!IOManager.Instance.Load())
        {
            NextPhase();
            GetChar();
        }    
        
        SoundManager.Instance.PlayBGM(Defines.SOUNDTYPE.BGM, 0.5f);
    } 

    public GameObject GetChar(int id = -1)
    {
        if (id == -1 && coinCount < priceGetChar) return null;
        GameObject spawned = null;   
        
        if(id == -1)
        {
            spawned = SpawnManager.Instance.SpawnChar(Random.Range(1, SpawnManager.Instance.CharCount + 1));
            if (spawned == null) return null;           
            else UseCoin(priceGetChar);
        }
        else
        {
            spawned = SpawnManager.Instance.SpawnChar(id); // 지정 생성 (저장파일 로드) 관련..
        }

        Character spChar = spawned.GetComponent<Character>();
        currentPlayers.Add(spChar.CapsuleIndex, spawned);
        return spawned;
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

    public bool UseCoin(int val)
    {
        if (coinCount < val) return false;
        coinCount -= val;
        UIManager.Instance.MainUIPanel.UpdateUserTreasueUpdate();
        return true;
    }

    public void GetCoin(int val)
    {
        coinCount += val;
        UIManager.Instance.MainUIPanel.UpdateUserTreasueUpdate();
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}

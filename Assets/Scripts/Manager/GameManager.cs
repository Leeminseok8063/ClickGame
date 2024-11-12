using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    public int currentLevel = 0;
    public InputController inputController;
    public CharController charController;

    public Dictionary<int, GameObject> currentPlayers = new Dictionary<int, GameObject>();
    public GameObject currentMonster;

    public int coinCount = 100000;//¿Á»≠
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
            charController.GetChar();
        }    
        
        SoundManager.Instance.PlayBGM(Defines.SOUNDTYPE.BGM, 0.5f);
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

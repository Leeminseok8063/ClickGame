using UnityEngine;

public class CharController : MonoBehaviour
{
    public Character targetObject;
    private GameManager inst;
    
    float increaseHealthVal     = 2.0f;
    float increaseDelayVal      = 0.01f;
    float increaseDamagehVal    = 0.5f;
    
    int increaseCost = 4000;
    public int getCharCost = 10000;
    public bool beingSetting = false;

    private void Awake()
    {
        inst = GameManager.Instance;
    }

    //타겟 정보를 등록합니다.
    public void SetTargetObject(Character target)
    {
        targetObject = target;
        UIManager.Instance.MainUIPanel.PopUpStatePanel(targetObject);
        beingSetting = true;
    }

    //타겟 정보를 제거 합니다.
    public void EraseTargetObject()
    {
        targetObject = null;
        beingSetting = false;
    }
    
    public float IncreaseHealth()
    {
        if(GameManager.Instance.UseCoin(increaseCost))
        {
            targetObject.maxHealth += increaseHealthVal;
            targetObject.currentHealth = targetObject.maxHealth;
        }
        
        return targetObject.maxHealth;
    }

    public float IncreaseAttackDelay()
    {
        if (GameManager.Instance.UseCoin(increaseCost))
        {
            targetObject.attackDelay -= increaseDelayVal;
        }
        return targetObject.attackDelay;
    }

    public float IncreaseDamage()
    {
        if (GameManager.Instance.UseCoin(increaseCost))
        {
            targetObject.damage += increaseDamagehVal;
        }
        return targetObject.damage;
    }

    public GameObject GetChar(int id = -1) // 캐릭터를 생성합니다.
    {
        if (id == -1 && inst.coinCount < getCharCost) return null;
        GameObject spawned = null;

        if (id == -1)
        {
            spawned = SpawnManager.Instance.SpawnChar(Random.Range(1, SpawnManager.Instance.CharCount + 1));
            if (spawned == null) return null;
            else inst.UseCoin(getCharCost);
        }
        else
        {
            spawned = SpawnManager.Instance.SpawnChar(id); // 지정 생성 (저장파일 로드) 관련..
        }

        Character spChar = spawned.GetComponent<Character>();
        inst.currentPlayers.Add(spChar.CapsuleIndex, spawned);
        return spawned;
    }

    public void ExitChar() // 캐릭터를 제거합니다.
    {
        if (inst.currentPlayers.Count <= 1) return;
        if (targetObject == null) return;

        inst.currentPlayers.Remove(targetObject.CapsuleIndex);
        StartCoroutine(targetObject.Exit());
    }

}

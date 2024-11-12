using Assets.Scripts.Utils;
using System.Collections;
using UnityEngine;

public class Character : Creature
{
    private int id;
    private int capsuleIndex;
    private float localTimer;

    public int CapsuleIndex { get { return capsuleIndex; } set { capsuleIndex = value; } }
    public int ID { get { return id; } set { id = value; } }

    private void Update()
    {
        UpdateMove();
        
        localTimer += Time.deltaTime;
        if(localTimer > attackDelay)
        {
            localTimer = 0;
            StartCoroutine(Attack(true));
        }
    }

    public override void IsSpawned(Vector3 start, Vector3 dest)
    {
        base.init();
        base.IsSpawned(start, dest);
        GameManager.Instance.inputController.MouseClicked += ClickAction;      
    }

    public void ClickAction()
    {
        if (!gameObject.activeSelf) return;
        localTimer = 0f;
        StartCoroutine(Attack());
    }

    private IEnumerator Attack(bool isAutomatic = false)
    {
        if(!isAutomatic)
        {
            GameObject destActor = GameManager.Instance.inputController.currentClickActor;
            if (destActor == null || !destActor.TryGetComponent<Monster>(out Monster temp))
                yield break;
        }
        
        if (behaviorLock) yield break;
        GameObject mob = GameManager.Instance.currentMonster;
        
        if (!mob.activeSelf || !(mob.GetComponent<Monster>().State == Defines.OBJECTSTATE.IDLE)) 
            yield break;
        IDamagable target = mob.GetComponent<IDamagable>();

        if(currentSkillCounter == 0)
        {
            animator.SetTrigger(isSkill);
            currentSkillCounter = maxSkillCounter;
            behaviorLock = true;
            yield return new WaitForSeconds(1f);
            target.TakeDamage(damage * 30);
            behaviorLock = false;
            yield break;
        }

        currentSkillCounter--;
        animator.SetTrigger(isAttack);
        target.TakeDamage(damage);
    }

    public IEnumerator Skill()
    {
        //TODO : 스킬 사용
        yield return null;
    }

    public IEnumerator Exit()
    {
        Vector3 temp = destPos;
        destPos = startPos;
        startPos = temp;
        dist = destPos - startPos;
        state = Defines.OBJECTSTATE.MOVE;
        yield return new WaitForSeconds(2f);
        
        SpawnManager.Instance.Despawn(this.gameObject);
        PositionManager.Instance.ReturnAcess(capsuleIndex);
    }
}

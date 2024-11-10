using Assets.Scripts.Utils;
using System.Collections;
using UnityEngine;

public class Character : Creature
{
    private int positionID;
    private float localTimer;

    private void Update()
    {
        UpdateMove();
        localTimer += Time.deltaTime;
        if(localTimer > attackDelay)
        {
            localTimer = 0;
            StartCoroutine(Attack());
        }
    }

    public override void IsSpawned(Vector3 start, Vector3 dest)
    {
        base.init();
        base.IsSpawned(start, dest);
        GameManager.Instance.inputController.MouseClicked += ClickAction;

        startPos = start;
        destPos = dest;
        dist = destPos - startPos;
        transform.position = startPos;
    }

    public void ClickAction()
    {
        localTimer = 0f;
        StartCoroutine(Attack());
    }

    private IEnumerator Attack()
    {
        if (behaviorLock) yield break;
        GameObject mob = GameManager.Instance.currentMonster;
        
        if (!mob.activeSelf || mob.GetComponent<Monster>().State == Defines.OBJECTSTATE.DEAD) 
            yield break;
        IDamagable target = mob.GetComponent<IDamagable>();

        if(currentSkillCounter == 0)
        {
            animator.SetTrigger(isSkill);
            currentSkillCounter = maxSkillCounter;
            target.TakeDamage(damage * 10);
            behaviorLock = true;
            yield return new WaitForSeconds(0.5f);
            behaviorLock = false;
            yield break;
        }

        currentSkillCounter--;
        animator.SetTrigger(isAttack);
        target.TakeDamage(damage);
    }
}

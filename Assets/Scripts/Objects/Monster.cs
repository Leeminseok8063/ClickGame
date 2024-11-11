using Assets.Scripts.Manager;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : Creature
{
    int currentReward;
    
    private void Update()
    {
        UpdateMove();     
    }

    public override void IsSpawned(Vector3 start, Vector3 dest)
    {
        base.init();
        base.IsSpawned(start, dest);
        currentReward = objectData.reward;
        UIManager.Instance.MainUIPanel.UpdateMobHealthBar(currentHealth / maxHealth);
        UIManager.Instance.MainUIPanel.UpdateMobNameText(objectData.creatureName);

        startPos = start;
        destPos = dest;
        dist = destPos - startPos;
        transform.position = startPos;
    }

    public override void TakeDamage(float damage)
    {
        if(state != Defines.OBJECTSTATE.DEAD)
        {
            base.TakeDamage(damage);
            animator.SetTrigger(isDamaged);
            currentHealth = Mathf.Max(currentHealth - damage, 0f);
            UIManager.Instance.MainUIPanel.UpdateMobHealthBar(currentHealth / maxHealth);
            GameManager.Instance.GetTreasure((int)(currentReward * 0.001));

            SoundManager.Instance.PlaySound(Defines.SOUNDTYPE.DAMAGED, 0.02f);
            SpawnManager.Instance.SpawnEffect(Defines.PARTICLETYPE.BLOOD, bx2d.bounds.center);
            if (currentHealth == 0) StartCoroutine(Dead());
        }      
    }

    private void Attack()
    {
        //TODO : 몬스터 공격기능
    }

    private IEnumerator Dead()
    {
        animator.SetTrigger(isDead);
        state = Defines.OBJECTSTATE.DEAD;
        GameManager.Instance.GetTreasure(currentReward);
        
        yield return new WaitForSeconds(4f);
        SpawnManager.Instance.Despawn(this.gameObject);
        GameManager.Instance.NextPhase();
    }

}

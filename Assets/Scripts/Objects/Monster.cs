using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : Creature
{
    int currentReward;
    Vector2 dist = Vector2.zero;
    Vector2 startPos = Vector2.zero;
    Vector2 destPos = Vector2.zero;

    private void Start()
    {
    }

    private void Update()
    {
        UpdateMove();     
    }

    private void UpdateMove()
    {
        if (transform.position == (Vector3)destPos) return;

        if(dist.magnitude > 0.1f && !(state == Defines.OBJECTSTATE.IDLE))
        {
            transform.Translate(dist.normalized * 3f * Time.deltaTime);
            dist = destPos - (Vector2)transform.position;
            animator.SetBool(isMove, true);
            state = Defines.OBJECTSTATE.MOVE;
        }
        else
        {
            transform.position = destPos;
            animator.SetBool(isMove, false);
            state = Defines.OBJECTSTATE.IDLE;
        }
    }

    public override void IsSpawned()
    {
        base.init();
        base.IsSpawned();
        currentReward = objectData.reward;
        
        startPos = new Vector3(6f, -0.6f);
        destPos = new Vector3(1.5f, -0.6f);
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
            if (currentHealth == 0) StartCoroutine(Dead());
        }      
    }

    private IEnumerator Dead()
    {
        animator.SetTrigger(isDead);
        state = Defines.OBJECTSTATE.DEAD;
        yield return new WaitForSeconds(4f);
        SpawnManager.Instance.DespawnMob(this.gameObject);
    }

}

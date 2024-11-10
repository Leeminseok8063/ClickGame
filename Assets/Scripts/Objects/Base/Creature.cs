using Assets.Scripts.Utils;
using UnityEngine;


public class Creature : MonoBehaviour, ICreature, IDamagable, ISpawnable
{
    protected Defines.OBJECTSTATE state = Defines.OBJECTSTATE.NONE;
    protected Animator animator;
    public CreatureData objectData;
    
    protected float maxHealth;
    protected float currentHealth;
    //========================
    protected float damage;
    protected float attackDelay;
    //========================
    protected int maxSkillCounter;
    protected int currentSkillCounter;
    //========================

    protected int isMove    = Animator.StringToHash("isMove");
    protected int isDead    = Animator.StringToHash("isDead");
    protected int isAttack  = Animator.StringToHash("isAttack");
    protected int isSkill   = Animator.StringToHash("isSkill");
    protected int isDamaged = Animator.StringToHash("isDamaged");
    protected int isMelee   = Animator.StringToHash("Melee");
    protected int isRange   = Animator.StringToHash("Range");
    protected int isMagic   = Animator.StringToHash("Magic");

    protected void init()
    {
        state = Defines.OBJECTSTATE.NONE;
        maxHealth = objectData.health;
        currentHealth = maxHealth;

        damage = objectData.damage;
        attackDelay = objectData.attackDelay;

        maxSkillCounter = objectData.skillCount;
        currentSkillCounter = maxSkillCounter;
        animator = GetComponentInChildren<Animator>();
    }

    public void SetData(CreatureData data)
    {
        objectData = data;
    }

    public virtual void TakeDamage(float damage)
    {
        //NONE
    }
    public virtual void IsSpawned()
    {
        //NONE
    }
}

using Assets.Scripts.Utils;
using UnityEngine;
using static Defines;


public class Creature : MonoBehaviour, ICreature, IDamagable, ISpawnable
{
    protected BoxCollider2D bx2d;
    protected Defines.OBJECTSTATE state = Defines.OBJECTSTATE.NONE;
    protected Animator animator;
    public CreatureData objectData;
    //========================
    protected Vector2 dist = Vector2.zero;
    protected Vector2 startPos = Vector2.zero;
    protected Vector2 destPos = Vector2.zero;
    //========================
    public float maxHealth;
    public float currentHealth;
    //========================
    public float damage;
    public float attackDelay;
    //========================
    public int maxSkillCounter;
    public int currentSkillCounter;
    //========================
    protected bool behaviorLock;

    public Defines.OBJECTSTATE State { get { return state; } }
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
        bx2d = GetComponent<BoxCollider2D>();

        switch(objectData.combatType)
        {
            case Defines.COMBATTYPE.MELEE:
                animator.SetBool(isMelee, true);
                break;
            case Defines.COMBATTYPE.MAGIC:
                animator.SetBool(isMagic, true);
                break;
            case Defines.COMBATTYPE.RANGE:
                animator.SetBool(isRange, true);
                break;

        }
    }

    public void SetData(CreatureData data)
    {
        objectData = data;
    }

    protected void UpdateMove()
    {
        if (transform.position == (Vector3)destPos) return;

        if (dist.magnitude > 0.1f && !(state == Defines.OBJECTSTATE.IDLE))
        {
            transform.Translate(dist.normalized * 3f * Time.deltaTime);
            dist = destPos - (Vector2)transform.position;
            animator.SetBool(isMove, true);
            behaviorLock = true;
            state = Defines.OBJECTSTATE.MOVE;
        }
        else
        {
            transform.position = destPos;
            animator.SetBool(isMove, false);
            behaviorLock = false;
            state = Defines.OBJECTSTATE.IDLE;
        }
    }

    public virtual void TakeDamage(float damage)
    {
        //NONE
    }
    public virtual void IsSpawned(Vector3 start, Vector3 dest)
    {
        state = OBJECTSTATE.NONE;
        //NONE
    }
}

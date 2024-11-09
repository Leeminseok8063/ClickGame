using Assets.Scripts.Utils;
using UnityEngine;


public class Creature : MonoBehaviour, ICreature
{
    public CreatureData objectData;
    float maxHealth;
    float currentHealth;

    float damage;
    float attackDelay;

    int maxSkillCounter;
    int currentSkillCounter;

    protected void init()
    {
        maxHealth = objectData.health;
        currentHealth = maxHealth;

        damage = objectData.damage;
        attackDelay = objectData.attackDelay;

        maxSkillCounter = objectData.skillCount;
        currentSkillCounter = maxSkillCounter;
    }
    
    public void SetData(CreatureData data)
    {
        objectData = data;
    }
}

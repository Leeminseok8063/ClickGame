using UnityEngine;

[CreateAssetMenu(fileName = "SO_CreatureData", menuName = "Datas/SO_CreatureData")]
public class CreatureData : ScriptableObject
{
    [Header("COMMON")]
    public string creatureName;
    public string creatureDesc;
    public float health;
    public float damage; 
    public float attackDelay;
    public int   skillCount;
    
    [Header("ATTACK TYPE")]
    public Defines.COMBATTYPE combatType;
    public Defines.SKILLTYPE  skillType;

    [Header("MONSTER ONLY")]
    public int reward;


}

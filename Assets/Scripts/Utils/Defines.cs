using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Defines : MonoBehaviour
{
    public enum COMBATTYPE
    {
        NONE,
        MELEE,
        RANGE,
        MAGIC,
    }

    public enum SKILLTYPE
    {
        NONE,
        HEAL,
        DAMAGE,
        BUFF,
        DEBUFF,
    }
}

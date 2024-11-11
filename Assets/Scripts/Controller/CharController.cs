using Assets.Scripts.Manager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Controller
{
    public class CharController : MonoBehaviour
    {
        public Character targetObject;
        float increaseHealthVal     = 2.0f;
        float increaseDelayVal      = 0.01f;
        float increaseDamagehVal    = 0.5f;
        int increaseCost = 4000;
        public bool beingSetting = false;

        public void SetTargetObject(Character target)
        {
            targetObject = target;
            UIManager.Instance.MainUIPanel.PopUpStatePanel(targetObject);
            beingSetting = true;
        }

        public void EraseTargetObject()
        {
            targetObject = null;
            beingSetting = false;
        }
        
        public float IncreaseHealth()
        {
            if(GameManager.Instance.UseTreasure(increaseCost))
            {
                targetObject.maxHealth += increaseHealthVal;
                targetObject.currentHealth = targetObject.maxHealth;
            }
            
            return targetObject.maxHealth;
        }

        public float IncreaseAttackDelay()
        {
            if (GameManager.Instance.UseTreasure(increaseCost))
            {
                targetObject.attackDelay -= increaseDelayVal;
            }
            return targetObject.attackDelay;
        }

        public float IncreaseDamage()
        {
            if (GameManager.Instance.UseTreasure(increaseCost))
            {
                targetObject.damage += increaseDamagehVal;
            }
            return targetObject.damage;
        }

        public void ReturnTargetChar()
        {
            if(targetObject)
            {
                GameManager.Instance.ExitChar(targetObject.gameObject);
            }
        }

    }
}

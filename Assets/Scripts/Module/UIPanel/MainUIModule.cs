using Assets.Scripts.Manager;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainUIModule : MonoBehaviour
{
    [Header("몬스터 연동")]
    public Text mobNameText;
    public Slider mobHealthSlider;

    [Header("게임매니저 연동")]
    public Text userTreasureValText;

    [Header("캐릭터 연동")]
    public GameObject statePanel;
    public Text nameText;
    public Text descText;
    public Text healthText;
    public Text attackDelayText;
    public Text attackDamageText;

    public void UpdateUserTreasueUpdate()
    {
        userTreasureValText.text = GameManager.Instance.treasureCount.ToString();
    }

    public void UpdateMobNameText(string name)
    {
        mobNameText.text = name;
    }

    public void UpdateMobHealthBar(float ratio)
    {
        mobHealthSlider.value = ratio;
    }

    public void SpawnCharButton()
    {
        GameManager.Instance.GetChar();
        SoundManager.Instance.PlaySound(Defines.SOUNDTYPE.BTCLICK, 0.8f);
    }

    public void PopUpStatePanel(Character target)
    {
        UIManager.Instance.IsPanel(true);
        statePanel.SetActive(true);
        nameText.text = target.objectData.creatureName;
        descText.text = target.objectData.creatureDesc;
        healthText.text = $"{target.currentHealth}/{target.maxHealth}";
        attackDamageText.text = target.damage.ToString();
        attackDelayText.text = target.attackDelay.ToString();
        SoundManager.Instance.PlaySound(Defines.SOUNDTYPE.BTCLICK, 0.8f);
    }

    public void ExitStatePanel()
    {
        UIManager.Instance.IsPanel(false);
        statePanel.SetActive(false);
        GameManager.Instance.charController.EraseTargetObject();
        SoundManager.Instance.PlaySound(Defines.SOUNDTYPE.BTCLICK, 0.8f);
    }

    public void IncreaseHealthButton()
    {
        Character target = GameManager.Instance.charController.targetObject;
        float maxHealth = GameManager.Instance.charController.IncreaseHealth();
        healthText.text = $"{target.currentHealth}/{maxHealth}";
        SoundManager.Instance.PlaySound(Defines.SOUNDTYPE.BTCLICK, 0.8f);
    }

    public void IncreaseAttackDelayButton()
    {
        attackDelayText.text = GameManager.Instance.charController.IncreaseAttackDelay().ToString();
        SoundManager.Instance.PlaySound(Defines.SOUNDTYPE.BTCLICK, 0.8f);
    }

    public void IncreaseAttackDamageButton()
    {
        attackDamageText.text = GameManager.Instance.charController.IncreaseDamage().ToString();
        SoundManager.Instance.PlaySound(Defines.SOUNDTYPE.BTCLICK, 0.8f);
    }

    public void ExitCharButton()
    {
        GameManager.Instance.charController.ReturnTargetChar();
        SoundManager.Instance.PlaySound(Defines.SOUNDTYPE.BTCLICK, 0.8f);
        ExitStatePanel();
    }
}

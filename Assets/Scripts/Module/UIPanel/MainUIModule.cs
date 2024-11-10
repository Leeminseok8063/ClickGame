using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainUIModule : MonoBehaviour
{
    [Header("���� ����")]
    public Text mobNameText;
    public Slider mobHealthSlider;

    [Header("���ӸŴ��� ����")]
    public Text userTreasureValText;

    [Header("ĳ���� ����")]
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
    }

    public void IncreaseHealthButton()
    {

    }

    public void IncreaseAttackDelayButton()
    {

    }

    public void IncreaseAttackDamageButton()
    {

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainUIModule : MonoBehaviour
{
    public Text mobNameText;
    public Slider mobHealthSlider;

    private void Update()
    {

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
}

using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
public class FloatingHealthBar : MonoBehaviour
{

    public Slider slider;
    public void UpdateHealthBar(float currentValue, float maxValue)
    {
        slider.value = currentValue / maxValue;
    }

    // Update is called once per frame
    void Update()
    {

    }
}

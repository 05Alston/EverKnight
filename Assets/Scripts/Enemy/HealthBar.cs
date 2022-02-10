using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{

    public Transform bar;
    [Header("Use only for bosses(Slider)")]
    public Slider slider;

    public void SetHealth(float health)
    {
        //Resize bar
        if (slider == null)
        {
            bar.localScale = new Vector3(health, 1f);
        }
        if (bar == null)
        {
            slider.value = health;
        }
    }
}

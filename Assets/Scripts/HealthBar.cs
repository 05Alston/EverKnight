using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{

    private Transform bar;
    private void Start()
    {
        //Find object named Bar
        bar = transform.Find("Bar");
    }
    public void SetHealth(float health)
    {
        //Resize bar
        bar.localScale = new Vector3(health, 1f);
    }
}

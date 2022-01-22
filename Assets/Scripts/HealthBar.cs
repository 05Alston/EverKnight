using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{

    public Transform bar;

    public void SetHealth(float health)
    {
        //Resize bar
        bar.localScale = new Vector3(health, 1f);
    }
}

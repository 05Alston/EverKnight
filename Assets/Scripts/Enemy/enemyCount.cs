using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class enemyCount : MonoBehaviour
{
    public TextMeshProUGUI text;
    public bool countReceived=false;
    public static enemyCount instance;
    int count;
    // Start is called before the first frame update
    void Start()
    {
        if(instance == null)
        {
            instance = this;
        }
    }
    public void SetCount(int c)
    {
        if (!countReceived)
        {
            count = c;
            text.text = "Enemies remaining : " + count.ToString();
            countReceived = true;
        }
    }
   public void ChangeCount()
    {
        count--;
        text.text = "Enemies remaining : "+count.ToString();
    }
}

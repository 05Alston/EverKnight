using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EnemyCount : MonoBehaviour
{
    public TextMeshProUGUI text;
    public bool countReceived=false;
    public static EnemyCount instance;
    int maxCount;
    [HideInInspector]
    public int count;
    // Start is called before the first frame update
    void Start()
    {
        if(instance == null)
        {
            instance = this;
        }
        maxCount = GameObject.FindGameObjectsWithTag("Enemy").Length;
        count = maxCount;
        text.text = "Enemies remaining : " + count.ToString() + "/" + maxCount.ToString();
    }
   public void ChangeCount()
    {
        count--;
        text.text = "Enemies remaining : "+count.ToString() + "/" + maxCount.ToString();
    }
}

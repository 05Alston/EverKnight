using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveButton : MonoBehaviour
{
    private GameObject player;
    private GameObject ally;
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        ally = GameObject.FindGameObjectWithTag("Ally");
    }
    public void SaveInfo()
    {
        SaveData.SaveState(player.GetComponent<PlayerHealth>(), player.GetComponent<PlayerAttack>(), player.GetComponent<PlayerMovement>(), ally.GetComponent<AllyAttack>());
    }
}

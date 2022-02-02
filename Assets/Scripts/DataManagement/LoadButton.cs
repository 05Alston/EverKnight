using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadButton : MonoBehaviour
{
    private GameObject player;
    private GameObject ally;
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        ally = GameObject.FindGameObjectWithTag("Ally");
    }
    public void LoadInfo()
    {
        Data data = SaveData.LoadState();
        player.GetComponent<PlayerAttack>().attackDamage = data.attackDamage;
        player.GetComponent<PlayerAttack>().attackRate = data.attackRate;
        player.GetComponent<PlayerHealth>().health = data.currentHealth;
        player.GetComponent<PlayerHealth>().numOfHearts = data.maxHealth;
        player.GetComponent<PlayerMovement>().moveSpeed = data.moveSpeed;
        ally.GetComponent<AllyAttack>().allyAttackRate = data.allyAttackRate;
    }
}

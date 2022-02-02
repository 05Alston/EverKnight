using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Data 
{
    public int area;// TODO: Add logic
    public int level;// TODO: Add logic
    public int currentHealth;
    public int maxHealth;
    public int coins;// TODO: Add logic
    public int attackDamage;
    public float attackRate;
    public float allyAttackRate;
    public float moveSpeed;


    public Data(PlayerHealth playerHealth, PlayerAttack playerAttack, PlayerMovement playerMovement, AllyAttack allyAttack)
    {
        currentHealth = playerHealth.health;
        maxHealth = playerHealth.numOfHearts;
        attackDamage = playerAttack.attackDamage;
        attackRate = playerAttack.attackRate;
        allyAttackRate = allyAttack.allyAttackRate;
        moveSpeed = playerMovement.moveSpeed;
    }
}

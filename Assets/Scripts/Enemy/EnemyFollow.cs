using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollow : MonoBehaviour
{
    public Transform player;
    private Vector2 movement;
    public float moveSpeed=2;
    public float delay;



    void Update()
    {
        //Displacement towards player
        Vector3 direction = player.position - transform.position;
        direction.Normalize();
        movement = direction;
    }
    private void FixedUpdate()
    {
        //Delay timer
        Invoke("moveCharacter", delay);

    }
    void moveCharacter()
    {
        transform.position = Vector2.MoveTowards(transform.position, player.position, moveSpeed * Time.deltaTime);
        delay = 0;
    }
}

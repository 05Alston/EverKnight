using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollow : MonoBehaviour
{
    private Transform player;
    public float moveSpeed=2;
    public float delay;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        //Displacement towards player
        Vector3 direction = player.position - transform.position;
        direction.Normalize();
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

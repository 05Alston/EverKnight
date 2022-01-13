using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollow : MonoBehaviour
{
    public Transform player;
    private Rigidbody2D rb;
    private Vector2 movement;
    private float moveSpeed=10;
    public float delay;

    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 direction = player.position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        rb.rotation = angle;
        direction.Normalize();
        movement = direction;
    }
    private void FixedUpdate()
    {
        Invoke("moveCharacter", delay);
    }
    void moveCharacter()
    {
        rb.MovePosition((Vector2)transform.position+ movement*moveSpeed*Time.deltaTime);
    }
}

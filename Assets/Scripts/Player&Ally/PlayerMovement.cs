using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 2000f;
    public bool touchStart = false;
    public Joystick Joystick;

    //IDK this one, copied from https://pressstart.vip/tutorials/2018/06/22/39/mobile-joystick-in-unity.html

    private void Update()
    {
        if (gameObject.GetComponent<Animator>().GetBool("isDead"))
        {
            return;
        }
        // Vector3 direction = new Vector3(transform.position.x + Joystick.Horizontal, transform.position.y + Joystick.Vertical);
        // MoveCharacter(direction);
        // transform.Translate(transform.right * Joystick.Horizontal * Time.deltaTime * moveSpeed);
        // transform.Translate(transform.forward * Joystick.Vertical * Time.deltaTime * moveSpeed);
        var rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(Joystick.Horizontal * Time.deltaTime * moveSpeed, Joystick.Vertical * Time.deltaTime * moveSpeed);


    }
    void MoveCharacter(Vector2 direction)
    {
        transform.Translate(direction * moveSpeed * Time.deltaTime);
    }
}
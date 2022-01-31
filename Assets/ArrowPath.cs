using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowPath : MonoBehaviour
{
    public float speed = 3f;
    private GameObject target;
    private float targetX;
    private float posX;
    private float dist;
    private float nextX;
    private float baseY;
    private float height;
    public float multiplier;
    // Start is called before the first frame update
    void Start()
    {
       target = GameObject.FindGameObjectWithTag("Enemy");
    }

    // Update is called once per frame
    void Update()
    {
        targetX = target.transform.position.x;
        posX = transform.position.x;
        dist = targetX - posX;
        nextX = Mathf.MoveTowards(transform.position.x, targetX, speed * Time.deltaTime);
        baseY = Mathf.Lerp(transform.position.y, target.transform.position.y, (nextX - posX) / dist);
        height = 2 * (nextX - posX) * (nextX - targetX) / (-multiplier * dist * dist);

        Vector3 movePosition = new Vector3(nextX, baseY + height, transform.position.z);
        transform.rotation = LookAtTarget(movePosition - transform.position);
        transform.position = movePosition;
        if (target.transform.position == transform.position)
        {
            DestroyImmediate(gameObject, true);
            target.GetComponent<EnemyHealth>().TakeDamage(1);
        }
    }
 
    public static Quaternion LookAtTarget(Vector2 rotation)
    {
        return Quaternion.Euler(0, 0, Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg -90);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 20f;
    public int damage = 30;

    private Rigidbody2D rb;
    public GameObject bulletDestroy;


    // Start is called before the first frame update
    void Start()
    {

        rb = GetComponent<Rigidbody2D>();
        rb.velocity = transform.right * speed;

    }

    private void OnTriggerEnter2D(Collider2D hitInfo)
    {
        EnemyDamage enemy = hitInfo.GetComponent<EnemyDamage>();

        if(enemy != null)
        {

            enemy.TakeDamage(damage);

        }

        Instantiate(bulletDestroy, transform.position, transform.rotation);

        Destroy(gameObject);
    }

    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

}

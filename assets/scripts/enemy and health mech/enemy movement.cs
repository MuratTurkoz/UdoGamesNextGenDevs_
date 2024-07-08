using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemymovement : MonoBehaviour
{
    public Rigidbody2D theRigidbody;
    public float movespeed,damage;
    private Transform target;
    private float damageInterval = 3.0f; // 3 saniyede bir hasar
    private float damageTimer = 0f;//timer

    // Start is called before the first frame update
    void Start()
    {
        target = FindObjectOfType<PlayerMovement>().transform;

        movespeed = Random.Range(0.7f, 1.4f);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        theRigidbody.velocity = (target.position - transform.position).normalized * movespeed;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.transform.tag=="Player")
        {
            
            PlayerHealth.instance.TakeDamage(damage);
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.transform.tag == "Player")
        {
            theRigidbody.velocity = Vector2.zero;
            
            damageTimer -= Time.deltaTime;
            if (damageTimer <= 0f)
            {
                PlayerHealth.instance.TakeDamage(damage);
                damageTimer = damageInterval; // Zamanlayıcıyı sıfırla
            }
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.transform.tag == "Player")
        {
            damageTimer = 0f; // Zamanlayıcıyı sıfırla
        }
    }
  
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemymovement : MonoBehaviour
{
    public Rigidbody2D theRigidbody;
    public float movespeed,damage;
    private Transform target;

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
  
}

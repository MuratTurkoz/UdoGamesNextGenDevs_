using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemymovement : MonoBehaviour
{
    public float movespeed;
    public float damage;
    private Transform target;
    private float damageInterval = 3.0f; // 3 saniyede bir hasar
    private float damageTimer = 0f; // Zamanlayıcı
    public float stoppingDistance = 1.5f; // duracağı mesafe

    void Start()
    {
        target = FindObjectOfType<PlayerMovement>().transform;
        movespeed = Random.Range(0.7f, 1.4f);
    }

    void FixedUpdate()
    {
        float step = movespeed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, target.position, step);
    }

    void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.transform.tag == "Player")
        {
            damageTimer -= Time.deltaTime;
            if (damageTimer <= 0f)
            {
                PlayerHealth.instance.TakeDamage(damage);
                damageTimer = damageInterval; // Zamanlayıcıyı sıfırla
            }
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.transform.tag == "Player")
        {
            damageTimer = 0f; // Zamanlayıcıyı sıfırla
        }
    }
}

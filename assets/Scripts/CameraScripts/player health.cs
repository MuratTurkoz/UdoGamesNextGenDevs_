using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public static PlayerHealth instance;

    public float currentHealth, maxHealth;

    private void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
       
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.T))
        {
            TakeDamage(10f);
        }
    }
    public void TakeDamage(float damage )
    {
        Debug.Log("0");
        currentHealth -= damage;
        if (currentHealth <= 0 )
        {
            gameObject.SetActive(false);

        }
    }
}

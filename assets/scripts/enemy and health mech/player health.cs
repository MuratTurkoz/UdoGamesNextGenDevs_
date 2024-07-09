using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public static PlayerHealth instance;

    [SerializeField] private Float currentHealth, maxHealth;

    private void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
       
        currentHealth.Value = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.T))
        {
            TakeDamage(10f);
        }
    }
    public void TakeDamage(float damage)
    {
        if (currentHealth <= 0) return;
        DamageIndicatorManager.Instance.ShowDamage(transform.position, damage, DamageIndicatorType.PlayerIndicator);
        currentHealth.Value -= damage;
        if (currentHealth <= 0 )
        {
            KillPlayer();
        }
    }

    private void KillPlayer()
    {
        gameObject.SetActive(false);
    }
}

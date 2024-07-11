using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageOnTrigger : MonoBehaviour
{
    [SerializeField] private Int _swordDamage;

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.TryGetComponent<IDamageable>(out var damageable))
        {
            damageable.ApplyDamage(_swordDamage);
        }
    }
}

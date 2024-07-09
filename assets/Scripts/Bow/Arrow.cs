using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    public Float damageAmaunt;
    public float arrowSpeed;
    public float borderLength;

    [HideInInspector] public Vector2 firstTransform;

    private void Start() {
       firstTransform = transform.position;
    }

    private void Update() {
         
         Move(Vector2.right);
         
         if(!InBorder())
         {
            // out of bounds
            gameObject.SetActive(false);
         }

         
    }

    private void OnTriggerEnter2D(Collider2D other) {
      if (other.TryGetComponent<IDamageable>(out var damageable))
      {
         damageable.ApplyDamage(damageAmaunt.Value);
         gameObject.SetActive(false);
      }
    }

    private void Move(Vector2 dir)
    {
      transform.Translate(dir * arrowSpeed * Time.deltaTime);
    }


    private bool InBorder()
    {
       return (Mathf.Abs(Vector2.Distance(firstTransform, transform.position)) > borderLength) ? false :  true;
    }



}

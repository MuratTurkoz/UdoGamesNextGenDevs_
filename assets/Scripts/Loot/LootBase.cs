using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public abstract class LootBase : MonoBehaviour
{
    protected bool isCollected;

    private void OnEnable() {
        transform.parent = null;
        isCollected = false;
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Player"))
        {
            if (isCollected) return;

            isCollected = true;

            Sequence seq = DOTween.Sequence();
            transform.SetParent(other.transform);
            Vector3 distantPos = transform.position + (transform.position - other.transform.position.normalized) * 3f;
            seq.Append(transform.DOMove(distantPos, 0.5f));
            seq.Append(transform.DOLocalMove(Vector3.zero, 0.5f));
            seq.OnComplete(() => Collect(other.gameObject));
        }
    }

    private void Collect(GameObject player)
    {
        OnCollect(player);
        gameObject.SetActive(false);
    }

    protected abstract void OnCollect(GameObject player);
}

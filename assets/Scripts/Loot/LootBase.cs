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
            Vector3 distance = transform.position - other.transform.position;
            distance.z = 0;
            Vector3 distantPos = transform.position + distance.normalized * 6f;
            transform.SetParent(other.transform);
            seq.Append(transform.DOMove(distantPos, 0.3f));
            seq.Append(transform.DOLocalMove(Vector3.zero, 0.5f).SetEase(Ease.Flash));
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

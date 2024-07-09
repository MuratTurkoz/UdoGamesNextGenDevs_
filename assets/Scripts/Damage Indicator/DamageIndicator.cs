using UnityEngine;
using TMPro;
using DG.Tweening;

[RequireComponent(typeof(TextMeshPro))]
public class DamageIndicator : MonoBehaviour
{
    private TextMeshPro _damageTMP;
    private Tween _tween;

    private void Awake() 
    {
        _damageTMP = GetComponent<TextMeshPro>();
    }

    public void StopDisplay()
    {
        // Stop the current tween animation if any and reset
        if (_tween != null)
        {
            _tween.Kill();
            _tween = null;
        }
        gameObject.SetActive(false);
        transform.localScale = Vector3.one;
    }

    public void ShowDamage(float damage, Color damageColor)
    {
        _damageTMP.color = damageColor;
        _damageTMP.SetText(damage.ToString());

        transform.position += new Vector3(0, 0.2f, 0);

        gameObject.SetActive(true);

        // Create a scaling and moving animation
        _tween = transform.DOScale(Vector3.one * 1.5f, 0.4f).SetLoops(2, LoopType.Yoyo).OnComplete(() => StopDisplay());

        // Randomize the movement direction slightly to avoid overlapping indicators
        float randomXOffset = Random.Range(-0.7f, 0.7f);
        float randomYOffset = Random.Range(0.5f, 2f);

        transform.DOMove(new Vector3(transform.position.x + randomXOffset, transform.position.y + randomYOffset, transform.position.z), 0.8f);
    }
}

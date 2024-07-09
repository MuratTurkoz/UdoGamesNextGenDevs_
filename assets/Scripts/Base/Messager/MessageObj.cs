using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using TMPro;
using UnityEngine;

namespace IgnuxNex.SpaceConqueror
{
    public class MessageObj : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _messageTMP;
        [SerializeField] private CanvasGroup _canvasGroup;
        private float _startY;
        private float _showTime = 1;
        private Sequence _sequence;

        private void Awake()
        {
            _startY = transform.position.y;    
        }

        public void StopDisplay()
        {
            StopCoroutine(Hide());
            _sequence.Kill(true);
        }

        public void Show(string message, Color color, float showTime)
        {
            StopAllCoroutines();
            gameObject.SetActive(false);
            _messageTMP.SetText(message);
            _messageTMP.color = color;
            transform.position = new Vector3(transform.position.x, _startY, transform.position.z);
            if (_sequence != null)
            {
                _sequence.Kill();
            }
            _canvasGroup.alpha = 1;

            _showTime = showTime;
            gameObject.SetActive(true);
            _sequence = DOTween.Sequence();
            /* _sequence.Append(transform.DOScale(transform.localScale, showTime / 2f).OnComplete(() => _sequence.Join(_canvasGroup.DOFade(0f, _showTime / 2f)))); */
            _sequence.Append(transform.DOScale(transform.localScale, showTime / 2f));
            _sequence.Append(_canvasGroup.DOFade(0f, _showTime / 2f));
            _sequence.Join(transform.DOMoveY(_startY + 150, _showTime / 2f));
            StartCoroutine(Hide());
        }

        public void Show(string message, float showTime)
        {
            StopAllCoroutines();
            gameObject.SetActive(false);
            _messageTMP.SetText(message);
            transform.position = new Vector3(transform.position.x, _startY, transform.position.z);
            if (_sequence != null)
            {
                _sequence.Kill();
            }
            _canvasGroup.alpha = 1;

            _showTime = showTime;
            gameObject.SetActive(true);
            _sequence = DOTween.Sequence();
            _sequence.Append(transform.DOScale(transform.localScale, showTime / 2f).OnComplete(() => _sequence.Join(_canvasGroup.DOFade(0f, _showTime / 2f))));
            _sequence.Append(transform.DOMoveY(_startY + 150, _showTime / 2f));
            StartCoroutine(Hide());
        }
    
        IEnumerator Hide()
        {
            yield return new WaitForSeconds(_showTime);
            gameObject.SetActive(false);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum DamageIndicatorType
{
    PlayerIndicator,
    EnemyIndicator
}

public class DamageIndicatorManager : MonoBehaviour
{
    public static DamageIndicatorManager Instance { get; private set; }
    [SerializeField] private GameObject _messagePF;
    [SerializeField] private int _maxMessageToShow = 5;
    protected List<DamageIndicator> _indicatorObjs;
    protected List<DamageIndicator> _activeIndicatorList;


    private void Awake()
    {
        Instance = this;
        _indicatorObjs = new List<DamageIndicator>();
        for (int i = 0; i < _maxMessageToShow; i++)
        {
            GameObject obj = Instantiate(_messagePF, transform);
            obj.SetActive(false);
            _indicatorObjs.Add(obj.GetComponent<DamageIndicator>());
        }
        _activeIndicatorList = new List<DamageIndicator>();
    }

    [SerializeField] private Color _playerDamageColor = Color.red;
    [SerializeField] private Color _enemyDamageColor = Color.white;

    public void ShowDamage(Vector3 pos, float damage, DamageIndicatorType damageIndicatorType)
    {
        _activeIndicatorList.RemoveAll(x => !x.gameObject.activeSelf);
        DamageIndicator messageObj = _indicatorObjs.Find(x => !x.gameObject.activeSelf);
        if (messageObj == null)
        {
            messageObj = _activeIndicatorList[0];
            _activeIndicatorList.RemoveAt(0);
            messageObj.StopDisplay();
        }

        if (messageObj == null)
            return;

        messageObj.transform.position = pos;
        messageObj.ShowDamage(damage,
        damageIndicatorType == DamageIndicatorType.PlayerIndicator ? _playerDamageColor : _enemyDamageColor);
        _activeIndicatorList.Add(messageObj);
    }
}

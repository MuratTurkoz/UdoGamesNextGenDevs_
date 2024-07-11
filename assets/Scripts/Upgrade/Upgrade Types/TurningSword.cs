using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurningSword : MonoBehaviour
{
    [SerializeField] private GameObject[] _swords;
    [SerializeField] private Int _swordCount;
    [SerializeField] private float _turnSpeed = 5f;
    [SerializeField] private float _radius = 1f; // Radius of the circular arrangement

    private void Awake()
    {
        // Set parent and position
        transform.SetParent(FindObjectOfType<PlayerMovement>().transform);
        transform.localPosition = Vector3.zero;

        // Initialize sword count and setup event listener
        _swordCount.Value = 1;
        _swordCount.OnValueChanged += OnSwordCountUpgrade;
        OnSwordCountUpgrade(_swordCount.Value);
    }

    private void OnDestroy()
    {
        _swordCount.OnValueChanged -= OnSwordCountUpgrade;
    }

    private void Update()
    {
        transform.Rotate(new Vector3(0, 0, _turnSpeed * Time.deltaTime));
    }

    private void OnSwordCountUpgrade(int swordCount)
    {
        for (int i = 0; i < _swords.Length; i++)
        {
            if (i < swordCount)
            {
                _swords[i].SetActive(true);
                PositionSword(_swords[i], i, swordCount);
            }
            else
            {
                _swords[i].SetActive(false);
            }
        }
    }

    private void PositionSword(GameObject sword, int index, int totalSwords)
    {
        float angle = 360f / totalSwords * index;
        float radian = angle * Mathf.Deg2Rad;

        // Set the position of the sword in a circular way
        sword.transform.localPosition = new Vector3(Mathf.Cos(radian) * _radius, Mathf.Sin(radian) * _radius, 0);

        // Set the rotation of the sword to face outward
        sword.transform.localRotation = Quaternion.Euler(0, 0, angle);
    }
}

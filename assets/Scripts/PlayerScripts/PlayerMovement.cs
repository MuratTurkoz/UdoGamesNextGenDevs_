using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Joystick joystick;
    [SerializeField] private Float _playerSpeed;
    [SerializeField] private float _defaultMoveSpeed = 5;
    public float playerSpeed{get{ return _playerSpeed;} set{ _playerSpeed.Value = value;}}
    public float PlayerSpeed{get{ return _playerSpeed;} set{ _playerSpeed.Value = value;}}

    private float horizontal;
    private float vertical;
    private float horizontal2;
    private float vertical2;
    private Vector3 lastPosition;
    public static bool IsTouched;
    [SerializeField] private Transform weaponTransform;
    [SerializeField] private SpriteRenderer characterSprite;

    public float maxX;
    public float maxY;
    public float minX;
    public float minY;

    private void Awake() {
        _playerSpeed.Value = _defaultMoveSpeed;
    }

    void Update()
    {
        if (joystick.Horizontal != 0 || joystick.Vertical != 0){
            horizontal2 = joystick.Horizontal;
            vertical2 = joystick.Vertical;
            Rotation(new Vector2(horizontal2,vertical2));
        }

        if(!IsTouched){
            if (joystick.Horizontal != 0 || joystick.Vertical != 0){
            horizontal = joystick.Horizontal;
            vertical = joystick.Vertical;
            Movement(new Vector2(horizontal,vertical), _playerSpeed);
            }
        }
    }

    /* private void OnCollisionEnter2D(Collision2D other) {
        if (!other.gameObject.CompareTag("Enemy"))
        {
            Vector3 dir = transform.position - other.transform.position;
            GetComponent<Rigidbody2D>().AddForce(dir.normalized * 2f);
        }
    } */

    private void Movement(Vector3 dir, float speed)
    {
        if (dir.x > 0) characterSprite.flipX = false;
        else if (dir.x < 0) characterSprite.flipX = true;

        Vector3 pos = transform.position + dir * speed * Time.deltaTime;
        pos.x = Mathf.Min(pos.x, maxX);
        pos.y = Mathf.Min(pos.y, maxY);
        pos.x = Mathf.Max(pos.x, minX);
        pos.y = Mathf.Max(pos.y, minY);
        
        transform.position = pos;
    }

    private void Rotation(Vector2 dir)
    {
        if (dir != Vector2.zero)
        {
            float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
            weaponTransform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
        }
    }

    public bool IsPlayerMoving()
    {
        if (transform.position != lastPosition)
        {
            lastPosition = transform.position;
            return true;
        }
        else
        {
            return false;
        }
    }
}

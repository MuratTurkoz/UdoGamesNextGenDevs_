using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Joystick joystick;
    [SerializeField] private float playerSpeed;
    public float PlayerSpeed{get{ return PlayerSpeed;} set{playerSpeed = value;}}

    private float horizontal;
    private float vertical;
    private float horizontal2;
    private float vertical2;
    private Vector3 lastPosition;
    public static bool IsTouched;
    [SerializeField] private Transform weaponTransform;
    [SerializeField] private SpriteRenderer characterSprite;

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
            Movement(new Vector2(horizontal,vertical),playerSpeed);
            }
        }
    }

    private void Movement(Vector3 dir, float speed)
    {
        if (dir.x > 0) characterSprite.flipX = false;
        else if (dir.x < 0) characterSprite.flipX = true;
        
        transform.position = transform.position + dir * speed * Time.deltaTime;
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

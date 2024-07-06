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

    void Update()
    {
        horizontal = joystick.Horizontal;
        vertical = joystick.Vertical;
        Movement(new Vector2(horizontal,vertical),playerSpeed);
    }

    private void Movement(Vector2 dir, float speed)
    {
        transform.Translate(dir * speed * Time.deltaTime);
    }

    private void Rotation(Vector2 dir)
    {
        // Player's rotation codes 
    }
}

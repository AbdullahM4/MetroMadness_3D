using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoystickMove : MonoBehaviour
{
    public Joystick movementJoyStick;
    public float playerSpeed;
    private Rigidbody rb;

    private void Start()
    {
        rb =GetComponent<Rigidbody>();
    }
    private void FixedUpdate()
    {
        if(movementJoyStick.Direction.y !=0)
        {
            rb.velocity= new Vector2(movementJoyStick.Direction.x * playerSpeed,movementJoyStick.Direction.y * playerSpeed);
        }
        else
        {
            rb.velocity=Vector2.zero;
        }
    }
}

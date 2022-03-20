using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoystickPlayerExample : MonoBehaviour
{
    public float horizontalSpeed;
    public float verticalSpeed;
    public FloatingJoystick floatingJoystick;
    //public Rigidbody rb;
    private float xPos;

    public void FixedUpdate()
    {
        //rb.AddForce(floatingJoystick.Horizontal * Vector3.right * horizontalSpeed * Time.fixedDeltaTime, ForceMode.VelocityChange);
        if(floatingJoystick.Horizontal > 0)
        {
            transform.position += transform.right * horizontalSpeed * Time.deltaTime;
        }

        if(floatingJoystick.Horizontal < 0)
        {
            transform.position -= transform.right * horizontalSpeed * Time.deltaTime;
        }


        MovingForward();
        xPos = Mathf.Clamp((transform.position.x), -3f, 3f);
        transform.position = new Vector3(xPos, transform.position.y, transform.position.z);
    }

    private void Update()
    {
        //MovingForward();
        //xPos = Mathf.Clamp((transform.position.x), -3f, 3f);
        //transform.position = new Vector3(xPos, transform.position.y, transform.position.z);
    }

    private void MovingForward()
    {
        transform.position += transform.forward * verticalSpeed * Time.deltaTime;
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class JoystickPlayerExample : MonoBehaviour
{
    public float horizontalSpeed;
    public float verticalSpeed;
    public FloatingJoystick floatingJoystick;
    //public Rigidbody rb;
    private float xPos;
    private bool onRamp = false;
    private int clickCounter = 0;


    public void FixedUpdate()
    {
        LeftAndRightMovement();

        MovingForward();
        xPos = Mathf.Clamp((transform.position.x), -3f, 3f);
        transform.position = new Vector3(xPos, transform.position.y, transform.position.z);
    }

    private void LeftAndRightMovement()
    {
        if (onRamp == false)
        {
            if (floatingJoystick.Horizontal > 0)
            {
                transform.position += transform.right * horizontalSpeed * Time.deltaTime;
            }

            if (floatingJoystick.Horizontal < 0)
            {
                transform.position -= transform.right * horizontalSpeed * Time.deltaTime;
            }
        }
    }

    private void Update()
    {
        RampMovementAcceleratorEffect();
    }

    private void MovingForward()
    {
        transform.position += transform.forward * verticalSpeed * Time.deltaTime;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "RampRotator")
        {
            onRamp = true;
            gameObject.transform.DORotate(new Vector3(-35, 0, 0), .5f);
            gameObject.transform.DOMove(new Vector3(0, 1.5f, transform.position.z + 2.2f), .5f);
        }

        if(other.gameObject.tag == "RampExit")
        {
            transform.position += transform.forward * 2;
            RampExitJump();
            verticalSpeed = 0f;
        }
    }

    private void RampExitJump()
    {
        var sequence = DOTween.Sequence();

        sequence.Append(
            transform.DOMove(new Vector3(0, 1.3f, transform.position.z + clickCounter * 1.1f), 2));
        sequence.Append(
            transform.DORotate(new Vector3(0, 0, 0), .5f));
        sequence.Append(
            transform.DOMove(new Vector3(0, .2f, transform.position.z + clickCounter * 1.1f), .5f));
    }

    private void RampMovementAcceleratorEffect()
    {
        if(onRamp == true && Input.GetMouseButton(0))
        {
            transform.position += transform.forward * Time.deltaTime * 2f;
            clickCounter++;
        }
    }
}
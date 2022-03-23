using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System;

public class JoystickPlayerExample : MonoBehaviour
{
    public float horizontalSpeed;
    public float verticalSpeed;
    public FloatingJoystick floatingJoystick;
    //public Rigidbody rb;
    private float xPos;
    [SerializeField] private bool onRamp = false;
    private bool isJumping = false;
    private int clickCounter = 0;
    LevelManager levelManager;
    UI ui;

    private void Start()
    {
        levelManager = LevelManager.instance;
        ui = UI.instance;
    }

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
        if (isJumping == false)
        {
            transform.position += transform.forward * verticalSpeed * Time.deltaTime;
        }
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
            isJumping = true;
            transform.position += transform.forward * 2;
            RampExitJump();
        }

        if(other.gameObject.tag == "AdvancerToNextLevel")
        {
            MoveToNextStartPoint();
        }
    }

   private void MoveToNextStartPoint()
   {
       StartCoroutine(MoverToNextStartPoint());
   }
   
   private IEnumerator MoverToNextStartPoint()
   {
       yield return new WaitForSeconds(3);
       ui.winCanvas.SetActive(true);
       StopCoroutine(MoverToNextStartPoint());
   }

    private void RampExitJump()
    {
        var sequence = DOTween.Sequence();

        sequence.Append(
            transform.DOMove(new Vector3(0, 1.3f, transform.position.z + clickCounter * 1.75f), 2));
        sequence.Append(
            transform.DORotate(new Vector3(0, 0, 0), .5f));
        sequence.Append(
            transform.DOMove(new Vector3(0, .2f, transform.position.z + clickCounter * 1.75f), .5f));
    }

    private void RampMovementAcceleratorEffect()
    {
        if(onRamp == true && Input.GetMouseButtonDown(0))
        {
            transform.position += transform.forward * Time.deltaTime * 2f;
            if (clickCounter < 50)
            {
                clickCounter++;
            }
        }
    }
}
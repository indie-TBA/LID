using System.Collections;
using System.Collections.Generic;
using System.Globalization;

using UnityEngine;

public class PlayerMovementTest : MonoBehaviour
{
    //[SerializeField]
    //float fMagnitude;

    //float fX, fY, fZ, fSpeedX, fSpeedZ;

    //void Start()
    //{
    //    fX = gameObject.transform.position.x;
    //    fZ = gameObject.transform.position.z;
    //    fY = gameObject.transform.position.y;

    //}




    //void Update()
    //{
    //    fSpeedX = Input.GetAxis("Horizontal");
    //    fSpeedZ = Input.GetAxis("Vertical");
    //    fX += fSpeedX * fMagnitude * Time.deltaTime;
    //    fZ += fSpeedZ * fMagnitude * Time.deltaTime;
    //    gameObject.transform.position = new Vector3(fX, fY, fZ);
    //}

    Rigidbody rbPlayer;
    [SerializeField]
    float fMaxSpeed = 10.0f;
    [SerializeField]
    float fSpeedMag = 5.0f;
    [SerializeField]
    float fSpeedBoost = 2.0f;
    float fYAngle;
    float fMouseX;
    float fMouseY;
    Vector3 vec3MoveDirection;

    [SerializeField]
    GameObject gobjCamera;

    [SerializeField]
    GameObject gobjPlayerHead;

    Animator _animator;

    void Start()
    {
        rbPlayer = gameObject.GetComponent<Rigidbody>();
        gameObject.transform.position = transform.position;
        _animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        //Player Movement========================================
        //vec3MoveDirection = new Vector3(Mathf.Sin(gameObject.transform.rotation.eulerAngles.y * Mathf.Deg2Rad), 0.0f, Mathf.Cos(gameObject.transform.rotation.eulerAngles.y * Mathf.Deg2Rad)).normalized;
        vec3MoveDirection = new Vector3(Mathf.Sin(gobjCamera.transform.eulerAngles.y * Mathf.Deg2Rad), 0.0f, Mathf.Cos(gobjCamera.transform.eulerAngles.y * Mathf.Deg2Rad)).normalized;
        if (Input.GetKey(KeyCode.W))
        {
            _animator.SetBool("isWalking", true);
            if (Input.GetKey(KeyCode.LeftShift))
            {
                gameObject.transform.position += vec3MoveDirection * fSpeedMag * fSpeedBoost * Time.deltaTime;
            }
            else
            {
                gameObject.transform.position += vec3MoveDirection * fSpeedMag * Time.deltaTime;
            }


        }
        if (Input.GetKeyUp(KeyCode.W))
        {
            _animator.SetBool("isWalking", false);
        }

        fMouseX = Input.GetAxis("Mouse X");
        fMouseY = Input.GetAxis("Mouse Y");
        
        gameObject.transform.localEulerAngles += new Vector3(0.0f, fMouseX, 0.0f);
        gobjPlayerHead.transform.localEulerAngles += new Vector3(gameObject.transform.localEulerAngles.x - fMouseY, 0.0f, 0.0f);
        //gameObject.transform.eulerAngles = new Vector3(gameObject.transform.eulerAngles.x, fCameraYAngle, gameObject.transform.eulerAngles.z);




    }

}

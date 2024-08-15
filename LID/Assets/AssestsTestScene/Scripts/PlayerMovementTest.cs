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
    public float fMaxSpeed = 10.0f;
    public float fSpeedMag = 5.0f;
    public float fSpeedBoost = 2.0f;
    float fYAngle;
    float fMouseX;
    float fMouseY;
    Vector3 vec3MoveDirection;
    public GameObject gobjCamera;



    void Start()
    {
        rbPlayer = gameObject.GetComponent<Rigidbody>();
        gameObject.transform.position = new Vector3(0.0f, 1.0f, 0.0f);
    }

    // Update is called once per frame
    void Update()
    {

        //Player Movement========================================
        vec3MoveDirection = new Vector3(Mathf.Sin(gameObject.transform.rotation.eulerAngles.y * Mathf.Deg2Rad), 0.0f, Mathf.Cos(gameObject.transform.rotation.eulerAngles.y * Mathf.Deg2Rad)).normalized;

        if (Input.GetKey(KeyCode.W))
        {
            if (Input.GetKey(KeyCode.LeftShift))
            {
                gameObject.transform.position += vec3MoveDirection * fSpeedMag * fSpeedBoost * Time.deltaTime;
            }
            else
            {
                gameObject.transform.position += vec3MoveDirection * fSpeedMag * Time.deltaTime;
            }


        }

        fMouseX = Input.GetAxis("Mouse X");
        fMouseY = Input.GetAxis("Mouse Y");
        gameObject.transform.localEulerAngles += new Vector3(-fMouseY, fMouseX, 0.0f);
        //gameObject.transform.eulerAngles = new Vector3(gameObject.transform.eulerAngles.x, fCameraYAngle, gameObject.transform.eulerAngles.z);




    }

}

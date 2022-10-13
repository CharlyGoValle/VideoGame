using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cameras : MonoBehaviour
{
    public Transform MainCamera;
    public Transform target;

    [Header("Camera settings:")]
    Vector3 velocity = Vector3.zero;
    public float smoothTime = 0.15f;
    [Header("Horizontal limits:")]
    public bool XminAct = false;
    public float Xmin = 0f;
    public bool XmaxAct = false;
    public float Xmax = 0f;
    [Header("Vertical limits:")]
    public bool YminAct = false;
    public float Ymin = 0f;
    public bool YmaxAct = false;
    public float Ymax = 0f;
    [Header("Auto-scroll:")]
    public bool Left = false;
    public bool Right = false;
    public bool Up = false;
    public bool Down = false;
    public float speed = 0f;


    public Player script;

    void Update()
    {
        if (script.Energia == 0 || MainCamera.position.y >= 33.5f)
        {
            speed = 0;
        }
    }


    // Update is called once per frame
    void FixedUpdate()
    {
        if (!Left && !Right && !Up && !Down)
        {
            Vector3 cameraPos = target.position;

            if (XmaxAct && XminAct)
                cameraPos.x = Mathf.Clamp(target.position.x, Xmin, Xmax);
            else if (XminAct)
                cameraPos.x = Mathf.Clamp(target.position.x, Xmin, target.position.x);
            else if (XmaxAct)
                cameraPos.x = Mathf.Clamp(target.position.x, target.position.x, Xmax);

            if (YmaxAct && YminAct)
                cameraPos.y = Mathf.Clamp(target.position.y, Ymin, Ymax);
            else if (YminAct)
                cameraPos.y = Mathf.Clamp(target.position.y, Ymin, target.position.y);
            else if (YmaxAct)
                cameraPos.y = Mathf.Clamp(target.position.y, target.position.y, Ymax);

            cameraPos.z = transform.position.z;
            transform.position = Vector3.SmoothDamp(transform.position, cameraPos, ref velocity, smoothTime);
        }
        else
        {
            if (Left)
            {
                XminAct = false;
                transform.Translate(-Vector3.right * Time.deltaTime * speed);
                if (Right)
                {
                    Left = false;
                    Right = false;
                }
            }
            else if (Right)
            {
                XmaxAct = false;
                transform.Translate(Vector3.right * Time.deltaTime * speed);
                if (Left)
                {
                    Left = false;
                    Right = false;
                }
            }

            if (Up)
            {
                YmaxAct = false;
                transform.Translate(Vector3.up * Time.deltaTime * speed);
                if (Down)
                {
                    Up = false;
                    Down = false;
                }
            }
            else if (Down)
            {
                YminAct = false;
                transform.Translate(-Vector3.up * Time.deltaTime * speed);
                if (Up)
                {
                    Up = false;
                    Down = false;
                }
            }
        }
    }
}

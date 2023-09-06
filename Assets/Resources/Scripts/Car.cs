using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car : MonoBehaviour
{
    [SerializeField]
    float MoveSpeed = 10.0f;
    [SerializeField]
    float TurnSpeed = 100.0f;
    protected static float TurnAngle = 0.0f;
    protected static float AngleGap = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Move_Control();
        Rotate();
    }

    void Move_Control()
    {
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(Vector3.forward * Time.deltaTime * MoveSpeed);
            transform.Rotate(Vector3.up * TurnAngle * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(Vector3.back * Time.deltaTime * MoveSpeed);
            transform.Rotate(Vector3.down * TurnAngle * Time.deltaTime);
        }
    }

    void Rotate()
    {
        float prevAngle = TurnAngle;
        if (Input.GetKey(KeyCode.A))
        {
            if (TurnAngle - TurnSpeed * Time.deltaTime <= -60.0f)
            {
                AngleGap = -60.0f + TurnAngle;
                TurnAngle = -60.0f;
            }
            else
                TurnAngle -= TurnSpeed * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.D))
        {
            if (TurnAngle + TurnSpeed * Time.deltaTime >= 60.0f)
            {
                AngleGap = 60.0f - TurnAngle;
                TurnAngle = 60.0f;
            }
            else
                TurnAngle += TurnSpeed * Time.deltaTime;
        }
    }
}
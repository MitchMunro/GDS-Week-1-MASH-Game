using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

public class PlayerBoatController : MonoBehaviour
{
    public Rigidbody2D rb;
    public float BoatSpeed = 5f;
    public float TurnSpeed = 2f;
    private float velocityMagnitude;
    public float h;
    public float v;


    void Awake()
    {
       
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        HandleAcceleration();
        HandleRotation();
    }

    void HandleAcceleration()
    {
        Vector2 speedVector = transform.up * BoatSpeed;

        if (Input.GetKey(KeyCode.UpArrow))
        {
            rb.AddForce(speedVector, ForceMode2D.Force);
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            rb.AddForce(-speedVector, ForceMode2D.Force);
        }
    }

    void HandleRotation()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {

            //transform.Rotate(Vector3.forward * TurnSpeed);
            rb.AddTorque(TurnSpeed);
            rb.velocity = RotateVector2(rb.velocity, TurnSpeed);

        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            //transform.Rotate(Vector3.back * TurnSpeed);
            rb.AddTorque(-TurnSpeed);
            rb.velocity = RotateVector2(rb.velocity, -TurnSpeed);
        }
    }

    Vector2 RotateVector2(Vector2 v, float degrees)
    {
        float sin = Mathf.Sin(degrees * Mathf.Deg2Rad);
        float cos = Mathf.Cos(degrees * Mathf.Deg2Rad);

        float tx = v.x;
        float ty = v.y;
        v.x = (cos * tx) - (sin * ty);
        v.y = (sin * tx) + (cos * ty);
        return v;
    }
}

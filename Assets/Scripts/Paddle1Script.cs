using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle1Script : MonoBehaviour
{
    public int PaddleNumber;
    float speed = 10.0f;
    public Rigidbody rb;
    private float movement;
    void Start()
    {
    
    }
    // Update is called once per frame
    void Update()
    {
        if (PaddleNumber == 1)
        {
            movement = Input.GetAxisRaw("Vertical");
        }
        if (PaddleNumber == 2)
        {
            movement = Input.GetAxisRaw("Horizontal2");
        }
        if (PaddleNumber == 3)
        {
            movement = Input.GetAxisRaw("Vertical2");
        }
        if (PaddleNumber == 4)
        {
            movement = Input.GetAxisRaw("Horizontal");
        }
        rb.velocity = new Vector3(movement * speed, movement * speed, 0);
    }
}

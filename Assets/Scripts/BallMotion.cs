using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMotion : MonoBehaviour
{
    public float ballSpeed = 5f;
    public float speedVariation = 0.5f;
    public float angleVariation = 0.05f;
    public Vector3 currentDirection = Vector3.zero;
    private float minSpeed, maxSpeed;
    private int collisions = 0;
    private void Start()
    {
        minSpeed = ballSpeed * (1 - speedVariation);
        maxSpeed = ballSpeed * (1 + speedVariation);
    }
    void Update()
    {
        Vector3 newPosition = transform.position;
        newPosition += currentDirection * ballSpeed * Time.deltaTime;
        transform.position = newPosition;
    }
    private void OnCollisionEnter(Collision other)
    {
        GameObject obj = other.gameObject;
        Vector3 newDirection = currentDirection;
       
        if (obj.CompareTag("verticalPaddle"))
        {
            newDirection.y = -newDirection.y;
        }
        else if (obj.CompareTag("horizontalPaddle"))
        {
            newDirection.x = -newDirection.x;
        }
        /*else if (obj.CompareTag("cornerPaddle"))
        {
            newDirection.y = -newDirection.x;
            newDirection.x = -newDirection.y;
        }*/
        //until we create the goal area
        else {
            newDirection = -newDirection;
        }
        ballSpeed = Random.Range(minSpeed, maxSpeed);
        //changing rotation formula: https://matthew-brett.github.io/teaching/rotation_2d.html
        if (collisions++ < 1) {
            float changeInRadians = Random.Range(-angleVariation, angleVariation) * Mathf.PI / 180;
            newDirection.x = Mathf.Cos(changeInRadians) * newDirection.x - Mathf.Sin(changeInRadians) * newDirection.y;
            newDirection.y = Mathf.Sin(changeInRadians) * newDirection.x + Mathf.Cos(changeInRadians) * newDirection.y;
            setDirection(newDirection);
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        collisions--;
    }
    public void setDirection(Vector3 newDirection) {
        currentDirection = newDirection.normalized;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMotion : MonoBehaviour
{
    public float ballSpeed = 5f;
    public float speedVariation = 0.5f;
    public float angleVariation = 0.05f;
    private Vector3 currentDirection = Vector3.zero;
    private float minSpeed, maxSpeed;
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
        if (obj.CompareTag("verticalPaddle")) {
            newDirection.y = newDirection.y * -1;
        }
        else if (obj.CompareTag("horizontalPaddle")) {
            newDirection.x = newDirection.x * -1;
        }
        else if (obj.CompareTag("cornerPaddle")) {
            newDirection.y = newDirection.y * -1;
            newDirection.x = newDirection.x * -1;
        }

        ballSpeed = Random.Range(minSpeed, maxSpeed);
        //changing rotation formula: https://matthew-brett.github.io/teaching/rotation_2d.html
        float changeInDegrees = Random.Range(-angleVariation, angleVariation);
        newDirection.x = Mathf.Cos(changeInDegrees * newDirection.x) - Mathf.Sin(changeInDegrees * newDirection.y);
        newDirection.y = Mathf.Sin(changeInDegrees * newDirection.x) - Mathf.Cos(changeInDegrees * newDirection.y);

        setDirection(newDirection);
    }
    public void setDirection(Vector3 newDirection) {
        currentDirection = newDirection.normalized;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMotion : MonoBehaviour
{
    int P1Score = 0;
    int P2Score = 0;

    public float ballSpeed = 5f;
    public float speedVariation = 0.5f;
    public float angleVariation = 0.05f;
    public Vector3 currentDirection = Vector3.zero;
    public BallManager manager;
    private float minSpeed, maxSpeed;
    private int collisions = 0;
    private void Start()
    {
        Debug.Log("ball created");
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
        //until we create the goal area
        else if (obj.CompareTag("P1Goal")) 
        {
            P2Score++;
            Debug.Log(P2Score);
            manager.SpawnBallWrapper(2, Random.Range(2, 3));
            Destroy(gameObject);
            
            
        }
        else if (obj.CompareTag("P2Goal"))
        {
            P1Score++;
            Debug.Log(P1Score);
            manager.SpawnBallWrapper(2, Random.Range(0, 1));
            Destroy(gameObject);
        }
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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallManager : MonoBehaviour
{
    public float startTime = 2f;
    public GameObject ballPrefab;
    public Vector3[] spawnPositions = {Vector3.zero};
    public Vector3[] spawnDirections = {Vector3.up}; //LENGTH MUST BE EQUAL TO SPAWNPOSITIONS
    private GameObject currentBall = null;
    void Start()
    {
        StartCoroutine(SpawnBall(startTime, Random.Range(0, spawnPositions.Length)));
    }
    public IEnumerator SpawnBall(float time, int positionIndex) {
        //Position must be within size of vector array, to avoid out of bounds exception
        yield return (new WaitForSeconds(time));
        GameObject newBall = Instantiate(ballPrefab, spawnPositions[positionIndex], Quaternion.identity);
        newBall.GetComponent<BallMotion>().setDirection(spawnDirections[positionIndex]);
    }
}

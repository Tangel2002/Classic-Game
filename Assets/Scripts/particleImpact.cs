using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class particleImpact : MonoBehaviour
{
    // Start is called before the first frame update

    public Transform ball;
    public GameObject prtcle;
    private Vector3 t;
    private Quaternion rotation;
    //public GameObject paddle;

    private void OnCollisionEnter(Collision collision)
    {
        //Vector3 t;
        if (collision.rigidbody)
        {
            if (collision.rigidbody.transform.position.y == 10)
            {
                rotation = Quaternion.Euler(90.0f, 0.0f, 0.0f);
            }
            if (collision.rigidbody.transform.position.y == -10)
            {
                rotation = Quaternion.Euler(-90.0f, 0.0f, 0.0f);
            }
            if (collision.rigidbody.transform.position.x == 10)
            {
                rotation = Quaternion.Euler(0.0f, 0.0f, -90.0f);
            }
            if (collision.rigidbody.transform.position.x == -10)
            {
                rotation = Quaternion.Euler(0.0f, 0.0f, 90.0f);
            }
        }
        ContactPoint contact = collision.contacts[0];
        
        Vector3 pos = contact.point;
        Instantiate(prtcle, pos, rotation);
    }
}

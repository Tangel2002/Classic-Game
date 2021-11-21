using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class particleImpact : MonoBehaviour
{
    // Start is called before the first frame update

    public Transform ball;
    public GameObject prtcle;
    public AudioSource blip;
    private Vector3 t;
    private Quaternion rotation;
    //public GameObject paddle;

    private void OnCollisionEnter(Collision collision)
    {
        //Vector3 t;
        if (collision.rigidbody != null)
        {
            if (collision.rigidbody.transform.position.y == 10)
            {
                rotation = Quaternion.Euler(90.0f, 0.0f, 0.0f);
                blip.Play();
            }
            if (collision.rigidbody.transform.position.y == -10)
            {
                rotation = Quaternion.Euler(-90.0f, 0.0f, 0.0f);
                blip.Play();
            }
            if (collision.rigidbody.transform.position.x == 10)
            {
                rotation = Quaternion.Euler(0.0f, -90.0f, 0.0f);
                blip.Play();
            }
            if (collision.rigidbody.transform.position.x == -10)
            {
                rotation = Quaternion.Euler(0.0f, 90.0f, 0.0f);
                blip.Play();
            }

            ContactPoint contact = collision.contacts[0];

            Vector3 pos = contact.point;
            Instantiate(prtcle, pos, rotation);
        }
        
    }
}

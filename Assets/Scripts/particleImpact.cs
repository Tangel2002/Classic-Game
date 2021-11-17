using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class particleImpact : MonoBehaviour
{
    // Start is called before the first frame update

    public Transform ball;
    public GameObject prtcle;
    //public GameObject paddle;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        print("collided");
        Vector3 t = new Vector3(-collision.rigidbody.transform.rotation.x, -collision.rigidbody.transform.rotation.y, -collision.rigidbody.transform.rotation.z);
        ContactPoint contact = collision.contacts[0];
        Quaternion rotation = Quaternion.FromToRotation(contact.normal, t);
        Vector3 pos = contact.point;
        Instantiate(prtcle, pos, rotation);
    }
}

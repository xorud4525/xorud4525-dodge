using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 8f;
    private Rigidbody bulletrigidbody;
    void Start()
    {
        bulletrigidbody = GetComponent<Rigidbody>();
        bulletrigidbody.velocity = transform.forward * speed;

        Destroy(gameObject, 3f);
    }
    void OnTriggerEnter(Collider other)
    {
        if(other.tag=="Player")
        {
            playercontroller playercontroller = other.GetComponent<playercontroller>();
        
            if(playercontroller!=null)
            {
                playercontroller.Die();
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

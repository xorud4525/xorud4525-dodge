using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 8f;
    private Rigidbody bulletrigidbody;
    public int damage = 30;
    void Start()
    {
        bulletrigidbody = GetComponent<Rigidbody>();
        bulletrigidbody.velocity = transform.forward * speed;

        Destroy(gameObject, 3f);
    }
    void Update()
    {
        
    }
    void OnTriggerEnter(Collider other)
    {
        if(other.tag=="Player")
        {
            playercontroller playercontroller = other.GetComponent<playercontroller>();
        
            if(playercontroller!=null)
            {
                playercontroller.GetDamage(damage);
                Destroy(gameObject);
                //playercontroller.Die();
            }
        }
    }

    // Update is called once per frame
    
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    int healAmount = 20;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0f, 15 * Time.deltaTime, 0f);
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag=="Player")
        {
            playercontroller playercontroller = other.GetComponent<playercontroller>();

            if(playercontroller!=null)
            {
                playercontroller.GetHeal(healAmount);
            }
        }
        Destroy(gameObject);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fusion;

public abstract class Pickup : NetworkBehaviour
{
    public GameObject particles;
    public string pickUpType;
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.GetComponent<Player>())
        {
            Activate();
            Instantiate(particles, transform.position, transform.rotation);
            gameObject.SetActive(false);
        }
    }
    public abstract void Activate();

   
}

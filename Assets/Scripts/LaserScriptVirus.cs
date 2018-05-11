using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserScriptVirus : MonoBehaviour 
{
    void Start ()
    {
        GetComponent<Rigidbody>().velocity = transform.forward * 20;
    }

    private void OnTriggerEnter(Collider other)
    {
        Destroy(this.gameObject);
    }
}

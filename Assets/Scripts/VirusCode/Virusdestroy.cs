using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Virusdestroy : MonoBehaviour
{
    void OnCollisionEnter(Collision other)
    {
        if (other.transform.tag == "Laser")
        {
            Destroy(this.gameObject); //Zerstört den Virus sobald er getroffen wurde
        }
    }
}

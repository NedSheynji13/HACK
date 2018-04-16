using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootHard : MonoBehaviour
{
    public float speed; // Public Variable die die Fluggeschwindigkeit des Schusses enthält

    void Start()
    {
        GetComponent<Rigidbody>().velocity = transform.forward * speed; //Gibt dem Laser eine Anfangsgeschwindigkeit entlang der lokalen Z-Achse mit.
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Wall")
        {
            Destroy(this.gameObject); //Zerstört den Schuss sobald er mit einer Wand oder einem Laser kollidiert
        }
        else
        {
            GetComponent<Rigidbody>().velocity = transform.forward * speed;
        }
    }
    
}

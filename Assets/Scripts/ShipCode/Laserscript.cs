using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laserscript : MonoBehaviour
{

    public float speed; // Public Variable die die Fluggeschwindigkeit des Lasers enthält

    void Start()
    {
        GetComponent<Rigidbody>().velocity = transform.forward * speed; //Gibt dem Laser eine Anfangsgeschwindigkeit entlang der lokalen Z-Achse mit.
    }

    void OnCollisionEnter(Collision other) 
    {
        if (other.transform.tag == "Wall" || other.transform.tag == "Projectile" || other.transform.tag == "Virus")
        {
            Destroy(this.gameObject); //Zerstört den Laser sobald er mit einer Wand oder einem stärkeren feindlichen Schuss kollidiert
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Wall" || other.transform.tag == "Projectile" || other.transform.tag == "Virus")
        {
            Destroy(this.gameObject); //Zerstört den Laser sobald er mit einer Wand oder einem stärkeren feindlichen Schuss kollidiert
        }
    }
}

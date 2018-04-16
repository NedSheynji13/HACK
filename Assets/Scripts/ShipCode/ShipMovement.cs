using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ShipMovement : MonoBehaviour
{
    private Rigidbody shipphys; //Private Variable zwecks Speicherung der Rigidbody Kompnente des Schiffes
    public float speed; //Float Variable zur Bestimmung der Bewegungsgeschwindigkeit des Schiffes
    public int scenechange;

    void Start()
    {
        shipphys = GetComponent<Rigidbody>(); //Speichert die Rigidbody Komponente um das Schiff im Spielverlauf bewegen zu können
    }

    void Update()
    {
        shipphys.velocity = new Vector3(Input.GetAxisRaw("Horizontal") * speed, shipphys.velocity.y, Input.GetAxisRaw("Vertical") * speed); //Bei Tastendruck wird dem Schiff eine entsprechende Geschwindigkeit gegeben um sich entlang des virtuellen Koordinatensystems zu bewegen.
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Projectile")
        {
            Destroy(this.gameObject); //Game over, bitches
            LoadByIndex(scenechange);
        }
    }
    public void LoadByIndex (int Scene)
    {
        SceneManager.LoadScene(Scene);
    }
}
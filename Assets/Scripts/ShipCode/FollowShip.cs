using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowShip : MonoBehaviour
{
    public GameObject ship; //public variable mit Referenz zum Schiff des Spielers
    private Vector3 offset; //Speichert die Distanz zwischen Spieler und Kamera für nachträgliche Rechnungen

    void Start()
    {
        offset = transform.position - ship.transform.position; //Errechnet sich den Offset beim Spielstart und speichert diese in offset
        Cursor.lockState = CursorLockMode.Confined; //Sperrt den Mauszeiger in den Bildschirm
        Cursor.visible = false; //Blendet den MausCursor aus
    }

    void Update() //Um sicherzustellen, dass die Kamera nach eventuellen Physikberechnungen nachgestellt wird.
    {
        transform.position = ship.transform.position + offset; //Setzt die Kamera auf die Position des Schiffes addiert mit dem offset
    }
}

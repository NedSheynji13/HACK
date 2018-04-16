using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class ShipShoot : MonoBehaviour
{
    public GameObject laser; //eine Public Variable zum Abspeichern des Laser Prefabs. Wird zum Instanzieren während der Laufzeit verwendet.
    public GameObject sound; //Der Soundeffekt der bei Abfeuern abgespielt wird
    public GameObject cursorCrystal; //Der Cursor um das Zielen zu vereinfachen
    public Transform laserspawn; //eine Public Variable zum Abspeichern des leeren Game Objects "LaserCannon". Wird als Startposition verwendet.
    public float firingspeed = 0.1f;//eine Public Variable zum einstellen der Schüsse pro Zeiteinheit.

    private bool canShoot = true; //ein boolean, verwendet um die Anzahl der Schüsse des Spielers pro Zeiteinheit abzugrenzen.
    private Vector3 targetPosition; //eine Vector 3 Variable wo die aktuelle Position des Mauszeigers gespeichert wird.
    private RaycastHit hit; //ein Raycasthit zwecks Berechnung der aktuellen Mausposition.

    void Update()
    {
        transform.LookAt(targetPosition); //Dreht das Object auf dem dieses Script liegt zu der Position wo der Raycast auftraf.
        if (Input.GetMouseButton(0)) //Feuert sobald die linke Maustaste betätigt wurde.
        {
            if (canShoot)//Fragt ab ob geschossen werden kann um einen Clusterfuck an Lasern im Bildschirm zu verhindern.
            {
                Instantiate(laser, laserspawn.position, laserspawn.rotation); //Instanziert einen Laser aus dem Prefab heraus.
                Instantiate(sound, laserspawn.position, laserspawn.rotation); //Instanziert den Soundeffekt des Lasers
                canShoot = false; //Setzt den Bool auf falsch damit der Spieler nicht sofort erneut schießen kann
                Invoke("ResetShoot", firingspeed); //Wartet erstmal 100ms ab bevor wieder gefeuert wird
            }
        }
    }

    private void FixedUpdate()
    {
        if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit))
        //Schickt pro Frame einen Raycast vom Zentrum der Camera View zur aktuellen Position des Mauszeigers. 
        //Sobald der Strahl auf eine Fläche auftrifft werden die Trefferkoordinaten über hit zurückgegeben.
        {
            targetPosition = hit.point; //Rückgabe des Punktes im Koordinatensystem des Auftreffens des Raycasts.
            targetPosition.y = transform.position.y; //Friert die Y Position ein des Zeigers ein damit der Laser später nicht irgendwohin fliegt.
            cursorCrystal.transform.position = targetPosition; //Stellt den Cursor an die Stelle wo der Mauszeiger sich befindet
        }
    }

    void ResetShoot()
    {
        canShoot = true;
    }
}

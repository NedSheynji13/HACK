using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VirusShoot : MonoBehaviour
{
    public GameObject shoot; //eine Public Variable zum Abspeichern des SoftShoot Prefabs. Wird zum Instanzieren während der Laufzeit verwendet.
    public GameObject hardshoot;//eine Public Variable zum Abspeichern des HardShoot Prefabs. Wird zum Instanzieren während der Laufzeit verwendet.
    public Transform shootspawn; //eine Public Variable zum Abspeichern des leeren Game Objects "VirusCannon". Wird als Startposition verwendet.
    public float firingspeed = 1f;//eine Public Variable zum einstellen der Schüsse pro Zeiteinheit.

    private bool canShoot = true; //ein boolean, verwendet um die Anzahl der Schüsse des Gegners pro Zeiteinheit abzugrenzen.

    void Update()
    {
        transform.LookAt(GameObject.FindGameObjectWithTag("Ship").transform.position); //Dreht das Object auf dem dieses Script liegt zu der Position des Spielers.

        if (canShoot) //Feuert in in firingspeed bestimmten Abständen
        {
            float shoottype = Random.value * 100;
            if (shoottype > 10)
            {
                Instantiate(shoot, shootspawn.position, shootspawn.rotation); //Instanziert einen Laser aus dem Prefab heraus.
                canShoot = false; //Setzt den Bool auf falsch damit der Gegner nicht sofort erneut schießen kann
                Invoke("ResetShoot", firingspeed); //Wartet erstmal 100ms ab bevor wieder gefeuert wird
            }
            else
            {
                Instantiate(hardshoot, shootspawn.position, shootspawn.rotation); //Instanziert einen Laser aus dem Prefab heraus.
                canShoot = false; //Setzt den Bool auf falsch damit der Gegner nicht sofort erneut schießen kann
                Invoke("ResetShoot", firingspeed); //Wartet erstmal 100ms ab bevor wieder gefeuert wird
            }
        }
    }

    void ResetShoot()
    {
        canShoot = true;
    }
}

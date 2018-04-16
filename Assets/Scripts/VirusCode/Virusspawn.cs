using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Virusspawn : MonoBehaviour {

    public GameObject virus; //eine public Variable zum Abspeichern des Virus Prefab
    private Vector3 virusspawn; //eine private Variable zur späteren Bestimmung des Spawnortes
    public Transform shipposition; // eine private Variable zum Abspeichern der Schiffsposition
    private List<float> shipSafeXArea; //eine private Variable zum Abspeichern der Schiffsposition + einen extra Sicherheitsbereich auf X
    private List<float> shipSafeZArea; //eine private Variable zum Abspeichern der Schiffsposition + einen extra Sicherheitsbereich auf Z
    public int safeSpot = 21; //eine public Variable zum Definieren des sicheren Bereichs um das Schiff herum
    private Quaternion virusrotation; //eine private Variable der Vollständigkeit halber
    public int border; //Spawnbereich um die Position der auftauchendenden Gegner einzugrenzen 
    private bool respawn = true; //Spawngrenze um einen Clusterfuck an Gegnern zu Vermeiden
    private bool spawnOK = false; //Berechtigung für einen Spawn, überprüft mit und durch den Spawncheck
    private float spawntimer = 10f; //Ein Spawntimer für das Zeitfenster zwischen den Spawns
    private int Killed = 0; //Eine Anzahl an gespawnten Gegnern welche mit steigender Zahl den Spawntimer nach und nach reduziert

    private void Start()
    {
        shipSafeXArea = new List<float>();
        shipSafeZArea = new List<float>();
    }

    void Update ()
    {
		if (respawn)
        {
            //Speichert die aktuelle Position des Schiffs mit einem Sicherheitsbereich für den Spawncheck
            
            for (int i = 1; i < safeSpot; i++)
            {
                shipSafeXArea.Add(shipposition.position.x + i);
                shipSafeXArea.Add(shipposition.position.x - i);
                shipSafeZArea.Add(shipposition.position.z + i);
                shipSafeZArea.Add(shipposition.position.z - i);
            }

            //Generiert eine Randomposition auf dem Spielfeld wo Gegner spawnen können und überprüft es mit dem Spawncheck
            do
            {
                spawnOK = false;
                //Random Gegner Position
                virusspawn.x = Random.value * border;
                virusspawn.y = 1;
                virusspawn.z = Random.value * border;

                //Spawncheck
                if (!shipSafeXArea.Contains(virusspawn.x) && !shipSafeZArea.Contains(virusspawn.z))
                    spawnOK = true;
            }
            while (!spawnOK);
            Instantiate(virus, virusspawn, virusrotation); //Instanziert einen Gegner an der zufälligen Stelle
            
            //Verzögert weiteres Respawnen
            respawn = false;
            Invoke("Respawntimer", spawntimer);
        }
	}
    void Respawntimer()
    {
        respawn = true; //Setzt den Respawn nach dem Timer wieder auf true um den Weg für einen weiteren Gegnerspawn zu ebnen
        Killed++;
        if (Killed % 10 == 0) //Verkürzt die Spawnzeit jedes Mal nach 10 gespawnten Gegnern
        {
            spawntimer *= 0.9f;
        }
    }
}

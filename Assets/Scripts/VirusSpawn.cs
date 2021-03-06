﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class VirusSpawn : NetworkBehaviour
{
    #region Variables
    public GameObject virus;
    //public List<Transform> sPos;

    //private List<float> xMax, xMin, zMax, zMin;
    private Vector3 spawn;
    private float spawntime = 10;
    private float timer = 0;
    #endregion

    private void Start()
    {
        for (int i = 0; i < 5; i++)
        {
            spawn.x = Random.value * 200;
            spawn.z = Random.value * 200;
            spawn.y = 1;
            NetworkServer.Spawn(Instantiate(virus, spawn, Quaternion.identity));
        }
    }

    void Update()
    {
        //for (int i = 0; i < sPos.Count; i++)
        //{
        //    //Calculate Safe Spot
        //    xMax[i] = sPos[i].position.x + 20;
        //    xMin[i] = sPos[i].position.x - 20;
        //    zMax[i] = sPos[i].position.z + 20;
        //    zMin[i] = sPos[i].position.z - 20;
        //}

        if (timer > spawntime)
        {
            //do
                spawn.x = Random.value * 100;
            //while (spawn.x < xMax && spawn.x > xMin);
            //do
                spawn.z = Random.value * 100;
            //while (spawn.z < zMax && spawn.z > zMin);
            spawn.y = 1;
            NetworkServer.Spawn(Instantiate(virus, spawn, Quaternion.identity));
            //spawntime = (spawntime < 0) ? spawntime -= 0.01f : spawntime = 0;
            timer = 0;
        }
        timer += Time.deltaTime;
    }
}

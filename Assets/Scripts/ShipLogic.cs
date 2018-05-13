using System;
using System.Collections;
using UnityEngine.Networking;
using System.Collections.Generic;
using UnityEngine;

public interface ITarget
{}

public class ShipLogic : NetworkBehaviour, ITarget
{
    #region Variables used for movement
    private Rigidbody physx;
    #endregion

    #region Variables used for shooting
    public GameObject laser, cursor;
    private float timer;
    private GameObject rotCenter;
    private RaycastHit hit;
    #endregion

    void Start()
    {
        respawn();
        physx = GetComponent<Rigidbody>();
        rotCenter = transform.GetChild(0).gameObject;
    }
    void FixedUpdate()
    {
        //Shooting
        if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit))
        {
            rotCenter.transform.LookAt(hit.point);
            cursor.transform.position = hit.point + (Vector3.up * 5);
        }
    }
    private void Update()
    {
        //Movement
        physx.velocity = new Vector3(Input.GetAxisRaw("Horizontal") * 30, physx.velocity.y, Input.GetAxisRaw("Vertical") * 30);

        if (!isLocalPlayer)
            return;
        else
            Camera.main.gameObject.transform.parent = this.transform;

        //Shooting
        timer += Time.deltaTime;
        if (Input.GetMouseButton(0) && timer >= 0.1f)
            CmdShoot();
    }


    [Command]
    private void CmdShoot()
    {
        GameObject laserprefab = Instantiate(laser, rotCenter.transform.position + (Quaternion.Euler(0, rotCenter.transform.rotation.eulerAngles.y, 0) * transform.forward * 10), Quaternion.Euler(0, rotCenter.transform.rotation.eulerAngles.y, 0));
        laserprefab.GetComponent<LaserScript>().Init();
        NetworkServer.Spawn(laserprefab);
        timer = 0;
    }

    private void OnTriggerEnter(Collider other)
    {
        //Game Over Bitches
        if (other.GetComponent<Collider>().isTrigger && other.GetComponent<ITarget>() == null)
            RpcRespawn();
    }

    public void respawn()
    {
        transform.position = new Vector3(100, 0.5f, 100);
        transform.rotation = Quaternion.identity;
    }

    [ClientRpc]
    void RpcRespawn()
    {
        if (isLocalPlayer)
            respawn();
    }
}

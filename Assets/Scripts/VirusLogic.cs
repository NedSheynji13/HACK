using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VirusLogic : MonoBehaviour
{
    #region Variables
    public GameObject laser;
    private float shoot = 0;
    private GameObject rotCenter;
    private Transform target;
    #endregion
	
	void Update ()
    {
        Collider[] cols = Physics.OverlapSphere(transform.position, 200);
        for (int i = 0; i < cols.Length; i++)
        {
            if (cols[i].gameObject.GetComponent<ITarget>() != null)
                target = cols[i].gameObject.transform;
        }
        rotCenter = transform.GetChild(0).gameObject;
        shoot += Time.deltaTime;
        rotCenter.transform.LookAt(target);
        if (shoot >= 1)
            Shoot();
    }

    private void Shoot()
    {
        Instantiate(laser, rotCenter.transform.position + (rotCenter.transform.rotation * transform.forward * 3), rotCenter.transform.rotation);
        shoot = 0;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Collider>().isTrigger)
            Destroy(this.gameObject);
    }
}

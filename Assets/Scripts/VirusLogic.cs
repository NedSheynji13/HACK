using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VirusLogic : MonoBehaviour
{
    #region Variables
    public GameObject laser;
    private bool shoot = false;
    private GameObject rotCenter;
    private Transform target;
    #endregion

    void Start ()
    {
        Collider[] cols = Physics.OverlapSphere(transform.position, 200);
        for (int i = 0; i < cols.Length; i++)
        {
            if (cols[i].gameObject.GetComponent<ITarget>() != null)
                target = cols[i].gameObject.transform;
        }
        rotCenter = transform.GetChild(0).gameObject;
    }
	
	void Update ()
    {
        rotCenter.transform.LookAt(target);
        if (!shoot)
            StartCoroutine(Shoot());
    }

    private IEnumerator Shoot()
    {
        Instantiate(laser, rotCenter.transform.position + (rotCenter.transform.rotation * transform.forward * 3), rotCenter.transform.rotation);
        shoot = true;
        yield return new WaitForSeconds(1f);
        shoot = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Collider>().isTrigger)
            Destroy(this.gameObject);
    }
}

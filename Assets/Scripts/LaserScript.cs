using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserScript : MonoBehaviour
{
    private float timer;

    public void Init()
    {
        GetComponent<Rigidbody>().velocity = transform.forward * 40;
    }
    private void Update()
    {
        timer += Time.deltaTime;
        if (timer > 10)
            Destroy(this.gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        Destroy(this.gameObject);
    }
}

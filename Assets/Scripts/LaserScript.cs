using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserScript : MonoBehaviour, ILaser
{
    private float timer;

    public void Init()
    {
        GetComponent<Rigidbody>().velocity = transform.forward * 50;
    }
    private void Update()
    {
        timer += Time.deltaTime;
        if (timer > 10)
            Destroy(this.gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<ILaser>() == null)
            Destroy(this.gameObject);
    }
}

public interface ILaser { }

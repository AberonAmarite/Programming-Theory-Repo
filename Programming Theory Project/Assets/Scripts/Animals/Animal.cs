using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animal : MonoBehaviour
{
    public GameObject projectile;
    public virtual void LaunchProjectile() {
        if (isActiveAndEnabled) {
            GameObject proj = Instantiate(projectile);
            proj.transform.position = transform.position + new Vector3(0, 2, 0);
            proj.GetComponent<Rigidbody>().AddForce(transform.forward * 2000);
            proj.GetComponent<Rigidbody>().AddTorque(transform.forward * 300);
        }

    }
    protected void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
          
                LaunchProjectile();


        }
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chicken : Animal
{
    public override void LaunchProjectile()
    {
        if (isActiveAndEnabled)
        {
            GameObject proj = Instantiate(projectile);
            proj.transform.position = transform.position + new Vector3(0, 6, 0);
            proj.GetComponent<Rigidbody>().AddForce(transform.forward * 2000);
            proj.GetComponent<Rigidbody>().AddTorque(transform.forward * 300);
        }

    }

}

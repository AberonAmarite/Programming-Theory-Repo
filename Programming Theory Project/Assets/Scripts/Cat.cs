using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cat : Animal
{
    public override void LaunchProjectile()
    {
        GameObject proj = Instantiate(projectile);
        proj.transform.position = transform.position + new Vector3(3, 5, 0);
        proj.GetComponent<Rigidbody>().AddForce(transform.forward * 2000);
        proj.GetComponent<Rigidbody>().AddTorque(transform.forward * 300);
        StartCoroutine(DestroyProjectile(proj));
    }


}

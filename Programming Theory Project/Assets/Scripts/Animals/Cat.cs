using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cat : Animal
{
    public override void LaunchProjectile()
    {
        if (isActiveAndEnabled) {
            Vector3 pos = transform.position + new Vector3(0, 5, 0);
            GameObject proj = Instantiate(projectile, pos, transform.rotation);
            proj.transform.Rotate(100, 0, 0);
            proj.GetComponent<Rigidbody>().AddForce((15 * transform.forward - transform.up) * 500);
        }
    }


}

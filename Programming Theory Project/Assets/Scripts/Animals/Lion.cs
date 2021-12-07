using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lion : Animal
{
    public GameObject player;
    private bool canFire = true;
    private float delayTime = 3;
    public override void LaunchProjectile()
    {
        if (isActiveAndEnabled && canFire)
        {
            SingleProjectile(10, 5, 5);
            SingleProjectile(10, -5, 5);
            SingleProjectile(10, 0, 0);
            SingleProjectile(15, 5, 5);
            SingleProjectile(15, -5, 5);
            SingleProjectile(15, 0, 0);
            canFire = false;
            StartCoroutine(FireDelay());
        }
    }
    void SingleProjectile(float distance, float offsetx, float offsetz) {
        float angleRad = player.transform.eulerAngles.y * Mathf.PI / 180;
        float z = Mathf.Cos(angleRad);
        float x = Mathf.Sin(angleRad);
        Vector3 pos = transform.position + new Vector3(distance * x +offsetx, 15, distance * z+offsetz);

        GameObject proj = Instantiate(projectile, pos, transform.rotation);
        proj.transform.Rotate(100, 0, 0);
        proj.transform.position = pos;
        proj.GetComponent<Rigidbody>().AddForce((transform.forward - transform.up) * 500);
    }

    IEnumerator FireDelay() {
        yield return new WaitForSeconds(delayTime);
        canFire = true;
    }
}

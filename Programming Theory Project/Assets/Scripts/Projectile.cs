using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public GameObject explosionPrefab;
    private float explosionRadius = 30;
    private float explosionPower = 6000;
    private void OnCollisionEnter(Collision collision)
    {
            GameObject explosion = Instantiate(explosionPrefab, transform.position, explosionPrefab.transform.rotation);
            explosion.GetComponent<ParticleSystem>().Play();
            explosion.GetComponent<Explosion>().DestroyWithDelay();
            Explode();
            Destroy(gameObject);
    }
    private void Explode() {
        Collider[] colliders = Physics.OverlapSphere(transform.position, explosionRadius);
        foreach (Collider hit in colliders)
        {
            GameObject obj = hit.gameObject;
            if (obj.CompareTag("Enemy")) {
                Rigidbody rb = hit.GetComponent<Rigidbody>();

                if (rb != null)
                    rb.AddExplosionForce(explosionPower, transform.position, explosionRadius, 6.0F);

                float distance = (obj.transform.position - transform.position).magnitude;
                obj.GetComponent<Enemy>().hp -= 100 * Mathf.Pow(((explosionRadius - distance) / explosionRadius), 2);
            }
           
        }
    }

}

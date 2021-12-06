using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public GameObject explosionPrefab;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Terrain") {

            GameObject explosion = Instantiate(explosionPrefab, transform.position, explosionPrefab.transform.rotation);
            explosion.GetComponent<ParticleSystem>().Play();
            explosion.GetComponent<Explosion>().DestroyWithDelay();
            Destroy(gameObject);
        }

 
    }

}

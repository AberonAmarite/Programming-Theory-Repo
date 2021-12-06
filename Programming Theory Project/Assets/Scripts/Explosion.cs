using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    public void DestroyWithDelay() { 
        StartCoroutine(DestroyExplosion());
    }
    private IEnumerator DestroyExplosion() { 
    yield return new WaitForSeconds(2);
        Destroy(gameObject);
    }
}

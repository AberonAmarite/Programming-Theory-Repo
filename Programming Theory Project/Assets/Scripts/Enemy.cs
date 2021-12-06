using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private GameObject player;
    Rigidbody rb;
    Vector3 playerPos;
    Animator anim;
    public float hp = 500;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        rb = GetComponent<Rigidbody>();
        
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        playerPos = player.transform.position;
        transform.LookAt(playerPos);
        rb.AddForce(2000*(playerPos - transform.position).normalized);
        if(hp < 0) Destroy(gameObject);
    }
  
}

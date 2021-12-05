using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    private float movementSpeed = 1000;
    public float jumpForce = 2000;
    public float timeBeforeNextJump = 1.60f;
    Animator anim;
    Rigidbody rb;
    [SerializeField] private float horizontalRotation = 4f;
    public bool inAir = false;
    public GameObject animal;
    public Cat cat;

    void Start()
    {
        anim = animal.GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
    }

    void FixedUpdate()
    {
        ControlPlayer();
    }

    void ControlPlayer()
    {
       
        float moveHorizontal = Input.GetAxisRaw("Horizontal");

        if (moveHorizontal != 0)
        {
            rb.freezeRotation = false;
            if (moveHorizontal > 0)
            {
               transform.Rotate(0, horizontalRotation, 0);
            }
            else if(moveHorizontal < 0){
                transform.Rotate(0, -horizontalRotation, 0);
            }
            anim.SetInteger("Walk", 1);
            rb.freezeRotation = true;
        }
        else {
            anim.SetInteger("Walk", 0);
        }
        if (!inAir)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                inAir = true;
                rb.freezeRotation = false;
                rb.AddForce(0, jumpForce, 0);
                anim.SetTrigger("jump");
                rb.freezeRotation = true;
            }
            if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))
            {
                inAir = true;
                rb.freezeRotation = false;
                rb.AddRelativeForce(0, movementSpeed / 2, movementSpeed);
                anim.SetTrigger("jump");
                rb.freezeRotation = true;
             
            }
            else if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))
            {
                inAir = true;
                rb.freezeRotation = false;
                rb.AddRelativeForce(0, movementSpeed / 2, -movementSpeed);
                anim.SetTrigger("jump");
                rb.freezeRotation = true;
              
            }
        }
        if (Input.GetKeyDown(KeyCode.LeftControl)) {
            cat.LaunchProjectile();
        }

    }

    private void OnCollisionStay (Collision collision)
    {
        inAir = false;
    }

}

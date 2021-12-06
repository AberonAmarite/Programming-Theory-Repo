using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    private float movementSpeed = 1000;
    public float jumpForce = 4000;
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
                LimitVelocity3D();

            }
            else if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))
            {
                inAir = true;
                rb.freezeRotation = false;
                rb.AddRelativeForce(0, movementSpeed / 2, -movementSpeed );
                anim.SetTrigger("jump");
                rb.freezeRotation = true;
                LimitVelocity3D();
            }
        }
        if (Input.GetKeyDown(KeyCode.LeftControl)) {
            cat.LaunchProjectile();
        }
        if (transform.position.x > 500 || transform.position.x < 0 || transform.position.z > 500 || transform.position.z < 0) {
            transform.position = new Vector3(250, 10, 250);
            rb.velocity = Vector3.zero;
        }
       
    }
 
    void LimitVelocity3D() {
        if (rb.velocity.x > 5)
        {
            rb.velocity = new Vector3(5, rb.velocity.y, rb.velocity.z);
        }
        else if (rb.velocity.x < -5)
        {
            rb.velocity = new Vector3(-5, rb.velocity.y, rb.velocity.z);
        }
        if (rb.velocity.y > 5)
        {
            rb.velocity = new Vector3(rb.velocity.x, 5, rb.velocity.z);
        }
        else if (rb.velocity.y < -5) {
            rb.velocity = new Vector3(rb.velocity.x, -5, rb.velocity.z);
        }
        if (rb.velocity.z > 5)
        {
            rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y, 5);
        }
        else if (rb.velocity.z < -5)
        {
            rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y, -5);
        }
    }

    private void OnCollisionStay (Collision collision)
    {
        if(collision.gameObject.name == "Terrain") inAir = false;
        if (collision.gameObject.CompareTag("Enemy") ){
            Vector3 lookDirection = (transform.position - collision.transform.position).normalized;
            rb.AddForce(4000 * (new Vector3(lookDirection.x, 0.005f, lookDirection.z)));
            MainManager.Instance.DisplayDamage();
        }
    }
    
}

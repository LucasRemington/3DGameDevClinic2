using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    public float speed;
    public Score_Difficulty score;
    public BoxCollider coll;
    private float gravity = 20.0f;
    private CharacterController controller;
    private Vector3 moveV;
    private float vertVelocity;
    private float jumpForce = 10.0f;
    private bool isDead = false;
    private Animator animator;
    private int lane;
    private float height;
    private static int delay;
    public int outerDelay;



    void Start () {
        controller = GetComponent<CharacterController>();
        lane = 0;
        delay = 0;
        animator = GetComponent<Animator>();
        coll = GetComponent<BoxCollider>();
	}

    void Update() {
        outerDelay = delay;
        if (isDead == true) { 
            return;
        }
        if (Time.time > 2.0f) delay = 1;
        
        if (delay == 1) {
            moveV = Vector3.zero;
            if (controller.isGrounded){
                vertVelocity = -0.5f;
                if (Input.GetButtonDown("Jump"))
                {
                    vertVelocity = jumpForce;
                    animator.SetBool("Jumping", true);
                    Invoke("stopJumping", 0.1f);
                }
            }
            else{
                vertVelocity -= gravity * Time.deltaTime;
            }
            moveV.y = vertVelocity;
            moveV.z = speed;
            controller.Move(moveV * Time.deltaTime);

            if (Input.GetButtonDown("Slide"))
            {
                coll.enabled = false;
                animator.SetBool("Sliding", true);
                Invoke("stopSliding", 1.0f);
            }
            if (Input.GetButtonDown("Left"))
            {
                if(lane > -1)
                {
                    lane--;
				    animator.SetTrigger("ShiftLeft");
                }
            }
            if (Input.GetButtonDown("Right"))
            {
                if (lane < 1)
                {
                    lane++;
				    animator.SetTrigger("ShiftRight");
                }
            }

            Vector3 newposition = transform.position;
            newposition.x = lane;
            transform.position = newposition;
            transform.Rotate(Vector3.up, 0.0f);
            }
    }

    public void SpeedLevel(float modifier)
    {
        speed = 3.0f + (modifier -0.5f);
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.gameObject.tag == "Obstacle")
        {
            animator.SetBool("Death", true);
            Invoke("Death", 2.0f);
        }
    }

    void stopJumping()
    {
        animator.SetBool("Jumping", false);
    }

    void stopSliding()
    {
        animator.SetBool("Sliding", false);
        coll.enabled = true;
    }

    void Death()
    {
        animator.SetBool("Death", false);
        isDead = true;
        score.OnDeath();
    }
}

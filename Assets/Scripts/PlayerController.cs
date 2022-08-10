using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public bool animPlayed = false;
    public Animator anim;
    private bool transition = false;
    public float jumpForce = 5.5f;
    private Rigidbody2D rb;
    public Transform feetPos;
    private bool isGrounded;
    public LayerMask layerGround;
    private Collision colli;
    private float jumpTimeCounter;
    public float jumpTime;
    public bool isJumping;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        colli = GetComponent<Collision>();
    }

    // Update is called once per frame
    void Update()
    {
        if (colli.dead == false)
        {
            if (animPlayed == true && transition == false){
            anim.Play("fox_run");
            transition = true;
            }

            isGrounded = Physics2D.OverlapCircle(feetPos.position,0.1f,layerGround);

        if (Input.GetKeyDown(KeyCode.Space) && transition == true && isGrounded == true){
            anim.Play("fox_jump");
            isJumping = true;
            jumpTimeCounter = jumpTime;
            rb.velocity = Vector2.up * jumpForce;
            }
        }
        else
        {
            anim.Play("fox_dead");
        }

        if (Input.GetKey(KeyCode.Space) && isJumping == true)
        {
            if (jumpTimeCounter > 0)
            {
                rb.velocity = Vector2.up * jumpForce;
                jumpTimeCounter -= Time.deltaTime;
            }
            else{
                isJumping = false;
            }
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            isJumping = false;
        }
    }
}

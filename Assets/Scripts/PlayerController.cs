using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public bool animPlayed = false;
    public Animator anim;
    private bool transition = false;
    public float jumpForce = 5.5f;
    public Rigidbody2D rb;
    public Transform feetPos;
    public bool isGrounded;
    public LayerMask layerGround;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (animPlayed == true && transition == false){
            anim.Play("fox_run");
            transition = true;
        }

        isGrounded = Physics2D.OverlapCircle(feetPos.position,0.1f,layerGround
        );

        if (Input.GetKeyDown(KeyCode.Space) && transition == true && isGrounded == true){
            anim.Play("fox_jump");
            rb.velocity = new Vector2(0, jumpForce);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdMove : MonoBehaviour
{
 
    public float birdSpeed = 6.0f;
    public Rigidbody2D rb;
    public BackgroundScroller bd;
    private void Start() {
        
    }

    void Update()
    {
        rb.velocity = new Vector2 (-(birdSpeed + bd.scrollSpeed), rb.velocity.y);
    }
}

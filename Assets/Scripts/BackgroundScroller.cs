using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScroller : MonoBehaviour
{
    private Rigidbody2D rb;
    public float scrollSpeed = 1.0f; 
    public PlayerController player;
    private float lastUpdate = 0f;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update() {
        if (player.animPlayed == true)
        {
            MoveBackground();
        }
        if (Time.time - lastUpdate > 5.0f && scrollSpeed < 15.0f){
            scrollSpeed += 0.1f;
            lastUpdate = Time.time;
        }
    }
    void MoveBackground()
    {
        rb.velocity = new Vector2(-scrollSpeed,rb.velocity.y);
        if (transform.position.x <= -154.98f)
        {
            transform.position = new Vector3(-37.2f, transform.position.y, 0);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class BackgroundScroller : MonoBehaviour
{
    private Rigidbody2D rb;
    public float scrollSpeed = 1.0f; 
    public PlayerController player;
    private float lastUpdate = 0f;
    public Collision collision;
    public Animator deadmenu;
    public Score scoreboard;
    public TextMeshProUGUI text;
    private float time;
    public AudioSource source;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        source.Play();
    }

    private void Update() {
        time = Time.timeSinceLevelLoad;
        if (player.animPlayed == true)
        {
            MoveBackground();
        }
        if (time - lastUpdate > 2.0f && scrollSpeed < 15.0f){
            scrollSpeed += 0.1f;
            lastUpdate = time;
        }
        if (collision.dead == true)
        {
            DeadMenu();
        }
    }
    void MoveBackground()
    {
        if (collision.dead == false){
            rb.velocity = new Vector2(-scrollSpeed,rb.velocity.y);
        }
        else {
            rb.velocity = new Vector2(0,rb.velocity.y);
        }
        if (transform.position.x <= -154.98f)
        {
            transform.position = new Vector3(-37.2f, transform.position.y, 0);
            ResetObstacle();
        }
    }

    void ResetObstacle()
    {
        transform.GetChild(0).GetChild(3).GetChild(0).localPosition = new Vector3(Random.Range(-3,3),-3.02f,0);
        transform.GetChild(0).GetChild(2).GetChild(0).localPosition = new Vector3(Random.Range(-3,3),-3.02f,0);
        transform.GetChild(0).GetChild(2).GetChild(1).localPosition = new Vector3(0,Random.Range(-1.25f,-1.8f),0);
        transform.GetChild(0).GetChild(1).GetChild(0).localPosition = new Vector3(Random.Range(0.5f,2.5f),-3.02f,0);
        transform.GetChild(0).GetChild(4).GetChild(0).localPosition = new Vector3(Random.Range(-5,5),-3.02f,0);
        transform.GetChild(0).GetChild(5).GetChild(0).localPosition = new Vector3(Random.Range(0.5f,2.5f),-3.02f,0);
        transform.GetChild(0).GetChild(6).GetChild(0).localPosition = new Vector3(Random.Range(0.5f,2.5f),-3.02f,0);
        transform.GetChild(0).GetChild(6).GetChild(1).localPosition = new Vector3(0,Random.Range(-1.25f,-1.8f),0);
    }

    void DeadMenu()
    {
        deadmenu.SetTrigger("show");
        text.SetText("Your score: " + scoreboard.score.ToString());
    }

    public void PlayAgain()
    {
        SceneManager.LoadScene("Main");
        scoreboard.score = 0;
    }
}

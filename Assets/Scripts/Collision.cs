using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Collision : MonoBehaviour
{
    public bool dead = false;
    private void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Obstacle")
        {
            Debug.Log(dead);
            dead = true;
        }
    }
}

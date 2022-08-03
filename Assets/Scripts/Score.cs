using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    private TextMeshProUGUI text;
    public BackgroundScroller bd;
    public int score;
    private float time;

    private void Start() {
        text = GetComponent<TextMeshProUGUI>();
    }

    private void Update(){
        time = Time.timeSinceLevelLoad;
        if (bd.collision.dead == false){
            score = (int)time  * (int)(bd.scrollSpeed/4);
        }
        text.SetText("Score: " + score.ToString());
    }
}

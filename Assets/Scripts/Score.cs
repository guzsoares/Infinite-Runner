using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    public TextMeshProUGUI text;
    public BackgroundScroller bd;

    private void Start() {
        text = GetComponent<TextMeshProUGUI>();
    }

    private void Update(){
        text.SetText("Score: " + ((int)Time.time  * (int)(bd.scrollSpeed/4)).ToString());
    }
}

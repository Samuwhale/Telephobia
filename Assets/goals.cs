using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class goals : MonoBehaviour
{
    public Text scoreboard;
    public int score;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        scoreboard.text = score.ToString();
    }
    private void OnTriggerEnter(Collider other)
    {
        score += 1;
    }
}

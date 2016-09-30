using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScoreGetter : MonoBehaviour {
    public int score = 0;

	// Use this for initialization
	void Start () {
	    
	}
	
	// Update is called once per frame
	void Update () {
        score = GameObject.Find("Player").GetComponent<Player>().score;
        GetComponent<Text>().text = "SCORE: " + score;
	}
}

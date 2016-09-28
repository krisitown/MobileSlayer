using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {
    public float moveSpeed = 3;
    public Sprite highlighted;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        transform.Translate(Vector2.left * moveSpeed * Time.deltaTime);
	}
}

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
        var rotation = transform.rotation;
        transform.rotation = rotation * Quaternion.Euler(0, 0, 3.4f);
        // transform.Translate(Vector2.left * moveSpeed * Time.deltaTime);
        transform.position = new Vector3(transform.position.x - 0.2f, transform.position.y, transform.position.z);
	}
}

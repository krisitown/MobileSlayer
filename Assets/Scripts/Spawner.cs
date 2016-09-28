using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour {
    public Transform angel;
    public Transform devil;
    public int speedIncrement = 120;

    private int spawnRate = 34;
    private int timer = 0;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        timer++;
        System.Random rnd = new System.Random();
        if(timer % spawnRate == 0) //rnd.Next(spawnRate, spawnRate + 20)
        {
            if(rnd.Next(101) <= 65)
            {
                if (rnd.Next(2) == 0)
                {
                    Instantiate(angel, new Vector3(GetPlayerPosition().x + 25, 0, 0), new Quaternion());
                }
                else
                {
                    Instantiate(devil, new Vector3(GetPlayerPosition().x + 25, 0, 0), new Quaternion());
                }
            }
        }

        if(timer % speedIncrement == 0)
        {
            spawnRate--;
            if (spawnRate <= 0) spawnRate = 0; 
        }
	}

    Vector2 GetPlayerPosition()
    {
        return GameObject.Find("Player").transform.position;
    }
}

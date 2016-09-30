using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
    public float range = 4;
    public float dashSpeed = 15;
    public int attackSpeed = 20;
    public float maxRange = 10;
    public float minRange = 4;
    public int score = 0;

    private bool dashing = false;
    private int timer = 0;
    private int attackTimer = 0;
    private string attackType = "";
    private int rangeTimer = 0;
    // Update is called once per frame
    void Update()
    {
        timer++;
        attackTimer++;
        rangeTimer++;

        IndicateRange();

        if (attackTimer >= attackSpeed)
        {
            Collider2D collider = Physics2D.OverlapCircle(transform.position, range);

            if (Input.GetKeyUp(KeyCode.LeftArrow))
            {
                attackType = "Devil";
                Attack(collider);
            }

            if (Input.GetKeyUp(KeyCode.RightArrow))
            {
                attackType = "Angel";
                Attack(collider);
            }
        }

        if (dashing)
        {
            transform.Translate(Vector2.right * dashSpeed * Time.deltaTime);
        }

        Collider2D enemyCollider = Physics2D.OverlapCircle(transform.position, 1f);
        if (enemyCollider != null)
        {
            if(enemyCollider.tag == attackType)
            {
                Debug.Log("enemy hit");
                score += 1;
                Destroy(enemyCollider.gameObject);
                
                if (range <= maxRange) range++;
            }
            else
            {
                Debug.Log("GameOver");
            }

            dashing = false;
        }

        if (rangeTimer % 60 == 0)
        {
            if(range > minRange)
            {
                range -= 0.3f;
            }
        }
    }

    private void Attack(Collider2D collider)
    {
        attackTimer = 0;
        if (collider != null)
        {
            dashing = true;
            timer = 0;
        }
    }

    private void IndicateRange()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, range);
        foreach (var collider in colliders)
        {
            collider.GetComponent<SpriteRenderer>().sprite = collider.GetComponent<Enemy>().highlighted;
        }
    }

}

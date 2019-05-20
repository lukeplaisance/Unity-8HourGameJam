using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    private Rigidbody2D rb;
    public float speed;
    public float health;
    public bool is_defeated = false; 

	// Use this for initialization
	void Start ()
    {
        rb = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        Move(Vector2.left);
	}

    public void Move(Vector2 direction)
    {
        var movement = (direction * speed * Time.deltaTime);
        rb.AddForce(movement, ForceMode2D.Impulse);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Projectile"))
        {
            ModifyHealth(1);
            Destroy(collision.gameObject);
        }
    }

    public void ModifyHealth(float amount)
    {
        health -= amount;
        if(health <= 0)
        {
            Destroy(gameObject);
            is_defeated = true;
        }
    }
}

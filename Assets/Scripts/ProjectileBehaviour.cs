using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ProjectileBehaviour : MonoBehaviour
{
    public Rigidbody2D rb;
    public float projectile_speed;
    public float torque_speed;
    private float timer = 1;

	// Use this for initialization
	void Start ()
    {
        rb = GetComponent<Rigidbody2D>();	
	}

    private void Update()
    {
        ShootProjectile();

        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            DestroyPrefab(timer);
            timer = 2;
        }
    }


    public void ShootProjectile()
    {
        Vector2 movement = (Vector2.right * projectile_speed * Time.deltaTime);
        rb.AddForce(movement, ForceMode2D.Impulse);
        rb.AddTorque(-torque_speed);
    }

    public void DestroyPrefab(float time)
    {
        StartCoroutine(WaitandDo(time));
    }

    private IEnumerator WaitandDo(float time)
    {
        yield return new WaitForSeconds(time);
        Destroy(gameObject);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class PlayerBehaviour : MonoBehaviour
{
    public int health;
    public UnityEvent Response;

    public void ModifyHealth(int amount)
    {
        health -= amount;
        if (health <= 0)
        {
            Response.Invoke();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Enemy"))
        {
            ModifyHealth(1);
            Destroy(collision.gameObject);
        }
    }
}

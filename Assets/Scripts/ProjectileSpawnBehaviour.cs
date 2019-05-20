using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ProjectileSpawnBehaviour : MonoBehaviour
{
    public GameObject projectile_prefab;
    public Transform projectile_spawn_pos;
    public UnityEvent Response;

    private void Update()
    {
        if(Input.GetButtonDown("Space"))
        {
            Response.Invoke();
        }
    }

    public void SpawnProjectile()
    {
        var projectile = Instantiate(projectile_prefab);
        projectile.transform.position = projectile_spawn_pos.position;
    }
}

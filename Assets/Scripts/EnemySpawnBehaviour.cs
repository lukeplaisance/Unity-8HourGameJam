using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnBehaviour : MonoBehaviour
{
    public GameObject enemy_prefab;
    public float timer;
    public int enemy_count;
    public float timer_set;
    
    // Update is called once per frame
    void Update ()
    {
        timer -= Time.deltaTime;
        if(timer <= 0)
        {
            SpawnEnemies(timer);
            enemy_count += 1;
            timer = timer_set;
        }
	}


    public void SpawnEnemies(float time)
    {
        StartCoroutine(SpawnTimer(timer));
    }

    private IEnumerator SpawnTimer(float time)
    {
        yield return new WaitForSeconds(time);
        var enemy = Instantiate(enemy_prefab);
        enemy.transform.position = transform.position;
    }
}

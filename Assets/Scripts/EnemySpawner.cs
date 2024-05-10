using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public float spawningDistance = 100;

    private float nextSpawn = 0;
    private float nextSpawnTime = 5;

    public GameObject enemyPrefab;
    private List<GameObject> enemies = new List<GameObject>();

    private void FixedUpdate()
    {
        if(Time.time > nextSpawn)
        {
            nextSpawn += nextSpawnTime;
            int ang = Random.Range(0, 360);
            float x = spawningDistance * Mathf.Cos(ang);
            float y = spawningDistance * Mathf.Sin(ang);
            Vector2 spawnPos = new Vector2(x, y);
            GameObject g = Instantiate(enemyPrefab, spawnPos, Quaternion.identity);
            Vector2 directionToCenter = Vector2.zero - spawnPos;
            Quaternion rotationToCenter = Quaternion.LookRotation(Vector3.forward, directionToCenter);
            g.transform.rotation = rotationToCenter;
            enemies.Add(g);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public float spawningDistance = 100;
    public float startSpawnTime;

    private float nextSpawn = 0;
    private float nextSpawnTime = 3;
    private bool[] stages = new bool[10];
    private int i = 0;
    private bool ifKraken = true;

    public GameObject[] enemyPrefab;
    //public List<GameObject> enemies = new List<GameObject>();
    private void Awake()
    {
        nextSpawn = startSpawnTime + Time.time;
    }
    private void FixedUpdate()
    {
        if(Time.time > nextSpawn)
        {
            nextSpawn = Time.time + nextSpawnTime;
            SpawnEnemy();
        }
    }

    private void SpawnEnemy()
    {
        GameObject objToSpawn = enemyPrefab[Random.Range(0, enemyPrefab.Length)];

        if (objToSpawn.GetComponent<EnemyMovement>() != null)
        {
            int ang = Random.Range(0, 360);
            float x = spawningDistance * Mathf.Cos(ang);
            float y = spawningDistance * Mathf.Sin(ang);
            Vector2 spawnPos = new Vector2(x, y);
            GameObject g = Instantiate(objToSpawn, spawnPos, Quaternion.identity);
            Vector2 directionToCenter = Vector2.zero - spawnPos;
            Quaternion rotationToCenter = Quaternion.LookRotation(Vector3.forward, directionToCenter);
            Quaternion rotation90Degrees = Quaternion.Euler(0, 0, 90); // Rotate by -90 degrees around the z-axis
            g.transform.rotation = rotationToCenter * rotation90Degrees;
        }
        else
        {
            Instantiate(objToSpawn, transform.position, Quaternion.identity);
        }
    }

    private void Update()
    {
        if (!stages[i] && Points.Score > i*1000+1000)
        {
            i++;
            Faster();
            Debug.Log(i);
        }
    }

    public void Faster()
    {
        nextSpawnTime -= 0.2f;
        GetComponent<Rotation>().IncrsRot();
        if(ifKraken)
        {
            GameObject.FindGameObjectWithTag("Player").GetComponent<Kraken>().SpawnKraken();
        }
        ifKraken = !ifKraken;
    }
}

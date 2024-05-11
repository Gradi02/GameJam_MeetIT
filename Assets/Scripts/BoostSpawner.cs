using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoostSpawner : MonoBehaviour
{
    public float spawningDistance = 1;
    public float startSpawnTime;

    private float nextSpawn = 0;

    public GameObject[] boostPrefab;
    private void Awake()
    {
        nextSpawn = startSpawnTime + Time.time;
    }

    private void FixedUpdate()
    {
        if (Time.time > nextSpawn)
        {
            nextSpawn = Time.time + Random.Range(2, 10);
            int ang = Random.Range(0, 360);
            float x = spawningDistance * Mathf.Cos(ang);
            float y = spawningDistance * Mathf.Sin(ang);
            Vector2 spawnPos = new Vector2(x, y);
            GameObject g = Instantiate(boostPrefab[Random.Range(0, boostPrefab.Length)], spawnPos, Quaternion.identity);
            /*Vector2 directionToCenter = Vector2.zero - spawnPos;
            Quaternion rotationToCenter = Quaternion.LookRotation(Vector3.forward, directionToCenter);
            g.transform.rotation = rotationToCenter;*/
        }
    }
}

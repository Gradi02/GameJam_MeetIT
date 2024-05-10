using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float endDistance = 2;
    public float speed = 3;
    private Transform player;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        speed = Random.Range(1, 2);
    }
    void FixedUpdate()
    {
        if(Vector2.Distance(player.position, transform.position) > endDistance)
        {
            transform.position += transform.up * speed * Time.fixedDeltaTime;
        }
        else if(Vector2.Distance(player.position, transform.position) < 0.2f)
        {
            Destroy(gameObject);
            player.GetComponent<HealthBar>().DecresseHealth();
        }
    }

    public void RemoveFromList()
    {
        player.GetComponent<EnemySpawner>().enemies.Remove(gameObject);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour, IFreeze
{
    public float endDistance = 2;
    public float speed = 3;
    private Transform player;
    private float lastSpeed = 0;
    private float timeToResetFreeze = 0;
    private float freezeTime = 5;
    private bool freezed = false;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        speed = Random.Range(1, 2);
    }
    void FixedUpdate()
    {
        if(Vector2.Distance(player.position, transform.position) > endDistance)
        {
            transform.position += transform.right * speed * Time.fixedDeltaTime;
        }
        else if(Vector2.Distance(player.position, transform.position) < 0.2f)
        {
            Destroy(gameObject);
            player.GetComponent<HealthBar>().DecresseHealth();
        }
    }

    public void FreezeEnemy()
    {
        if (GetComponent<EnemyInfo>().enemy_color == "white")
        {
            lastSpeed = speed;
            speed /= 4;
            timeToResetFreeze = Time.time + freezeTime;
            freezed = true;
        }
    }

    void Update()
    {
        if(Time.time > timeToResetFreeze && freezed)
        {
            freezed = false;
            speed = lastSpeed;
        }
    }
}

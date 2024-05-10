using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoostTowards : MonoBehaviour
{
    public float speed = 3;
    private Transform player;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void FixedUpdate()
    {
        transform.position += transform.up * speed * Time.fixedDeltaTime;

        if (Vector2.Distance(player.position, transform.position) < 0.2f)
            Destroy(gameObject);
    }
}

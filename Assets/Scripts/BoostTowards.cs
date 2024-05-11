using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoostTowards : MonoBehaviour
{
    public float speed = 3;
    private Transform player;
    private PowerUps pwr;
    public string ptype = "hp";
    private Vector3 dir;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        pwr = player.GetComponent<PowerUps>();
        dir = Vector3.zero - transform.position;
    }

    void FixedUpdate()
    {
        transform.position += dir * speed * Time.fixedDeltaTime;

        if (Vector2.Distance(player.position, transform.position) < 0.5f)
        {
            if(ptype == "hp")
            {
                pwr.AddHp();
            }
            else if (ptype == "drate")
            {
                pwr.DoubleBulletRate();
            }
            else if (ptype == "mblt")
            {
                pwr.MoreBullets();
            }
            else if(ptype == "freeze")
            {
                pwr.FreezeMap();
            }
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision != null)
        {
            if (collision.CompareTag("bullet"))
            {            
                Destroy(collision.gameObject);
                Destroy(gameObject);
            }
        }
    }
}

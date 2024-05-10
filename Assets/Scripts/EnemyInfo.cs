using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyInfo : MonoBehaviour
{
    private int hp = 100;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision != null)
        {
            if(collision.CompareTag("bullet"))
            {
                hp -= 40;
                Destroy(collision.gameObject);

                if(hp < 0)
                {
                    GetComponent<EnemyMovement>().RemoveFromList();
                    Destroy(gameObject);
                }
            }
        }
    }
}

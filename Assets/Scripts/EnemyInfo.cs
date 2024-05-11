using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyInfo : MonoBehaviour
{
    [SerializeField] private int hp = 100;
    public string enemy_color;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision != null)
        {
            if(collision.CompareTag("bullet"))
            {
                if (enemy_color == collision.GetComponent<enemyType>().GetEnemyType())
                {
                    hp -= 50;
                    Destroy(collision.gameObject);

                    if (hp < 0)
                    {
                        Destroy(transform.root.gameObject);
                    }
                }
            }
        }
    }
}

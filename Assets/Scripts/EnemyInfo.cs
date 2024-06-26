using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyInfo : MonoBehaviour
{
    [SerializeField] private int hp = 100;
    public string enemy_color;
    public int scoreToGet = 50;
    public GameObject prt;

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
                    //FindObjectOfType<AudioManager>().Play("receive");


                    if (hp < 0)
                    {
                        FindObjectOfType<AudioManager>().Play("enemydeath");
                        if (transform.GetChild(0).GetComponent<ParticleSystem>() != null)
                        {
                            GameObject g = Instantiate(prt, transform.position, Quaternion.identity);
                            Destroy(g, 2);
                        }
                        Points.Score += scoreToGet;
                        Destroy(transform.root.gameObject);
                    }
                }
            }
        }
    }
}

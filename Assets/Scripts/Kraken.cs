using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Kraken : MonoBehaviour
{
    private Vector2[] mackiPos = { 
        new Vector2(-6, -2),
        new Vector2(-7, 0),
        new Vector2(-6, 2),
        new Vector2(6, 2),
        new Vector2(7, 0),
        new Vector2(6, -2)
    };

    public GameObject macka;
    private GameObject[] macki = new GameObject[6];
    private int krakenHealth = 10000;
    
    public Slider krakenHP;
    private float nextShot = 0;
    private float nextShotTime = 5f;
    private bool boss = false;

    public GameObject[] items;

    private void Start()
    {
        krakenHP.gameObject.SetActive(false);
    }

    [ContextMenu("kraken")]
    public void SpawnKraken()
    {
        krakenHP.gameObject.SetActive(true);
        GetComponent<EnemySpawner>().enabled = false;
        FindObjectOfType<AudioManager>().Stop("sound");
        FindObjectOfType<AudioManager>().Play("boss");

        StartCoroutine(spawn());
        krakenHP.maxValue = krakenHealth;
        krakenHP.minValue = 0;
        nextShot = Time.time + nextShotTime;
        boss = true;
    }

    private IEnumerator spawn()
    {
        for (int i = 0; i < 6; i++)
        {
            yield return new WaitForSeconds(1f);
            GameObject k = Instantiate(macka, mackiPos[i], Quaternion.identity);
            macki[i] = k;
            if (i < 3) k.GetComponent<SpriteRenderer>().flipX = true;
            //animacja
        }
    }

    private void Update()
    {
        krakenHP.value = krakenHealth;

        if(Time.time > nextShot && boss)
        {
            if(krakenHealth > 5000)
            {
                nextShot = Time.time + nextShotTime;
                int r = Random.Range(0, 6);
                MackaAtak(r);
            }
            else
            {
                for (int i = 0; i < 2; i++)
                {
                    nextShot = Time.time + nextShotTime;

                    HashSet<int> drawnNumbers = new HashSet<int>();
                    System.Random random = new System.Random();

                    while (drawnNumbers.Count < 3)
                    {
                        drawnNumbers.Add(random.Next(0, 6));
                    }

                    foreach (int number in drawnNumbers)
                    {
                        MackaAtak(number);
                    }
                }
            }
        }

        if(krakenHealth <= 0)
        {
            boss = false;
            foreach(GameObject g in macki)
            {
                Destroy(g);
            }
            GetComponent<EnemySpawner>().enabled = true;
            krakenHP.gameObject.SetActive(false);
            Points.Score += 1000;
            krakenHealth = 10000;
            FindObjectOfType<AudioManager>().Stop("boss");
            FindObjectOfType<AudioManager>().Play("sound");
        }
    }

    private void MackaAtak(int i)
    {
        GameObject g = items[Random.Range(0, items.Length)];
        GameObject g2 = Instantiate(g, mackiPos[i], Quaternion.identity);
    }

    public void Damage()
    {
        krakenHealth -= 50;
    }
}

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

    [ContextMenu("kraken")]
    public void SpawnKraken()
    {
        GetComponent<EnemySpawner>().enabled = false;

        StartCoroutine(spawn());
        krakenHP.maxValue = krakenHealth;
        krakenHP.minValue = 0;
    }

    private IEnumerator spawn()
    {
        for (int i = 0; i < 6; i++)
        {
            yield return new WaitForSeconds(0.3f);
            GameObject k = Instantiate(macka, mackiPos[i], Quaternion.identity);
            macki[i] = k;
            if (i > 2) k.GetComponent<SpriteRenderer>().flipX = true;
            //animacja
        }
    }

    private void Update()
    {
        //krakenHP.value = 
    }
}

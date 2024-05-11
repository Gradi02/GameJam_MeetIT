using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    public GameObject[] serca;
    private int iloscSerc;
    private bool inv = false;
    private SpriteRenderer spr;
    Color c1 = new Color(255, 255, 255, 0.3f);
    Color c2 = new Color(255, 255, 255, 1f);

    void Start()
    {
        iloscSerc = serca.Length;
        spr = GetComponent<SpriteRenderer>();
    }

    public void AddHealth()
    {
        if (iloscSerc < serca.Length)
        {
            iloscSerc++;

            for (int i = 0; i < iloscSerc; i++)
            {
                serca[i].gameObject.SetActive(true);
            }
        }
    }

    public void DecresseHealth()
    {
        if (inv) return;

        if (iloscSerc > 0)
        {
            iloscSerc--;

            for (int i = iloscSerc; i < serca.Length; i++)
            {
                serca[i].gameObject.SetActive(false);
            }
            StartCoroutine(hit());
        }

        if(iloscSerc <= 0)
        {
            GameObject.FindGameObjectWithTag("manager").GetComponent<GameOver>().Gameover();
        }
    }

    private IEnumerator hit()
    {
        Time.timeScale = 0.01f;
        inv = true;
        yield return new WaitForSeconds(0.01f);
        Time.timeScale = 1;
        spr.color = c1;
        yield return new WaitForSeconds(0.5f);
        spr.color = c2;
        yield return new WaitForSeconds(0.5f);
        spr.color = c1;
        yield return new WaitForSeconds(0.5f);
        spr.color = c2;
        yield return new WaitForSeconds(0.5f);
        inv = false;
    }
}

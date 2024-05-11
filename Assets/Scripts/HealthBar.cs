using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class HealthBar : MonoBehaviour
{
    public GameObject[] serca;
    private int iloscSerc;
    private bool inv = false;
    private SpriteRenderer spr;
    Color c1 = new Color(255, 255, 255, 0.3f);
    Color c2 = new Color(255, 255, 255, 1f);
    private ColorAdjustments clr;

    void Start()
    {
        iloscSerc = serca.Length;
        spr = GetComponent<SpriteRenderer>();
    }

    public void AddHealth()
    {
        FindObjectOfType<AudioManager>().Play("heal");
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
            FindObjectOfType<AudioManager>().Play("hit");

            for (int i = iloscSerc; i < serca.Length; i++)
            {
                serca[i].gameObject.SetActive(false);
            }

            if (iloscSerc <= 0)
            {
                GameObject.FindGameObjectWithTag("manager").GetComponent<GameOver>().Gameover();
            }
            else
            {
                StartCoroutine(hit());
            }
        }
    }

    private IEnumerator hit()
    {
        Volume vol = Camera.main.GetComponent<Volume>();
        ColorAdjustments tmp;
        if (vol.profile.TryGet<ColorAdjustments>(out tmp))
        {
            clr = tmp;
        }

        Time.timeScale = 0.01f;
        inv = true;
        clr.active = true;
        yield return new WaitForSeconds(0.01f);
        clr.active = false;
        Time.timeScale = 1;
        spr.color = c1;
        yield return new WaitForSeconds(2f);
        spr.color = c2;
        inv = false;
    }
}

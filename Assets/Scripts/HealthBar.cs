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
        EdgeGlowVolume eg = VolumeManager.instance.stack.GetComponent<EdgeGlowVolume>();
        Time.timeScale = 0.01f;
        inv = true;
        eg.Active = new BoolParameter(true, true);
        yield return new WaitForSeconds(0.01f);
        eg.Active = new BoolParameter(false, true);
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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    public GameObject[] serca;
    private int iloscSerc;

    void Start()
    {
        iloscSerc = serca.Length;
    }

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.K)) 
        {
            iloscSerc--;

            for (int i = iloscSerc; i < serca.Length; i++)
            {
                serca[i].gameObject.SetActive(false);
            }
        }
        if (Input.GetKeyUp(KeyCode.L))
        {
            iloscSerc++;

            for (int i = 0; i < iloscSerc; i++)
            {
                serca[i].gameObject.SetActive(true);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision != null)
        {
            if (collision.CompareTag("enemy"))
            {
                iloscSerc--;

                for (int i = iloscSerc; i < serca.Length; i++)
                {
                    serca[i].gameObject.SetActive(false);
                }
            }
        }
    }
}

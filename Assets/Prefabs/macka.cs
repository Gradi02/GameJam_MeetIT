using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class macka : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision != null)
        {
            if (collision.CompareTag("bullet"))
            {
                GameObject.FindGameObjectWithTag("Player").GetComponent<Kraken>().Damage();
                Destroy(collision.gameObject);
                //FindObjectOfType<AudioManager>().Play("enemydeath");
            }
        }
    }
}

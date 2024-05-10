using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletGoingMiddle : MonoBehaviour
{ 
    private void Start()
    {
        LeanTween.move(this.gameObject, new Vector3(0, 0, 0), 3f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision != null)
        {
            if (collision.CompareTag("bullet"))
            {             
                 Destroy(collision.gameObject);
                 Destroy(gameObject);
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pocisk : MonoBehaviour
{
    [SerializeField]
    public int bulletSpeed;


    private void Start()
    {
        Destroy(gameObject, 1.5f);
    }

    void FixedUpdate()
    {
        transform.position += Time.fixedDeltaTime * bulletSpeed * transform.right;

    }
}

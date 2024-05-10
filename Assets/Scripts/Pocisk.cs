using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pocisk : MonoBehaviour
{
    [SerializeField]
    public int bulletSpeed;

    private void Start()
    {
        Destroy(gameObject, 10);
    }

    void FixedUpdate()
    {
        transform.position += Time.fixedDeltaTime * bulletSpeed * transform.up;
    }
}

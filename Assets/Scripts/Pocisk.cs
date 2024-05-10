using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pocisk : MonoBehaviour
{
    [SerializeField]
    public int bulletSpeed;
    public GameObject statek;
    private Vector3 kierunek;

    private void Start()
    {
        kierunek = statek.transform.position;
    }

    void FixedUpdate()
    {
        transform.position += Time.fixedDeltaTime * bulletSpeed * transform.up;
    }
}

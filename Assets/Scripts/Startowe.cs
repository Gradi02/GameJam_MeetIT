using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Startowe : MonoBehaviour
{
    public GameObject statek;
    private void Start()
    {
        Instantiate(statek, new Vector3(0, 0, 0), Quaternion.identity);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenMoveLine : MonoBehaviour
{
    void Update()
    {
        transform.position += (Vector3.up/3);
    }
}

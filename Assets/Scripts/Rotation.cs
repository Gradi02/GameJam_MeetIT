using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : MonoBehaviour
{
    private float rotateLeft = 0.111f;
    void Update()
    {
        if(Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            Quaternion rotationAmount = Quaternion.Euler(0, 0, rotateLeft);
            this.gameObject.transform.rotation *= rotationAmount;
        }
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            Quaternion rotationAmount = Quaternion.Euler(0, 0, -rotateLeft);
            this.gameObject.transform.rotation *= rotationAmount;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : MonoBehaviour
{
    private float rotate = 4f;

    private void Start()
    {
        Animator animator = GetComponent<Animator>();
    }
    void FixedUpdate()
    {
        if(Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Rotate(0, 0, +rotate);
            animator.SetBool("nazwaParametruBool", true);
        }
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            transform.Rotate(0, 0, -rotate);
        }
    }

    public void IncrsRot()
    {
        rotate += 0.2f;
    }
}

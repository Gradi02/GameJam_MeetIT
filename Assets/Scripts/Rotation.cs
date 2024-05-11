using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : MonoBehaviour
{
    private float rotate = 4f;
    Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }
    void FixedUpdate()
    {
        if(Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Rotate(0, 0, +rotate);
            animator.SetBool("swim", true);
        }
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            transform.Rotate(0, 0, -rotate);
            animator.SetBool("swim", true);
        }
        animator.SetBool("swim", false);
    }

    public void IncrsRot()
    {
        rotate += 0.2f;
    }
}

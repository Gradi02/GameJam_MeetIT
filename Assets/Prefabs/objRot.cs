using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class objRot : MonoBehaviour
{
    float speed = 2;
    void Start()
    {
        speed = Random.Range(1, 4);
        StartCoroutine(anim());
    }

    private IEnumerator anim()
    {
        while (true)
        {
            LeanTween.rotateAround(gameObject, new Vector3(0, 0, 1), 360, speed);
            yield return new WaitForSeconds(speed);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class EnemyRotateAround : MonoBehaviour
{
    public GameObject RotateAnchor;
    public GameObject Enemy;
    void Start()
    {
        Enemy.transform.localScale = new Vector3(0, 0, 0);
        int rotate = Random.Range(0, 360);
        this.gameObject.transform.Rotate(0, 0, +rotate);
        LeanTween.scale(Enemy, new Vector3(3, 3, 3), 0.5f).setEase(LeanTweenType.easeInOutSine);
        LeanTween.rotateAround(RotateAnchor, new Vector3(0, 0, 1), -360f, 10f).setLoopCount(-1);
        StartCoroutine(SpawnAround());
    }

    private IEnumerator SpawnAround()
    {
        int RandomSleep = Random.Range(20, 25);
        yield return new WaitForSeconds(RandomSleep);
        LeanTween.scale(Enemy, new Vector3(0,0,0), 0.5f).setEase(LeanTweenType.easeInOutSine);
        yield return new WaitForSeconds(0.5f);
        Destroy(this);
    }

}

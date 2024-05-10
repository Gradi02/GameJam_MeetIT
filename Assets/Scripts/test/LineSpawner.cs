using System.Collections;
using UnityEngine;

public class LineSpawner : MonoBehaviour
{
    public GameObject Line;
    public GameObject spawnPlace;
    private float newWidth = 10000;

    void Start()
    {
        StartCoroutine(LineGenerator());
    }

    private IEnumerator LineGenerator()
    {
        while (true)
        {
            yield return new WaitForSeconds(1f);
            GameObject newLine = Instantiate(Line, spawnPlace.transform);
            newLine.GetComponent<RectTransform>().sizeDelta = new Vector2(newWidth, newLine.GetComponent<RectTransform>().sizeDelta.y);
        }
    }
}
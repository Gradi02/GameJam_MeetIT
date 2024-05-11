using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class PiratGadaIJara : MonoBehaviour
{
    public GameObject piratSpawner;
    public GameObject banerSpawner;
    public GameObject pirat;
    public GameObject baner;
    public RectTransform canvasRectTransform;

    void Start()
    {

        if (canvasRectTransform == null)
        {
            Debug.LogError("Brak referencji do canvasu!");
            return;
        }

        StartCoroutine(SprawnPirate());

    }

    public IEnumerator SprawnPirate()
    {
        yield return new WaitForSeconds(0.5f);
        Instantiate(pirat, piratSpawner.transform.position, Quaternion.identity, canvasRectTransform);
        Instantiate(baner, banerSpawner.transform.position, Quaternion.identity, canvasRectTransform);
    }
}
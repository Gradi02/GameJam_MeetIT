using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class PiratGadaIJara : MonoBehaviour
{
    public GameObject piratSpawner;
    public GameObject banerSpawner;
    public GameObject pirat;
    public GameObject baner, baner2;
    public RectTransform canvasRectTransform;

    void Start()
    {

        if (canvasRectTransform == null)
        {
            Debug.LogError("Brak referencji do canvasu!");
            return;
        }

        StartCoroutine(SprawnPirate(true));

    }

    public void stcr()
    {
        StartCoroutine(SprawnPirate(false));
    }

    public IEnumerator SprawnPirate(bool one)
    {
        yield return new WaitForSeconds(0.5f);
        Instantiate(pirat, piratSpawner.transform.position, Quaternion.identity, canvasRectTransform);
        Instantiate(one ? baner : baner2, banerSpawner.transform.position, Quaternion.identity, canvasRectTransform);
        FindObjectOfType<AudioManager>().Play(one ? "pirat" : "pirat2");
    }
}
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class PiratGadaIJara : MonoBehaviour
{
    public RectTransform canvasRectTransform;
    public GameObject pirat;
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
        yield return new WaitForSeconds(2f);
        Instantiate(pirat, transform.position, Quaternion.identity, canvasRectTransform);
    }
}
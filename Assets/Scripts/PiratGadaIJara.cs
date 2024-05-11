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
        
        Instantiate(pirat, transform.position, Quaternion.identity, canvasRectTransform);

    }
}
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class RuchPirata : MonoBehaviour
{
    void Start()
    {
        Canvas canvas = FindObjectOfType<Canvas>();

        if (canvas == null)
        {
            Debug.LogError("Nie znaleziono obiektu Canvas na scenie!");
            return;
        }
        RectTransform canvasRectTransform = canvas.GetComponent<RectTransform>();
        if (canvasRectTransform == null)
        {
            Debug.LogError("Brak komponentu RectTransform na obiekcie Canvas!");
            return;
        }
        Vector3 targetPosition = new Vector3(canvasRectTransform.rect.width - 300, transform.position.y, 0f);
        LeanTween.move(gameObject, targetPosition, 1.0f).setEase(LeanTweenType.easeInOutSine);
        Vector3 targetPosition2 = new Vector3(canvasRectTransform.rect.width + 400, transform.position.y, 0f);
        LeanTween.move(gameObject,targetPosition2 ,1.0f).setEase(LeanTweenType.easeInOutSine).setDelay(4f);
    }
}
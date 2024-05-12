using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class RuchBannera : MonoBehaviour
{
    void Start()
    {
        Destroy(gameObject, 20);
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
        Debug.Log(canvasRectTransform.rect.width);
        Vector3 targetPosition = new Vector3(transform.position.x, GameObject.FindGameObjectWithTag("t2").transform.position.y, 0f);
        Vector3 targetPosition2 = new Vector3(transform.position.x, transform.position.y, 0f);
        LeanTween.move(gameObject, targetPosition, 1.0f).setEase(LeanTweenType.easeInOutSine);
        LeanTween.move(gameObject,targetPosition2 ,1.0f).setEase(LeanTweenType.easeInOutSine).setDelay(8f);
    }
}

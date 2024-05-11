using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Points : MonoBehaviour
{
    public static int Score = 0;
    public TextMeshProUGUI scoreTxt;

    private void Awake()
    {
        Score = 0;
    }

    private void Update()
    {
        scoreTxt.text = Score.ToString();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    public GameObject img;
    private ColorAdjustments clr;
    private void Start()
    {
        img.SetActive(false);
    }

    [ContextMenu("t")]
    public void Gameover()
    {
        Volume vol = Camera.main.GetComponent<Volume>();
        ColorAdjustments tmp;
        if (vol.profile.TryGet<ColorAdjustments>(out tmp))
        {
            clr = tmp;
        }
        clr.active = true;
        FindObjectOfType<AudioManager>().Stop("sound");
        FindObjectOfType<AudioManager>().Stop("boss");
        FindObjectOfType<AudioManager>().Play("gameover");
        Time.timeScale = 0;
        img.SetActive(true);
    }
}

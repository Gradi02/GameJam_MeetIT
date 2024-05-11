using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    public Image img;
    private Color fromColor = new Color(0, 0, 0, 0);


    public void Gameover()
    {
        StartCoroutine(fade());
    }

    private IEnumerator fade()
    {
        Color c = fromColor;
        while (c.a < 1)
        {
            yield return new WaitForSeconds(0.1f);
            c.a += 0.05f;
            img.color = c;
        }
    }
}

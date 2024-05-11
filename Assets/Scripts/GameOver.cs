using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    public GameObject img;
    private void Start()
    {
        img.SetActive(false);
    }

    [ContextMenu("t")]
    public void Gameover()
    {
        EdgeGlowVolume eg = VolumeManager.instance.stack.GetComponent<EdgeGlowVolume>();
        eg.Active = new BoolParameter(true, true);
        FindObjectOfType<AudioManager>().Play("gameover");
        StartCoroutine(end());
    }

    private IEnumerator end()
    {
        yield return new WaitForSeconds(2f);
        Time.timeScale = 0;
        img.SetActive(true);
    }
}

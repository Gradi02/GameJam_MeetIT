using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public TextMeshProUGUI name;
    public TextMeshProUGUI start;
    public TextMeshProUGUI exit;
    private bool First = true;
    private bool Second = false;

    private void Start()
    {
        StartCoroutine(ChangeColors());
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
        {
            First = false;
            Second = true;
        }
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
        {
            First = true;
            Second = false;
        }
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Return))
        {
            if (First)
            {
                SceneManager.LoadScene("Gradi");
            }
            if (Second)
            {
                Application.Quit();
            }
        }

        if (First) 
        { 
            start.color = new Color(60 / 255f, 184 / 255f, 207 / 255f);
            exit.color = new Color(255, 255, 255);
        }
        if (Second)
        {
            start.color = new Color(255, 255, 255);
            exit.color = new Color(60 / 255f, 184 / 255f, 207 / 255f);
        }
    }

    public IEnumerator ChangeColors ()
    {
        while (true)
        {
            float i = Random.Range(0.8f, 1.8f);
            yield return new WaitForSeconds(i);
            name.gameObject.SetActive(false);
            i = Random.Range(0.1f, 0.3f);
            yield return new WaitForSeconds(i);
            name.gameObject.SetActive(true);
        }
    }
}

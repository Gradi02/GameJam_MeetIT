using UnityEngine;
using TMPro;

public class TimeGame : MonoBehaviour
{
    public TextMeshProUGUI timeText;
    private float startTime = 0;

    private void Awake()
    {
        startTime = Time.time;
    }
    void FixedUpdate()
    {
        float currentTime = Time.time - startTime;
        int minutes = Mathf.FloorToInt(currentTime / 60);
        int seconds = Mathf.FloorToInt(currentTime % 60);

        // Format the time as a string with leading zeros for single-digit seconds
        string formattedTime = string.Format("{0:00}.{1:00}", minutes, seconds);

        // Update the text UI
        timeText.text = formattedTime;
    }
}
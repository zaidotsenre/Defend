using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{

    Text timerText;
    GameManager gameManager;
    bool running;

    // Start is called before the first frame update
    void Start()
    {
        running = true;
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        gameManager.gameOver.AddListener(StopRunning);
        timerText = GetComponent<Text>();
        InvokeRepeating("UpdateTimer", 1, 1);
    }

    // Update the onscreen timer in the format mm:ss
    private void UpdateTimer()
    {
        if (running)
        {
            int minutes = (int)(Time.timeSinceLevelLoad / 60);
            int seconds = (int)(Time.timeSinceLevelLoad % 60);
            timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
        }
        
    }

    void StopRunning ()
    {
        running = false;
        PlayerPrefs.SetString("Time", timerText.text);
        PlayerPrefs.Save();
    }
}

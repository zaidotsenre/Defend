using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PostGame : MonoBehaviour
{

    [SerializeField] Button playAgainButton;
    [SerializeField] Text timeText;

    // Start is called before the first frame update
    void Start()
    {
        timeText.text = PlayerPrefs.GetString("Time");
        playAgainButton.onClick.AddListener(LoadPlayScene);
    }

    void LoadPlayScene ()
    {
        SceneManager.LoadScene("Play");
    }
}

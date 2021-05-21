using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class GameManager : Singleton<GameManager>
{
    [HideInInspector] public UnityEvent gameOver;

    private void Start()
    {
        gameOver.AddListener(LoadPostGameScene);
    }


    void LoadPostGameScene()
    {
        SceneManager.LoadScene("Post Game");
    }
}
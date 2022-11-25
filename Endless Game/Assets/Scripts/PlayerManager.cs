using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public static bool gameOver;
    [SerializeField] GameObject gameoverPanel;
    void Start()
    {
        gameOver = false;
        Time.timeScale = 1;
    }

    
    void Update()
    {
        if (gameOver)
        {
            Time.timeScale = 0;
            gameoverPanel.SetActive(true);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public static bool gameOver;
    [SerializeField] GameObject gameoverPanel;
    [SerializeField] GameObject startingText;

    public static bool isGameStarted;
    void Start()
    {
        gameOver = false;
        Time.timeScale = 1;
        isGameStarted = false;
    }

    
    void Update()
    {
        if (gameOver)
        {
            Time.timeScale = 0;
            gameoverPanel.SetActive(true);
        }

        if (SwipeManager.tap)
        {
            isGameStarted = true;
            Destroy(startingText);
        }
    }
}

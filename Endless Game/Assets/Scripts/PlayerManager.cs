using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerManager : MonoBehaviour
{
    public static bool gameOver;
    [SerializeField] GameObject gameoverPanel;
    [SerializeField] GameObject startingText;

    public static bool isGameStarted;
    public static int numberOfCoins;
    [SerializeField] private TextMeshProUGUI coinsText;
    void Start()
    {
        gameOver = false;
        Time.timeScale = 1;
        isGameStarted = false;
        numberOfCoins = 0;
    }

    
    void Update()
    {
        if (gameOver)
        {
            Time.timeScale = 0;
            gameoverPanel.SetActive(true);
        }

        coinsText.text = "Coins: " + numberOfCoins;
        if (SwipeManager.tap && !isGameStarted)
        {
            isGameStarted = true;
            Destroy(startingText);
        }
    }
}

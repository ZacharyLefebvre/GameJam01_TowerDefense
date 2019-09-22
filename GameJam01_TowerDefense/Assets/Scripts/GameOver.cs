using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    private bool gameHasEnded = false;

    [SerializeField] private GameObject UI_GameOver;

    public void GameOverMethod()
    {
        if (!gameHasEnded)
        {
            gameHasEnded = true;

            DisplayGameOverScreen();
        }
    }

    private void DisplayGameOverScreen()
    {
        UI_GameOver.SetActive(true);
    }
}

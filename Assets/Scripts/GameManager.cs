using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public enum GameState
{
    PREGAME,
    INGAME,
    POSTGAME
}

public class GameManager : MonoBehaviour
{

    public UIManager UIManager;
    public GameObject Game;

    public GameObject PostGameUI;
    public GameObject WinUI;
    public GameObject LoseUI;

    public GameState GameState = GameState.PREGAME;

    public void StartGame()
    {
        if (GameState == GameState.PREGAME)
        {
            Game.SetActive(true);
            UIManager.PregameUI.SetActive(false);
            GameState = GameState.INGAME;
        }
        else if (GameState == GameState.POSTGAME)
        {
            Application.Quit();
        }
    }

    public void StartGame(InputAction.CallbackContext context)
    {
        StartGame();
    }

    public void LoseGame()
    {
        Destroy(Game);
        PostGameUI.SetActive(true);
        LoseUI.SetActive(true);
    }

    public void WinGame()
    {
        Destroy(Game);
        PostGameUI.SetActive(true);
        WinUI.SetActive(true);
    }
}

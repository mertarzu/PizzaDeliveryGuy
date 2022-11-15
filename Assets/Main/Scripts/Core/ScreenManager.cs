using System.Collections.Generic;
using UnityEngine;

public class ScreenManager : MonoBehaviour
{
    [SerializeField] GameManager _gameManager;
    [SerializeField] List<UIScreen> _uiScreens;
    enum Screen
    {
        Loading,
        Idle,
        Gameplay,
        Win,
        Lose
    }

    public void Initialize()
    {
        foreach (var uiScreen in _uiScreens) uiScreen.Initialize();
        
        IdleScreen idleScreen = (IdleScreen)_uiScreens[(int)Screen.Idle]; ;
        idleScreen.OnPlayPressed = StartGame;

        WinScreen winScreen = (WinScreen)_uiScreens[(int)Screen.Win];
        winScreen.OnNextLevelPressed = LoadNextLevel;

        LoseScreen loseScreen = (LoseScreen)_uiScreens[(int)Screen.Lose];
        loseScreen.OnReplayPressed = Reload;
    }

    void StartGame()
    {
        _gameManager.StartGame();
    }

    void LoadNextLevel()
    {
        _gameManager.LoadNextLevel();
    }

    void Reload()
    {
        _gameManager.Reload();
    }

    public void Show(int screen)
    {
        _uiScreens[screen].Show();
    }

    public void Hide(int screen)
    {
        _uiScreens[screen].Hide();
    }

}

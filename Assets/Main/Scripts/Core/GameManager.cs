using Cinemachine;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] PlayerController _playerController;
    [SerializeField] LevelController _levelController;
    [SerializeField] ScreenManager _screenManager;
    [SerializeField] CinemachineVirtualCamera _vcamFollow;
    [SerializeField] CinemachineVirtualCamera _vcaEnd;
    [SerializeField] Water _water;
   
    const float WaitAmount = 3;
    
    private GameState _gameState;
    enum GameState
    {
        Loading,
        Idle,
        Gameplay,
        Win,
        Lose
    }

    private void Awake()
    {
        Initialize();
    }
    public void Initialize()
    {
        _playerController.Initialize();    
        _screenManager.Initialize();
        _water.gameObject.SetActive(true);
        // SetLoadingState();
        SetIdleState();
    }

    public void StartGame()
    {
        _levelController.StartLevel();
        _playerController.StartGame();
       
        _vcamFollow.Priority = 1;
        _vcaEnd.Priority = 0;
        SetGamePlayState();
    }

    public void GameOver(bool isWin)
    {
        float waitAmount;
        if (isWin)
        {
            PoolParticle confettiFX =(PoolParticle)PoolManager.Instance.GetItemByName("ConfettiFX");
            if (confettiFX != null)
            {
                confettiFX.Play(_levelController.EndTransform.position);
            }
            _vcamFollow.Priority = 0;
            _vcaEnd.Priority = 1;
            waitAmount = 4f;

        }
        else
        {       
            waitAmount = .5f; 
        }
        _water.gameObject.SetActive(false);
        _levelController.EndLevel();
       
    }
   public void  OnGameOver(bool isWin)
    {
        _playerController.UnloadPlayer();

        if (isWin)
        {
            _vcamFollow.Priority = 1;
            _vcaEnd.Priority = 0;
            SetWinState();
        }
        else
        {
            SetLoseState();
        }
    }
   

    public void LoadNextLevel()
    {
        _levelController.UnloadLevel();    
        PlayerProgress();
        //SetLoadingState();    
        SetIdleState();
    }

    public void Reload()
    {
        _levelController.UnloadLevel();
        _playerController.Reload();        
        SetIdleState();
    }

    void PlayerProgress()
    {
        ++DataHandler.Level;
        ++DataHandler.UILevel;
        if (DataHandler.Level > 2) DataHandler.Level = 1;
    }

    IEnumerator LoadingCoroutine()
    {
        yield return new WaitForSeconds(WaitAmount);
        SetIdleState();
    }


    void SetLoadingState()
    {
        
        _screenManager.Hide((int)_gameState);
        _gameState = GameState.Loading;      
        _screenManager.Show((int)_gameState);
        StartCoroutine(LoadingCoroutine());
    }

    void SetIdleState()
    {
        _screenManager.Hide((int)_gameState);
        _gameState = GameState.Idle;   
        _screenManager.Show((int)_gameState);
        _levelController.LoadLevel(DataHandler.Level);   
        _playerController.LoadPlayer(_levelController.StartTransform,_levelController.EndTransform);
        
    }

    void SetGamePlayState()
    {
        _screenManager.Hide((int)_gameState);
        _gameState = GameState.Gameplay;    
        _screenManager.Show((int)_gameState);
    }
    void SetWinState()
    {
        _screenManager.Hide((int)_gameState);
        _gameState = GameState.Win;     
        _screenManager.Show((int)_gameState);
        
    }

    void SetLoseState()
    {
        _screenManager.Hide((int)_gameState);
        _gameState = GameState.Lose;
        _screenManager.Show((int)_gameState);
       
    }
}

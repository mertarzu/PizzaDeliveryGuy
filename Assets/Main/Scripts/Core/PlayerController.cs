using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    IInputHandler<float> _inputHandler;
    public float Output => _inputHandler.Output;

    [SerializeField] GameManager _gameManager;
    [SerializeField] Player _player;
    [SerializeField] PlayerMover _playerMover;
    [SerializeField] PlayerStackItemHandler _playerStackHandler;
    [SerializeField] PlayerFX _playerFX;
    Transform _endTransform;
    bool _isActive;
    private bool _isGameOver;

    public void Initialize()
    {
        _inputHandler = new SwipeHandler();
        _player.Initialize();
        _playerStackHandler.Initialize();
        _playerMover.OnGameOver += OnGameOver;

    }

    private void OnGameOver()
    {

        _gameManager.OnGameOver(true);
        _isGameOver = false;
 
    }

    public void StartGame()
    {
        
        _player.StartGame();
        _playerStackHandler.StartGame();
        _playerFX.gameObject.SetActive(true);
        _isActive = true;
    }

   

    public void GameOver()
    {
        _isActive = false;
        _gameManager.GameOver(true);
        _player.GameOver();
        _playerStackHandler.GameOver(_endTransform);
        _playerFX.SetWinAnim(true);
        _playerFX.gameObject.SetActive(false);
        _isGameOver = true;

    }

    public void Reload()
    {
        _isActive = false;

        _player.Reload();
    }

     public void LoadPlayer(Transform startTransform, Transform endTransform)
     {
        _player.transform.rotation = Quaternion.Euler(0, 0, 0);
        _player.gameObject.transform.position = startTransform.position;
        _endTransform = endTransform;
        _player.gameObject.SetActive(true);
       


    }
    public void UnloadPlayer()
    {
        _player.gameObject.SetActive(false);
        _playerFX.SetWinAnim(false);
    }

    void Update()
    {
        if (_isActive)
        {
            _inputHandler.InputUpdate();
            _playerMover.MoveForward();
            if (_player.transform.position.z >= _endTransform.position.z)
            {
                _isActive = false;
                GameOver();
            }
            if (Mathf.Abs(Output) > 0) MovementUpdate();
            else if (_playerStackHandler.IsPicked)
            {
                _player.transform.rotation = Quaternion.RotateTowards(_player.transform.rotation, Quaternion.identity, Time.deltaTime * 5);
                _playerMover.Swing();
            }
            else _player.transform.rotation = Quaternion.RotateTowards(_player.transform.rotation, Quaternion.identity, Time.deltaTime * 5);
                   
        }
        if (_isGameOver) _playerMover.GameOverUpdate(new Vector3(0, 0, _endTransform.position.z + .5f));
    }

   
    void MovementUpdate()
    {
     
        _playerMover.MovementUpdate(Output);
    }
   
}

using System;
using UnityEngine;
using UnityEngine.InputSystem;
using PlayerInput = Character.PlayerInput;

namespace Game
{
    [DefaultExecutionOrder(100)]
    public class GameStarter : MonoBehaviour
    {
        private PlayerInput _playerInput;
        

        private void Start()
        {
            _playerInput = FindObjectOfType<PlayerInput>();

            _playerInput.PlayerControls.Player.Jump.performed += StartGame;
            
            Application.targetFrameRate = 60; //Lock fps at 60
        }
        

        public event Action OnGameStart;
        private void StartGame(InputAction.CallbackContext obj)
        {
            OnGameStart?.Invoke();
            UnSubscribe();
        }

        private void UnSubscribe()
        {
            _playerInput.PlayerControls.Player.Jump.performed -= StartGame;
        }
    }
}

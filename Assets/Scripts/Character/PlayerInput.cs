using System;
using UnityEngine;

namespace Character
{
    [RequireComponent(typeof(BirdMove))]
    public class PlayerInput : MonoBehaviour
    {
        public PlayerControls PlayerControls => _playerControls;

        private PlayerControls _playerControls;
        private BirdMove _birdMove;
        
        private void Awake()
        {
            _playerControls = new PlayerControls();
            _birdMove = GetComponent<BirdMove>();

            _playerControls.Player.Jump.performed += _ => Jump();
        }

        private void OnEnable()
        {
            _playerControls.Enable();
        }

        private void OnDisable()
        {
            _playerControls.Disable();
        }

        private void Jump()
        {
            _birdMove.Jump();
        }
    }
}

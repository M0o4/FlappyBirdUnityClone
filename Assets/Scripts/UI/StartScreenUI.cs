using System;
using Game;
using UnityEngine;

namespace UI
{
    public class StartScreenUI : MonoBehaviour, IWindowUI
    {
        private GameStarter _gameStarter;

        private void Awake()
        {
            _gameStarter = FindObjectOfType<GameStarter>();
        }

        private void Start()
        {
            ShowWindow();
            
            _gameStarter.OnGameStart += HideWindow;
        }

        private void OnDestroy()
        {
            _gameStarter.OnGameStart -= HideWindow;
        }

        public void ShowWindow()
        {
            gameObject.SetActive(true);
        }

        public void HideWindow()
        {
            gameObject.SetActive(false);
        }
    }
}

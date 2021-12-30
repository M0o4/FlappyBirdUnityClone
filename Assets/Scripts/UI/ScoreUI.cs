using System;
using Character;
using Game;
using TMPro;
using UnityEngine;

namespace UI
{
    [RequireComponent(typeof(TextMeshProUGUI))]
    public class ScoreUI : MonoBehaviour, IWindowUI
    {
        private GameStarter _gameStarter;
        private TextMeshProUGUI _scoreText;

        private void Awake()
        {
            _gameStarter = FindObjectOfType<GameStarter>();
        }

        private void Start()
        {
            _scoreText = GetComponent<TextMeshProUGUI>();

            Bird.OnDamageReceived += HideWindow;
            Bird.OnScoreChanged += ChangeScoreText;
            _gameStarter.OnGameStart += ShowWindow;
            
            gameObject.SetActive(false);
        }

        private void OnDestroy()
        {
            Bird.OnDamageReceived -= HideWindow;
            Bird.OnScoreChanged -= ChangeScoreText;
            _gameStarter.OnGameStart -= ShowWindow;
        }

        public void ShowWindow()
        {
            gameObject.SetActive(true);
        }

        public void HideWindow()
        {
            gameObject.SetActive(false);
        }

        private void ChangeScoreText(int score)
        {
            _scoreText.text = score.ToString();
        }
    }
}

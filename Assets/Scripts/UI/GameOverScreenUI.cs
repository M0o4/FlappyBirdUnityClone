using System;
using Character;
using Game;
using TMPro;
using UnityEngine;

namespace UI
{
    public class GameOverScreenUI : MonoBehaviour, IWindowUI
    {
        [SerializeField] private TextMeshProUGUI _scoreText;
        [SerializeField] private TextMeshProUGUI _bestScoreText;

        private void Start()
        {
            Bird.OnDamageReceived += ShowWindow;
            
            HideWindow();
        }

        private void OnDestroy()
        {
            Bird.OnDamageReceived -= ShowWindow;
        }

        public void ShowWindow()
        {
            gameObject.SetActive(true);

            _scoreText.text = $"Score: {Bird.Singleton.Score}";
            _bestScoreText.text = $"Best: {GameSaves.Singleton.BestScore}";
        }

        public void HideWindow()
        {
            gameObject.SetActive(false);
        }
    }
}

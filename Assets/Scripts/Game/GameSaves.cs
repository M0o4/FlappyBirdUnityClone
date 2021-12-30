using System;
using Character;
using UnityEngine;

namespace Game
{
    public class GameSaves : MonoBehaviour
    {
        public static GameSaves Singleton => _current;
        public int BestScore => _bestScore;

        private static GameSaves _current;
        private int _bestScore;

        private void Awake()
        {
            if (_current != null)
            {
                Debug.LogError("Another instance of CustomersController already exists!");
                return;
            }

            _current = this;
        }

        private void Start()
        {
            Bird.OnDamageReceived += Save;
            
            LoadSaves();
        }

        private void OnDestroy()
        {
            Bird.OnDamageReceived -= Save;
            
            if (_current == this)
                _current = null;
        }

        private void Save()
        {
            SaveBestScore(Bird.Singleton.Score);
        }

        private void SaveBestScore(int score)
        {
            if(BestScore < score)
            {
                PlayerPrefs.SetInt(nameof(BestScore), score);
            }
        }

        private void LoadSaves()
        {
            _bestScore = PlayerPrefs.HasKey(nameof(BestScore)) ? PlayerPrefs.GetInt(nameof(BestScore)) : 0;
        }
    }
}

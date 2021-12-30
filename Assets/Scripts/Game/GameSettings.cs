using System;
using Character;
using UnityEngine;

namespace Game
{
    public class GameSettings : MonoBehaviour
    {
        public static GameSettings Singleton => _current;

        public float WorldSpeed
        {
            get
            {
                if (_worldSpeed == 0)
                    return _worldSpeed;

                if (_worldSpeed + _bird.Score / _speedUp >= _maxSpeed)
                    return _maxSpeed;

                return _worldSpeed + _bird.Score / _speedUp;
            }
        }
        
        [SerializeField] private float _worldSpeed;
        [SerializeField] private float _maxSpeed;
        [SerializeField] private float _speedUp;
        
        private static GameSettings _current;
        private Bird _bird;

        private void Awake()
        {
            if(_current != null)
            {
                Debug.LogError("Another instance of CustomersController already exists!");
                return;
            }

            _current = this;
        }

        private void Start()
        {
            _bird = FindObjectOfType<Bird>();
            
            Bird.OnDamageReceived += StopWorld;
        }

        private void StopWorld()
        {
            _worldSpeed = 0;
        }

        private void OnDestroy()
        { 
            if ( _current == this )
                _current = null;
            
            Bird.OnDamageReceived -= StopWorld;
        }
    }
}

using System;
using Entity;
using UnityEngine;

namespace Character
{
    [RequireComponent(typeof(Animator))]
    public class Bird : MonoBehaviour
    {
        public static Bird Singleton => _current;
        public int Score => _score;

        [SerializeField] private AudioSource _hitSound;
        
        private static Bird _current;
        private Animator _animator; 
        private int _score;
        
        public static event Action<int> OnScoreChanged;
        public void IncreaseScore()
        {
            _score++;
            OnScoreChanged?.Invoke(_score);
        } 
        
        public static event Action OnDamageReceived;
        public static void DamageReceived()
        {
            OnDamageReceived?.Invoke();
        }

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
            _animator = GetComponent<Animator>();

            OnDamageReceived += StopAnimator;
            OnDamageReceived += PlayHitSound;
        }

        private void OnDestroy()
        {
            OnDamageReceived -= StopAnimator;
            OnDamageReceived -= PlayHitSound;

            if (_current == this)
                _current = null;
        }

        private void StopAnimator()
        {
            _animator.enabled = false;
        }

        private void PlayHitSound()
        {
            _hitSound.Play();
        }
    }
}

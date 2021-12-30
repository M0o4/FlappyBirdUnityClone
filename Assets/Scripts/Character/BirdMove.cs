using System;
using Game;
using Unity.Mathematics;
using UnityEngine;

namespace Character
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class BirdMove : MonoBehaviour
    {
        [SerializeField] private AudioSource _wingSound;
        
        [SerializeField] private float _tapForce;
        [SerializeField] private float _rotationSpeed;
        [SerializeField] private float _maxRotationZ;
        [SerializeField] private float _minRotationZ;

        private GameStarter _gameStarter;
        private Rigidbody2D _rb2d;
        private Quaternion _maxRotation;
        private Quaternion _minRotation;
        private bool _isMoving;

        private void Awake()
        {
            _gameStarter = FindObjectOfType<GameStarter>();
        }

        private void Start()
        {
            _rb2d = GetComponent<Rigidbody2D>();
            _rb2d.velocity = Vector2.zero;
            _rb2d.bodyType = RigidbodyType2D.Static;
            
            _maxRotation = quaternion.Euler(0,0,_maxRotationZ);
            _minRotation = quaternion.Euler(0,0,_minRotationZ);

            Bird.OnDamageReceived += StopMove;
            _gameStarter.OnGameStart += StartMove;
        }

        private void OnDestroy()
        {
            Bird.OnDamageReceived -= StopMove;
            _gameStarter.OnGameStart -= StartMove;
        }

        private void Update()
        {
            if(_isMoving)
                MoveDown();
        }

        private void MoveDown()
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, _minRotation, _rotationSpeed * Time.deltaTime);
        }

        private void StartMove()
        {
            _isMoving = true;
            _rb2d.bodyType = RigidbodyType2D.Dynamic;
            Jump();
        }

        private void StopMove()
        {
            _isMoving = false;
            _rb2d.bodyType = RigidbodyType2D.Static;
            enabled = false;
        }

        public void Jump()
        {
            if(!_isMoving) return;
            
            _wingSound.Play();
            
            _rb2d.velocity = new Vector2(_rb2d.velocity.x, 0);
            transform.rotation = _maxRotation;
            _rb2d.AddForce(Vector2.up * _tapForce, ForceMode2D.Force);
        }
    }
}

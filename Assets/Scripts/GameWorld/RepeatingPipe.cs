using System;
using System.Collections.Generic;
using Extension;
using Game;
using PoolObject;
using UnityEngine;
using Random = UnityEngine.Random;

namespace GameWorld
{
    public class RepeatingPipe : MonoBehaviour
    {
        [SerializeField] private GameObject _pipePrefab;
        [SerializeField] private float _respawnOffset;
        [SerializeField] private float _maxSpawnHight;
        [SerializeField] private float _minSpawnHight;

        private GameStarter _gameStarter;
        private PoolObject.PoolObject _oldPipe;
        private PoolObject.PoolObject _spawnedPipe;
        private Camera _mainCamera;
        private int _pipeHashCode;
        private float _leftScreenEdge;
        private float _rightScreenEdge;
        private bool _isGameStarted;

        private void Awake()
        {
            _gameStarter = FindObjectOfType<GameStarter>();
        }

        private void Start()
        {
            _mainCamera = Camera.main;

            _rightScreenEdge = _mainCamera.GetScreenBounds().x;
            _leftScreenEdge = -_rightScreenEdge; //Use minus to get left edge
            _pipeHashCode = _pipePrefab.name.GetHashCode();

            _gameStarter.OnGameStart += StartGame;
        }

        private void Update()
        {
            if(_isGameStarted)
                RepeatPipes();
        }

        private void OnDestroy()
        {
            _gameStarter.OnGameStart -= StartGame;
        }

        private void StartGame()
        {
            _isGameStarted = true;
        }

        private void RepeatPipes()
        {
            if (_spawnedPipe == null)
            {
                _spawnedPipe = SpawnPipe();
            }
            else
            {
                if (_spawnedPipe.transform.position.x <= _leftScreenEdge + _respawnOffset)
                {
                    _oldPipe = _spawnedPipe;
                    _spawnedPipe = null;
                }
            }

            if (_oldPipe != null)
            {
                if (_oldPipe.transform.position.x < _leftScreenEdge - 1f)
                {
                    _oldPipe.ReturnToPool();
                    _oldPipe = null;
                }
            }  
        }

        private PoolObject.PoolObject SpawnPipe()
        {
            var spawnedPipeObj = PoolManager.GetObject(_pipeHashCode, new Vector3(_rightScreenEdge + 2f, 0f, 0f),
                Quaternion.identity);
            var spawnedPipe = spawnedPipeObj.GetComponent<Pipe>();
            SetPipeToScreenEdge(spawnedPipe);
            return spawnedPipe.PoolObject;
        }

        private void SetPipeToScreenEdge(Pipe pipe)
        {
            var spawnedPipeRenderer = pipe.Pipe1Renderer;
            pipe.transform.position = spawnedPipeRenderer.GetTransformFromEdge(pipe.transform,
                _mainCamera.GetScreenBounds(), SpriteEdge.Right);
            pipe.transform.position = new Vector3(pipe.transform.position.x+0.2f, GetRandomPipeY());
        }

        private float GetRandomPipeY()
        {
            return Random.Range(_minSpawnHight, _maxSpawnHight);
        }

        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(new Vector3(_leftScreenEdge + _respawnOffset, 0f), 0.5f);
        }
    }
}

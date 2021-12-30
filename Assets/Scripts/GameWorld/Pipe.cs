using System;
using System.Collections.Generic;
using UnityEngine;

namespace GameWorld
{
    [RequireComponent(typeof(PoolObject.PoolObject))]
    public class Pipe : MonoBehaviour
    {
        public PoolObject.PoolObject PoolObject => _poolObject;
        public SpriteRenderer Pipe1Renderer => _pipe1Renderer;
        public SpriteRenderer Pipe2Renderer => _pipe2Renderer;

        [SerializeField] private SpriteRenderer _pipe1Renderer;
        [SerializeField] private SpriteRenderer _pipe2Renderer;

        private PoolObject.PoolObject _poolObject;

        private void Awake()
        {
            _poolObject = GetComponent<PoolObject.PoolObject>();
        }
    }
}

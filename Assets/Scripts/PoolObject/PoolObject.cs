using System;
using System.Collections.Generic;
using UnityEngine;

namespace PoolObject
{
    [AddComponentMenu("Pool/PoolObject")]
    public class PoolObject : MonoBehaviour
    {
        public Animator Animator => _animator;
        public Queue<PoolObject> PoolObjects
        {
            set => _pool = value;
        }

        private Animator _animator;
        private Queue<PoolObject> _pool;

        private void Start()
        {
            _animator = GetComponent<Animator>();
        }

        public void ReturnToPool () {
            _pool.Enqueue(this);
            gameObject.SetActive (false);
        }
    }
}

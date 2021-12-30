using UnityEngine;
using System.Collections.Generic;

namespace PoolObject
{
    public class ObjectPooling
    {
        private Queue<PoolObject> _objects;
        private PoolObject _sample;
        private Transform _objectsParent;
        
        public void Initialize (int count, PoolObject sample, Transform objectsParent)
        {
            _objects = new Queue<PoolObject>();
            _objectsParent = objectsParent;
            _sample = sample;
            for (int i=0; i<count; i++) {
                AddObject(sample, objectsParent);
            }
        }


        public PoolObject GetObject () {
            if (_objects.Count != 0)
                return _objects.Dequeue();
            
            AddObject(_sample, _objectsParent);
            return _objects.Dequeue();
        }
        
        private void AddObject(PoolObject sample, Transform objectsParent) {
            var temp = Object.Instantiate(sample.gameObject, objectsParent, true);
            temp.name = sample.name;
            var poolObject = temp.GetComponent<PoolObject>();
            poolObject.PoolObjects = _objects;
            _objects.Enqueue(poolObject);
            if (poolObject.Animator)
                poolObject.Animator.StartPlayback();
            temp.SetActive(false);
        }
    }
}

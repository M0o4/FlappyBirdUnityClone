using System;
using UnityEngine;
namespace PoolObject
{
    public static class PoolManager 
    {
        private static PoolPart[] _pools;
        private static GameObject _objectsParent;

        [Serializable]
        public struct PoolPart {
            public string name;
            public int _hashCode;
            public PoolObject prefab;
            public int count;
            public ObjectPooling ferula;
        }

        public static void Initialize(PoolPart[] newPools) {
            _pools = newPools;
            _objectsParent = new GameObject {name = "Pool"};
            for (int i=0; i<_pools.Length; i++) {
                if(_pools[i].prefab!=null) {
                    _pools[i].ferula = new ObjectPooling();
                    _pools[i].ferula.Initialize(_pools[i].count, _pools[i].prefab, _objectsParent.transform);
                }
            }
        }


        public static GameObject GetObject (string name, Vector3 position, Quaternion rotation) {
            if (_pools != null) {
                for (int i = 0; i < _pools.Length; i++) {
                    if (String.CompareOrdinal (_pools [i].name, name) == 0) {
                        var result = _pools[i].ferula.GetObject().gameObject;
                        result.transform.position = position;
                        result.transform.rotation = rotation;
                        result.SetActive (true);
                        return result;
                    }
                }
            } 
            return null;
        }
        
        public static GameObject GetObject (int hashCode, Vector3 position, Quaternion rotation) {
            if (_pools != null) {
                for (int i = 0; i < _pools.Length; i++) {
                    if (_pools[i]._hashCode == hashCode) {
                        var result = _pools[i].ferula.GetObject().gameObject;
                        result.transform.position = position;
                        result.transform.rotation = rotation;
                        result.SetActive (true);
                        return result;
                    }
                }
            } 
            return null;
        }
    }
}

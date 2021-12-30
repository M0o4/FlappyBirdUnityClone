using UnityEngine;

namespace PoolObject
{
    [AddComponentMenu("Pool/PoolSetup")]
    public class PoolSetup : MonoBehaviour
    {
        [SerializeField] private PoolManager.PoolPart[] pools;
        
        private void OnValidate() {
            for (int i = 0; i < pools.Length; i++) {
                pools[i].name = pools[i].prefab.name;
                pools[i]._hashCode = pools[i].name.GetHashCode();
            }
        }

        private void Awake() {
            Initialize ();
        }

        private void Initialize () {
            PoolManager.Initialize(pools);
        }
    }
}

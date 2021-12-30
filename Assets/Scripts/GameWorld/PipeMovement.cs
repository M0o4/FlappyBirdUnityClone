using Game;
using UnityEngine;

namespace GameWorld
{
    public class PipeMovement : MonoBehaviour
    {
        private void Update()
        {
            transform.Translate(Vector2.left * GameSettings.Singleton.WorldSpeed * Time.deltaTime);
        }
    }
}

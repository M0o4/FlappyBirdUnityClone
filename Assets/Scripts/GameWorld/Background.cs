using System;
using Extension;
using UnityEngine;

namespace GameWorld
{
    [RequireComponent(typeof(SpriteRenderer))]
    public class Background : MonoBehaviour
    {
        public Vector2 RightEdge => GetRightEdge();
        public SpriteRenderer Renderer => _renderer;
        
        private SpriteRenderer _renderer;

        private void Awake()
        {
            _renderer = GetComponent<SpriteRenderer>();
        }

        private Vector2 GetRightEdge()
        {
            var spriteEdgeSide = SpriteEdge.Right;
            return _renderer.GetEdgePosition(_renderer.GetComponent<Transform>(), spriteEdgeSide);
        }
    }
}

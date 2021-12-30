using UnityEngine;

namespace Extension
{
    public enum SpriteEdge
    {
        Left,
        Right
    }
    
    public static class SpriteRendererExtension 
    {
        public static Vector2 GetEdgePosition(this SpriteRenderer renderer, Transform transform, SpriteEdge edge)
        {
            float spriteWidth = renderer.sprite.bounds.size.x * transform.lossyScale.x;
            
            if(edge == SpriteEdge.Left)
                return new Vector2(transform.position.x - (spriteWidth / 2), transform.position.y);
            else
                return new Vector2(transform.position.x + (spriteWidth / 2), transform.position.y);
        }

        public static Vector2 GetTransformFromEdge(this SpriteRenderer renderer, Transform transform, Vector2 edge, SpriteEdge spriteSide)
        {
            float spriteWidth = renderer.sprite.bounds.size.x * transform.lossyScale.x;
            
            if(spriteSide == SpriteEdge.Left)
                return new Vector2((-spriteWidth / 2) + edge.x, transform.position.y);
            else
                return new Vector2(-(-spriteWidth / 2) + edge.x, edge.y);
        }
    }
}

using System;
using Character;
using UnityEngine;

namespace GameWorld
{
    public class ScoreZone : MonoBehaviour
    {
        [SerializeField] private AudioSource _pointSound;
        
        private void OnTriggerExit2D(Collider2D other)
        {
            if (other.TryGetComponent<Bird>(out var bird))
            {
                bird.IncreaseScore();
                _pointSound.Play();
            }
        }
    }
}

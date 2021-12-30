using System;
using Character;
using UnityEngine;

namespace GameWorld
{
    public class DamagingZone : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D col)
        {
            if (col.GetComponent<Bird>() != null)
            {
                Bird.DamageReceived();
            }
        }
    }
}

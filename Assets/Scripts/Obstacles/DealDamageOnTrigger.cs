using System;
using Controllers;
using UnityEngine;

namespace Obstacles
{
    public class DealDamageOnTrigger : MonoBehaviour
    {
        public float damageToTake;
        public bool onlyHitsPlayer;
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (onlyHitsPlayer && other.CompareTag("Player") || !onlyHitsPlayer)
            {
                other.GetComponentInParent<HealthController>().TakeDamage(damageToTake);
            }
        }
    }
}

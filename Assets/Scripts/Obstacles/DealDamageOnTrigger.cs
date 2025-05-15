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
            if ((onlyHitsPlayer && other.CompareTag("Player")) || !onlyHitsPlayer)
            {
                var healthController = other.GetComponentInParent<HealthController>();

                if (healthController != null)
                {
                    healthController.TakeDamage(damageToTake);
                }
                else
                {
                    Debug.LogWarning($"{other.name} entered trigger but has no HealthController component.");
                }
            }
        }

        public bool OnlyHitsPlayer
        {
            get => onlyHitsPlayer;
            set => onlyHitsPlayer = value;
        }
    }
}
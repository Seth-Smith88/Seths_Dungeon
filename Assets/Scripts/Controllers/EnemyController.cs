using System;
using UnityEngine;

namespace Controllers
{
    public class EnemyController : MonoBehaviour
    {
        public Transform player; // Reference to the player's Transform
        private Animator _animator;
        public float moveSpeed = 2f; // Movement speed of the enemy

        private void Start()
        {
            _animator = GetComponent<Animator>();
            _animator.enabled = false;
        }

        void Update()
        {
            if (player == null) return; // Exit if no player assigned

            // Calculate the direction towards the player
            Vector3 direction = (player.position - transform.position).normalized;
            _animator.enabled = true;

            // Move the enemy towards the player
            transform.position += direction * moveSpeed * Time.deltaTime;
        }
    }
}

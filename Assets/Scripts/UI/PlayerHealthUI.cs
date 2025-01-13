using Controllers;
using UnityEngine;

namespace UI
{
    public class PlayerHealthUI : MonoBehaviour
    {
        public GameObject Player;
        public GameObject HeartsPrefabEmpty;
        public GameObject HeartsPrefabHalf;
        public GameObject HeartsPrefabFull;
        public Transform heartsContainer;
        private float currentHealth;
        private float maxHealth;
        private float heartsMath;
        private float f = 0;
        private float h = 0;
        private float e = 0;

        private void Start()
        {
            Player = GameObject.FindWithTag("Player");
            UpdateOnDamage();
        }

        public void UpdateOnDamage()
        {
            ClearHeartsDisplay();
            UpdateValues();
            UpdateHeartsDisplay();
            InstantiateHearts(f,h,e);
        }

        private void UpdateValues()
        {
            currentHealth = Player.GetComponent<HealthController>().health;
            maxHealth = Player.GetComponent<HealthController>().maxHealth;
        }

        private void ResetValues()
        {
            f = 0;
            h = 0;
            e = 0;
        }

        private void ClearHeartsDisplay()
        {
            // Clear existing hearts
            foreach (Transform t in heartsContainer)
            {
                Destroy(t.gameObject);
            }
            ResetValues();
        }
    
        private void UpdateHeartsDisplay()
        {
            // Instantiate new hearts based on current health
            float fullHearts = currentHealth / 2;
            bool hasHalfHeart = currentHealth % 2 != 0;

            for (var i = 1; i <= fullHearts; i++)
            {
                f++;
            }

            if (hasHalfHeart)
            {
                h++;
            }

            float emptyHearts = (maxHealth - currentHealth + 1) / 2;

            for (var i = 1; i < emptyHearts; i++)
            {
                e++;
            }
        }

        private void InstantiateHearts(float full, float half, float empty)
        {
            for (int i = 1; i <= full; i++)
            {
                Instantiate(HeartsPrefabFull, heartsContainer);
            }
            for (int i = 0; i < half; i++)
            {
                Instantiate(HeartsPrefabHalf, heartsContainer);
            }

            for (int i = 0; i < empty; i++)
            {
                Instantiate(HeartsPrefabEmpty, heartsContainer);
            }
        }
    }
}

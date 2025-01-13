using UnityEngine;

namespace Controllers
{
    public class LadderController : MonoBehaviour
    {
        // The ladder controller script does only one thing - triggers when the player reaches it!
        
        // This is a reference to the level manager. This is created manually by dragging the manager
        // into the corresponding spot in the LadderController Unity Component
        public LevelManager levelManager;
        
        // OnTriggerEnter2D is a method that triggers automatically if the object that this script
        // is attached to has a 2D collider that is set to "Trigger"
        private void OnTriggerEnter2D(Collider2D other)
        {
            // It checks if the collision is the player
            if (!other.CompareTag("Player")) return;
            // Prints to debug.log
            Debug.Log("Player has hit the end trigger");
            // And then triggers a method in the level manager
            levelManager.NextLevel();
        }
    }
}

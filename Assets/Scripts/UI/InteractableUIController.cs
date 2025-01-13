using UnityEngine;

namespace UI
{
    public class InteractableUIController : MonoBehaviour
    {
        // This clever little script just makes sure that the interactable text appears over our
        // player's head, which is trickier than it sounds. This is because the player is on the "game" layer
        // and the UI in on a UI Canvas layer - completely different!
        
        // This assigns the position of our player to follow
        public Transform playerTransform;
        
        // This is just a reference to our own text object
        private RectTransform textBoxUI; 

        // This is a reference to the camera - as we need to know what the camera is looking at
        // to track where our text should be
        private Camera mainCamera;

        private void Start()
        {
            // Set up the reference to the main camera in the game
            mainCamera = Camera.main;

            // And then set up the reference to the position of our own text object
            textBoxUI = gameObject.GetComponent<RectTransform>();
        }

        private void Update()
        {
            // Per frame, update the position
            UpdateTextBoxPosition();
        }

        private void UpdateTextBoxPosition()
        {
            // Convert the world position of the Player to screen space relative to the object
            Vector3 screenPosition = RectTransformUtility.WorldToScreenPoint(mainCamera, playerTransform.position);

            // Convert screen position to UI position
            textBoxUI.anchoredPosition = screenPosition - new Vector3(Screen.width / 2f - 105, Screen.height / 2f - 180);
        }
    }
}

using UnityEngine;
using UnityEngine.Events;

namespace Interactables
{
    // We make a list of all of the keyboard input buttons that a designer might want to use

    public class Interactable : MonoBehaviour
    {
        // We make a keyboard input for the interactable to ask for
        public KeyCode requiredInput;
        
        // We start with a reference to our Sprite Renderer, as we'll be changing the image later
        private SpriteRenderer _spriteRenderer;
        
        // Unity event in case you want anything to happen when the button is pressed
        public UnityEvent onInteraction;
        
        // We then set an "Up" sprite and a "Down" sprite, which we'll change to when the button is up or down
        public Sprite uninteractedSprite, interactedSprite;
        
        // Two booleans. One to check if the button has been pressed, and one for the designer to make it
        // reset after a certain time. The timer aspects are just below these booleans.
        [HideInInspector] public bool hasInteracted;
        public bool doesReset;
        
        // These floats are the time it takes for the button to reset once it has been pressed.
        // The private float _timer is increased over time until it = timeToReset, where the Reset()
        // method is triggered
        public float timeToReset;
        private float _timer;

        private void Start()
        {
            // Set up component reference for SpriteRenderer, on the Button gameobject
            _spriteRenderer = GetComponent<SpriteRenderer>();
        }

        private void Update()
        {
            // If the interactable hasn't been triggered, or doesn't reset, then we wouldn't need any of this
            // code to fire on Update, so we return out of it
            if (!hasInteracted || !doesReset) return;

            // As soon as the button is pressed, and knowing that it resets, we begin adding time to our timer
            _timer += Time.deltaTime;
            
            // If the timer meets the timeToReset value, it'll Reset() the button
            if (_timer >= timeToReset)
            {Reset();}
        }
        
        public void Interact()
        {
            // Set the sprite to the on position
            _spriteRenderer.sprite = interactedSprite;
            // Sets bool to true
            hasInteracted = true;
            // Triggers Unity event
            onInteraction.Invoke();
        }

        public void Reset()
        {
            // Resets, as the button does
            hasInteracted = false;
            _spriteRenderer.sprite = uninteractedSprite;
        }
    }
}

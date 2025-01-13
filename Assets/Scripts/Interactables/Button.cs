using UnityEngine;
using UnityEngine.Events;

namespace Interactables
{
    public class Button : MonoBehaviour
    {
        // This button script provides a reusable approach that can meet multiple different
        // type of application.
        
        // We start with a reference to our Sprite Renderer, as we'll be changing the image later
        private SpriteRenderer _spriteRenderer;
        
        // Unity event in case you want anything to happen when the button is pressed
        public UnityEvent onButtonPress;
        
        // We then set an "Up" sprite and a "Down" sprite, which we'll change to when the button is up or down
        public Sprite buttonUpSprite, buttonDownSprite;
        
        // Two booleans. One to check if the button has been pressed, and one for the designer to make it
        // reset after a certain time. The timer aspects are just below these booleans.
        [HideInInspector] public bool isPressed;
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

        // We're once again checking for a collision on our Trigger2D.
        private void OnTriggerEnter2D(Collider2D col)
        {
            // If the collision is not the player then ignore it
            if (!col.CompareTag("Player") || isPressed) return;
            
            // Otherwise, the button has been pressed
            isPressed = true;
            
            // Change the sprite to show that it has been pressed
            _spriteRenderer.sprite = buttonDownSprite;
            
            // Set the timer to zero (in case this isn't the first time that it's been pressed)
            _timer = 0;
            
            // Trigger the onButtonPress Unity Event
            onButtonPress.Invoke();
        }

        private void Update()
        {
            // If the button hasn't been pressed, or doesn't reset, then we wouldn't need any of this
            // code to fire on Update, so we return out of it
            if (!isPressed || !doesReset) return;

            // As soon as the button is pressed, and knowing that it resets, we begin adding time to our timer
            _timer += Time.deltaTime;
            
            // If the timer meets the timeToReset value, it'll Reset() the button
            if (_timer >= timeToReset)
            {Reset();}
        }

        public void Reset()
        {
            // The reset is simple - button is no longer pressed, and it's now in the "up" position
            isPressed = false;
            _spriteRenderer.sprite = buttonUpSprite;
        }
    }
}

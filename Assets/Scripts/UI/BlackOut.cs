using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class BlackOut : MonoBehaviour
    {
        // This script is simple - it turns on a black image and fades it in or out at the beginning and end
        // of the level. It uses an animator and a couple of components.
        
        // These references are on the blackout object, and we'll use them below
        private Animator _anim;
        private Image _image;
        
        void Start()
        {
            // First we assign those references to the components
            _anim = GetComponent<Animator>();
            _image = GetComponent<Image>();

            // Then we turn on the Image component - it was off before so the screen isn't always
            // black, which would make working on the game pretty difficult!
            _image.enabled = true;
            
            // Then we call the FadeOut() method
            FadeOut();
        }

        public void FadeIn()
        {
            // FadeIn is just an animation. We tell it to play here with .Play();
            _anim.Play("Base Layer.FadeIn", 0,0f);
        }

        public void FadeOut()
        {
            // Same for FadeOut - called with .Play()
            _anim.Play("Base Layer.FadeOut", 0,0f);
        }
    }
}

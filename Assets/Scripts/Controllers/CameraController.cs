using MoreMountains.Feedbacks;
using UnityEngine;

namespace Controllers
{
    public class CameraController : MonoBehaviour
    {
        
        // Welcome to the Camera Controller! This ensures that the camera is always centred on the player
        
        // As with before, we set up a useful reference, and the most important one is the player itself
        public GameObject player;
        
        // Then we set up some values to determines how fast our camera should move
        public float moveSpeed;
        private bool _timeCount;
        private float _timer;
        
        void Update()
        {
            // Every frame, we trigger the below method
            UpdatePosition();
        }

        // This method figures out where the camera is, then checks where the player is,
        // and says "go over there!"
        void UpdatePosition()
        {
            // Where is the player? Follow the method below
            Vector3 targetPos = GetCameraTargetPosition();

            // Go over there! 
            transform.position = Vector3.MoveTowards(transform.position, targetPos, Time.deltaTime * moveSpeed);
        }

        // This method determines where the player is and RETURNS a vector 3 (number, number, number)
        // which is how we move around the Unity world space (ie a Vector3(0,0,0) is the centre of the world)
        private Vector3 GetCameraTargetPosition()
        {
            var position = player.transform.position;
            return new Vector3(position.x, position.y, -10);
        }
    }
}

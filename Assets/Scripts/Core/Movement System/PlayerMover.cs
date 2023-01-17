using Core.InputSystem;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Core.MovementSystem
{
    public class PlayerMover : MonoBehaviour
    {
        [Title("Speed Coefficients")]
        [SerializeField] [Range(0,10)] private float forwardSpeed = 5;
        [SerializeField] [Range(0,10)] private float sideSpeed = 2;

        [Title("Boundary")]
        [SerializeField] private float boundaryX;

        private void Move()
        {
            Vector3 currentPosition = transform.position;
            
            currentPosition.z += forwardSpeed * Time.deltaTime;
            currentPosition.x += InputManager.DeltaX * sideSpeed * Time.deltaTime;
            currentPosition.x = Mathf.Clamp(currentPosition.x, -boundaryX, boundaryX);

            transform.position = currentPosition;
        }

        private void OnEnable()
        {
            InputManager.onMouseButton += Move;
        }

        private void OnDisable()
        {
            InputManager.onMouseButton -= Move;
        }
    }
}



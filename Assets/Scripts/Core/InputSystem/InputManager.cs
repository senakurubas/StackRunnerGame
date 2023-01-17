using System;
using UnityEngine;

namespace Core.InputSystem
{
    public class InputManager : MonoBehaviour
    {
        public static event Action onMouseButtonDown;
        public static event Action onMouseButton;
        public static event Action onMouseButtonUp;
        
        public static float DeltaX;
        
        private Vector2 current;
        private Vector2 previous = Vector2.zero;

        private void Update()
        {
            GetInputs();
        }

        private void GetInputs()
        {
            current = Input.mousePosition;

            if (Input.GetMouseButtonDown(0))
            {
                onMouseButtonDown?.Invoke();
            }

            if (Input.GetMouseButton(0))
            {
                onMouseButton?.Invoke();
                DeltaX = current.x - previous.x;
            }

            if (Input.GetMouseButtonUp(0))
            {
                onMouseButtonUp?.Invoke();
            }

            previous = current;
        }
        
    }
}
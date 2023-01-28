using System;
using Core.InputSystem;
using Core.LevelEndSystem;
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

        private GameManager _gameManager;
        
        private bool _levelEnded;

        private void Awake()
        {
            _gameManager = FindObjectOfType<GameManager>();
        }

        private void Move()
        {
            if (_levelEnded) return;
            
            Vector3 currentPosition = transform.position;
            
            currentPosition.z += forwardSpeed * Time.deltaTime;
            currentPosition.x += InputManager.DeltaX * sideSpeed * Time.deltaTime;
            currentPosition.x = Mathf.Clamp(currentPosition.x, -boundaryX, boundaryX);

            transform.position = currentPosition;
        }

        private void LevelEnd()
        {
            _levelEnded = true;
        }

        private void OnEnable()
        {
            InputManager.onMouseButton += Move;
            _gameManager.OnLevelSuccess += LevelEnd;
            _gameManager.OnLevelFailed += LevelEnd;
        }

        private void OnDisable()
        {
            InputManager.onMouseButton -= Move;
            _gameManager.OnLevelSuccess -= LevelEnd;
            _gameManager.OnLevelFailed -= LevelEnd;
        }
    }
}



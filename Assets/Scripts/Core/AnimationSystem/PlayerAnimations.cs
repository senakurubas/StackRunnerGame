using Core.InputSystem;
using Core.LevelEndSystem;
using UnityEngine;

namespace Core.AnimationSystem
{
    public class PlayerAnimations : MonoBehaviour
    {
        [SerializeField] private Animator animator;
        
        private static readonly int IsRunning = Animator.StringToHash("IsRunning");

        private GameManager _gameManager;
        private bool _levelEnded;

        private void Awake()
        {
            _gameManager = FindObjectOfType<GameManager>();
        }

        private void SetRunningAnimation()
        {
            if (_levelEnded) return;
            animator.SetBool(IsRunning, true);
        }

        private void StopRunningAnimation()
        {
            animator.SetBool(IsRunning, false);
        }

        private void StopAnimations()
        {
            _levelEnded = true;
            StopRunningAnimation();
        }

        private void OnEnable()
        {
            InputManager.onMouseButtonDown += SetRunningAnimation;
            InputManager.onMouseButtonUp += StopRunningAnimation;
            _gameManager.OnLevelSuccess += StopAnimations;
            _gameManager.OnLevelFailed += StopAnimations;
        }

        private void OnDisable()
        {
            InputManager.onMouseButtonDown -= SetRunningAnimation;
            InputManager.onMouseButtonUp -= StopRunningAnimation;
            _gameManager.OnLevelSuccess -= StopAnimations;
            _gameManager.OnLevelFailed -= StopAnimations;
        }

        private void OnDestroy()
        {
            StopRunningAnimation();
        }
    }
}
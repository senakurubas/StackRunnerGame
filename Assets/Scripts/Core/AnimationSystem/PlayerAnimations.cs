using System;
using Core.InputSystem;
using UnityEngine;

namespace Core.AnimationSystem
{
    public class PlayerAnimations : MonoBehaviour
    {
        [SerializeField] private Animator animator;
        
        private static readonly int IsRunning = Animator.StringToHash("IsRunning");

        private void SetRunningAnimation()
        {
            animator.SetBool(IsRunning, true);
        }

        private void StopRunningAnimation()
        {
            animator.SetBool(IsRunning, false);
        }

        private void OnEnable()
        {
            InputManager.onMouseButtonDown += SetRunningAnimation;
            InputManager.onMouseButtonUp += StopRunningAnimation;
        }

        private void OnDisable()
        {
            InputManager.onMouseButtonDown -= SetRunningAnimation;
            InputManager.onMouseButtonUp -= StopRunningAnimation;
        }

        private void OnDestroy()
        {
            StopRunningAnimation();
        }
    }
}
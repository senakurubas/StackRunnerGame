using System;
using Core.AnimationSystem;
using Core.AudioSystem;
using Core.MovementSystem;
using Core.StackSystem;
using UnityEngine;

namespace Core.LevelEndSystem
{
    public class LevelEndTrigger : MonoBehaviour
    {
        private AudioManager _audioManager;
        private GameManager _gameManager;

        private void Awake()
        {
            _audioManager = FindObjectOfType<AudioManager>();
            _gameManager = FindObjectOfType<GameManager>();
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out Player player))
            {
                _audioManager.Play("LevelEnd");
                
                if (player.TryGetComponent(out PlayerMover playerMover))
                {
                    Destroy(playerMover);
                }

                if (player.TryGetComponent(out PlayerAnimations playerAnimations))
                {
                    Destroy(playerAnimations);
                }

                if (player.TryGetComponent(out Collector collector))
                {
                    StartCoroutine(collector.LevelEndOrder(transform.position + transform.forward * 1f));
                }

                _gameManager.GameStart();
            }
        }
    }
}
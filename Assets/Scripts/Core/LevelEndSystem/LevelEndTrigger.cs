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
        public static event Action onLevelEndStart;
        
        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out Player player))
            {
                FindObjectOfType<AudioManager>().Play("LevelEnd");
                
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
                
                onLevelEndStart?.Invoke();
            }
        }
    }
}
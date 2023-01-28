using System;
using UnityEngine;

namespace Core.LevelEndSystem
{
    public class ParticlePlayer : MonoBehaviour
    {
        [SerializeField] private ParticleSystem[] particlesToPlay;
        
        private GameManager _gameManager;

        private void Awake()
        {
            _gameManager = FindObjectOfType<GameManager>();
        }

        private void PlayAllParticles()
        {
            foreach (ParticleSystem p in particlesToPlay)
            {
                p.Play();
            }
        }

        private void OnEnable()
        {
            _gameManager.OnLevelSuccess += PlayAllParticles;
        }

        private void OnDisable()
        {
            _gameManager.OnLevelSuccess -= PlayAllParticles;
        }
    }
}
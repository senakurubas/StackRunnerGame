using Core.LevelEndSystem;
using UnityEngine;

namespace Core
{
    public class Player : MonoBehaviour
    {
        private GameManager _gameManager;

        private void Awake()
        {
            _gameManager = FindObjectOfType<GameManager>();
        }
        
        private void Start()
        {
            _gameManager.GameStart();
        }
    }
}
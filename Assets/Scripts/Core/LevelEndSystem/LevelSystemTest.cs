using UnityEngine;

namespace Core.LevelEndSystem
{
    public class LevelSystemTest : MonoBehaviour
    {
        private GameManager _gameManager;

        private void Awake()
        {
            _gameManager = FindObjectOfType<GameManager>();
        }

        private void Update()
        {
            //if (Input.GetKeyDown(KeyCode.Space))
            // _gameManager.LevelSuccess();


            if (Input.GetKeyDown(KeyCode.R))
                SceneController.LoadCurrentLevel();
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out LevelEndTrigger levelEndTrigger))
            {
                _gameManager.LevelSuccess();
            }
        }

    }
}
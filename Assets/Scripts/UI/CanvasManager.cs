using Core.LevelEndSystem;
using UnityEngine;

namespace UI
{
    public class CanvasManager : MonoBehaviour
    {
        [SerializeField] private RectTransform levelEndCanvas;

        private GameManager _gameManager;

        private void Awake()
        {
            _gameManager = FindObjectOfType<GameManager>();
        }

        private void LevelEndCanvasEnabled()
        {
            levelEndCanvas.gameObject.SetActive(true);
        }

        private void LevelEndCanvasDisabled()
        {
            levelEndCanvas.gameObject.SetActive(false);
        }

        private void OnEnable()
        {
            _gameManager.OnGameStart += LevelEndCanvasDisabled;
            _gameManager.OnLevelSuccess += LevelEndCanvasEnabled;
        }

        private void OnDisable()
        {
            _gameManager.OnGameStart -= LevelEndCanvasDisabled;
            _gameManager.OnLevelSuccess -= LevelEndCanvasDisabled;
        }
    }
}
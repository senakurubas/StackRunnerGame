using Core.LevelEndSystem;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class UI_NextLevelButton : MonoBehaviour
    {
        [SerializeField] private Button button;

        private void TriggerNextLevel()
        {
            StartCoroutine(SceneController.LoadNextLevel());
        }

        private void OnEnable()
        {
            button.onClick.AddListener(TriggerNextLevel);
        }

        private void OnDisable()
        {
            button.onClick.RemoveListener(TriggerNextLevel);
        }
    }
}
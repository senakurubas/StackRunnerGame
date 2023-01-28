using System;
using DG.Tweening;
using UnityEngine;

namespace Core.LevelEndSystem
{
    public class GameManager : MonoBehaviour
    {
        public event Action OnGameStart;
        public event Action OnLevelSuccess;
        public event Action OnLevelFailed;

        public void GameStart()
        {
            OnGameStart?.Invoke();
        }

        public void LevelSuccess()
        {
            OnLevelSuccess?.Invoke();
        }

        public void LevelFailed()
        {
            OnLevelFailed?.Invoke();
        }
    }
}
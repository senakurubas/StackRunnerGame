using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Core.LevelEndSystem
{
    public static class SceneController
    {
        public static IEnumerator LoadNextLevel()
        {
            int totalSceneCount = SceneManager.sceneCount;

            if (SceneManager.GetActiveScene().buildIndex > totalSceneCount)
            {
                SceneManager.LoadScene(0);
                yield return new WaitForSeconds(.1f);
            }
            else
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
                yield return new WaitForSeconds(.1f);
            }
        }
        
        public static void LoadCurrentLevel()
        {
            
        }
    }
}
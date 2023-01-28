using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Core
{
    public class LevelLoader : MonoBehaviour
    {
        private void Update()
        {
           if (Input.GetKey(KeyCode.Space))
           {
                LoadNextScene(); 
           }
        }
        
        private void LoadNextScene()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
    
   
}
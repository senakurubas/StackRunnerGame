using UnityEngine;

namespace Utils.Logger
{
    public class Logger
    {
        public static void WriteLog(string logString)
        {
    #if UNITY_EDITOR
            //if (Application.platform == RuntimePlatform.WindowsEditor || Application.platform == RuntimePlatform.OSXEditor)
            Debug.Log(logString);
    #endif
        }

        public static void WriteLogErr(string logString)
        {
    #if UNITY_EDITOR
            //if (Application.platform == RuntimePlatform.WindowsEditor || Application.platform == RuntimePlatform.OSXEditor)
            Debug.LogError(logString);
    #endif
        }

        public static void WriteLogWarning(string logString)
        {
    #if UNITY_EDITOR
            //if (Application.platform == RuntimePlatform.WindowsEditor || Application.platform == RuntimePlatform.OSXEditor)
            Debug.LogWarning(logString);
    #endif
        }
        
        public static void DrawLine(Vector3 start, Vector3 end, Color color)
        {
    #if UNITY_EDITOR
            Debug.DrawLine(start, end, color);
    #endif
        }

        public static void DrawRay(Vector3 start, Vector3 direction, Color color)
        {
    #if UNITY_EDITOR
            Debug.DrawRay(start, direction, color);
    #endif
        }
    }   
}
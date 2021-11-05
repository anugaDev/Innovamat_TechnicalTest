using UnityEngine;
using UnityEditor;

namespace GuessTheNumber
{
    public class ExitGameUtil : MonoBehaviour
    {
        public void ExitGame()
        {
#if UNITY_EDITOR
            EditorApplication.isPlaying = false;
#else
            Application.Quit();
#endif
        }
    }
}
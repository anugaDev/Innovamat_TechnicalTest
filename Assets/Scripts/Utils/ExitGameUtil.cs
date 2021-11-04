using UnityEngine;
using UnityEditor;
using UnityEngine.SceneManagement;

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
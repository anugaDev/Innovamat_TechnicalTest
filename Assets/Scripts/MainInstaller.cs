using GuessTheNumber.Board;
using UnityEngine;

namespace GuessTheNumber
{
    public class MainInstaller: MonoBehaviour
    {
        [SerializeField] private BoardInstaller _boardInstaller;

        [SerializeField] private BoardConfiguration _boardConfiguration;
        
        private void Awake()
        {
            _boardInstaller.Install(_boardConfiguration);
        }
    }
}

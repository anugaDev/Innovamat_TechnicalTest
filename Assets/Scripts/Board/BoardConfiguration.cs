using UnityEngine;

namespace GuessTheNumber.Board
{
    [CreateAssetMenu(menuName = "Config/BoardConfigurationSO", fileName = "BoardConfigurationSO")]
    public class BoardConfiguration : ScriptableObject
    {
        [SerializeField] private int displayNumberTime;
        [SerializeField] private int _dispayedNumberPanels;

        [SerializeField] private int _currentBoardLocalizationIndex;

        public int DisplayNumberTime => displayNumberTime;
        public int DispayedNumberPanels => _dispayedNumberPanels;
    }
}

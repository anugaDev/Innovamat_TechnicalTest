using UnityEngine;

namespace GuessTheNumber.Localization
{
    [CreateAssetMenu(menuName = "Config/GameLocalizationSO", fileName = "GameLocalizationSO")]
    public class GameLocalizationSO : ScriptableObject
    {
        [SerializeField] private LanguageLocalizationSO[] _languageLocalizations;
        [SerializeField] private int _defaultBoardLocalizationIndex;
        public LanguageLocalizationSO[] LanguageLocalizations => _languageLocalizations;
        public int DefaultBoardLocalizationIndex => _defaultBoardLocalizationIndex;
    }
}


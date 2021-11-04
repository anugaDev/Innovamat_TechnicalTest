using UnityEngine;

namespace GuessTheNumber.Localization
{
    [CreateAssetMenu(menuName = "Config/LanguageLocalizationSO", fileName = "LanguageLocalizationSO")]
    public class LanguageLocalizationSO : ScriptableObject
    {
        [SerializeField] private string _languageName;
        [SerializeField] private string[] _numberNameKeys = new string[11];

        public string[] NumberNames => _numberNameKeys;
        public string languageName => _languageName;
    }
}


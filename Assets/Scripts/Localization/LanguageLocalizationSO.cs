using UnityEngine;

namespace GuessTheNumber.Localization
{
    [CreateAssetMenu(menuName = "Config/LanguageLocalizationSO", fileName = "LanguageLocalizationSO")]
    public class LanguageLocalizationSO : ScriptableObject
    {
        [SerializeField] private string _languageName;
        [SerializeField] private string[] _numberNameKeys = new string[11];
        
        [SerializeField] private string _title;
        [SerializeField] private string _description;
        [SerializeField] private string _play;
        [SerializeField] private string _exit;
        [SerializeField] private string _chooseLanguage;
        [SerializeField] private string _backToMenu;
        [SerializeField] private string _fails;
        [SerializeField] private string _successes;
        [SerializeField] private string _endGame;

        public string[] NumberNames => _numberNameKeys;
        public string LanguageName => _languageName;
        public string Title => _title;
        public string Description => _description;
        public string Play => _play;
        public string Exit => _exit;
        public string ChooseLanguage => _chooseLanguage;
        public string Fails => _fails;
        public string Successes => _successes;
        public string EndGame => _endGame;
        public string BackToMenu => _backToMenu;
    }
}


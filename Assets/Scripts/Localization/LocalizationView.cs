using GuessTheNumber.Panel;
using UnityEngine;
using UnityEngine.UI;

namespace GuessTheNumber.Localization
{
    public class LocalizationView : MonoBehaviour
    {
        [SerializeField] private GameObject _buttonPanel;
        [SerializeField] private Text _currentLanguageSelected;
        
        [Header("Localized Text")]
        
        [SerializeField] private Text _title;
        [SerializeField] private Text _description;
        [SerializeField] private Text _play;
        [SerializeField] private Text _exit;
        [SerializeField] private Text _chooseLanguage;
        [SerializeField] private Text _chooseLanguageLocalizationMenu;
        [SerializeField] private Text _backToMenu;
        [SerializeField] private Text _fails;
        [SerializeField] private Text _successes;
        [SerializeField] private Text _endGame;
        
        private DisplayPanelView[] _languageButtons;

        public GameObject ButtonsPanel => _buttonPanel;
        public DisplayPanelView[] LanguageButtonPanels => _languageButtons;

        public void SetCurrentLanguageSelectedText(string languageText)
        {
            _currentLanguageSelected.text = languageText;
        }

        public void SetLanguageButtons(DisplayPanelView[] buttons)
        {
            _languageButtons = buttons;
        }

        public void SetLocalizedText(LanguageLocalizationSO languageLocalization)
        {
             _title.text = languageLocalization.Title;
             _description.text = languageLocalization.Description;
             _play.text = languageLocalization.Play;
             _exit.text = languageLocalization.Exit;
             _chooseLanguage.text = languageLocalization.ChooseLanguage;
             _chooseLanguageLocalizationMenu.text = languageLocalization.ChooseLanguage;
             _backToMenu.text = languageLocalization.BackToMenu;
             _fails.text = languageLocalization.Fails;
             _successes.text = languageLocalization.Successes;
             _endGame.text = languageLocalization.EndGame;
            
        }
    }
}
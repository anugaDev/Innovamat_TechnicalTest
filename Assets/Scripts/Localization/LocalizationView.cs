using GuessTheNumber.Panel;
using UnityEngine;
using UnityEngine.UI;

namespace GuessTheNumber.Localization
{
    public class LocalizationView : MonoBehaviour
    {
        [SerializeField] private GameObject _buttonPanel;
        [SerializeField] private Text _currentLanguageSelected;
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
    }
}
using GuessTheNumber.Panel;
using UnityEngine;
using UnityEngine.UI;

namespace GuessTheNumber.Localization
{
    public class LocalizationInstaller : MonoBehaviour
    {
        [SerializeField] private LocalizationView _view;
        [SerializeField] private DisplayPanelView _languageButton;
        
        public void Install(LocalizationModel model, SetGameLocalizationCommand setGameLocalizationCommand, GameLocalizationSO localizationConfiguration)
        {
            SetLocalizationPanel(localizationConfiguration);
            
            var controller = new LocalizationController(model, _view, setGameLocalizationCommand);
        }
        private void SetLocalizationPanel(GameLocalizationSO localizationConfiguration)
        {
            var languageButtons = new DisplayPanelView[localizationConfiguration.LanguageLocalizations.Length];

            for (var i = 0; i < languageButtons.Length; i++)
            {
                languageButtons[i] = Instantiate(_languageButton, _view.GetButtonsPanel().transform);
                languageButtons[i].SetPanelText(localizationConfiguration.LanguageLocalizations[i].languageName);
            }
            _view.SetLanguageButtons(languageButtons);
            
        }
    }
}
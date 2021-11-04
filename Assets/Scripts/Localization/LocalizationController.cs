using System;

namespace GuessTheNumber.Localization
{
    public class LocalizationController
    {
        private LocalizationModel _model;
        private LocalizationView _view;

        private SetGameLocalizationCommand _setGameLocalizationCommand;
        
        public LocalizationController(LocalizationModel model, LocalizationView view, SetGameLocalizationCommand setGameLocalizationCommand)
        {
            _model = model;
            _view = view;
            _setGameLocalizationCommand = setGameLocalizationCommand;

            foreach(var button in _view.GetLanguageButtonPanels())
            {
                button.GetPanelButton().onClick.AddListener(() =>
                {
                    var selectedLanguageIndex = Array.IndexOf(_view.GetLanguageButtonPanels(), button);
                    _model.SetCurrentLanguage(selectedLanguageIndex);
                    _view.SetCurrentLanguageSelectedText(_model.GetLanguageByIndex(selectedLanguageIndex).languageName);
                    _setGameLocalizationCommand.Execute();
                });
            }
            
            _setGameLocalizationCommand.Execute();

        }
    }
}

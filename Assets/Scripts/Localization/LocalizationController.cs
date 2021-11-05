using System;

namespace GuessTheNumber.Localization
{
    public class LocalizationController
    {
        private readonly LocalizationModel _model;
        private readonly LocalizationView _view;
        private readonly SetGameLocalizationCommand _setGameLocalizationCommand;
        
        public LocalizationController(LocalizationModel model, LocalizationView view, SetGameLocalizationCommand setGameLocalizationCommand)
        {
            _model = model;
            _view = view;
            _setGameLocalizationCommand = setGameLocalizationCommand;

            foreach(var button in _view.LanguageButtonPanels)
            {
                button.PanelButton.onClick.AddListener(() =>
                {
                    var selectedLanguageIndex = Array.IndexOf(_view.LanguageButtonPanels, button);
                    _model.SetCurrentLanguage(selectedLanguageIndex);
                    _view.SetCurrentLanguageSelectedText(_model.GetLanguageByIndex(selectedLanguageIndex).languageName);
                    _setGameLocalizationCommand.Execute();
                });
            }
            
            _setGameLocalizationCommand.Execute();
        }
    }
}

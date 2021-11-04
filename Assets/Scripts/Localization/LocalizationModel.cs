namespace GuessTheNumber.Localization
{
    public class LocalizationModel
    {
        private GameLocalizationSO _gameLocalizationConfiguration;
        private LanguageLocalizationSO _currentSelectedLanguage;
        private int _currentLanguageIndex;

        public LocalizationModel(GameLocalizationSO gameLocalizationConfiguration)
        {
            _gameLocalizationConfiguration = gameLocalizationConfiguration;
            
            _currentSelectedLanguage =
                gameLocalizationConfiguration.LanguageLocalizations[
                    gameLocalizationConfiguration.DefaultBoardLocalizationIndex];
        }

        public LanguageLocalizationSO GetLanguageByIndex(int languageIndex)
        {
            return _gameLocalizationConfiguration.LanguageLocalizations[languageIndex];
        }

        public LanguageLocalizationSO GetcurrentLanguage()
        {
            return _currentSelectedLanguage;
        }
        public void SetCurrentLanguage(int languageIndex)
        {
            _currentSelectedLanguage = _gameLocalizationConfiguration.LanguageLocalizations[languageIndex];
        }
    }
}

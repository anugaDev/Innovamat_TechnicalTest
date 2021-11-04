using GuessTheNumber.Board;

namespace GuessTheNumber.Localization
{
    public class SetGameLocalizationCommand
    {
        private LocalizationModel _localizationModel;
        private BoardModel _boardModel;

        public SetGameLocalizationCommand(LocalizationModel localizationModel, BoardModel boardModel)
        {
            _localizationModel = localizationModel;
            _boardModel = boardModel;
        }
        
        public void Execute()
        {
            _boardModel.SetNumberList(_localizationModel.GetcurrentLanguage().NumberNames);
        }
    }
}

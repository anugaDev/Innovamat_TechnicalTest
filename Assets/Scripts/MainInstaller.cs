using GuessTheNumber.Board;
using GuessTheNumber.Localization;
using UnityEngine;

namespace GuessTheNumber
{
    public class MainInstaller: MonoBehaviour
    {
        [SerializeField] private BoardInstaller _boardInstaller;
        [SerializeField] private LocalizationInstaller _localizationInstaller;
        [SerializeField] private BoardConfiguration _boardConfiguration;
        [SerializeField] private GameLocalizationSO _gameLocalizationConfiguration;
        
        private void Awake()
        {
            var localizationModel = new LocalizationModel(_gameLocalizationConfiguration);
            var boardModel = new BoardModel(_boardConfiguration);

            var setLocalizationCommand = new SetGameLocalizationCommand(localizationModel, boardModel);

            _localizationInstaller.Install(localizationModel, setLocalizationCommand, _gameLocalizationConfiguration);
            _boardInstaller.Install(boardModel, _boardConfiguration);
        }
    }
}

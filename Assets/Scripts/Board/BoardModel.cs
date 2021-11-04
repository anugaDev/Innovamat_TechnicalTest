namespace GuessTheNumber.Board
{
    public class BoardModel
    {
        private BoardConfiguration _boardConfiguration;
        private LanguageLocalizationSO _currentLocalization;
        
        private int _roundsSuccessfull;
        private int _roundsFailed;
        private int _currentFails;
        private int _currentNumberIndex;
        
        private int[] _currentDisplayedNumbers;

        public int CurrentNumberIndex
        {
            get => _currentNumberIndex;
            set => _currentNumberIndex = value;
        }

        public int CurrentFails
        {
            get => _currentFails;
            set => _currentFails = value;
        }

        public int RoundsSuccessfull
        {
            get => _roundsSuccessfull;
            set => _roundsSuccessfull = value;
        }

        public int RoundsFailed
        {
            get => _roundsFailed;
            set => _roundsFailed = value;
        }
        
        public int[] CurrentDisplayedNumbers
        {
            get => _currentDisplayedNumbers;
            set => _currentDisplayedNumbers = value;
        }

        public BoardModel(BoardConfiguration boardConfiguration)
        {
            _boardConfiguration = boardConfiguration;
            _currentDisplayedNumbers = new int[boardConfiguration.DispayedNumberPanels];
            _currentLocalization =
                _boardConfiguration.BoardLocalizations[_boardConfiguration.CurrentBoardLocalizationIndex];
        }

        public int GetMaxPossibleNumber()
        {
            return _currentLocalization.NumberNames.Length;
        }

        public string GetLocalizedNumber(int number)
        {
            return _currentLocalization.NumberNames[number];
        }

        public bool IsCurrentRoundFailed()
        {
            return _currentFails >= _boardConfiguration.DispayedNumberPanels - 1;
        }

        public int GetNumberDisplayTime()
        {
            return _boardConfiguration.DisplayNumberTime;
        }

    }
}

using GuessTheNumber.Localization;

namespace GuessTheNumber.Board
{
    public class BoardModel
    {
        private BoardConfiguration _boardConfiguration;
        private string[] _numbers;
        
        private int _roundsSuccessful;
        private int _roundsFailed;
        private int _currentFails;
        private int _currentNumberIndex;
        
        private int[] _currentDisplayedNumbers;

        public int CurrentNumberIndex => _currentNumberIndex;
        public int CurrentFails => _currentFails;
        public int RoundsSuccessful => _roundsSuccessful;
        public int RoundsFailed => _roundsFailed;
        public int[] CurrentDisplayedNumbers => _currentDisplayedNumbers;
        public int NumberDisplayTime() => _boardConfiguration.DisplayNumberTime;

        public void SetNumberList(string[] numbers)
        {
            _numbers = numbers;
        }

        public BoardModel(BoardConfiguration boardConfiguration)
        {
            _boardConfiguration = boardConfiguration;
            _currentDisplayedNumbers = new int[boardConfiguration.DispayedNumberPanels];
        }

        public int GetMaxPossibleNumber()
        {
            return _numbers.Length;
        }

        public string GetNumber(int numberIndex)
        {
            return _numbers[numberIndex];
        }

        public bool IsCurrentRoundFailed()
        {
            return _currentFails >= _boardConfiguration.DispayedNumberPanels - 1;
        }

        public void SetCurrentFails(int currentFails)
        {
            _currentFails = currentFails;
        }

        public void SetRoundsFailed(int roundsFailed)
        {
            _roundsFailed = roundsFailed;
        }

        public void SetRoundsSuccessful(int roundsSuccessful)
        {
            _roundsSuccessful = roundsSuccessful;
        }

        public void SetRoundCountToZero()
        {
            _roundsFailed = 0;
            _roundsSuccessful = 0;
        }

        public void SetCurrentNumberIndex(int index)
        {
            _currentNumberIndex = index;
        }
    }
}

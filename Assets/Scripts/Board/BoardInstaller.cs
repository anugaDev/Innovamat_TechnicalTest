using GuessTheNumber.Panel;
using UnityEngine;

namespace GuessTheNumber.Board
{
    public class BoardInstaller : MonoBehaviour
    {
        [SerializeField] private BoardView _view;
        [SerializeField] private NumberDisplayPanelView _displayNumber;
        
        public void Install(BoardModel model, BoardConfiguration boardConfiguration)
        {
            SetBoardView(boardConfiguration);
            
            var controller = new BoardController(model, _view);
        }

        private void SetBoardView(BoardConfiguration boardConfiguration)
        {
            var numberDisplayPanelViews = new NumberDisplayPanelView[boardConfiguration.DispayedNumberPanels];
            
            for (var i = 0; i < boardConfiguration.DispayedNumberPanels; i++)
            {
                numberDisplayPanelViews[i] = Instantiate(_displayNumber, _view.NumbersPanel);
            }
            _view.SetNumberDisplayPanels(numberDisplayPanelViews);
            
        }
    }
}

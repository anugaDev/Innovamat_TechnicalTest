using System;
using System.Linq;
using GuessTheNumber.Panel;
using UnityEngine.SocialPlatforms;
using Random = UnityEngine.Random;

namespace GuessTheNumber.Board
{
    public class BoardController
    {
        private BoardModel _model;
        private BoardView _view;

        public BoardController(BoardModel model, BoardView view)
        {
            _model = model;
            _view = view;
            
            foreach(var panel in _view.GetNumberDisplayPanels())
            {
                panel.GetPanelButton().onClick.AddListener(() =>
                {
                    CheckChosenPanel(panel);
                });
            }
            
            SetNewRound();
        }

        private void SetNewRound()
        {
            _model.CurrentFails = 0;
            
            for (var i = 0; i <  _model.CurrentDisplayedNumbers.Length; i ++)
            {
                var nextNumber = Random.Range(0, _model.GetMaxPossibleNumber());;
                
                while (_model.CurrentDisplayedNumbers.Contains(nextNumber))
                {
                    nextNumber = Random.Range(0, _model.GetMaxPossibleNumber());;
                }
                
                _model.CurrentDisplayedNumbers[i] = nextNumber;
                
                var numberPanel = _view.GetNumberDisplayPanel(i);
                    
                numberPanel.SetPanelText(_model.CurrentDisplayedNumbers[i].ToString());
                
                numberPanel.GetPanelButton().interactable = true;
            }

            SetNumber();
        }

        private void SetNumber()
        {
            _model.CurrentNumberIndex = Random.Range(0, _model.CurrentDisplayedNumbers.Length);

            var correctNumber = _model.CurrentDisplayedNumbers[_model.CurrentNumberIndex];
            
            _view.GetTextPanel().SetPanelText(_model.GetLocalizedNumber(correctNumber));

            _view.GetTextPanel().GetOpenAnimation().Play();

            _view.StartCoroutine(_view.CallActionAfterTime((float) _view.GetTextPanel().GetOpenAnimation().duration,
                () =>
                {
                    _view.StartCoroutine(_view.CallActionAfterTime(_model.GetNumberDisplayTime(), HideText));

                }));
        }

        private void HideText()
        {
            _view.GetTextPanel().GetCloseAnimation().Play();

            _view.StartCoroutine(_view.CallActionAfterTime(
                (float) _view.GetTextPanel().GetCloseAnimation().duration, SetNumbersPanel));
        }

        private void SetNumbersPanel()
        {
            _view.ShowPanelNumbers();

            _view.StartCoroutine(_view.CallActionAfterTime(
                (float) _view.GetTextPanel().GetCloseAnimation().duration,
                () => _view.SetBlockInputActive(false)));
        }

        private void CheckChosenPanel(NumberDisplayPanelView panel)
        {
            panel.GetPanelButton().interactable = false;
            
            var selectedPanelIndex = Array.IndexOf(_view.GetNumberDisplayPanels(), panel);
            
            if (selectedPanelIndex == _model.CurrentNumberIndex)
            {
                _model.RoundsSuccessfull++;
                
                _view.SetUserSuccesses(_model.RoundsSuccessfull.ToString());
                RoundEnded(selectedPanelIndex);
            }
            
            else
            {
                _model.CurrentFails++;
                _view.GetNumberDisplayPanel(selectedPanelIndex).GetFailAnimation().Play();

                if (_model.IsCurrentRoundFailed())
                {
                    _model.RoundsFailed++;
                    _view.SetUserFails(_model.RoundsFailed.ToString());

                    RoundEnded(_model.CurrentNumberIndex);
                }
            }
        }

        private void RoundEnded(int winningPanelIndex)
        {
            _view.GetNumberDisplayPanel(winningPanelIndex).GetSuccessAnimation().Play();
           
            _view.SetBlockInputActive(true);

            _view.StartCoroutine(_view.CallActionAfterTime((float)_view.GetNumberDisplayPanel(winningPanelIndex).GetSuccessAnimation().duration, () =>
            {
                _view.HidePanelNumbers();

                _view.StartCoroutine(_view.CallActionAfterTime(
                    (float) _view.GetNumberDisplayPanel(0).GetCloseAnimation().duration, SetNewRound));
            }));

        }
    }
}

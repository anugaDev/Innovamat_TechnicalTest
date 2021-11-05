using System;
using System.Linq;
using GuessTheNumber.Panel;
using Random = UnityEngine.Random;

namespace GuessTheNumber.Board
{
    public class BoardController
    {
        private readonly BoardModel _model;
        private readonly BoardView _view;

        public BoardController(BoardModel model, BoardView view)
        {
            _model = model;
            _view = view;
            
            foreach(var panel in _view.NumberDisplayPanels)
            {
                panel.PanelButton.onClick.AddListener(() =>
                {
                    CheckChosenPanel(panel);
                });
            }
            
            _view.StartGameEvent.AddListener(() =>
            {
                _model.SetRoundCountToZero();

                _view.SetUserFails(_model.RoundsFailed.ToString());
                _view.SetUserSuccesses(_model.RoundsSuccessful.ToString());
                
                _view.gameObject.SetActive(true);
                SetNewRound();
            });
            
            _view.EndGameEvent.AddListener(ExitGame);
        }

        private void SetNewRound()
        {
            _model.SetRoundsFailed(0);
            
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
                
                numberPanel.PanelButton.interactable = true;
            }
            
            SetNumber();
            
            _view.StartCoroutine(_view.CallActionAfterTime((float) _view.TextPanel.OpenAnimation.duration,
                () =>
                {
                    _view.StartCoroutine(_view.CallActionAfterTime(_model.NumberDisplayTime(), HideText));
                }));
        }

        private void SetNumber()
        {
            var numberIndex = Random.Range(0, _model.CurrentDisplayedNumbers.Length);
            
            _model.SetCurrentNumberIndex(numberIndex);
            
            var correctNumber = _model.CurrentDisplayedNumbers[_model.CurrentNumberIndex];
            
            _view.TextPanel.SetPanelText(_model.GetNumber(correctNumber));

            _view.TextPanel.OpenAnimation.Play();
        }

        private void HideText()
        {
            _view.TextPanel.CloseAnimation.Play();

            _view.StartCoroutine(_view.CallActionAfterTime
            ((float) _view.TextPanel.CloseAnimation.duration, SetNumbersPanel));
        }

        private void SetNumbersPanel()
        {
            _view.ShowPanelNumbers();

            _view.StartCoroutine(_view.CallActionAfterTime
            ((float) _view.TextPanel.CloseAnimation.duration,
                () => _view.SetBlockInputActive(false)));
        }

        private void CheckChosenPanel(NumberDisplayPanelView panel)
        {
            panel.PanelButton.interactable = false;
            
            var selectedPanelIndex = Array.IndexOf(_view.NumberDisplayPanels, panel);
            
            if (selectedPanelIndex == _model.CurrentNumberIndex)
            {
                _model.SetRoundsSuccessful(_model.RoundsSuccessful + 1);

                _view.SetUserSuccesses(_model.RoundsSuccessful.ToString());
                RoundEnded(selectedPanelIndex);
            }
            
            else
            {
                _model.SetCurrentFails(_model.CurrentFails + 1);
                _view.GetNumberDisplayPanel(selectedPanelIndex).FailAnimation.Play();

                if (_model.IsCurrentRoundFailed())
                { 
                    _model.SetRoundsFailed(_model.RoundsFailed + 1);
                    _view.SetUserFails(_model.RoundsFailed.ToString());

                    RoundEnded(_model.CurrentNumberIndex);
                }
            }
        }

        private void RoundEnded(int winningPanelIndex)
        {
            _view.GetNumberDisplayPanel(winningPanelIndex).SuccessAnimation.Play();
           
            _view.SetBlockInputActive(true);

            _view.StartCoroutine(_view.CallActionAfterTime((float)_view.GetNumberDisplayPanel(winningPanelIndex).SuccessAnimation.duration, () =>
            {
                _view.CloseNumbersWithAnimation();

                _view.StartCoroutine(_view.CallActionAfterTime
                ((float) _view.GetNumberDisplayPanel(0).CloseAnimation.duration, SetNewRound));
            }));
        }
        
        private void ExitGame()
        {
            _view.HideNumbers();
            _view.StopAllCoroutines();
            _view.gameObject.SetActive(false);
        }
    }
}

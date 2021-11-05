using System;
using System.Collections;
using GuessTheNumber.Panel;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GuessTheNumber.Board
{
    public class BoardView : MonoBehaviour
    {
        [SerializeField] private Text _failsCounter;
        [SerializeField] private Text _successesCounter;
        [SerializeField] private Transform _numbersPanel;
        [SerializeField] private GameObject _blockinput;
        [SerializeField] private DisplayPanelView _textPanelView;
        
        private NumberDisplayPanelView[] _numberDisplayPanelViews;
        private UnityEvent _startGame = new UnityEvent();
        private UnityEvent _endGame = new UnityEvent();
        
        public NumberDisplayPanelView[] NumberDisplayPanels => _numberDisplayPanelViews;
        public DisplayPanelView TextPanel => _textPanelView;
        public UnityEvent StartGameEvent => _startGame;
        public UnityEvent EndGameEvent => _endGame;
        public Transform NumbersPanel() => _numbersPanel;

        public NumberDisplayPanelView GetNumberDisplayPanel(int index)
        {
            return _numberDisplayPanelViews[index];
        }
        
        public void SetNumberDisplayPanels(NumberDisplayPanelView[] numberDisplayPanelViews)
        {
            _numberDisplayPanelViews = numberDisplayPanelViews;
        }

        public void SetBlockInputActive(bool active)
        {
            _blockinput.SetActive(active);
        }
        
        public void SetUserSuccesses(string successes)
        {
            _successesCounter.text = successes;
        }
        
        public void SetUserFails(string fails)
        {
            _failsCounter.text = fails;
        }
        
        public void ShowPanelNumbers()
        {
            foreach(var  panel in _numberDisplayPanelViews)
            {
                panel.OpenAnimation.Play();
                panel.CloseAnimation.gameObject.SetActive(false);
            }
        }

        public void CloseNumbersWithAnimation()
        {
            foreach (var panel in _numberDisplayPanelViews)
            {
                panel.CloseAnimation.gameObject.SetActive(true);
            }
        }

        public void HideNumbers()
        {
            foreach (var panel in _numberDisplayPanelViews)
            {
                panel.ContentPanel.SetActive(false);
                panel.CloseAnimation.gameObject.SetActive(false);
            }
        }

        public void StartGame()
        {
            _startGame.Invoke();
        }
        
        public void EndGame()
        {
            _endGame.Invoke();
        }

        public IEnumerator CallActionAfterTime(float time, Action action)
        {
            yield return new WaitForSeconds(time);

            action.Invoke();
        }  
    }
}

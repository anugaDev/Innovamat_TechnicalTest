﻿using System;
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
        
        public void SetNumberDisplayPanels(NumberDisplayPanelView[] numberDisplayPanelViews)
        {
            _numberDisplayPanelViews = numberDisplayPanelViews;
        }
        
        public NumberDisplayPanelView[] GetNumberDisplayPanels()
        {
            return _numberDisplayPanelViews;
        }

        public DisplayPanelView GetTextPanel()
        {
            return _textPanelView;
        }
        
        public NumberDisplayPanelView GetNumberDisplayPanel(int index)
        {
            return _numberDisplayPanelViews[index];
        }
        
        public UnityEvent GetStartGameEvent()
        {
            return _startGame;
        }
        
        public UnityEvent GetEndGameEvent()
        {
            return _endGame;
        }
        
        public void SetBlockInputActive(bool active)
        {
            _blockinput.SetActive(active);
        }
        
        public Transform GetNumbersPanel()
        {
            return _numbersPanel;
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
                panel.GetOpenAnimation().Play();
                panel.GetCloseAnimation().gameObject.SetActive(false);
            }
        }

        public void CloseNumbersWithAnimation()
        {
            foreach (var panel in _numberDisplayPanelViews)
            {
                panel.GetCloseAnimation().gameObject.SetActive(true);
            }
        }

        public void HideNumbers()
        {
            foreach (var panel in _numberDisplayPanelViews)
            {
                panel.GetContentPanel().SetActive(false);
                panel.GetCloseAnimation().gameObject.SetActive(false);
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

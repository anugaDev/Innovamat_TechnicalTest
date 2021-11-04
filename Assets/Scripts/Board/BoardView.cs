using System;
using System.Collections;
using GuessTheNumber.Panel;
using UnityEngine;
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

        public void HidePanelNumbers()
        {
            foreach(var  panel in _numberDisplayPanelViews)
            {
                panel.GetCloseAnimation().gameObject.SetActive(true);
            }
        }

        public IEnumerator CallActionAfterTime(float time, Action action)
        {
            yield return new WaitForSeconds(time);

            action.Invoke();
        }  
    }
}

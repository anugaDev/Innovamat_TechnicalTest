using GuessTheNumber.Localization;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.UI;

namespace GuessTheNumber.Panel
{
    public class DisplayPanelView : MonoBehaviour
    {
        [SerializeField] private GameObject _contentPanel;
        [SerializeField] private Button _button;
        [SerializeField] private Text _displayedText;
        [SerializeField] private PlayableDirector _openAnimation;
        [SerializeField] private PlayableDirector _closeAnimation;

        public Button GetPanelButton()
        {
            return _button;
        }

        public void SetPanelText(string text)
        {
            _displayedText.text = text;
        }
        
        public PlayableDirector GetOpenAnimation()
        {
            return _openAnimation;
        }

        public PlayableDirector GetCloseAnimation()
        {
            return _closeAnimation;
        }

        public GameObject GetContentPanel()
        {
            return _contentPanel;
        }
        
    }
}


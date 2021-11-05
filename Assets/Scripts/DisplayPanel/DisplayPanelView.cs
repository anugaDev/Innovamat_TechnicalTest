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

        public Button PanelButton => _button;
        public PlayableDirector OpenAnimation=> _openAnimation;
        public PlayableDirector CloseAnimation => _closeAnimation;
        public GameObject ContentPanel => _contentPanel;

        public void SetPanelText(string text)
        {
            _displayedText.text = text;
        }
        
       
    }
}


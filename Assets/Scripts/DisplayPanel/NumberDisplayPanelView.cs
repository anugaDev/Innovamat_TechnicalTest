using System.Collections;
using System.Collections.Generic;
using GuessTheNumber.Panel;
using UnityEngine;
using UnityEngine.Playables;

namespace GuessTheNumber.Panel
{
    public class NumberDisplayPanelView : DisplayPanelView
    {
        [SerializeField] private PlayableDirector _successAnimation;
        [SerializeField] private PlayableDirector _failAnimation;

        public PlayableDirector SuccessAnimation => _successAnimation;

        public PlayableDirector FailAnimation => _failAnimation;
    }
}


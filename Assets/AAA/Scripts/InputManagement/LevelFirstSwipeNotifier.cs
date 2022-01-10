using System;
using Eflatun.CodePatterns;
using UnityEngine;

namespace Sule.BoatStack.InputManagement
{
    public class LevelFirstSwipeNotifier : GlobalSingleton<LevelFirstSwipeNotifier>
    {
        public event Action FirstSwipeHappened;
        
        [SerializeField] [Range(0f, 1f)] private float thresholdX;
        [SerializeField] [Range(0f, 1f)] private float thresholdY;

        private bool _didNotify;

        void Update()
        {
            if (_didNotify)
            {
                return;
            }

            var swipeDelta01 = InputController.Instance.SwipeDelta01;
            if (Mathf.Abs(swipeDelta01.x) >= thresholdX || Mathf.Abs(swipeDelta01.y) >= thresholdY)
            {
                _didNotify = true;
                
                // null-conditional access / null-propagation / elvis
                FirstSwipeHappened?.Invoke();
            }
        }

        public void Reset()
        {
            _didNotify = false;
        }
    }
}

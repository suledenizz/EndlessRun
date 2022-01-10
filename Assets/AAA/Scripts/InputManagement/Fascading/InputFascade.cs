// source: https://answers.unity.com/questions/448771/simulate-touch-with-mouse.html

using System.Collections.Generic;
using UnityEngine;

namespace Sule.BoatStack.InputManagement.Fascading
{
    public static class InputFascade
    {
        private static TouchCreator _lastFakeTouch;

        public static List<Touch> GetTouches()
        {
            var touches = new List<Touch>();
            touches.AddRange(Input.touches);

#if UNITY_EDITOR
            _lastFakeTouch ??= new TouchCreator();

            if (Input.GetMouseButtonDown(0))
            {
                _lastFakeTouch.Phase = TouchPhase.Began;
                _lastFakeTouch.DeltaPosition = new Vector2(0, 0);
                _lastFakeTouch.Position = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
                _lastFakeTouch.FingerId = 0;
            }
            else if (Input.GetMouseButtonUp(0))
            {
                _lastFakeTouch.Phase = TouchPhase.Ended;
                var newPosition = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
                _lastFakeTouch.DeltaPosition = newPosition - _lastFakeTouch.Position;
                _lastFakeTouch.Position = newPosition;
                _lastFakeTouch.FingerId = 0;
            }
            else if (Input.GetMouseButton(0))
            {
                _lastFakeTouch.Phase = TouchPhase.Moved;
                var newPosition = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
                _lastFakeTouch.DeltaPosition = newPosition - _lastFakeTouch.Position;
                _lastFakeTouch.Position = newPosition;
                _lastFakeTouch.FingerId = 0;
            }
            else
            {
                _lastFakeTouch = null;
            }

            if (_lastFakeTouch != null)
            {
                touches.Add(_lastFakeTouch.Create());
            }
#endif

            return touches;
        }
    }
}

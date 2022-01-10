using Eflatun.CodePatterns;
using Sule.BoatStack.InputManagement.Fascading;
using UnityEngine;

namespace Sule.BoatStack.InputManagement
{
    public class InputController : GlobalSingleton<InputController>
    {
        [Tooltip("Example: For 0.1, we calculate screen width as 10% smaller.")]
        [SerializeField] [Range(0, 1)] private float horizontalEdgeBuffer;

        [Tooltip("Example: For 0.1, we calculate screen height as 10% smaller.")]
        [SerializeField] [Range(0, 1)] private float verticalEdgeBuffer;

        private Vector2 EdgeBuffer => new Vector2(horizontalEdgeBuffer, verticalEdgeBuffer);
        private Vector2 ScreenSizeActual => new Vector2(Screen.width, Screen.height);
        private Vector2 ScreenSizeEdgeBuffered => ScreenSizeActual * (Vector2.one - EdgeBuffer);

        public Vector2 SwipeDelta01 { get; private set; }

        void LateUpdate()
        {
            var touches = InputFascade.GetTouches();

            SwipeDelta01 = touches.Count > 0
                ? (touches[0].deltaPosition / ScreenSizeEdgeBuffered).ClampNeg1Pos1()
                : Vector2.zero;
        }
    }
}

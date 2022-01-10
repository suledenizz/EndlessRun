using UnityEngine;

namespace Sule.BoatStack
{
    public static class Utils
    {
        /// Clamp both components of the given Vector2 between [-1, 1] range.
        public static Vector2 ClampNeg1Pos1(this Vector2 v2)
        {
            return v2.Clamp(-1, 1);
        }

        /// Clamp both components of the given Vector2 between [min, max] range.
        public static Vector2 Clamp(this Vector2 v2, float min, float max)
        {
            return new Vector2(Mathf.Clamp(v2.x, min, max), Mathf.Clamp(v2.y, min, max));
        }
    }
}